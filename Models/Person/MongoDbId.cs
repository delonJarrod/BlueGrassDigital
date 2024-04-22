using Newtonsoft.Json;

namespace BlueGrassDigital.Models.Person
{
    public class MongoDbId
    {
        [JsonProperty("oid")]
        public string Oid { get; set; }
    }
}
