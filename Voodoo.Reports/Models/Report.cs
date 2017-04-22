using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pdf = Voodoo.Reports.Adapters.MigraDocs;

namespace Voodoo.Reports.Models
{
	public class Report: Part
	{
        public string DefaultFontFamily { get; set; } = "Verdana";
        public double DefaultFontSize { get; set; } = 7;        
        public Section Header { get; set; } 
        public Section Body { get; set; } 
        public Section Footer { get; set; }
        public Orientation Orientation { get; set; } = Orientation.Portrait;


        public Report()
        {      
            Header = new Section() { Parent = this };
            Body = new Section { Parent = this };
            Footer = new Models.Section { Parent = this };
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
