using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel.Tables;
using Voodoo.Reports.Models;

namespace Voodoo.Reports.Models
{
    public class Section : Part
    {
        public Table[] Children()
        {
            return tables.ToArray();
        }

        private List<Table> tables = new List<Table>();
        private int tableIndex = 0;
        public Table AddTable()
        {
            var table = new Table() {Parent = this, Index = tableIndex ++};
            tables.Add(table);

            return table;
        }

        public void AddVerticalSpacer(double? heightInInces)
        {
            var table = new Table {Parent = this};
            tables.Add(table);
            table.AddColumn(7.5);
            var row = table.AddRow(heightInInces);
            row.AddCell(string.Empty);
        }
    }
}