using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using Voodoo.Reports.Models;
using Document = MigraDoc.DocumentObjectModel.Document;
using Orientation = Voodoo.Reports.Models.Orientation;

namespace Voodoo.Reports.Adapters.MigraDocs
{
    public class ReportAdapter : IReportAdapter
    {
        public ReportAdapter()
        {
            Document = new Document();
            
            
            DefaultSection = Document.AddSection();
            Header = DefaultSection.Headers.Primary;
            Footer = DefaultSection.Footers.Primary;
        }

        public byte[] Render(Report report)
        {
            this.Report = report;

            var style = Document.Styles["Normal"];
            var paddingBefore = report.VerticalPaddingBefore ?? .01m;
            var paddingAfter = report.VerticalPaddingAfter ?? .01m;
                style.ParagraphFormat.SpaceBefore = $"{paddingBefore}in";
            style.ParagraphFormat.SpaceAfter = $"{paddingAfter}in";


            switch (Report.Orientation)
            {
                case Orientation.Portrait:
                    Document.DefaultPageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Portrait;
                    break;
                case Orientation.Landscape:
                    Document.DefaultPageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Report.HandlePrerendingTasks();
            buildHeader();
            buildBody();
            buildFooter();
            applyDefaultStyles();
            var renderer = new DocumentRenderer(Document);
            var pdfRenderer = new PdfDocumentRenderer
            {
                DocumentRenderer = renderer,
                Document = Document
            };
            pdfRenderer.RenderDocument();
            using (var ms = new MemoryStream())
            {
                pdfRenderer.Save(ms, false);
                var buffer = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Flush();
                ms.Read(buffer, 0, (int) ms.Length);
                return buffer;
            }
        }

        private void applyDefaultStyles()
        {
            DefaultSection.PageSetup.RightMargin = $"{Report.MarginInInches.Right}in";
            DefaultSection.PageSetup.LeftMargin = $"{Report.MarginInInches.Left}in";
            DefaultSection.PageSetup.TopMargin = $"{Report.MarginInInches.Top}in";
            DefaultSection.PageSetup.BottomMargin = $"{Report.MarginInInches.Bottom}in";

            // Get the predefined style Normal.
            var style = Document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = Report.DefaultFontFamily;
            style.Font.Size = Unit.FromPoint(Report.DefaultFontSize);

            //style = Document.Styles[StyleNames.Header];
            //style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            //style = Document.Styles[StyleNames.Footer];
            //style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            //style = Document.Styles.AddStyle("Table", "Normal");
            //style.Font.Name = Report.DefaultFontFamily;
            //style.Font.Size = Report.DefaultFontSize;

            //// Create a new style called Reference based on style Normal
            //style = Document.Styles.AddStyle("Reference", "Normal");
            //style.ParagraphFormat.SpaceBefore = "5mm";
            //style.ParagraphFormat.SpaceAfter = "5mm";
            //style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        public Report Report { get; set; }

        private void buildHeader()
        {
            if (Report.ShowRuler)
                Report.AddRuler(Report.Header);
            foreach (var table in Report.Header.Children())
            {
                var migraDocTable = this.Header.AddTable();
                migraDocTable.Borders.ClearAll();
                var adapter = new TableAdapter(table, migraDocTable, Report);
            }
        }

        private void buildBody()
        {
            foreach (var table in Report.Body.Children())
            {
                var migraDocTable = this.DefaultSection.AddTable();
                var adapter = new TableAdapter(table, migraDocTable, Report);
            }
        }

        private void buildFooter()
        {
            if (Report.ShowRuler)
                Report.AddRuler(Report.Footer);
            foreach (var table in Report.Footer.Children())
            {
                var migraDocTable = this.Footer.AddTable();
                var adapter = new TableAdapter(table, migraDocTable, Report);
            }
        }

        public HeaderFooter Header { get; set; }
        public HeaderFooter Footer { get; set; }
        public MigraDoc.DocumentObjectModel.Section DefaultSection { get; set; }
        public Document Document { get; set; }
    }
}