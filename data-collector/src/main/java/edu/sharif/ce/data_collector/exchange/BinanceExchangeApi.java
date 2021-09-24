package edu.sharif.ce.data_collector.exchange;

import com.binance.api.client.BinanceApiClientFactory;
import com.binance.api.client.BinanceApiRestClient;
import com.binance.api.client.domain.market.CandlestickInterval;
import edu.sharif.ce.commons.model.Candlestick;
import edu.sharif.ce.data_collector.config.Config;
import edu.sharif.ce.data_collector.exchange.converter.CandlestickConverter;

import java.util.List;
import java.util.stream.Collectors;

public class BinanceExchangeApi implements ExchangeApi {
    private final BinanceApiRestClient client;

    public BinanceExchangeApi() {
        var apiKey = Config.BINANCE_API_KEY;
        var secret = Config.BINANCE_SECRET;
        var factory = BinanceApiClientFactory.newInstance(apiKey, secret);
        client = factory.newRestClient();
    }

    public List<Candlestick> getCandlestickBars(String symbol, CandlestickInterval interval) {
        var converter = new CandlestickConverter();

        return client.getCandlestickBars(symbol, interval)
                .stream()
                .map(x -> converter.convert(symbol, x))
                .collect(Collectors.toList());
    }
}
