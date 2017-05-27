using System;
using System.Collections.Generic;
using System.Linq;
using Voodoo.Reports.RenderingLogic;
using Color = System.Drawing.Color;

namespace Voodoo.Reports.Models
{
    public class Table : Part, ITabularObject
    {
        public Section Section => Parent as Section;

        private List<double?> columns = new List<double?>();
        private List<Row> rows = new List<Row>();
        public CellPositionCalculator CellPositionCalculator { get; set; }        
        internal List<OuterBorder> OuterBorders { get;  set; } = new List<OuterBorder>();
        internal List<InnerBorder> InternalBorders { get;  set; } = new List<InnerBorder>();
  
        public Row[] Children()
        {
            return rows.ToArray();
        }
        public double?[] Columns()
        {
            return columns.ToArray();
        }
        public void AddSpacer(double heightInInches=.2)
        {
            this.AddRow(heightInInches).NoBorder();
        }
        public void AddColumns(int numberOfColumns)
        {
            var width = Math.Round(7.5m / numberOfColumns.To<decimal>(),2);
            foreach (var col in Enumerable.Range(1, numberOfColumns))
                columns.Add(width.To<double>());
        }
        public void AddColumn(double? widthInInches = default(double?))
        {
            columns.Add(widthInInches);
        }
        public Row AddRow(double heightInInches=.15)
        {
            var row = new Row() { Parent = this, Height=heightInInches };
            rows.Add(row);
            return row;
        }
       
        public CellPosition GetPosition(Cell cell)
        {            
            return this.CellPositionCalculator.PositionDictionary[cell];
        }
        public Cell[] SetOuterBorders(Color color, BorderStyle style, params ITabularObject[] parts)
        {
            var cells = getCellsFromParts(parts);
            this.OuterBorders.Add(new OuterBorder { Color = color, BorderStyle = style, Cells = cells });
            return cells;
        }
        public Cell[] SetInnerBorders(Color color, BorderStyle style, params ITabularObject[] parts)
        {
            var cells = getCellsFromParts(parts);
            this.InternalBorders.Add(new InnerBorder { Color = color, BorderStyle = style, Cells = cells });
            return cells;
        }
        
        private Cell[] getCellsFromParts(ITabularObject[] parts)
        {
            var result = new List<Cell>();
            foreach (var part in parts)
            {
                result.AddRange(part.GetAllCells());
            }
            return result.Distinct().ToArray();
        }

        public Cell[] GetAllCells()
        {
            return rows.SelectMany(c => c.GetAllCells()).ToArray();
        }
        internal override void HandlePrerendingTasks()
        {
            var maxColumns = this.Children().Max(c => c.Children().Count());
            if (maxColumns < columns.Count())
                throw new Exception($"Found {maxColumns} but only {columns.Count()} are defined.  Use AddColumn or AddColumns to add columns to this table");

            if (this.CellPositionCalculator == null)
            {
                this.CellPositionCalculator = new CellPositionCalculator(this);
            }
            new BorderFactory().BuildBorders(this);
            base.HandlePrerendingTasks();
        }
    }
}