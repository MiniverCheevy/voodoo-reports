using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voodoo.Reports.Models;
using Voodoo.TestData.Models;

namespace Voodoo.Reports.Tests
{
    public class UnfilledCellsReport : Report
    {
        public void Build(List<RandomPerson> data)
        {
            var table = getTable();
            var row = table.AddRow();
            row.AddCell();
            row.AddCell();
        }

        private Table getTable()
        {
            var table = this.Body.AddTable();
            table.AddColumns(4);
            table.AddSpacer();
            return table;
        }
    }
}
