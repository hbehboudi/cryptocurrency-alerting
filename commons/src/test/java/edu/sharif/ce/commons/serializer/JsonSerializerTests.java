package edu.sharif.ce.commons.serializer;

import edu.sharif.ce.commons.config.Config;
import edu.sharif.ce.commons.model.Candlestick;
import edu.sharif.ce.commons.util.JsonDeserializer;
import edu.sharif.ce.commons.util.JsonSerializer;
import org.junit.Assert;
import org.junit.Test;

import java.util.HashMap;

public class JsonSerializerTests {
    @Test
    public void serialize() {
        var jsonSerializer = new JsonSerializer<>();
        var jsonDeserializer = createJsonDeserializer();

        var actual = new Candlestick("symbol 1", 1L, "open 1", "high 1", "low 1", "close 1", 2L, "1m");
        var bytes = jsonSerializer.serialize("", actual);
        var expected = jsonDeserializer.deserialize("", bytes);

        Assert.assertEquals(expected, actual);
    }

    private JsonDeserializer<?> createJsonDeserializer() {
        var jsonDeserializer = new JsonDeserializer<>();

        var map = new HashMap<String, String>();
        map.put(Config.VALUE_CLASS, Candlestick.class.getName());
        jsonDeserializer.configure(map, false);

        return jsonDeserializer;
    }
}
