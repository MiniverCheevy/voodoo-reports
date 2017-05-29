using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.ClosedXml.Styles
{
    public class BigFontHandler : StyleHandler
    {
        public BigFontHandler(BigFont style, Report report) : base(report)
        {
        }

        public override void ApplyStyle(IXLCell cell, Fragment fragment = null)
        {
            if (fragment == null || fragment.Length == 0)
                return;
            var text = cell.RichText.Substring(fragment.StartIndex, fragment.Length);
            var size = report.DefaultFontSize;

            size = size * 1.3;
            text.SetFontSize(size);
        }
    }

    public class FontSizeHandler : StyleHandler
    {
        private FontSize style;

        public FontSizeHandler(FontSize style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(IXLCell cell, Fragment fragment = null)
        {
            if (fragment == null || fragment.Length == 0)
                return;
            var text = cell.RichText.Substring(fragment.StartIndex, fragment.Length);

            text.SetFontSize(Unit.FromPoint(style.Size));
        }
    }
}