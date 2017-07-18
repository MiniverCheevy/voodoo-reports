using System.Linq;
using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Adapters.MigraDocs;
using Voodoo.Reports.Models;
using Border = Voodoo.Reports.Models.Border;
using Table = Voodoo.Reports.Models.Table;

namespace Voodoo.Reports.Adapters.ClosedXml
{
    public class RowAdapter
    {
        private Report report;
        private Models.Row row;
        private Models.Row[] tableRows;
        private Table table;
        private IXLWorksheet worksheet;
        private int currentRowIndex;

        public RowAdapter(Row row, IXLWorksheet worksheet, Report report, int currentRowIndex)
        {
            this.row = row;
            this.worksheet = worksheet;
            this.report = report;
            this.currentRowIndex = currentRowIndex;

            table = row.Parent as Models.Table;
            tableRows = table.Children();

            this.row.HandlePrerendingTasks();
            var height = row.Height ?? .15;
            worksheet.Row(currentRowIndex).Height = height *
                                                    report.RenderOptions.Excel.VerticleUnitsPerInch.To<double>();

            this.report = report;
            applyStyles();
            handleChidren();
            if (row.IsHeader)
            {
            }
        }

        private void handleChidren()
        {
            foreach (var cell in row.Children())
            {
                var position = table.GetPosition(cell);
                var column = ColumnHelper.GetColumnName(position.Column + 1);
                var excelCell = worksheet.Cell(currentRowIndex, position.Column + 1);
                var adapter = new CellAdapter(cell, excelCell, report, currentRowIndex);
            }
        }

        private void applyStyles()
        {
        }
    }
}