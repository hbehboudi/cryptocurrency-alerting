package edu.sharif.ce.data_collector.producer;

import edu.sharif.ce.commons.model.Candlestick;
import edu.sharif.ce.data_collector.config.Config;
import edu.sharif.ce.data_collector.exchange.ExchangeApi;
import edu.sharif.ce.data_collector.producer.factory.KafkaProducerFactory;
import org.apache.kafka.clients.producer.*;

import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;
import java.util.stream.Collectors;

public class Producer extends Thread {
    private final ExchangeApi exchangeApi;
    private final Map<String, Long> lastOpenTimeBySymbol = new HashMap<>();

    public Producer(ExchangeApi exchangeApi) {
        this.exchangeApi = exchangeApi;
        Config.SYMBOLS.forEach(x -> lastOpenTimeBySymbol.put(x, 0L));
    }

    @Override
    public void run() {
        var delay = Config.PRODUCER_DELAY;
        var timeUnit = TimeUnit.MILLISECONDS;

        var producer = new KafkaProducerFactory().create();
        Runtime.getRuntime().addShutdownHook(new Thread(producer::close));

        var executor = Executors.newSingleThreadScheduledExecutor();
        executor.scheduleAtFixedRate(() -> sendAllSymbols(producer), 0, delay, timeUnit);
    }

    private void sendAllSymbols(KafkaProducer<String, Candlestick> producer) {
        Config.SYMBOLS.stream().parallel().forEach(x -> send(producer, x));
        producer.flush();
    }

    private void send(KafkaProducer<String, Candlestick> producer, String symbol) {
        var topic = Config.TOPIC;
        var candlestickInterval = Config.CANDLESTICK_INTERVAL;
        var lastOpenTime = lastOpenTimeBySymbol.get(symbol);

        var candlesticks = exchangeApi.getCandlestickBars(symbol, candlestickInterval)
                .stream()
                .filter(x -> x.getOpenTime() > lastOpenTime)
                .collect(Collectors.toList());

        for (var candlestick : candlesticks) {
            var record = new ProducerRecord<>(topic, symbol, candlestick);
            producer.send(record);
        }

        var newLastOpenTime = candlesticks.stream().mapToLong(Candlestick::getOpenTime).max().orElse(lastOpenTime);
        lastOpenTimeBySymbol.put(symbol, newLastOpenTime);
    }
}
