using System;
using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.ClosedXml.Styles
{
    internal class AlignHandler : StyleHandler
    {
        private Align style;

        public AlignHandler(Align style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(IXLCell cell, Fragment fragment = null)
        {
            switch (style.Alignment)
            {
                case Alignment.Left:
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    break;
                case Alignment.Center:
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    break;
                case Alignment.Right:
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    break;
                case Alignment.Justified:
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Justify;

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}