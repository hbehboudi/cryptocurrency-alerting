package edu.sharif.ce.data_collector.producer;

import edu.sharif.ce.commons.util.JsonSerializer;
import edu.sharif.ce.data_collector.Config;
import edu.sharif.ce.data_collector.exchange.ExchangeApi;
import edu.sharif.ce.data_collector.model.TickerPrice;
import org.apache.kafka.clients.producer.KafkaProducer;
import org.apache.kafka.clients.producer.ProducerConfig;
import org.apache.kafka.clients.producer.ProducerRecord;
import org.apache.kafka.common.serialization.StringSerializer;

import java.util.Properties;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class Producer {
    private final ExchangeApi exchangeApi;

    public Producer(ExchangeApi exchangeApi) {
        this.exchangeApi = exchangeApi;
    }

    public void run() {
        var topic = Config.TOPIC;
        var delay = Config.DELAY;
        var producer = createKafkaProducer();

        Runtime.getRuntime().addShutdownHook(new Thread(producer::close));

        var executor = Executors.newSingleThreadScheduledExecutor();
        executor.scheduleAtFixedRate(() -> run(producer, topic), 0, delay, TimeUnit.MILLISECONDS);
    }

    private void run(KafkaProducer<String, TickerPrice> producer, String topic) {
        for (var tickerPrice : exchangeApi.getAllPrices()) {
            var record = new ProducerRecord<String, TickerPrice>(topic, tickerPrice);
            producer.send(record);
        }

        producer.flush();
    }

    private KafkaProducer<String, TickerPrice> createKafkaProducer() {
        var bootstrapServers = Config.BOOTSTRAP_SERVERS;
        var tradeSerializer = new JsonSerializer<TickerPrice>();

        var properties = new Properties();
        properties.setProperty(ProducerConfig.BOOTSTRAP_SERVERS_CONFIG, bootstrapServers);
        properties.setProperty(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG, StringSerializer.class.getName());
        properties.setProperty(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG, tradeSerializer.getClass().getName());

        return new KafkaProducer<>(properties);
    }
}
