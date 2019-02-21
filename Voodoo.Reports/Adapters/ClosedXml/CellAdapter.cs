using System;
using System.Linq;
using ClosedXML.Excel;
using Voodoo.Reports.Adapters.ClosedXml.Styles;
using Voodoo.Reports.Models;
using Border = Voodoo.Reports.Models.Border;

namespace Voodoo.Reports.Adapters.ClosedXml
{
    internal class CellAdapter
    {
        private Models.Cell cell;
        private Report report;
        private IXLCell excelCell;
        private int currentRowIndex;

        public CellAdapter(Cell cell, IXLCell excelCell, Report report, int currentRowIndex)
        {
            this.currentRowIndex = currentRowIndex;
            this.cell = cell;
            this.excelCell = excelCell;
            excelCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
            this.report = report;
            this.cell = cell;
            this.cell.HandlePrerendingTasks();

            if (cell.Columns != 1 || cell.Rows != 1)
                mergeCell();

            this.report = report;
            handleChidren();
        }

        private void mergeCell()
        {
            var row = this.currentRowIndex;
            var column = excelCell.WorksheetColumn().ColumnNumber();
            var columnName = ColumnHelper.GetColumnName(column);
            var thisCell = $"{columnName}{row}";

            var endColumn = column + cell.Columns - 1;
            var endRow = row + cell.Rows - 1;
            var endColumnName = ColumnHelper.GetColumnName(endColumn);
            var endCell = $"{endColumnName}{endRow}";

            var range = $"{thisCell}:{endCell}";
            excelCell.Worksheet.Range(range).Merge();
        }

        private void handleChidren()
        {
            var styles = cell.GetCalculatedStyles();
            foreach (var style in styles)
            {
                StyleFactory.GetHandler(style, cell.Report).ApplyStyle(excelCell);
            }

            if (cell.imageBytes != null)
            {
                addImage();
            }

            foreach (var fragment in cell.Children())
            {
                addFragment(fragment);
            }
        }

        private void addImage()
        {
            var imageString = "base64:" + Convert.ToBase64String(cell.imageBytes);
            // migraDocCell.AddImage(imageString);
        }

        private void addFragment(Fragment fragment)
        {
            fragment.StartIndex = excelCell.Value.To<string>().Length;
            excelCell.Value = $"{excelCell.Value}{fragment.Text}";

            //if (fragment.IsNumberOfPages)
            //    paragraph.AddNumPagesField();
            //else if (fragment.IsPageNumber)
            //    paragraph.AddPageField();
            //else
            //{
            //    if (cell.HasNonBreakingSpaces)
            //    {
            //        var nonBreakingSpace = ' ';//<alt>+255 in visual studio
            //        fragment.Text = fragment.Text.Replace(' ', nonBreakingSpace);
            //    }
            //    var text = paragraph.AddFormattedText(fragment.Text.To<string>());
            var styles = fragment.GetCalculatedStyles();
            foreach (var style in styles)
            {
                StyleFactory.GetHandler(style, fragment.Report).ApplyStyle(excelCell, fragment);
            }
            //}
        }
    }
}