package edu.sharif.ce.data_collector.exchange;

import com.binance.api.client.BinanceApiClientFactory;
import com.binance.api.client.BinanceApiRestClient;
import edu.sharif.ce.data_collector.Config;
import edu.sharif.ce.data_collector.model.TickerPrice;

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

    public List<TickerPrice> getAllPrices() {
        return client.getAllPrices()
                .stream()
                .map(x -> new TickerPrice(x.getSymbol(), x.getPrice()))
                .collect(Collectors.toList());
    }
}
