package edu.sharif.ce.data_collector.exchange;

import com.binance.api.client.BinanceApiClientFactory;
import com.binance.api.client.BinanceApiRestClient;
import com.binance.api.client.domain.market.CandlestickInterval;
import edu.sharif.ce.commons.model.Candlestick;
import edu.sharif.ce.data_collector.config.Config;

import java.util.List;
import java.util.Objects;
import java.util.stream.Collectors;

public class BinanceExchangeApi implements ExchangeApi {

    private final BinanceApiRestClient client;

    public BinanceExchangeApi() {
        var apiKey = Config.BINANCE_API_KEY;
        var secret = Config.BINANCE_SECRET;
        client = BinanceApiClientFactory.newInstance(apiKey, secret).newRestClient();
    }

    public List<Candlestick> getCandlestickBars(String symbol, String timeFrame) {
        return client.getCandlestickBars(symbol, convert(timeFrame))
                .stream()
                .map(x -> convert(symbol, timeFrame, x))
                .collect(Collectors.toList());
    }

    private static Candlestick convert(String symbol, String timeFrame,
                                       com.binance.api.client.domain.market.Candlestick candlestick) {
        var openTime = candlestick.getOpenTime();
        var open = candlestick.getOpen();
        var high = candlestick.getHigh();
        var low = candlestick.getLow();
        var close = candlestick.getClose();
        var closeTime = candlestick.getCloseTime();

        return new Candlestick(symbol, openTime, open, high, low, close, closeTime, timeFrame);
    }

    private static CandlestickInterval convert(String timeFrame) {
        if (Objects.equals(timeFrame, "1m")) {
            return CandlestickInterval.ONE_MINUTE;
        }

        if (Objects.equals(timeFrame, "1h")) {
            return CandlestickInterval.HOURLY;
        }

        if (Objects.equals(timeFrame, "1d")) {
            return CandlestickInterval.DAILY;
        }

        if (Objects.equals(timeFrame, "1w")) {
            return CandlestickInterval.WEEKLY;
        }

        if (Objects.equals(timeFrame, "1M")) {
            return CandlestickInterval.MONTHLY;
        }

        throw new UnsupportedOperationException();
    }
}
