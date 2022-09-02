package edu.sharif.ce.rules_evaluator.model;

import edu.sharif.ce.commons.model.PriceType;

import java.io.Serializable;
import java.util.Objects;

public class Rule implements Serializable {

    private final long id;
    private final String symbol;
    private final PriceType shortPriceType;
    private final PriceType longPriceType;
    private final int shortTerm;
    private final int longTerm;
    private final IndicatorType indicatorType;
    private final String timeFrame;
    private final String condition;

    public Rule(long id, String symbol, PriceType shortPriceType, PriceType longPriceType, int shortTerm, int longTerm,
                IndicatorType indicatorType, String timeFrame, String condition) {
        this.id = id;
        this.symbol = symbol;
        this.shortPriceType = shortPriceType;
        this.longPriceType = longPriceType;
        this.shortTerm = shortTerm;
        this.longTerm = longTerm;
        this.indicatorType = indicatorType;
        this.timeFrame = timeFrame;
        this.condition = condition;
    }

    public long getId() {
        return id;
    }

    public String getSymbol() {
        return symbol;
    }

    public PriceType getShortPriceType() {
        return shortPriceType;
    }

    public PriceType getLongPriceType() {
        return longPriceType;
    }

    public int getShortTerm() {
        return shortTerm;
    }

    public int getLongTerm() {
        return longTerm;
    }

    public IndicatorType getIndicatorType() {
        return indicatorType;
    }

    public String getTimeFrame() {
        return timeFrame;
    }

    public String getCondition() {
        return condition;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        var rule = (Rule) o;
        return id == rule.id;
    }

    @Override
    public int hashCode() {
        return Objects.hash(id);
    }

    @Override
    public String toString() {
        return "Rule{" +
                "symbol='" + symbol + '\'' +
                ", " + shortTerm +
                "-" + longTerm +
                '}';
    }
}
