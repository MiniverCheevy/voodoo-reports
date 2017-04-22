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
            if (row.ExcludedStyles.Any(c => c.GetType() == typeof(Border)))
            {
                migraDocRow.Borders.ClearAll();
                //migraDocRow.Borders.Width = 0;
            }
            var borders = row.GetCalculatedStyles().Where(c => c is Border).ToArray();
            foreach (var border in borders)
            {
                var borderHandler = new BorderHandler(border as Border, report);
                borderHandler.ApplyStyle(migraDocRow);
            }
            var excludedBorders = row.ExcludedStyles.Where(c => c is Border).ToArray();
            foreach (var b in excludedBorders)
            {
                var border = b as Border;
                border.Style = Models.BorderStyle.None;
                var borderHandler = new BorderHandler(border as Border, report);
                borderHandler.ApplyStyle(migraDocRow);
            }
        }
    }
}