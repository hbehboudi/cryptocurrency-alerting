package edu.sharif.ce.data_collector;

import edu.sharif.ce.data_collector.exchange.factory.ExchangeApiFactory;
import edu.sharif.ce.data_collector.producer.Producer;

public class Main {
    public static void main(String[] args) {
        var exchange = Config.EXCHANGE;

        var exchangeApi = new ExchangeApiFactory().create(exchange);
        var producer = new Producer(exchangeApi);

        producer.run();
    }
}
