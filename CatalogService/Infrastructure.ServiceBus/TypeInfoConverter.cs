using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.ServiceBus;

internal class TypeInfoConverter : JsonConverter
{
    private readonly JsonSerializer _serializer =
        new JsonSerializer { ContractResolver = new CamelCasePropertyNamesContractResolver() };

    private readonly IEnumerable<Type> _types;

    public TypeInfoConverter(IEnumerable<Type> types)
    {
        _types = types;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var jObject = JObject.FromObject(value, _serializer);
        jObject.AddFirst(new JProperty("_type", value.GetType().Name));
        jObject.WriteTo(writer);
    }

    public override object ReadJson(
        JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jObject = JToken.ReadFrom(reader);
        var typeName = jObject["_type"]?.Value<string>();
        var type = _types.First(t => t.Name == typeName);
        return jObject.ToObject(type);
    }

    public override bool CanConvert(Type objectType)
    {
        return true;
    }
}