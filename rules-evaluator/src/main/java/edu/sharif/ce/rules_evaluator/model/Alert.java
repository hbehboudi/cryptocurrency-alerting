package edu.sharif.ce.rules_evaluator.model;

import edu.sharif.ce.commons.model.Candlestick;

import java.util.Objects;

public class Alert {

    private final long ruleId;
    private final Candlestick candlestick;

    public Alert(long ruleId, Candlestick candlestick) {
        this.ruleId = ruleId;
        this.candlestick = candlestick;
    }

    public long getRuleId() {
        return ruleId;
    }

    public Candlestick getCandlestick() {
        return candlestick;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        var alert = (Alert) o;
        return ruleId == alert.ruleId && Objects.equals(candlestick, alert.candlestick);
    }

    @Override
    public int hashCode() {
        return Objects.hash(ruleId, candlestick);
    }
}
