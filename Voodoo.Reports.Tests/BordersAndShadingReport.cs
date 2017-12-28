using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Voodoo.Reports.Models;
using Voodoo.TestData.Models;
using Color = System.Drawing.Color;
using Table = Voodoo.Reports.Models.Table;

namespace Voodoo.Reports.Tests
{
    public class BordersAndShadingReport : Report
    {
        public void Build(List<RandomPerson> data)
        {
            var table = getTable();
            Row row = null;
            Cell cell = null;

            foreach (var r in Enumerable.Range(1, 4))
            {
                row = table.AddRow();
                foreach (var c in Enumerable.Range(1, 4))
                {
                    cell = row.AddCell("X");
                }
            }
            var cells = getJaggedOutline(table);
            cells.ForEach(c => c.BackColor(Color.LightGray));
            table.SetInnerBorders(Color.Red, Reports.Models.BorderStyle.Solid, cells);
            table.SetOuterBorders(Color.Blue, Reports.Models.BorderStyle.Solid, cells);

            table = getTable();
            row = table.AddRow(.25).Big().Big().Bold().Border(BorderPosition.Bottom);
            cell = row.AddCell("Title").ColSpan(4).Center();
            row = table.AddRow(.2).Big().Bold().BackColor(Color.LightGray);
            row.AddCell("Left").ColSpan(2).Right().ForeColor(Color.Blue);
            row.AddCell("Right").ColSpan(2).Left().ForeColor(Color.Red);
            row = table.AddRow(2).Border(BorderPosition.All).Center();
            row.AddCell("Vertical Alignment").Middle().Center();
            row.AddCell("Top").Top().Center();
            row.AddCell("Middle").Middle().Center();
            row.AddCell("Bottom").Bottom().Center();
            row = table.AddRow().Center();
            row.AddCell("A").Row.AddCell("B").Row.AddCell("C").Row.AddCell("D");
            row = table.AddRow();
            var colorfulCell = row.AddCell().Row.AddCell().Row.AddCell().Row.AddCell();
            colorfulCell.AddFragment("A").ForeColor(Color.Red);
            colorfulCell.AddFragment("B").ForeColor(Color.Blue);
            colorfulCell.AddFragment("C").ForeColor(Color.Red);
            colorfulCell.AddFragment("D").ForeColor(Color.Blue);
        }

        private Cell[] getJaggedOutline(Table table)
        {
            var rows = table.Children().Select(c => c as Row).ToArray();
            var cells = new List<Cell>();
            cells.AddRange(rows[0].Children().Take(4).ToArray());
            cells.AddRange(rows[1].Children().Take(3).ToArray());
            cells.AddRange(rows[2].Children().Take(2).ToArray());
            cells.AddRange(rows[3].Children().Take(1).ToArray());
            return cells.ToArray();
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