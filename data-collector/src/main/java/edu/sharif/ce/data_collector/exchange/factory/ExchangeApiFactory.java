package edu.sharif.ce.data_collector.exchange.factory;

import edu.sharif.ce.data_collector.exchange.BinanceExchangeApi;
import edu.sharif.ce.data_collector.exchange.ExchangeApi;
import edu.sharif.ce.data_collector.model.Exchange;

public class ExchangeApiFactory {

    public ExchangeApi create(Exchange exchange) {
        if (exchange == Exchange.BINANCE) {
            return new BinanceExchangeApi();
        }

        throw new UnsupportedOperationException();
    }
}
