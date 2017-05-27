using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voodoo.Reports.Adapters;
using Pdf = Voodoo.Reports.Adapters.MigraDocs;

namespace Voodoo.Reports.Models
{
    public class Report : Part
    {
        public string DefaultFontFamily { get; set; } = "Verdana";
        public double DefaultFontSize { get; set; } = 7;
        public decimal TopMarginInInches {get;set;} = 1.25m;
        public decimal BottomMarginInInches { get; set; } = 1m;
        public decimal RightMarginInInches { get; set; } = .5m;
        public decimal LeftMarginInInches { get; set; } = .5m;

        public Section Header { get; set; } 
        public Section Body { get; set; } 
        public Section Footer { get; set; }
        public Orientation Orientation { get; set; } = Orientation.Portrait;

        public bool ShowRuler { get; set; }

        public Report()
        {      
            Header = new Section() { Parent = this };
            Body = new Section { Parent = this };
            Footer = new Models.Section { Parent = this };
        }

        

	    internal void AddRuler(Section section)
	    {
            var ruler = section.AddTable();
	       
	        var row = ruler.AddRow();
	        ruler.Border(BorderPosition.Right, BorderPosition.Left);
	        var measure = .5;
	        for (var i = 0; i < 23; i++)
	        {
	            ruler.AddColumn(.5);
	        }
	        for (var i = 0; i < 23; i++)
	        {
	            row.AddCell().Right().AddFragment(measure.ToString());
	            measure += .5;
	        }
	    }
        public Byte[] Render(IReportAdapter adapter)
        {
            return adapter.Render(this);
        }
	    public Byte[] Render(ReportFormat format)
        {
            switch (format)
            {
                case ReportFormat.Pdf:
                    return new Pdf.ReportAdapter().Render(this);

            }
            return null;
        }

    }
}
