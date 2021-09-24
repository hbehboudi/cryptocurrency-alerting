package edu.sharif.ce.commons.config;

import java.util.List;

public class Config {
    public static final String BOOTSTRAP_SERVERS = "127.0.0.1:9092";
    public static final String TOPIC = "cryptocurrency";
    public static final String VALUE_CLASS = "valueClass";
    public static final String KEY_CLASS = "keyClass";
    public static final List<String> SYMBOLS = List.of("ETHBTC", "LTCBTC", "BNBBTC", "NEOBTC", "QTUMETH");
}
