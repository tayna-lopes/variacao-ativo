namespace variacao_ativo.Models
{
    public class quote
    {
        public List<double?> high { get; set; }
        public List<long?> volume { get; set; }
        public List<double?> open { get; set; }
        public List<double?> low { get; set; }
        public List<double?> close { get; set; }
    }
}
