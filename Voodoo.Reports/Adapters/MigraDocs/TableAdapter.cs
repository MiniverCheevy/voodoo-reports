using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using Voodoo.Reports.Models;
using Border = Voodoo.Reports.Models.Border;
using Row = Voodoo.Reports.Models.Row;
using Voodoo.Reports.Adapters.MigraDocs.Styles;

namespace Voodoo.Reports.Adapters.MigraDocs
{
    public class TableAdapter
    {
        private MigraDoc.DocumentObjectModel.Tables.Table migraDocTable;
        private Report report;
        private Models.Table table;

        public TableAdapter(Models.Table table, MigraDoc.DocumentObjectModel.Tables.Table migraDocTable, Report report)
        {
            this.table = table;
            this.table.HandlePrerendingTasks();
            this.migraDocTable = migraDocTable;
            this.report = report;
            applyStyles();
            handleChidren();
        }


        private void handleChidren()
        {
            foreach (var column in table.Columns())
            {
                if (column.HasValue)
                    migraDocTable.AddColumn(Unit.FromInch(column.Value));
                else
                    migraDocTable.AddColumn();
            }

            foreach (var row in table.Children())
            {
                var migraDocRow = this.migraDocTable.AddRow();
                migraDocRow.Borders.ClearAll();
                var adapter = new RowAdapter(row, migraDocRow, report);
            }
        }

        private void applyStyles()
        {
            migraDocTable.Borders.ClearAll();
        }
    }
}