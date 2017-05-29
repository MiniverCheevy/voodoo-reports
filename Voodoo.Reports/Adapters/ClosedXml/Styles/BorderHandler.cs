using System.Linq;
using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Border = Voodoo.Reports.Models.Border;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;
using Table = MigraDoc.DocumentObjectModel.Tables.Table;
using Row = MigraDoc.DocumentObjectModel.Tables.Row;
using System;

namespace Voodoo.Reports.Adapters.ClosedXml.Styles
{
    public class BorderHandler : StyleHandler
    {
        private Border style;

        private BorderPosition[] allBorders = new BorderPosition[]
            {BorderPosition.Bottom, BorderPosition.Top, BorderPosition.Left, BorderPosition.Right};

        public BorderHandler(Border border, Report report) : base(report)
        {
            this.style = border;
        }

        public void ApplyStyle(Table table)
        {
        }

        public void ApplyStyle(Row row)
        {
        }

        public override void ApplyStyle(IXLCell cell, Fragment fragment = null)
        {
            if (style.Position.Contains(BorderPosition.All))
                style.Position = allBorders;

            var cellBorder = cell.Style.Border;

            if (style.Position.Contains(BorderPosition.Bottom))
            {
                if (style.Style == Models.BorderStyle.Solid)
                {
                    cellBorder.BottomBorder = XLBorderStyleValues.Thin;
                    cellBorder.BottomBorderColor = XLColor.FromArgb(style.Color.R, style.Color.G, style.Color.B);
                }
                else
                {
                    cellBorder.BottomBorder = XLBorderStyleValues.None;
                }
            }

            if (style.Position.Contains(BorderPosition.Top))
            {
                if (style.Style == Models.BorderStyle.Solid)
                {
                    cellBorder.TopBorder = XLBorderStyleValues.Thin;
                    cellBorder.TopBorderColor = XLColor.FromArgb(style.Color.R, style.Color.G, style.Color.B);
                }
                else
                {
                    cellBorder.TopBorder = XLBorderStyleValues.None;
                }
            }

            if (style.Position.Contains(BorderPosition.Left))
            {
                if (style.Style == Models.BorderStyle.Solid)
                {
                    cellBorder.LeftBorder = XLBorderStyleValues.Thin;
                    cellBorder.LeftBorderColor = XLColor.FromArgb(style.Color.R, style.Color.G, style.Color.B);
                }
                else
                {
                    cellBorder.LeftBorder = XLBorderStyleValues.None;
                }
            }
            if (style.Position.Contains(BorderPosition.Right))
            {
                if (style.Style == Models.BorderStyle.Solid)
                {
                    cellBorder.RightBorder = XLBorderStyleValues.Thin;
                    cellBorder.RightBorderColor = XLColor.FromArgb(style.Color.R, style.Color.G, style.Color.B);
                }
                else
                {
                    cellBorder.RightBorder = XLBorderStyleValues.None;
                }
            }
        }
    }
}