using System.Linq;
using ClosedXML.Excel;
using Voodoo.Reports.Adapters.MigraDocs;
using Voodoo.Reports.Models;
using Border = Voodoo.Reports.Models.Border;
using Row = Voodoo.Reports.Models.Row;

namespace Voodoo.Reports.Adapters.ClosedXml
{
    public class TableAdapter
    {
        private Report report;
        private Models.Table table;
        private IXLWorksheet worksheet;

        public int CurrentRowIndex { get; internal set; }

        public TableAdapter(Table table, IXLWorksheet worksheet, Report report, int currentRowIndex)
        {
            this.table = table;
            this.worksheet = worksheet;
            this.report = report;
            this.CurrentRowIndex = currentRowIndex;
            this.table.HandlePrerendingTasks();
            applyStyles();
            handleChidren();
        }

        private void handleChidren()
        {
            var columnIndex = 1;
            foreach (var column in table.Columns())
            {
                var columnName = ColumnHelper.GetColumnName(columnIndex);
                if (column.HasValue)
                {
                    var converted = column.Value * report.RenderOptions.Excel.HorizontalUnitsPerInch.To<double>();
                    worksheet.Columns(columnName).Width = converted;
                }
                columnIndex++;
            }
            foreach (var row in table.Children())
            {
                var adapter = new RowAdapter(row, worksheet, report, CurrentRowIndex);
                CurrentRowIndex++;
            }
        }

        private void applyStyles()
        {
        }
    }
}