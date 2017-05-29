using Voodoo.Reports.Models;
using Color = System.Drawing.Color;
using FontFamily = Voodoo.Reports.Models.FontFamily;

namespace Voodoo.Reports
{
    public static class PartExtensions
    {
        /// <summary>
        /// Only works at Cell Level or Higher
        /// </summary>
        public static T Right<T>(this T part)
            where T : Part
        {
            part.Styles.Add(new Align {Alignment = Alignment.Right});
            return part;
        }

        /// <summary>
        /// Only works at Cell Level or Higher
        /// </summary>
        public static T Center<T>(this T part)
            where T : Part
        {
            part.Styles.Add(new Align {Alignment = Alignment.Center});
            return part;
        }

        /// <summary>
        /// Only works at Cell Level or Higher
        /// </summary>
        public static T Left<T>(this T part)
            where T : Part
        {
            part.Styles.Add(new Align {Alignment = Alignment.Left});
            return part;
        }

        /// <summary>
        /// Only works at Cell Level or Higher
        /// </summary>
        public static T Justified<T>(this T part)
            where T : Part
        {
            part.Styles.Add(new Align {Alignment = Alignment.Justified});
            return part;
        }

        public static T Bold<T>(this T part)
            where T : Part
        {
            part.Styles.Add(new Bold());
            return part;
        }

        public static T Italics<T>(this T part)
            where T : Part
        {
            part.Styles.Add(new Italics());
            return part;
        }

        public static T Underline<T>(this T part)
            where T : Part
        {
            part.Styles.Add(new Underline());
            return part;
        }

        public static T ForeColor<T>(this T part, Color color)
            where T : Part
        {
            part.Styles.Add(new ForeColor() {Color = color});
            return part;
        }

        public static T BackColor<T>(this T part, Color color)
            where T : Part
        {
            part.Styles.Add(new BackColor() {Color = color});
            return part;
        }

        public static T FontSize<T>(this T part, double size)
            where T : Part
        {
            part.Styles.Add(new FontSize() {Size = size});
            return part;
        }

        public static T FontFamily<T>(this T part, string name)
            where T : Part
        {
            part.Styles.Add(new FontFamily() {Name = name});
            return part;
        }

        public static T NotBold<T>(this T part)
            where T : Part
        {
            part.ExcludedStyles.Add(new Bold());
            return part;
        }

        public static T NotItalics<T>(this T part)
            where T : Part
        {
            part.ExcludedStyles.Add(new Italics());
            return part;
        }

        public static T NotUnderline<T>(this T part)
            where T : Part
        {
            part.ExcludedStyles.Add(new Underline());
            return part;
        }

        public static T NoForeColor<T>(this T part)
            where T : Part
        {
            part.ExcludedStyles.Add(new ForeColor());
            return part;
        }

        public static T NoBackColor<T>(this T part)
            where T : Part
        {
            part.ExcludedStyles.Add(new BackColor());
            return part;
        }

        public static T NoFontSize<T>(this T part)
            where T : Part
        {
            part.ExcludedStyles.Add(new FontSize());
            return part;
        }

        public static T NoFontFamily<T>(this T part)
            where T : Part
        {
            part.ExcludedStyles.Add(new FontFamily());
            return part;
        }

        public static T NoBorder<T>(this T part, params BorderPosition[] positions)
            where T : Part
        {
            part.ExcludedStyles.Add(new Border {Position = positions});
            return part;
        }

        public static T Border<T>(this T part, params BorderPosition[] positions)
            where T : Part
        {
            part.Styles.Add(new Border {Position = positions, Color = Color.Black});
            return part;
        }

        public static T Border<T>(this T part, Color color, params BorderPosition[] positions)
            where T : Part
        {
            part.Styles.Add(new Border {Position = positions, Color = color});
            return part;
        }

        public static T Big<T>(this T part)
            where T : Part
        {
            part.Styles.Add(new BigFont());
            return part;
        }
    }
}