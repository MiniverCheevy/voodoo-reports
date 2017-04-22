using System;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Document = MigraDoc.DocumentObjectModel.Document;

namespace Voodoo.Reports.Adapters.ClosedXmls
{
    public class ReportAdapter
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
            buildHeader();
            buildBody();
            buildFooter();
            return new Byte[] { };

        }

        public Report Report { get; set; }

        private void buildHeader()
        {
            foreach (var table in Report.Header.Children())
            {
                var migraDocTable = this.Header.AddTable();
                var adapter = new TableAdapter(table, migraDocTable, Report);
            }
        }

        private void buildBody()
        {

        }

        private void buildFooter()
        {

        }

        public HeaderFooter Header { get; set; }
        public HeaderFooter Footer { get; set; }
        public MigraDoc.DocumentObjectModel.Section DefaultSection { get; set; }
        public Document Document { get; set; }
    }
}
