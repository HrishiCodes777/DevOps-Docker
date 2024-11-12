using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [DataMember]
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
