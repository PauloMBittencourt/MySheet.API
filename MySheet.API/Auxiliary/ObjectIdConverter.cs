using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MongoDB.Bson;

public class ObjectIdConverter : JsonConverter<ObjectId>
{
    public override ObjectId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var objectIdString = reader.GetString();
        return new ObjectId(objectIdString);
    }

    public override void Write(Utf8JsonWriter writer, ObjectId value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}