using Voodoo.Reports.Models;

namespace Voodoo.Reports.Adapters.ClosedXmls
{
    public class RowAdapter
    {
        private MigraDoc.DocumentObjectModel.Tables.Row migraDocRow;
        private Report report;
        private Row row;

        public RowAdapter(Row row, MigraDoc.DocumentObjectModel.Tables.Row migraDocRow, Report report)
        {
            this.row = row;
            this.migraDocRow = migraDocRow;
            this.report = report;
            applyStyles();
            handleChidren();
        }

        private void handleChidren()
        {
            int counter = 0;
            foreach (var cell in row.Children())
            {
                var migraDocCell = this.migraDocRow.Cells[counter];                
                var adapter = new CellAdapter(cell, migraDocCell, report);
            }
        }

        private void applyStyles() { }
    }
}