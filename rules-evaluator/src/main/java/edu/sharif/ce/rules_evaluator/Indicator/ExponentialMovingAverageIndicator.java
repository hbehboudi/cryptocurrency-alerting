package edu.sharif.ce.rules_evaluator.Indicator;

import edu.sharif.ce.commons.model.Candlestick;
import edu.sharif.ce.commons.model.PriceType;

import java.util.LinkedHashMap;
import java.util.List;

public class ExponentialMovingAverageIndicator implements Indicator {

    private final int period;
    private final PriceType priceType;

    public ExponentialMovingAverageIndicator(int period, PriceType priceType) {
        this.period = period;
        this.priceType = priceType;
    }

    @Override
    public LinkedHashMap<Candlestick, Double> calculate(List<Candlestick> candlesticks) {
        var result = new LinkedHashMap<Candlestick, Double>();

        if (candlesticks.size() < period) {
            return result;
        }

        double smoothingConstant = 2d / (this.period + 1);

        var smaResult = new SimpleMovingAverageIndicator(period, priceType).calculate(candlesticks);

        var oldEma = -1D;

        for (var key : smaResult.keySet()) {
            if (oldEma == -1) {
                result.put(key, smaResult.get(key));
            } else {
                result.put(key, smoothingConstant * (key.getPrice(priceType) - oldEma) + oldEma);
            }

            oldEma = result.get(key);
        }

        return result;
    }
}
