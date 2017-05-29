using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;
using Underline = Voodoo.Reports.Models.Underline;

namespace Voodoo.Reports.Adapters.ClosedXml.Styles
{
    public class UnderlineHandler : StyleHandler
    {
        private Underline style;

        public UnderlineHandler(Underline style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(IXLCell cell, Fragment fragment = null)
        {
            if (fragment == null || fragment.Length == 0)
                return;

            cell.RichText.Substring(fragment.StartIndex, fragment.Length)
                .Underline = XLFontUnderlineValues.Single;
        }
    }
}