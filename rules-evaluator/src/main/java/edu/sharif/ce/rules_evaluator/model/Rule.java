package edu.sharif.ce.rules_evaluator.model;

import edu.sharif.ce.commons.model.PriceType;

import java.util.Objects;

public class Rule {
    private final String symbol;
    private final PriceType morePriceType;
    private final PriceType lessPriceType;
    private final int morePeriod;
    private final int lessPeriod;
    private final IndicatorType indicatorType;

    public Rule(String symbol, PriceType morePriceType, PriceType lessPriceType, int morePeriod, int lessPeriod, IndicatorType indicatorType) {
        this.symbol = symbol;
        this.morePriceType = morePriceType;
        this.lessPriceType = lessPriceType;
        this.morePeriod = morePeriod;
        this.lessPeriod = lessPeriod;
        this.indicatorType = indicatorType;
    }

    public String getSymbol() {
        return symbol;
    }

    public PriceType getMorePriceType() {
        return morePriceType;
    }

    public PriceType getLessPriceType() {
        return lessPriceType;
    }

    public int getMorePeriod() {
        return morePeriod;
    }

    public int getLessPeriod() {
        return lessPeriod;
    }

    public IndicatorType getIndicatorType() {
        return indicatorType;
    }

    public int getMaxPeriod() {
        return Math.max(morePeriod, lessPeriod);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Rule rule = (Rule) o;
        return morePeriod == rule.morePeriod && lessPeriod == rule.lessPeriod && Objects.equals(symbol, rule.symbol) && morePriceType == rule.morePriceType && lessPriceType == rule.lessPriceType && indicatorType == rule.indicatorType;
    }

    @Override
    public int hashCode() {
        return Objects.hash(symbol, morePriceType, lessPriceType, morePeriod, lessPeriod, indicatorType);
    }

    @Override
    public String toString() {
        return "Rule{" +
                "symbol='" + symbol + '\'' +
                ", morePriceType=" + morePriceType +
                ", lessPriceType=" + lessPriceType +
                ", morePeriod=" + morePeriod +
                ", lessPeriod=" + lessPeriod +
                ", indicatorType=" + indicatorType +
                '}';
    }
}
