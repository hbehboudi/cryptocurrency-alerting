package edu.sharif.ce.rules_evaluator.consumer;

import edu.sharif.ce.rules_evaluator.config.Config;
import edu.sharif.ce.rules_evaluator.consumer.factory.KafkaConsumerFactory;
import edu.sharif.ce.rules_evaluator.holder.CandlestickHolder;

import java.time.Duration;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class Consumer extends Thread {
    @Override
    public void run() {
        var delay = Config.CONSUMER_DELAY;
        var candlestickHolder = CandlestickHolder.getInstance();

        var consumer = new KafkaConsumerFactory().create();

        var executor = Executors.newSingleThreadScheduledExecutor();
        executor.scheduleAtFixedRate(() -> {
            var records = consumer.poll(Duration.ofMillis(delay));

            for (var record : records) {
                candlestickHolder.addCandlestick(record.value());
            }
        }, 0, delay, TimeUnit.MILLISECONDS);
    }
}
