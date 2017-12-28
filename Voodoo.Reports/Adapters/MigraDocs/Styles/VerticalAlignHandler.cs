using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using Voodoo;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.MigraDocs.Styles
{
    internal class VerticalAlignHandler : StyleHandler
    {
        private VAlign style;
        public VerticalAlignHandler(VAlign style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {
            switch (style.VerticleAlignment)
            {
                case VerticleAlignment.Top:
                    cell.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                    break;

                case VerticleAlignment.Center:
                    cell.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
                    break;

                case VerticleAlignment.Bottom:
                    cell.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Bottom;
                    break;
              
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void ApplyStyle(FormattedText cell)
        {
            NoOp();
        }
    }
}