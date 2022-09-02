package edu.sharif.ce.rules_evaluator.Indicator;

import edu.sharif.ce.commons.model.PriceType;
import edu.sharif.ce.rules_evaluator.model.IndicatorType;

public class IndicatorFactory {

    public Indicator create(IndicatorType indicatorType, int period, PriceType priceType) {
        if (indicatorType == IndicatorType.SMA) {
            return new SimpleMovingAverageIndicator(period, priceType);
        }

        if (indicatorType == IndicatorType.WMA) {
            return new WeightedMovingAverageIndicator(period, priceType);
        }

        if (indicatorType == IndicatorType.EMA) {
            return new ExponentialMovingAverageIndicator(period, priceType);
        }

        throw new UnsupportedOperationException();
    }
}
