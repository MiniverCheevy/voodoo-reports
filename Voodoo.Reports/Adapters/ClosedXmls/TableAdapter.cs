using Voodoo.Reports.Models;

namespace Voodoo.Reports.Adapters.ClosedXmls
{
    public class TableAdapter
    {
        private MigraDoc.DocumentObjectModel.Tables.Table migraDocTable;
        private Report report;
        private Models.Table table;

        public TableAdapter(Models.Table table, MigraDoc.DocumentObjectModel.Tables.Table migraDocTable, Report report)
        {
            this.table = table;
            this.migraDocTable = migraDocTable;
            this.report = report;
            applyStyles();
            handleChidren();
        }

        private void handleChidren()
        {
            foreach (var row in table.Children())
            {
                var migraDocRow = this.migraDocTable.AddRow();
                var adapter = new RowAdapter(row, migraDocRow, report);
            }
        }

        private void applyStyles()
        {
            
        }
    }
}
