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
        var consumer = new KafkaConsumerInitiator().create();
        Runtime.getRuntime().addShutdownHook(new Thread(consumer::close));

        var executor = Executors.newSingleThreadScheduledExecutor();
        executor.scheduleAtFixedRate(() -> receive(consumer), 0, Config.CONSUMER_DELAY, TimeUnit.MILLISECONDS);
    }

    private void receive(KafkaConsumer<String, Candlestick> consumer) {
        var candlestickHolder = CandlestickHolder.getInstance();

        var records = consumer.poll(Duration.ofMillis(Config.CONSUMER_TIMEOUT));

        for (var record : records) {
            candlestickHolder.addCandlestick(record.value());
        }
    }
}
