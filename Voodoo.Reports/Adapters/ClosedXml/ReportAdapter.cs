using System;
using System.IO;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using MigraDoc.Rendering;
using Voodoo.Reports.Models;
using Orientation = Voodoo.Reports.Models.Orientation;

namespace Voodoo.Reports.Adapters.ClosedXml
{
    public class ReportAdapter : IReportAdapter
    {
        public ReportAdapter()
        {
            this.Workbook = new XLWorkbook(XLEventTracking.Disabled);
            this.Worksheet = Workbook.Worksheets.Add("Worksheet");
        }

        public byte[] Render(Report report)
        {
            this.Report = report;
            Report.HandlePrerendingTasks();
            buildHeader();
            buildBody();
            buildFooter();
            applyDefaultStyles();

            byte[] bytes = null;
            using (var memoryStream = new MemoryStream())
            {
                Workbook.SaveAs(memoryStream);
                bytes = memoryStream.ToArray();
                memoryStream.Close();
            }
            return bytes;
        }

        private void applyDefaultStyles()
        {
            Worksheet.PageSetup.Margins.Right = Report.MarginInInches.Right.To<double>();
            Worksheet.PageSetup.Margins.Left = Report.MarginInInches.Left.To<double>();
            Worksheet.PageSetup.Margins.Top = Report.MarginInInches.Top.To<double>();
            Worksheet.PageSetup.Margins.Bottom = Report.MarginInInches.Bottom.To<double>();
        }

        public Report Report { get; set; }

        private void buildHeader()
        {
            //foreach (var table in Report.Header.Children())
            //{
            //    var migraDocTable = this.Header.AddTable();
            //    var adapter = new TableAdapter(table, migraDocTable, Report);
            //}
        }

        private void buildBody()
        {
            var currentRowIndex = 1;
            foreach (var table in Report.Body.Children())
            {
                var adapter = new TableAdapter(table, Worksheet, Report, currentRowIndex);
                currentRowIndex = adapter.CurrentRowIndex;
            }
        }

        private void buildFooter()
        {
            //if (Report.ShowRuler)
            //    Report.AddRuler(Report.Footer);
            //foreach (var table in Report.Footer.Children())
            //{
            //    var migraDocTable = this.Footer.AddTable();
            //    var adapter = new TableAdapter(table, migraDocTable, Report);
            //}
        }

        public HeaderFooter Header { get; set; }
        public HeaderFooter Footer { get; set; }
        public XLWorkbook Workbook { get; private set; }
        public IXLWorksheet Worksheet { get; private set; }
    }
}