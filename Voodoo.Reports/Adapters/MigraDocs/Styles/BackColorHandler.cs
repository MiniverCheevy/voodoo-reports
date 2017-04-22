using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.MigraDocs.Styles
{
    public class BackColorHandler : StyleHandler
    {
        private BackColor style;

        public BackColorHandler(BackColor style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {
            cell.Shading.Color = Color.FromRgb(style.Color.R, style.Color.G, style.Color.B);
        }
        public override void ApplyStyle(FormattedText text)
        {
            NoOp();
        }
    }
}