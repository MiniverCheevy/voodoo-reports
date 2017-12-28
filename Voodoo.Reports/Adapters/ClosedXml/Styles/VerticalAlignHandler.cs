using System;
using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Underline = Voodoo.Reports.Models.Underline;

namespace Voodoo.Reports.Adapters.ClosedXml.Styles
{
    internal class VerticalAlignHandler : StyleHandler
    {
        private VAlign style;
        public VerticalAlignHandler(VAlign style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(IXLCell cell, Fragment fragment = null)
        {           

            switch (style.VerticleAlignment)
            {
                case VerticleAlignment.Top:
                    cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                    break;

                case VerticleAlignment.Center:
                    cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    break;

                case VerticleAlignment.Bottom:
                    cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Bottom;
                    break;
              
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}