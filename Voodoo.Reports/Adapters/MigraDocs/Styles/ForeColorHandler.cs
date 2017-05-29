using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.MigraDocs.Styles
{
    public class ForeColorHandler : StyleHandler
    {
        private ForeColor style;

        public ForeColorHandler(ForeColor style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {
            NoOp();
        }

        public override void ApplyStyle(FormattedText text)
        {
            text.Font.Color = Color.FromRgb(style.Color.R, style.Color.G, style.Color.B);
        }
    }
}