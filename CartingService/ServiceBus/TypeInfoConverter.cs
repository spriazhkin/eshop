using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace ServiceBus;

internal class TypeInfoConverter(IEnumerable<Type> types)
    : JsonConverter
{
    private readonly JsonSerializer _serializer = new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var jObject = JObject.FromObject(value, _serializer);
        jObject.AddFirst(new JProperty("_type", value.GetType().Name));
        jObject.WriteTo(writer);
    }

    public override object ReadJson(
        JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var jObject = JToken.ReadFrom(reader);
        var typeName = jObject["_type"]?.Value<string>();
        var type = types.First(t => t.Name == typeName);
        return jObject.ToObject(type);
    }

    public override bool CanConvert(Type objectType)
    {
        return true;
    }
}