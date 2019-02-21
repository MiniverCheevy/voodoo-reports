using System;
using System.Collections.Generic;
using System.Linq;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using Voodoo.Reports.Adapters.MigraDocs.Styles;
using Voodoo.Reports.Models;
using Border = Voodoo.Reports.Models.Border;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;
using Style = Voodoo.Reports.Models.Style;

namespace Voodoo.Reports.Adapters.MigraDocs
{
    internal class CellAdapter
    {
        private Models.Cell cell;
        private MigraDoc.DocumentObjectModel.Tables.Cell migraDocCell;
        private Report report;
        private Paragraph paragraph;

        public CellAdapter(Models.Cell cell, MigraDoc.DocumentObjectModel.Tables.Cell migraDocCell, Report report)
        {
            this.cell = cell;
            this.cell.HandlePrerendingTasks();
            this.migraDocCell = migraDocCell;
            
            this.migraDocCell.Borders.ClearAll();
            if (cell.Columns != 1)
                migraDocCell.MergeRight = cell.Columns - 1;
            if (cell.Rows != 1)
                migraDocCell.MergeDown = cell.Rows - 1;
            

            this.report = report;
            handleChidren();
        }

        private void handleChidren()
        {
            clearBorders();
            var styles = cell.GetCalculatedStyles();
            foreach (var style in styles)
            {
                StyleFactory.GetHandler(style, cell.Report).ApplyStyle(migraDocCell);
            }

            if (cell.imageBytes != null)
            {
                addImage();
            }

            paragraph = migraDocCell.AddParagraph();

            foreach (var fragment in cell.Children())
            {
                addFragment(fragment);
            }
        }

        private void clearBorders()
        {
            migraDocCell.Borders.ClearAll();
            var style = new Border
            {
                Style = Models.BorderStyle.None,
                Position = new BorderPosition[] { BorderPosition.All }
            };

            StyleFactory.GetHandler(style, cell.Report).ApplyStyle(migraDocCell);
        }

        private void addImage()
        {

            var imageString = "base64:" + Convert.ToBase64String(cell.imageBytes);            
            var image = migraDocCell.AddImage(imageString);
            image.LockAspectRatio = true;
            image.RelativeVertical = RelativeVertical.Line;
            image.RelativeHorizontal = RelativeHorizontal.Margin;
            image.Top = ShapePosition.Top;
            image.Left = ShapePosition.Right;
            image.WrapFormat.Style = WrapStyle.Through;
            if (cell.imageHeight.HasValue)
                image.Height = new Unit(cell.imageHeight.Value, UnitType.Inch);

        }

        private void addFragment(Fragment fragment)
        {
            if (fragment.IsNumberOfPages)
                paragraph.AddNumPagesField();
            else if (fragment.IsPageNumber)
                paragraph.AddPageField();
            else
            {
                if (cell.HasNonBreakingSpaces)
                {
                    var nonBreakingSpace = ' '; //<alt>+255 in visual studio
                    fragment.Text = fragment.Text.Replace(' ', nonBreakingSpace);
                }
                var text = paragraph.AddFormattedText(fragment.Text.To<string>());
                var styles = fragment.GetCalculatedStyles();
                foreach (var style in styles)
                {
                    StyleFactory.GetHandler(style, fragment.Report).ApplyStyle(text);
                }
            }
        }
    }
}