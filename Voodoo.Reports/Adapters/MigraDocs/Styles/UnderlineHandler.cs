using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;
using Underline = Voodoo.Reports.Models.Underline;

namespace Voodoo.Reports.Adapters.MigraDocs.Styles
{
    public class UnderlineHandler : StyleHandler
    {
        private Underline style;

        public UnderlineHandler(Underline style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {
            NoOp();
        }

        public override void ApplyStyle(FormattedText text)
        {
            text.Font.Underline = MigraDoc.DocumentObjectModel.Underline.Single;
        }
    }
}