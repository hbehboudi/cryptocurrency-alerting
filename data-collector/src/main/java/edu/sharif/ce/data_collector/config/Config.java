package edu.sharif.ce.data_collector.config;

import com.binance.api.client.domain.market.CandlestickInterval;
import edu.sharif.ce.data_collector.model.Exchange;

public class Config extends edu.sharif.ce.commons.config.Config {

    public static final String BINANCE_API_KEY = "l7WKXOPWVWtOPteG4ThnxVyZqRhtMra1W1XZmmlwkHtKZuydHSff70RlN7WmifRm";
    public static final String BINANCE_SECRET = "l7WKXOPWVWtOPteG4ThnxVyZqRhtMra1W1XZmmlwkHtKZuydHSff70RlN7WmifRm";
    public static final Exchange EXCHANGE = Exchange.BINANCE;
    public static final CandlestickInterval CANDLESTICK_INTERVAL = CandlestickInterval.ONE_MINUTE;
    public static final int PRODUCER_DELAY = 60_000;
}
