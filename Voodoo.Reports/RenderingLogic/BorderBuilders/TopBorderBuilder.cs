using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voodoo.Reports.Models;

namespace Voodoo.Reports.RenderingLogic.BorderBuilders
{
    internal class TopBorderBuilder
    {
        private CellPositionMap cell;
        private List<CellPositionMap> map;
        private OutlineInlineBorder border;
        private InnerOuter innerOuter;
        private bool isTop;

        internal TopBorderBuilder(CellPositionMap cell, List<CellPositionMap> map, OutlineInlineBorder border)
        {
            this.cell = cell;
            this.map = map;
            this.border = border;
            this.innerOuter = border.InnerOuter;            
        }
        internal void SetTopBorder()
        {
            isTop = IsTopRow();
            var shouldApply = ShouldApplyTopBorder();
            if (shouldApply)
                cell.Cell.Border(border.Color, BorderPosition.Top);

        }
        internal bool IsTopRow()
        {
            var topRow = map.Where(c => c.Position.Column == cell.Position.Column).Min(c => c.Position.Row);            
            var isTop = cell.Position.Row == topRow;
            return isTop;
        }
        internal bool ShouldApplyTopBorder()
        {
            return ((isTop && innerOuter == InnerOuter.Outer) || (!isTop && innerOuter == InnerOuter.Inner));
        }
    }
}
