using System.Collections;
using System.Linq;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Border = Voodoo.Reports.Models.Border;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;
using Table = MigraDoc.DocumentObjectModel.Tables.Table;
using Row = MigraDoc.DocumentObjectModel.Tables.Row;

namespace Voodoo.Reports.Adapters.MigraDocs.Styles
{
    public class BorderHandler : StyleHandler
    {
        private Border style;
        private BorderPosition[] allBorders= new BorderPosition[] { BorderPosition.Bottom, BorderPosition.Top, BorderPosition.Left, BorderPosition.Right };

        public BorderHandler(Border border, Report report):base(report)
        {
            this.style = border;
        }
        public void ApplyStyle(Table table)
        {
            if (style.Position.Contains(BorderPosition.All))
                style.Position = allBorders;

            if (style.Position.Contains(BorderPosition.Bottom))
                setBorder(table.Borders.Bottom, style);

            if (style.Position.Contains(BorderPosition.Top))
                setBorder(table.Borders.Top, style);

            if (style.Position.Contains(BorderPosition.Left))
                setBorder(table.Borders.Left, style);

            if (style.Position.Contains(BorderPosition.Right))
                setBorder(table.Borders.Right, style);

        }
        public void ApplyStyle(Row row)
        {
            if (style.Position.Contains(BorderPosition.All))
                style.Position = allBorders;

            if (style.Position.Contains(BorderPosition.Bottom))
                setBorder(row.Borders.Bottom, style);

            if (style.Position.Contains(BorderPosition.Top))
                setBorder(row.Borders.Top, style);

            if (style.Position.Contains(BorderPosition.Left))
                setBorder(row.Borders.Left, style);

            if (style.Position.Contains(BorderPosition.Right))
                setBorder(row.Borders.Right, style);

        }
        public override void ApplyStyle(Cell cell)
        {
            if (style.Position.Contains(BorderPosition.All))
                style.Position = allBorders;

            if (style.Position.Contains(BorderPosition.Bottom))
                setBorder(cell.Borders.Bottom, style);

            if (style.Position.Contains(BorderPosition.Top))
                setBorder(cell.Borders.Top, style);

            if (style.Position.Contains(BorderPosition.Left))
                setBorder(cell.Borders.Left, style);

            if (style.Position.Contains(BorderPosition.Right))
                setBorder(cell.Borders.Right, style);


        } 

        private void setBorder(MigraDoc.DocumentObjectModel.Border border, Border borderStyle)
        {
            if (borderStyle.Style == Models.BorderStyle.Solid)
            {
                border.Visible = true;
                border.Width = .1;
                border.Color = Color.FromRgb(style.Color.R, style.Color.G, style.Color.B);
            }
            else
            {
                border.Visible = false;
                border.Color = Color.FromArgb(0, 0, 0, 0);
                border.Width = 0;

            }

        }


        public override void ApplyStyle(FormattedText text)
        {
            NoOp();
        }
    }
}