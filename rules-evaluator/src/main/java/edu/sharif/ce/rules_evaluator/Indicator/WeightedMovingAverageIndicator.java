package edu.sharif.ce.rules_evaluator.Indicator;

import edu.sharif.ce.commons.model.Candlestick;
import edu.sharif.ce.commons.model.PriceType;

import java.util.LinkedHashMap;
import java.util.List;

public class WeightedMovingAverageIndicator implements Indicator {

    private final int period;
    private final PriceType priceType;

    public WeightedMovingAverageIndicator(int period, PriceType priceType) {
        this.period = period;
        this.priceType = priceType;
    }

    @Override
    public LinkedHashMap<Candlestick, Double> calculate(List<Candlestick> candlesticks) {
        var result = new LinkedHashMap<Candlestick, Double>();

        if (candlesticks.size() < period) {
            return result;
        }

        for (var i = period - 1; i < candlesticks.size(); i++) {
            result.put(candlesticks.get(i), calculate(candlesticks, i));
        }

        return result;
    }

    public double calculate(List<Candlestick> candlesticks, int n) {
        var result = 0D;

        for (var i = 1 ; i <= period; i++) {
            result += i * candlesticks.get(i - period + n).getPrice(priceType);
        }

        result /= (double) period * (period + 1) / 2;

        return result;
    }
}
