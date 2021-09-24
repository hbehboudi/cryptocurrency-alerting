package edu.sharif.ce.rules_evaluator.Indicator;

import edu.sharif.ce.commons.model.Candlestick;
import edu.sharif.ce.commons.model.PriceType;

import java.util.LinkedHashMap;
import java.util.List;

public class SimpleMovingAverage extends Indicator {
    public SimpleMovingAverage(int period, PriceType priceType) {
        super(period, priceType);
    }

    @Override
    public LinkedHashMap<Candlestick, Double> calculateConsecutiveCandlesticks(List<Candlestick> candlesticks) {
        var result = new LinkedHashMap<Candlestick, Double>();

        if (candlesticks.size() < period) {
            return result;
        }

        var sum = candlesticks.stream().limit(period).mapToDouble(x -> x.getPrice(priceType)).sum();
        result.put(candlesticks.get(period - 1), sum / period);

        for (int i = 0; i < candlesticks.size() - period; i++) {
            sum -= candlesticks.get(i).getPrice(priceType);
            sum += candlesticks.get(i + period).getPrice(priceType);
            result.put(candlesticks.get(period + i), sum / period);
        }

        return result;
    }
}
