namespace variacao_ativo.Models
{
    public class tradingPeriod
    {
        public string timezone { get; set; }
        public long start { get; set; }
        public long end { get; set; }
        public int gmtoffset { get; set; }
    }
}
