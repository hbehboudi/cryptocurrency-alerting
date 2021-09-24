package edu.sharif.ce.rules_evaluator.evaluator;

import edu.sharif.ce.rules_evaluator.Indicator.factory.IndicatorFactory;
import edu.sharif.ce.rules_evaluator.config.Config;
import edu.sharif.ce.rules_evaluator.holder.CandlestickHolder;
import edu.sharif.ce.rules_evaluator.model.Rule;

import java.util.List;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;
import java.util.stream.Collectors;

public class Evaluator extends Thread {
    private final List<Rule> rules;
    private final ConcurrentHashMap<String, Long> lastOpenTimeBySymbol = new ConcurrentHashMap<>();

    public Evaluator(List<Rule> rules) {
        this.rules = rules;
        Config.SYMBOLS.forEach(x -> lastOpenTimeBySymbol.put(x, 0L));
    }

    @Override
    public synchronized void start() {
        var delay = Config.CONSUMER_DELAY;

        var executor = Executors.newSingleThreadScheduledExecutor();
        executor.scheduleAtFixedRate(this::evaluate, 0, delay, TimeUnit.MILLISECONDS);
    }

    private void evaluate() {
        for (var rule : rules) {
            evaluateRule(rule);
        }
    }

    public void evaluateRule(Rule rule) {
        var startTime = lastOpenTimeBySymbol.get(rule.getSymbol()) - rule.getMaxPeriod() * 1_000L;
        var candlesticks = CandlestickHolder.getInstance().getCandlesticks(rule.getSymbol(), startTime);

        if (candlesticks.isEmpty()) {
            return;
        }

        lastOpenTimeBySymbol.put(rule.getSymbol(), candlesticks.get(candlesticks.size() - 1).getOpenTime());

        var lessIndicator = new IndicatorFactory().create(rule.getIndicatorType(), rule.getLessPeriod(), rule.getLessPriceType());
        var moreIndicator = new IndicatorFactory().create(rule.getIndicatorType(), rule.getMorePeriod(), rule.getMorePriceType());

        var lessResults = lessIndicator.calculate(candlesticks);
        var moreResults = moreIndicator.calculate(candlesticks);

        var accepted = false;

        for (var key : lessResults.keySet().stream().filter(moreResults::containsKey).collect(Collectors.toList())) {
            var lessResult = lessResults.get(key);
            var moreResult = moreResults.get(key);

            if (lessResult > moreResult) {
                accepted = true;
            } else if (accepted) {
                System.out.println(key);
                accepted = false;
            }
        }
    }
}
