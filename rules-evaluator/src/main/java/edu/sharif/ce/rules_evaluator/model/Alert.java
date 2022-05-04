package edu.sharif.ce.rules_evaluator.model;

import edu.sharif.ce.commons.model.Candlestick;

import java.util.Objects;

public class Alert {

    private final long ruleId;
    private final Candlestick candlestick;
    private final Position position;

    public Alert(long ruleId, Candlestick candlestick, Position position) {
        this.ruleId = ruleId;
        this.candlestick = candlestick;
        this.position = position;
    }

    public long getRuleId() {
        return ruleId;
    }

    public Candlestick getCandlestick() {
        return candlestick;
    }

    public Position getPosition() {
        return position;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        var alert = (Alert) o;
        return ruleId == alert.ruleId && Objects.equals(candlestick, alert.candlestick) && position == alert.position;
    }

    @Override
    public int hashCode() {
        return Objects.hash(ruleId, candlestick, position);
    }
}
