package edu.sharif.ce.rules_evaluator.Indicator;

import edu.sharif.ce.commons.model.Candlestick;

import java.util.LinkedHashMap;
import java.util.List;

public interface Indicator {

    LinkedHashMap<Candlestick, Double> calculate(List<Candlestick> candlesticks);
}
