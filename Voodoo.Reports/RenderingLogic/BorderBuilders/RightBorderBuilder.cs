using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voodoo.Reports.Models;

namespace Voodoo.Reports.RenderingLogic.BorderBuilders
{
    public class RightBorderBuilder
    {
        private CellPositionMap cell;
        private List<CellPositionMap> map;
        private OutlineInlineBorder border;
        private InnerOuter innerOuter;
        private bool isRightSide;

        internal RightBorderBuilder(CellPositionMap cell, List<CellPositionMap> map, OutlineInlineBorder border)
        {
            this.cell = cell;
            this.map = map;
            this.border = border;
            this.innerOuter = border.InnerOuter;
        }

        public void SetRightBorder()
        {
            isRightSide = IsRightMost();
            var shouldApply = ShouldApplyRightBorder();

            if (shouldApply)
                cell.Cell.Border(border.Color, BorderPosition.Right);
        }

        public bool IsRightMost()
        {
            var rightSide = map.Where(c => c.Position.Row == cell.Position.Row).Max(c => c.Position.Column);
            var isRightMost = cell.Position.Column == rightSide;
            return isRightMost;
        }
        public bool ShouldApplyRightBorder()
        {
            return ((isRightSide && innerOuter == InnerOuter.Outer) || (!isRightSide && innerOuter == InnerOuter.Inner));
        }
    }
}
