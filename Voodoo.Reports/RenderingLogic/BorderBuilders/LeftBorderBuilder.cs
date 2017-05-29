using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voodoo.Reports.Models;

namespace Voodoo.Reports.RenderingLogic.BorderBuilders
{
    public class LeftBorderBuilder
    {
        private CellPositionMap cell;
        private List<CellPositionMap> map;
        private OutlineInlineBorder border;
        private InnerOuter innerOuter;
        private bool isLeftMost;

        internal LeftBorderBuilder(CellPositionMap cell, List<CellPositionMap> map, OutlineInlineBorder border)
        {
            this.cell = cell;
            this.map = map;
            this.border = border;
            this.innerOuter = border.InnerOuter;
        }

        public void SetLeftBorder()
        {
            isLeftMost = IsLeftMost();
            var shouldApply = ShouldApplyLeftBorder();
            if (shouldApply)
                cell.Cell.Border(border.Color, BorderPosition.Left);
        }

        public bool ShouldApplyLeftBorder()
        {
            return ((isLeftMost && innerOuter == InnerOuter.Outer) || (!isLeftMost && innerOuter == InnerOuter.Inner));
        }

        public bool IsLeftMost()
        {
            var leftSide = map.Where(c => c.Position.Row == cell.Position.Row).Min(c => c.Position.Column);
            var isLeftMost = cell.Position.Column == leftSide;
            return isLeftMost;
        }
    }
}