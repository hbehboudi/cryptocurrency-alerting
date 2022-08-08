package edu.sharif.ce.rules_evaluator.evaluator;

import edu.sharif.ce.rules_evaluator.Indicator.IndicatorFactory;
import edu.sharif.ce.rules_evaluator.config.Config;
import edu.sharif.ce.rules_evaluator.holder.CandlestickHolder;
import edu.sharif.ce.rules_evaluator.httpClient.WebApi;
import edu.sharif.ce.rules_evaluator.model.Alert;
import edu.sharif.ce.rules_evaluator.model.Position;
import edu.sharif.ce.rules_evaluator.model.Rule;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;
import java.util.stream.Collectors;

public class Evaluator extends Thread {

    private List<Rule> rules = List.of();
    private final ConcurrentHashMap<Rule, Long> lastOpenTimeByRule = new ConcurrentHashMap<>();

    @Override
    public synchronized void start() {
        var delay = Config.CONSUMER_DELAY;

        var executor = Executors.newSingleThreadScheduledExecutor();
        executor.scheduleAtFixedRate(this::evaluate, 0, delay, TimeUnit.MILLISECONDS);
    }

    private void evaluate() {
        var alerts = new ArrayList<Alert>();

        for (var rule : rules) {
            alerts.addAll(getNewAlerts(rule));
        }

        postAlerts(alerts);
        updateRules();
    }

    private ArrayList<Alert> getNewAlerts(Rule rule) {
        var result = new ArrayList<Alert>();
        var candlesticks = CandlestickHolder.getInstance().getCandlesticks(
                rule.getSymbol(),
                lastOpenTimeByRule.get(rule) - 60_000L * rule.getLongTerm());

        lastOpenTimeByRule.put(rule, candlesticks.get(candlesticks.size() - 1).getOpenTime());

        if (candlesticks.isEmpty()) {
            return new ArrayList<>();
        }

        var midTermIndicator = new IndicatorFactory().create(rule.getIndicatorType(), rule.getLongTerm(), rule.getLongPriceType());
        var shortTermIndicator = new IndicatorFactory().create(rule.getIndicatorType(), rule.getShortTerm(), rule.getShortPriceType());

        var midTermResults = midTermIndicator.calculate(candlesticks);
        var shortTermResults = shortTermIndicator.calculate(candlesticks);

        var acceptedBuy = false;
        var acceptedSell = false;

        for (var key : midTermResults.keySet().stream().filter(shortTermResults::containsKey).collect(Collectors.toList())) {
            var midTermResult = midTermResults.get(key);
            var shortTermResult = shortTermResults.get(key);

            if (midTermResult > shortTermResult) {
                if (acceptedSell) {
                    result.add(new Alert(rule.getId(), key, Position.SELL));
                    acceptedSell = false;
                }
                acceptedBuy = true;
            } else if (midTermResult < shortTermResult) {
                if (acceptedBuy) {
                    result.add(new Alert(rule.getId(), key, Position.BUY));
                    acceptedBuy = false;
                }
                acceptedSell = true;
            }
        }

        return result;
    }

    private void postAlerts(List<Alert> alerts) {
        for (var alert : alerts) {
            while (true) {
                try {
                    WebApi.getInstance().addAlert(alert);
                    break;
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        }
    }

    private void updateRules() {
        while (true) {
            try {
                rules = WebApi.getInstance().getRules();
                break;
            } catch (IOException | InterruptedException e) {
                e.printStackTrace();
            }
        }

        rules.forEach(x -> lastOpenTimeByRule.putIfAbsent(x, 0L));
    }
}
