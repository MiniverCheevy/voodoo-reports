using System.Collections.Generic;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;
using Style = Voodoo.Reports.Models.Style;

namespace Voodoo.Reports.Adapters.ClosedXmls
{
    internal class CellAdapter
    {
        private Models.Cell cell;
        private MigraDoc.DocumentObjectModel.Tables.Cell migraDocCell;
        private Report report;

        public CellAdapter(Models.Cell cell, MigraDoc.DocumentObjectModel.Tables.Cell migraDocCell, Report report)
        {
            this.cell = cell;
            this.migraDocCell = migraDocCell;
            this.report = report;
            handleChidren();
        }

        private void handleChidren()
        {
            //TODO: images
            var adapter = new StyleAdapter(migraDocCell, cell);
            foreach (var fragment in cell.Children())
            {
                addFragment(fragment);
            }
            
        }

        private void addFragment(Fragment fragment)
        {
            var text = migraDocCell.AddParagraph(fragment.Text);
            var adapter = new StyleAdapter(text, fragment);
        }
    }

    public class StyleAdapter
    {
        private MigraDoc.DocumentObjectModel.Tables.Cell migraDocCell;
        private Paragraph text;
        private Models.Cell cell;
        private Fragment fragment;
        private List<Style> styles;

        public StyleAdapter(Cell migraDocCell, Models.Cell cell)
        {
            this.cell = cell;
            this.migraDocCell = migraDocCell;
            this.styles = cell.GetCalculatedStyles();
            applyStyles();
        }
        
        public StyleAdapter(Paragraph text, Fragment fragment)
        {
            this.text = text;
            this.fragment = fragment;
            this.styles = fragment.GetCalculatedStyles();
            applyStyles();
        }

        private void applyStyles()
        {
            foreach (var style in styles)
            {

            }
        }
    }
}