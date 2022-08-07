package edu.sharif.ce.data_collector;

import edu.sharif.ce.data_collector.producer.Producer;
import edu.sharif.ce.data_collector.config.Config;
import edu.sharif.ce.data_collector.exchange.factory.ExchangeApiFactory;

public class Main {

    public static void main(String[] args) {
        new Producer(new ExchangeApiFactory().create(Config.EXCHANGE)).start();
    }
}
