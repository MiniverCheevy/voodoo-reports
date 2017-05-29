using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voodoo.Reports.Models;

namespace Voodoo.Reports.RenderingLogic.BorderBuilders
{
    public class BottomBorderBuilder
    {
        private CellPositionMap cell;
        private List<CellPositionMap> map;
        private OutlineInlineBorder border;
        private InnerOuter innerOuter;
        private bool isBottom;

        public BottomBorderBuilder(CellPositionMap cell, List<CellPositionMap> map, OutlineInlineBorder border)
        {
            this.cell = cell;
            this.map = map;
            this.border = border;
            this.innerOuter = border.InnerOuter;
        }

        public void SetBottomBorder()
        {
            isBottom = IsBottomRow();
            var shouldApply = SHouldApplyBottomBorder();
            if (shouldApply)
                cell.Cell.Border(border.Color, BorderPosition.Bottom);
        }

        public bool IsBottomRow()
        {
            var bottomRow = map.Where(c => c.Position.Column == cell.Position.Column).Max(c => c.Position.Row);
            var isBottom = cell.Position.Row == bottomRow;
            return isBottom;
        }

        public bool SHouldApplyBottomBorder()
        {
            return ((isBottom && innerOuter == InnerOuter.Outer) || (!isBottom && innerOuter == InnerOuter.Inner));
        }
    }
}