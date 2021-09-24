package edu.sharif.ce.rules_evaluator.Indicator;

import edu.sharif.ce.commons.model.Candlestick;
import edu.sharif.ce.commons.model.PriceType;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;

public abstract class Indicator {
    protected final int period;
    protected final PriceType priceType;

    public Indicator(int period, PriceType priceType) {
        this.period = period;
        this.priceType = priceType;
    }

    public LinkedHashMap<Candlestick, Double> calculate(List<Candlestick> candlesticks) {
        var result = new LinkedHashMap<Candlestick, Double>();

        if (candlesticks.size() < period) {
            return result;
        }

        ArrayList<Candlestick> consecutiveCandlesticks = new ArrayList<>();
        consecutiveCandlesticks.add(candlesticks.get(0));

        for (int i = 1; i < candlesticks.size(); i++) {
            if (!candlesticks.get(i).getOpenTime().equals(candlesticks.get(i - 1).getOpenTime() + 60_000)) {
                result.putAll(calculateConsecutiveCandlesticks(consecutiveCandlesticks));
                consecutiveCandlesticks = new ArrayList<>();
            }

            consecutiveCandlesticks.add(candlesticks.get(i));
        }

        result.putAll(calculateConsecutiveCandlesticks(consecutiveCandlesticks));

        return result;
    }

    protected abstract LinkedHashMap<Candlestick, Double> calculateConsecutiveCandlesticks(List<Candlestick> candlesticks);
}
