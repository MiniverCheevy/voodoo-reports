namespace Voodoo.Reports.Models
{
  
    public class Margin
    {
        public decimal Top { get; set; } = 1.25m;
        public decimal Bottom { get; set; } = 1m;
        public decimal Right { get; set; } = .5m;
        public decimal Left { get; set; } = .5m;
        public decimal HeaderDistance { get; set; } = .5m;
        public decimal FooterDistance { get; set; } = .5m;
    }
}