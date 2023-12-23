using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace variacao_ativo.Models
{
    public class Pregao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("Data")]
        public long Data { get; set; }

        [BsonElement("Valor")]
        public double? Valor { get; set; }

        [BsonElement("Ativo")]
        public string Ativo { get; set; }
    }
}
