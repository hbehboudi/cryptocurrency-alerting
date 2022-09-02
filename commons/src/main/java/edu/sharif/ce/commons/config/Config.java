package edu.sharif.ce.commons.config;

import java.util.List;

public class Config {
    public static final String BOOTSTRAP_SERVERS = "kafka:9092";
    public static final String TOPIC = "cryptocurrency";
    public static final String VALUE_CLASS = "valueClass";
    public static final String KEY_CLASS = "keyClass";
    public static final List<String> SYMBOLS = List.of("ETHBTC", "LTCBTC", "BNBBTC", "NEOBTC", "QTUMETH");
    public static final List<String> TIME_FRAMES = List.of("1m", "1h", "1d", "1w", "1M");
}
