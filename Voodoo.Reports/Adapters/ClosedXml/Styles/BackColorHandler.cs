using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.ClosedXml.Styles
{
    public class BackColorHandler : StyleHandler
    {
        private BackColor style;

        public BackColorHandler(BackColor style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(IXLCell cell, Fragment fragment = null)
        {
            var color = XLColor.FromArgb(style.Color.R, style.Color.G, style.Color.B);
            cell.Style.Fill.BackgroundColor = color;
        }
    }
}