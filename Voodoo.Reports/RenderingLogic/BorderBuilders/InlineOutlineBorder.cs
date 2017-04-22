using System;
using System.Drawing;
using Voodoo.Reports.RenderingLogic;

namespace Voodoo.Reports.Models
{
    public abstract class OutlineInlineBorder
    {
        public Color Color { get; set; }
        public BorderStyle BorderStyle { get; set; }
        public Cell[] Cells { get; set; }
        public abstract InnerOuter InnerOuter { get; }
    }

    public class OuterBorder: OutlineInlineBorder
    {
        public override InnerOuter InnerOuter => InnerOuter.Outer;
    }
    public class InnerBorder : OutlineInlineBorder
    {
        public override InnerOuter InnerOuter => InnerOuter.Inner;
    }
    public enum InnerOuter
    {
        Inner = 1,
        Outer = 2
    }
}