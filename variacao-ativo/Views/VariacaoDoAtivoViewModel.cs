using MongoDB.Bson.Serialization.Attributes;

namespace variacao_ativo.Views
{
    public class VariacaoDoAtivoViewModel
    {
        public DateTime Data { get; set; }
        public string Valor { get; set; }
        public string Ativo { get; set; }
        public string VariacaoDiaAnterior { get; set; }
        public string variacaoD1 { get; set; }
    }
}
