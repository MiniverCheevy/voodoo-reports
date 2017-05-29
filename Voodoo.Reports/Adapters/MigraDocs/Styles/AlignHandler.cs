using System;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.MigraDocs.Styles
{
    internal class AlignHandler : StyleHandler
    {
        private Align style;

        public AlignHandler(Align style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {
            switch (style.Alignment)
            {
                case Alignment.Left:
                    cell.Format.Alignment = ParagraphAlignment.Left;
                    break;
                case Alignment.Center:
                    cell.Format.Alignment = ParagraphAlignment.Center;

                    break;
                case Alignment.Right:
                    cell.Format.Alignment = ParagraphAlignment.Right;

                    break;
                case Alignment.Justified:
                    cell.Format.Alignment = ParagraphAlignment.Justify;

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