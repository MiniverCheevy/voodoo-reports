using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;

namespace Voodoo.Reports.Adapters.MigraDocs.Styles
{
    public class BoldHandler : StyleHandler
    {
        private Bold style;

        public BoldHandler(Bold style, Report report) : base(report)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {
            NoOp();
        }

        public override void ApplyStyle(FormattedText text)
        {
            text.Font.Bold = true;
        }
    }
}