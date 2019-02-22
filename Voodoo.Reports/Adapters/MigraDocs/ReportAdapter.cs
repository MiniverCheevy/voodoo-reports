using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Didstopia.PDFSharp.Fonts;
using DocumentFormat.OpenXml.Wordprocessing;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDocCore.DocumentObjectModel.MigraDoc.DocumentObjectModel.Shapes;
using Voodoo.Reports.Models;
using Orientation = Voodoo.Reports.Models.Orientation;

namespace Voodoo.Reports.Adapters.MigraDocs
{
    public class ReportAdapter : IReportAdapter
    {
        static ReportAdapter()
        {
            if (ImageSource.ImageSourceImpl == null)
            ImageSource.ImageSourceImpl = new ImageSharpImageSource();
            
            //https://stackoverflow.com/questions/48679265/loading-a-font-with-pdfsharp-net-standard-preview-from-xamarin-forms-fails-no

            if (GlobalFontSettings.FontResolver == null)
                GlobalFontSettings.FontResolver = new FontResolver();

        }
        public ReportAdapter()
        {            
            Document = new MigraDoc.DocumentObjectModel.Document();
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
            DefaultSection.PageSetup.FooterDistance = $"{Report.MarginInInches.FooterDistance}in";
            DefaultSection.PageSetup.HeaderDistance = $"{Report.MarginInInches.HeaderDistance}in";
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
            var first = Report.Children().FirstOrDefault();
            if (first != null)
                addTables(this.DefaultSection, first);

            foreach(var section in Report.Children().Skip(1).ToArray())
            {
                var migraDocSection = this.Document.AddSection();
                addTables(migraDocSection, section);
            }
        }

        private void addTables(MigraDoc.DocumentObjectModel.Section migraDocSection, Models.Section section)
        {
            
            migraDocSection.PageSetup.RightMargin = $"{this.Report.MarginInInches.Right}in";
            migraDocSection.PageSetup.LeftMargin = $"{this.Report.MarginInInches.Left}in";
            migraDocSection.PageSetup.TopMargin = $"{this.Report.MarginInInches.Top}in";
            migraDocSection.PageSetup.BottomMargin = $"{this.Report.MarginInInches.Bottom}in";
            foreach (var table in section.Children())
            {
                var migraDocTable = migraDocSection.AddTable();
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
        public MigraDoc.DocumentObjectModel.Document Document { get; set; }
    }
}