using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voodoo;
using Voodoo.Reports.Models;
using Voodoo.TestData;
using Voodoo.TestData.Models;

namespace Voodoo.Reports.Tests
{
    public class FormatStringsReport : Report
    {
        private Table table;
        private string[] cells = new string[] { "String", "Int", "Decimal", "Currency", "Percent", "Date", "Time", "DateTime" };
        public FormatStringsReport()
        {
            this.MarginInInches.HeaderDistance = .4m;
            this.Body.Border(BorderPosition.Top, BorderPosition.Bottom);
            addHeader();
            AddDefaultFooter();
            //ShowRuler = true;
        }
        private void addHeader()
        {
            var header = Header.AddTable().Italics().ForeColor(System.Drawing.Color.Blue);
            header.NoBorder();
            header.AddColumn(1.5);
            header.AddColumn(4);
            header.AddColumn(1.5);

            var image = new Images.Images().Hat;
            var row = header.AddRow(.7);
            var left = row.AddCell().AddImage(image, .7);
            var middle = row.AddCell().Bold().Big().Big().Big()
                .Center().Middle().AddFragment("Title");
            var right = row.AddCell();
        }


        public void Build(List<FormatStringTestClass> data)
        {
            table = this.Body.AddTable();
            cells.ForEach(c => table.AddColumn(.8));
            addHeaderRow();
            data.ForEach(addRow);
        }

        private void addHeaderRow()
        {
            var header = this.table.AddRow().Bold().Big().Header();
            cells.ForEach(c => header.AddCell(c).Right());
        }

        private void addRow(FormatStringTestClass obj)
        {
            var row = table.AddRow();
            row.AddCell(obj.StringValue);
            row.AddIntCell(obj.IntValue);
            row.AddDecimalCell(obj.DecimalValue);
            row.AddCurrencyCell(obj.CurrencyValue);
            row.AddPercentCell(obj.PercentValue);
            row.AddDateCell(obj.DateValue);
            row.AddTimeCell(obj.DateValue);
            row.AddDateTimeCell(obj.DateValue);
        }


    }
}

