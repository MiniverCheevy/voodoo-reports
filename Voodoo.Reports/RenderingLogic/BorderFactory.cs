using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voodoo.Reports.Models;
using Voodoo.Reports.RenderingLogic.BorderBuilders;

namespace Voodoo.Reports.RenderingLogic
{
    public class BorderFactory
    {
        private Table table;

        public void BuildBorders(Table table)
        {
            this.table = table;
            foreach (var outerBorder in table.OuterBorders)
            {
                buildBorders(outerBorder);
            }
            foreach (var internalBorder in table.InternalBorders)
            {
                buildBorders(internalBorder);
            }
        }

        private void buildBorders(OutlineInlineBorder border)
        {
            var map = new CellPositionMapper(table, border.Cells).CellPositionMaps;
            foreach (var cell in map)
            {
                new TopBorderBuilder(cell, map, border).SetTopBorder();
                new BottomBorderBuilder(cell, map, border).SetBottomBorder();
                new LeftBorderBuilder(cell, map, border).SetLeftBorder();
                new RightBorderBuilder(cell, map, border).SetRightBorder();
            }
        }
    }
}