using System;
using System.Collections.Generic;


namespace Voodoo.Reports.Models
{
    public class Row : Part, ITabularObject
    {
        


        private DefaultCellFormatOptions formatOptions => Table.Report.FormatOptions;
        private int cellIndex = 0;
        public Table Table => Parent as Table;

        public Cell[] Children()
        {
            return cells.ToArray();
        }

        internal double? Height { get; set; }
        internal bool IsHeader { get; private set; }
        public int Index { get; internal set; }

        private List<Cell> cells = new List<Cell>();

        public Row Header()
        {
            IsHeader = true;
            return this;
        }

        public Cell AddCell()
        {
            var cell = new Cell
            {
                Parent = this,
                Index = cellIndex++
            };
            cells.Add(cell);
            return cell;
        }

        public Cell AddCell(string content)
        {
            var cell = new Cell
            {
                Parent = this,
                Index = cellIndex++
            };
            cell.AddFragment(content);
            cells.Add(cell);
            return cell;
        }

        public Cell AddIntCell(int content)
        {
           return AddCell(content, formatOptions.IntFormatOptions);
        }
        public Cell AddDecimalCell(decimal content)
        {
            return AddCell(content, formatOptions.DecimalFormatOptions);
        }
        public Cell AddCurrencyCell(decimal content)
        {
            return AddCell(content, formatOptions.CurrencyFormatOptions);
        }
        public Cell AddPercentCell(decimal content)
        {
            return AddCell(content, formatOptions.PercentFormatOptions);
        }
        public Cell AddDateCell(DateTime content)
        {
            return AddCell(content, formatOptions.DateFormatOptions);
        }
        public Cell AddTimeCell(DateTime content)
        {
            return AddCell(content, formatOptions.TimeFormatOptions);
        }
        public Cell AddDateTimeCell(DateTime content)
        {
            return AddCell(content, formatOptions.DateTimeFormatOptions);
        }
        public Cell AddCell(object content, CellFormatOptions options)
        {
            var cell = new Cell() { Parent = this, Index = cellIndex++ };
            cell.Styles.Add(new Align { Alignment = options.Alignment });
            cell.AddFragment(content, options.FormatString);
            cells.Add(cell);
            return cell;
        }
        public Cell[] GetAllCells()
        {
            return this.cells.ToArray();
        }

        public override string ToString()
        {
            return string.Join("|", cells);
        }
    }
}