package edu.sharif.ce.data_collector;

import edu.sharif.ce.data_collector.model.Exchange;

public class Config {
    public static final String BINANCE_API_KEY = "l7WKXOPWVWtOPteG4ThnxVyZqRhtMra1W1XZmmlwkHtKZuydHSff70RlN7WmifRm";
    public static final String BINANCE_SECRET = "l7WKXOPWVWtOPteG4ThnxVyZqRhtMra1W1XZmmlwkHtKZuydHSff70RlN7WmifRm";
    public static final Exchange EXCHANGE = Exchange.BINANCE;
    public static final String BOOTSTRAP_SERVERS = "127.0.0.1:9092";
    public static final String TOPIC = "CRYPTOCURRENCY";
    public static final int DELAY = 60_000;
}
