package edu.sharif.ce.commons.util;

import com.google.gson.Gson;
import edu.sharif.ce.commons.config.Config;
import org.apache.kafka.common.serialization.Deserializer;

import java.util.Map;

public class JsonDeserializer<T> implements Deserializer<T> {
    private final Gson gson = new Gson();
    private Class<T> deserializedClass;

    @Override
    @SuppressWarnings("unchecked")
    public void configure(Map<String, ?> configs, boolean isKey) {
        try {
            var propertyName = isKey ? Config.KEY_CLASS : Config.VALUE_CLASS;
            deserializedClass = (Class<T>) Class.forName((String) configs.get(propertyName));
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }

    @Override
    public T deserialize(String s, byte[] bytes) {
        if (bytes == null) {
            return null;
        }

        return gson.fromJson(new String(bytes), deserializedClass);
    }
}
