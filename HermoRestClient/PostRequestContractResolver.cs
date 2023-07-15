using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HermoRestClient
{
    internal class PostRequestContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            return properties.Where(p => p.PropertyName != "Id").ToList();
        }
    }
}