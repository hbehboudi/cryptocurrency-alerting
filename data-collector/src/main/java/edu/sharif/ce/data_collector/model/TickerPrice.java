package edu.sharif.ce.data_collector.model;

public class TickerPrice {
    private final String symbol;
    private final String price;
    private final long time;

    public TickerPrice(String symbol, String price) {
        this.symbol = symbol;
        this.price = price;
        this.time = System.nanoTime();
    }

    public String getSymbol() {
        return this.symbol;
    }

    public String getPrice() {
        return this.price;
    }

    public long getTime() {
        return time;
    }
}
