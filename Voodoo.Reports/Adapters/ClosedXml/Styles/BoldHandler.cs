using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.ClosedXml.Styles
{
    public class BoldHandler : StyleHandler
    {
        private Bold style;

        public BoldHandler(Bold style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(IXLCell cell, Fragment fragment = null)
        {
            if (fragment == null || fragment.Length == 0)
                return;

            cell.RichText.Substring(fragment.StartIndex, fragment.Length)
                .Bold = true;
        }
    }
}