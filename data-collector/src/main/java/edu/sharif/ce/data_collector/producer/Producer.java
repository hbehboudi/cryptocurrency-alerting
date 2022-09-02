package edu.sharif.ce.data_collector.producer;

import edu.sharif.ce.commons.model.Candlestick;
import edu.sharif.ce.data_collector.config.Config;
import edu.sharif.ce.data_collector.exchange.ExchangeApi;
import org.apache.kafka.clients.producer.KafkaProducer;
import org.apache.kafka.clients.producer.ProducerRecord;

import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;
import java.util.stream.Collectors;

public class Producer extends Thread {

    private final ExchangeApi exchangeApi;
    private final Map<String, Map<String, Long>> lastOpenTimes = new HashMap<>();

    public Producer(ExchangeApi exchangeApi) {
        this.exchangeApi = exchangeApi;

        for (String symbol : Config.SYMBOLS) {
            var lastOpenTimeByTimeFrame = new HashMap<String, Long>();
            Config.TIME_FRAMES.forEach(x -> lastOpenTimeByTimeFrame.put(x, 0L));
            lastOpenTimes.put(symbol, lastOpenTimeByTimeFrame);
        }
    }

    @Override
    public void run() {
        var producer = new KafkaProducerInitiator().create();
        Runtime.getRuntime().addShutdownHook(new Thread(producer::close));

        var executor = Executors.newSingleThreadScheduledExecutor();
        executor.scheduleAtFixedRate(() -> sendAllSymbols(producer), 0, Config.PRODUCER_DELAY, TimeUnit.MILLISECONDS);
    }

    private void sendAllSymbols(KafkaProducer<String, Candlestick> producer) {
        Config.SYMBOLS.stream().parallel().forEach(x -> send(producer, x));
        producer.flush();
    }

    private void send(KafkaProducer<String, Candlestick> producer, String symbol) {
        Config.TIME_FRAMES.forEach(x -> send(producer, symbol, x));
    }

    private void send(KafkaProducer<String, Candlestick> producer, String symbol, String timeFrame) {
        var topic = Config.TOPIC;
        var lastOpenTime = lastOpenTimes.get(symbol).get(timeFrame);

        var candlesticks = exchangeApi.getCandlestickBars(symbol, timeFrame)
                .stream()
                .filter(x -> x.getOpenTime() > lastOpenTime)
                .collect(Collectors.toList());

        for (var candlestick : candlesticks) {
            var record = new ProducerRecord<>(topic, symbol, candlestick);
            producer.send(record);
        }

        if (candlesticks.size() == 1) {
            System.out.printf("%s %s: %d candle is added.\n", symbol, timeFrame, candlesticks.size());
        }

        if (candlesticks.size() > 1) {
            System.out.printf("%s %s: %d candles are added.\n", symbol, timeFrame, candlesticks.size());
        }

        var newLastOpenTime = candlesticks.stream().mapToLong(Candlestick::getOpenTime).max().orElse(lastOpenTime);
        lastOpenTimes.get(symbol).put(timeFrame, newLastOpenTime);
    }
}
