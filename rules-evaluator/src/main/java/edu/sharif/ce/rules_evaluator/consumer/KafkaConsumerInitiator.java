package edu.sharif.ce.rules_evaluator.consumer;

import edu.sharif.ce.commons.model.Candlestick;
import edu.sharif.ce.commons.util.JsonDeserializer;
import edu.sharif.ce.rules_evaluator.config.Config;
import org.apache.kafka.clients.consumer.ConsumerConfig;
import org.apache.kafka.clients.consumer.KafkaConsumer;
import org.apache.kafka.common.serialization.StringDeserializer;

import java.util.Collections;
import java.util.Properties;
import java.util.Random;

public class KafkaConsumerInitiator {

    public KafkaConsumer<String, Candlestick> create() {
        var bootstrapServers = Config.BOOTSTRAP_SERVERS;
        var keyDeserializerName = StringDeserializer.class.getName();
        var valueDeserializerName = JsonDeserializer.class.getName();
        var valueClass = Candlestick.class.getName();
        var consumerGroupId = Config.CONSUMER_GROUP_ID + new Random().nextInt();
        var autoOffsetReset = Config.AUTO_OFFSET_RESET;
        var topic = Config.TOPIC;

        Properties properties = new Properties();
        properties.setProperty(ConsumerConfig.BOOTSTRAP_SERVERS_CONFIG, bootstrapServers);
        properties.setProperty(ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG, keyDeserializerName);
        properties.setProperty(ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG, valueDeserializerName);
        properties.setProperty(Config.VALUE_CLASS, valueClass);
        properties.setProperty(ConsumerConfig.GROUP_ID_CONFIG, consumerGroupId);
        properties.setProperty(ConsumerConfig.AUTO_OFFSET_RESET_CONFIG, autoOffsetReset);

        var consumer = new KafkaConsumer<String, Candlestick>(properties);
        consumer.subscribe(Collections.singletonList(topic));

        return consumer;
    }
}
