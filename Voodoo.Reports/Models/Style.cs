using MigraDoc.DocumentObjectModel;
using System.Linq;
using Color = System.Drawing.Color;

namespace Voodoo.Reports.Models
{
    public abstract class Style
    {
        public bool IsHandled { get; set; }
    }

    public enum Alignment
    {
        Left = 1,
        Center = 2,
        Right = 3,
        Justified = 4
    }

    public class Align : Style
    {
        public Alignment Alignment { get; set; }
    }

    public enum VerticleAlignment
    {
        Top = 0,
        Center = 1,
        Bottom = 2
    }
    public class VAlign : Style
    {
        public VerticleAlignment VerticleAlignment { get; set; } = VerticleAlignment.Center;
    }

    

    public class Bold : Style
    {
    }

    public class Italics : Style
    {
    }

    public class Underline : Style
    {
    }

    public class ForeColor : Style
    {
        public Color Color { get; set; }
    }

    public class BackColor : Style
    {
        public Color Color { get; set; }
    }

    public class BigFont : Style
    {
    }

    public class FontSize : Style
    {
        public double Size { get; set; }
    }

    public class FontFamily : Style
    {
        public string Name { get; set; }
    }

    public class Border : Style
    {
        public BorderPosition[] Position { get; set; }
        public Color Color { get; set; } = Color.Black;
        public BorderStyle Style { get; set; } = BorderStyle.Solid;

        public override string ToString()
        {
            var positions = Position.Select(c => c.ToString()).ToArray();
            return $"{Style} {Color} {string.Join(" ", positions)}";
        }
    }

    public enum BorderStyle
    {
        None = 0,
        Solid = 1,
        Bold =2

    }

    public enum BorderPosition
    {
        All = 0,
        Left,
        Right,
        Top,
        Bottom
    }
}