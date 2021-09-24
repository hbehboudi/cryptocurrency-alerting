package edu.sharif.ce.data_collector.exchange.converter;

import edu.sharif.ce.commons.model.Candlestick;

public class CandlestickConverter {
    public Candlestick convert(String symbol, com.binance.api.client.domain.market.Candlestick candlestick) {
        var openTime = candlestick.getOpenTime();
        var open = candlestick.getOpen();
        var high = candlestick.getHigh();
        var low = candlestick.getLow();
        var close = candlestick.getClose();
        var closeTime = candlestick.getCloseTime();

        return new Candlestick(symbol, openTime, open, high, low, close, closeTime);
    }
}
