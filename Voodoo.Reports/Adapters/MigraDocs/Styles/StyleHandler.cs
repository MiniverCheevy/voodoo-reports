using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;

namespace Voodoo.Reports.Adapters.MigraDocs.Styles
{
    public abstract class StyleHandler
    {
        protected Report report;
        public abstract void ApplyStyle(MigraDoc.DocumentObjectModel.Tables.Cell cell);
        public abstract void ApplyStyle(FormattedText text);

        protected StyleHandler(Report report)
        {
            this.report = report;
        }
        /// <summary>
        /// Does not apply, do nothing
        /// </summary>
        public void NoOp() { }
    }
}