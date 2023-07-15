using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HermoRestClient
{
    internal class PatchRequestContractResolver : PostRequestContractResolver
    {
        internal PatchRequestContractResolver(bool[] includeProperties) : base()
        {
            this.includeProperties = includeProperties;
        }

        private readonly bool[] includeProperties;

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            return properties.Where(p => includeProperties[properties.IndexOf(p)]).ToList();
        }
    }
}