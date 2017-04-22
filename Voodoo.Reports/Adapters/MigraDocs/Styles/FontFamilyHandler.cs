using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.MigraDocs.Styles
{
    public class FontFamilyHandler : StyleHandler
    {
        private FontFamily style;

        public FontFamilyHandler(FontFamily style, Report report): base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {
            NoOp();
        }

        public override void ApplyStyle(FormattedText text)
        {
            if (style.Name != report.DefaultFontFamily)
                text.Font.ApplyFont(new Font(style.Name));
        }
    }
}