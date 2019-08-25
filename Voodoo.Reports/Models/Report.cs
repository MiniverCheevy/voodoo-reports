using System;
using System.Collections.Generic;
using Voodoo.Reports.Adapters;
using Excel = Voodoo.Reports.Adapters.ClosedXml;
using Pdf = Voodoo.Reports.Adapters.MigraDocs;

namespace Voodoo.Reports.Models
{
    public partial class Report : Part
    {
        private List<Section> sections = new List<Section>();

        public DefaultCellFormatOptions FormatOptions { get; private set; } = new DefaultCellFormatOptions();
        public string DefaultFontFamily { get; set; } = "Verdana";
        public double DefaultFontSize { get; set; } = 7;
        public Margin MarginInInches { get; set; } = new Margin();
        public RenderOptions RenderOptions { get; set; } = new RenderOptions();
        public decimal? VerticalPaddingBefore { get; set; }
        public decimal? VerticalPaddingAfter { get; set; }
        public Section Header { get; set; }
        public Section Body { get; set; }
        public Section Footer { get; set; }
        public Orientation Orientation { get; set; } = Orientation.Portrait;

        public bool ShowRuler { get; set; }

        public bool HasNoBody { get; }
        public Section AddSection()
        {
            var section = new Section() { Parent = this};
            this.sections.Add(section);
            return section;            
        }

        public Section[] Children()
        {
            return this.sections.ToArray();
        }

        public Report(bool withNoBody = false)
        {
            this.Header = new Section { Parent = this };
            
            if (!withNoBody)
            {
                this.Body = new Section { Parent = this };                
                this.sections.Add(this.Body);
                this.HasNoBody = withNoBody;
            }
            this.Footer = new Section { Parent = this };            
        }

        public void AddDefaultFooter()
        {
            var footer = Footer.AddTable().Italics();

            footer.NoBorder();
            footer.AddColumn(1.5);
            footer.AddColumn(4.5);
            footer.AddColumn(1.5);

            var row = footer.AddRow();
            row.AddCell().AddFragment(DateTime.Now.ToLongDateString()).Right();
            row.AddCell();
            row.AddCell().AddPageOfPagesString().Right();
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
                case ReportFormat.Excel:
                    return new Excel.ReportAdapter().Render(this);
            }
            return null;
        }
    }
}