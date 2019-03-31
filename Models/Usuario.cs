using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIformCad.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Sobrenome")]
        public string Sobrenome { get; set; }
    }
}