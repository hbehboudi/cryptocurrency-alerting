package edu.sharif.ce.data_collector.producer;

import edu.sharif.ce.commons.model.Candlestick;
import edu.sharif.ce.commons.util.JsonSerializer;
import edu.sharif.ce.data_collector.config.Config;
import org.apache.kafka.clients.producer.KafkaProducer;
import org.apache.kafka.clients.producer.ProducerConfig;
import org.apache.kafka.common.serialization.StringSerializer;

import java.util.Properties;

public class KafkaProducerInitiator {
    public KafkaProducer<String, Candlestick> create() {
        var bootstrapServers = Config.BOOTSTRAP_SERVERS;
        var keySerializerName = StringSerializer.class.getName();
        var valueSerializerName = JsonSerializer.class.getName();

        var properties = new Properties();
        properties.setProperty(ProducerConfig.BOOTSTRAP_SERVERS_CONFIG, bootstrapServers);
        properties.setProperty(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG, keySerializerName);
        properties.setProperty(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG, valueSerializerName);

        return new KafkaProducer<>(properties);
    }
}
