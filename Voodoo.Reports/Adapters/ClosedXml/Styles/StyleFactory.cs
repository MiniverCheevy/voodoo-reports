using Voodoo.Reports.Models;
using Style = Voodoo.Reports.Models.Style;
using Underline = Voodoo.Reports.Models.Underline;

namespace Voodoo.Reports.Adapters.ClosedXml.Styles
{
    public static class StyleFactory
    {
        //TODO: DI this?
        public static StyleHandler GetHandler<T>(T style, Report report)
            where T : Style
        {
            var type = typeof(T);
            var align = style as Align;
            if (align != null)
                return new AlignHandler(align, report);
            var vAlign = style as VAlign;
            if (vAlign != null)
                return new VerticalAlignHandler(vAlign, report);
            var bold = style as Bold;
            if (bold != null)
                return new BoldHandler(bold, report);
            var italics = style as Italics;
            if (italics != null)
                return new ItalicsHandler(italics, report);
            var underline = style as Underline;
            if (underline != null)
                return new UnderlineHandler(underline, report);
            var color = style as ForeColor;
            if (color != null)
                return new ForeColorHandler(color, report);
            var backColor = style as BackColor;
            if (backColor != null)
                return new BackColorHandler(backColor, report);
            var bigFont = style as BigFont;
            if (bigFont != null)
                return new BigFontHandler(bigFont, report);
            var size = style as FontSize;
            if (size != null)
                return new FontSizeHandler(size, report);
            var family = style as FontFamily;
            if (family != null)
                return new FontFamilyHandler(family, report);
            var border = style as Border;
            if (border != null)
                return new BorderHandler(border, report);

            throw new System.Exception($"No style handler found for {style.GetType().Name}");
        }
    }
}