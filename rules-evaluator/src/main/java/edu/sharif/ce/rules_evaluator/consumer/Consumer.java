package edu.sharif.ce.rules_evaluator.consumer;

import edu.sharif.ce.commons.model.Candlestick;
import edu.sharif.ce.rules_evaluator.config.Config;
import edu.sharif.ce.rules_evaluator.holder.CandlestickHolder;
import org.apache.kafka.clients.consumer.KafkaConsumer;

import java.time.Duration;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class Consumer extends Thread {
    @Override
    public void run() {
        var delay = Config.CONSUMER_DELAY;

        var consumer = new KafkaConsumerInitiator().create();
        Runtime.getRuntime().addShutdownHook(new Thread(consumer::close));

        var executor = Executors.newSingleThreadScheduledExecutor();
        executor.scheduleAtFixedRate(() -> receive(consumer, delay), 0, delay, TimeUnit.MILLISECONDS);
    }

    private void receive(KafkaConsumer<String, Candlestick> consumer, int delay) {
        var candlestickHolder = CandlestickHolder.getInstance();

        var records = consumer.poll(Duration.ofMillis(delay));

        for (var record : records) {
            candlestickHolder.addCandlestick(record.value());
        }
    }
}
