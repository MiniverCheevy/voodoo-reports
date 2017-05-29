using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.ClosedXml.Styles
{
    public class ForeColorHandler : StyleHandler
    {
        private ForeColor style;

        public ForeColorHandler(ForeColor style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(IXLCell cell, Fragment fragment = null)
        {
            if (fragment == null || fragment.Length == 0)
                return;
            var color = XLColor.FromArgb(style.Color.R, style.Color.G, style.Color.B);
            cell.RichText.Substring(fragment.StartIndex, fragment.Length)
                .FontColor = color;
        }
    }
}