package edu.sharif.ce.commons.model;

import java.util.Objects;

public class Candlestick {
    private final String symbol;
    private final Long openTime;
    private final String open;
    private final String high;
    private final String low;
    private final String close;
    private final Long closeTime;
    private final String timeFrame;

    public Candlestick(String symbol, Long openTime, String open, String high, String low, String close, Long closeTime,
                       String timeFrame) {
        this.symbol = symbol;
        this.openTime = openTime;
        this.open = open;
        this.high = high;
        this.low = low;
        this.close = close;
        this.closeTime = closeTime;
        this.timeFrame = timeFrame;
    }

    public String getSymbol() {
        return symbol;
    }

    public Long getOpenTime() {
        return openTime;
    }

    public Long getCloseTime() {
        return closeTime;
    }

    public Double getPrice(PriceType priceType) {
        switch (priceType) {
            case OPEN:
                return Double.valueOf(open);
            case CLOSE:
                return Double.valueOf(close);
            case HIGH:
                return Double.valueOf(high);
            case LOW:
                return Double.valueOf(low);
        }

        return -1D;
    }

    public String getTimeFrame() {
        return timeFrame;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Candlestick that = (Candlestick) o;
        return Objects.equals(symbol, that.symbol) && Objects.equals(openTime, that.openTime) && Objects.equals(open, that.open) && Objects.equals(high, that.high) && Objects.equals(low, that.low) && Objects.equals(close, that.close) && Objects.equals(closeTime, that.closeTime) && Objects.equals(timeFrame, that.timeFrame);
    }

    @Override
    public int hashCode() {
        return Objects.hash(symbol, openTime, open, high, low, close, closeTime, timeFrame);
    }

    @Override
    public String toString() {
        return "Candlestick{" +
                "symbol='" + symbol + '\'' +
                ", openTime=" + openTime +
                ", open='" + open + '\'' +
                ", high='" + high + '\'' +
                ", low='" + low + '\'' +
                ", close='" + close + '\'' +
                ", closeTime=" + closeTime +
                ", timeFrame='" + timeFrame + '\'' +
                '}';
    }
}
