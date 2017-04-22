using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;
using Border = Voodoo.Reports.Models.Border;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;
using Style = Voodoo.Reports.Models.Style;
using Underline = Voodoo.Reports.Models.Underline;

namespace Voodoo.Reports.Adapters.ClosedXmls.Styles
{
    public static class StyleFactory
    {


        public static StyleHandler GetHandler<T>(T style)
            where T : Style
        {
            var type = typeof(T);
            var align = style as Align;
            if (align != null)
                return new AlignHandler(align);
            var bold = style as Bold;
            if (bold != null)
                return new BoldHandler(bold);
            var underline = style as Underline;
            if (underline != null)
                return new UnderlineHandler(underline);
            var color = style as ForeColor;
            if (color != null)
                return new ForeColorHandler(color);
            var backColor = style as BackColor;
            if (backColor != null)
                return new BackColorHandler(backColor);
            var size = style as FontSize;
            if (size != null)
                return new FontSizeHandler(size);
            var family = style as FontFamily;
            if (family != null)
                return new FontFamilyHandler(family);
            var border = style as Border;
            if (border != null)
                return new BordernHandler(border);

            return null;
        }


    }

    public class FontFamilyHandler : StyleHandler
    {
        private FontFamily style;

        public FontFamilyHandler(FontFamily style)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {

        }

        public override void ApplyStyle(Paragraph text)
        {

        }
    }

    public class FontSizeHandler : StyleHandler
    {
        private FontSize style;

        public FontSizeHandler(FontSize style)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {

        }
        public override void ApplyStyle(Paragraph text)
        {

        }
    }

    public class BackColorHandler : StyleHandler
    {
        private BackColor style;

        public BackColorHandler(BackColor style)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {

        }
        public override void ApplyStyle(Paragraph text)
        {

        }
    }

    public class ForeColorHandler : StyleHandler
    {
        private ForeColor style;

        public ForeColorHandler(ForeColor style)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {

        }

        public override void ApplyStyle(Paragraph text)
        {
           
        }
    }

  

    public class UnderlineHandler : StyleHandler
    {
        private Underline style;

        public UnderlineHandler(Underline style)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {

        }
        public override void ApplyStyle(Paragraph text)
        {

        }
    }

    public class BoldHandler : StyleHandler
    {
        private Bold style;

        public BoldHandler(Bold style)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {

        }
        public override void ApplyStyle(Paragraph text)
        {

        }
    }

    internal class AlignHandler : StyleHandler
    {
        private Align style;

        public AlignHandler(Align style)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {

        }
        public override void ApplyStyle(Paragraph text)
        {

        }
    }

    internal class BordernHandler : StyleHandler
    {
        private Border style;

        public BordernHandler(Border style)
        {
            this.style = style;
        }

        public override void ApplyStyle(Cell cell)
        {

        }
        public override void ApplyStyle(Paragraph text)
        {

        }
    }

    public abstract class StyleHandler
    {
        public abstract void ApplyStyle(MigraDoc.DocumentObjectModel.Tables.Cell cell);
        public abstract void ApplyStyle(Paragraph text);
    }
}
