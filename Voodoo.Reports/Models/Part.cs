using System;
using System.Collections.Generic;
using System.Linq;

namespace Voodoo.Reports.Models
{
    public abstract class Part
    {
        public Report Report
        {
            get
            {
                //TODO: cache?
                var target = this;

                while (target != null)
                {
                    var report = target as Report;
                    if (report != null)
                        return report;

                    target = target.Parent;
                }
                return null;
            }
        }
        internal Part()
        {

        }
        public Part Parent { get; set; }
        internal List<Style> Styles { get; set; } = new List<Style>();

        internal List<Style> ExcludedStyles { get; set; } = new List<Style>();
        protected bool ContainsType(List<Style> collection, Style style)
        {
            var type = style.GetType();
            if (style.GetType() == typeof(Border))
            {
                var border = style as Border;
                var position = border.Position.First();
                return collection.Any(c => c is Border && ((Border)c).Position.Contains(position));
            }
            else
            { 
            return collection.Any(i => i.GetType() == type);
            }
        }
        public List<Style> GetCalculatedStyles()
        {
            breakUpBorders();
            var styles = new List<Style>();

            var excluded = this.ExcludedStyles;
            var target = this;

            while (target != null)
            {
                var targetStyles = target.Styles;
                foreach (var style in targetStyles)
                {
                    if (!ContainsType(ExcludedStyles, style))
                    {
                        styles.Add(style);
                    }
                }
                target = target.Parent;
                if (target != null)
                    excluded.AddRange(target.ExcludedStyles);
            }
            return styles;
        }

        private void breakUpBorders()
        {
            Styles = unpackBordersIfNeeded(Styles);
            ExcludedStyles = unpackBordersIfNeeded(ExcludedStyles);
        }

        private List<Style> unpackBordersIfNeeded(List<Style> packed)
        {
            var styles = new List<Style>();
            foreach (var style in packed)
            {
                if (style is Border)
                {
                    var border = style as Border;
                    var positions = border.Position;
                    if (positions.Any(c => c == BorderPosition.All))
                        positions = new BorderPosition[] { BorderPosition.Bottom, BorderPosition.Top, BorderPosition.Left, BorderPosition.Right };
                    foreach (var postion in border.Position)
                    {
                        styles.Add(new Border {Position = new BorderPosition[] { postion }, Color = border.Color, Style = border.Style});
                    }
                }
                else
                {
                    styles.Add(style);
                }
            }
            return styles;
        }

        internal virtual void HandlePrerendingTasks()
        { }
        public object NativeObject { get; set; }
        


    }
    public interface ITabularObject
    {
         Cell[] GetAllCells();
    }
}