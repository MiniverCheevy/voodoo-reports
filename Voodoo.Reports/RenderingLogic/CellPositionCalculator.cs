using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voodoo.Reports.Models;

namespace Voodoo.Reports.RenderingLogic
{
    public class CellPositionCalculator
    {
        private Table table;
        private int numberOfColumns;
        private int numberOfRows;

        public CellPosition[,] CellPosition { get; private set; }
        public Dictionary<Cell, CellPosition> PositionDictionary { get; private set; }

        public CellPositionCalculator(Table table)
        {
            this.table = table;
            this.PositionDictionary = new Dictionary<Cell, Models.CellPosition>();
            buildArray();
            setPositions();
        }

        private void buildArray()
        {
            numberOfColumns = table.Columns().Count();
            numberOfRows = table.Children().Count();
            this.CellPosition = new CellPosition[numberOfColumns, numberOfRows];
            foreach (var column in Enumerable.Range(0, numberOfColumns))
            {
                foreach (var row in Enumerable.Range(0, numberOfRows))
                {
                    this.CellPosition[column, row] = new Models.CellPosition();
                }
            }
        }

        public void setPositions()
        {
            var tableRows = table.Children().Select(c => c as Row).ToArray();
            var rowCount = 0;
            foreach (var row in tableRows)
            {
                var columns = row.Children().Select(c => c as Cell).ToArray();

                var columnCount = 0;
                foreach (var column in columns)
                {
                    var thisColumn = positionCell(columnCount, rowCount, column);

                    PositionDictionary.Add(column, thisColumn);
                    columnCount++;
                }
                rowCount++;
            }
        }

        private CellPosition positionCell(int columnCount, int rowCount, Cell rowCell)
        {
            try
            {
                var thisCell = CellPosition[columnCount, rowCount];
                thisCell.Row += rowCount;
                thisCell.Column += columnCount;

                var colSpan = rowCell.Columns;
                var rowSpan = rowCell.Rows;

                adjustColumns(colSpan, columnCount, rowCount);
                adjustRows(rowSpan, columnCount, rowCount);
                return thisCell;
            }
            catch (Exception ex)
            {
                var error =
                    $"Error encountered with row {rowCount} column {columnCount} data = {rowCell}, you may have tried to add more cells than there are columns.";
                throw new Exception(error, ex);
            }
        }

        private void adjustColumns(int colSpan, int cellCount, int rowCount)
        {
            if (colSpan <= 1) return;
            foreach (var offsetColumn in Enumerable.Range(1, colSpan - 1))
            {
                CellPosition[cellCount + offsetColumn, rowCount].Column += 1;
            }
        }

        private void adjustRows(int rowSpan, int cellCount, int rowCount)
        {
            if (rowSpan <= 1) return;
            foreach (var offSetRow in Enumerable.Range(1, rowSpan - 1))
            {
                CellPosition[cellCount, rowCount + offSetRow].Column += 1;
                foreach (var otherColumns in Enumerable.Range(cellCount + 1, numberOfColumns - 1))
                {
                    CellPosition[otherColumns, rowCount + offSetRow].Column += 1;
                }
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            var tableRows = table.Children().Select(c => c as Row).ToArray();

            foreach (var row in tableRows)
            {
                var columns = row.Children().Select(c => c as Cell).ToArray();
                foreach (var column in columns)
                {
                    var position = this.PositionDictionary[column];
                    builder.Append($"(x={position.Column},y={position.Row})".PadRight(10));
                    builder.Append(" - ");
                    builder.Append(column.ToString().PadRight(30));

                    builder.Append("|");
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}