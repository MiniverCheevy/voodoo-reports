using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.MigraDocs.Styles
{
    public class BigFontHandler : StyleHandler
    {

        public BigFontHandler(BigFont style, Report report) : base(report)
        {
          
        }

        public override void ApplyStyle(Cell cell)
        {
            NoOp();
        }
        public override void ApplyStyle(FormattedText text)
        {
            var size = text.Font.Size.Point;
            if (size == 0)
                size = report.DefaultFontSize;
            size = size * 1.3;
            text.Font.Size = size;            

        }
    }
    public class FontSizeHandler : StyleHandler
    {
        private FontSize style;

        public FontSizeHandler(FontSize style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {
            NoOp();
        }
        public override void ApplyStyle(FormattedText text)
        {
            if (style.Size != report.DefaultFontSize)
                text.Font.Size = Unit.FromPoint(style.Size);

        }
    }
}