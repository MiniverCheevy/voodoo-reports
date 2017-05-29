using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.ClosedXml.Styles
{
    public class ItalicsHandler : StyleHandler
    {
        private Italics style;

        public ItalicsHandler(Italics style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(IXLCell cell, Fragment fragment = null)
        {
            if (fragment == null || fragment.Length == 0)
                return;

            cell.RichText.Substring(fragment.StartIndex, fragment.Length)
                .Italic = true;
        }
    }
}