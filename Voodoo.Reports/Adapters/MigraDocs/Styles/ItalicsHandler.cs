using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.MigraDocs.Styles
{
    public class ItalicsHandler : StyleHandler
    {
        private Italics style;

        public ItalicsHandler(Italics style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {
            NoOp();
        }
        public override void ApplyStyle(FormattedText text)
        {
            text.Font.Italic = true;
        }
    }
}