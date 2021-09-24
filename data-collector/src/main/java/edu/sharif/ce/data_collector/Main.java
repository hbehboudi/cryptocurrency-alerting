package edu.sharif.ce.data_collector;

import edu.sharif.ce.data_collector.producer.Producer;
import edu.sharif.ce.data_collector.config.Config;
import edu.sharif.ce.data_collector.exchange.factory.ExchangeApiFactory;

public class Main {
    public static void main(String[] args) {
        startProducer();
    }

    private static void startProducer() {
        var exchange = Config.EXCHANGE;

        var exchangeApi = new ExchangeApiFactory().create(exchange);
        var producer = new Producer(exchangeApi);

        producer.start();
    }
}
