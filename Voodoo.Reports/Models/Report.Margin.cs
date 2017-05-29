namespace Voodoo.Reports.Models
{
    public partial class Report
    {
        public class Margin
        {
            public decimal Top { get; set; } = 1.25m;
            public decimal Bottom { get; set; } = 1m;
            public decimal Right { get; set; } = .5m;
            public decimal Left { get; set; } = .5m;

        }
    }
}