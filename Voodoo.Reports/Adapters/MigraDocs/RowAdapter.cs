using System;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using Voodoo.Reports.Models;
using System.Linq;
using Border = Voodoo.Reports.Models.Border;
using Cell = Voodoo.Reports.Models.Cell;
using Table = Voodoo.Reports.Models.Table;
using Voodoo.Reports.Adapters.MigraDocs.Styles;

namespace Voodoo.Reports.Adapters.MigraDocs
{
    public class RowAdapter
    {
        private MigraDoc.DocumentObjectModel.Tables.Row migraDocRow;
        private Report report;
        private Models.Row row;
        private Models.Row[] tableRows;
        private Table table;

        public RowAdapter(Models.Row row, MigraDoc.DocumentObjectModel.Tables.Row migraDocRow, Report report)
        {
            table = row.Parent as Models.Table;
            tableRows = table.Children();
            this.row = row;
            this.row.HandlePrerendingTasks();
            this.migraDocRow = migraDocRow;
            migraDocRow.Height = Unit.FromInch(row.Height);
            this.report = report;
            applyStyles();
            handleChidren();
            if (row.IsHeader)
                migraDocRow.HeadingFormat = true;
        }

        private void handleChidren()
        {
            foreach (var cell in row.Children())
            {
                var position = table.GetPosition(cell);
                var migraDocCell = this.migraDocRow.Cells[position.Column];
                var adapter = new CellAdapter(cell, migraDocCell, report);
            }
        }

        private void applyStyles()
        {
            migraDocRow.Borders.ClearAll();
        }
    }
}