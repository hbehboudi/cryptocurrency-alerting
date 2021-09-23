package edu.sharif.ce.commons.serializer;

import edu.sharif.ce.commons.util.JsonDeserializer;
import edu.sharif.ce.commons.util.JsonSerializer;
import org.junit.Assert;
import org.junit.Test;

import java.util.Random;

public class JsonSerializerTests {
    @Test
    public void serialize() {
        var jsonSerializer = new JsonSerializer<>();
        var jsonDeserializer = new JsonDeserializer<>(Integer.class);

        var random = new Random();
        var actual = Integer.valueOf(random.nextInt());
        var bytes = jsonSerializer.serialize("", actual);
        var expected = jsonDeserializer.deserialize("", bytes);

        Assert.assertEquals(expected, actual);
    }
}
