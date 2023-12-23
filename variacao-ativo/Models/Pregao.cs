using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace variacao_ativo.Models
{
    public class Pregao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Dia { get; set; }

        [BsonElement("Data")]
        public DateTime Data { get; set; }

        [BsonElement("Valor")]
        public double Valor { get; set; }
    }
}
