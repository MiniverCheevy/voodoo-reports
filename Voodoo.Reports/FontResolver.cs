using Didstopia.PDFSharp.Fonts;
using SixLabors.Fonts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Voodoo.Reports
{
    public class FontResolver : IFontResolver
    {
        private class AvailableFontStyle
        {
            public bool IsBold { get; set; }
            public bool IsItalics { get; set; }

        }
        private FontCollection fonts;
        public Dictionary<string, string> FontMap { get; private set; } = new Dictionary<string, string>();
        public FontResolver()
        {

            var fontRoot = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            fonts = new FontCollection();
            foreach (var file in System.IO.Directory.GetFiles(fontRoot))
            {
                if (System.IO.Path.GetExtension(file).ToLower() == ".ttf")
                {
                    var font = fonts.Install(file);
                    var styles = new List<AvailableFontStyle>() { new AvailableFontStyle()};
                    foreach (var style in font.AvailableStyles)
                    {
                        if (style == FontStyle.Bold)
                            styles.Add(new AvailableFontStyle { IsBold = true });
                        if (style == FontStyle.Italic)
                            styles.Add(new AvailableFontStyle { IsItalics = true });
                        if (style == FontStyle.BoldItalic)
                        {
                            styles.Add(new AvailableFontStyle { IsItalics = true });
                            styles.Add(new AvailableFontStyle { IsBold = true });
                            styles.Add(new AvailableFontStyle { IsBold = true, IsItalics = true });
                        }

                    }
                    foreach (var style in styles)
                    {
                        var name = getName(font.Name, style.IsBold, style.IsItalics);
                        if (!FontMap.ContainsKey(name))
                            FontMap.Add(name, file);
                    }
                }
            }

        }

        private string getName(string name, bool isBold, bool isItalics)
        {
            var boldString = isBold ? "Bold" : string.Empty;
            var italicsString = isItalics ? "Italics" : string.Empty;
            return $"{name}|{boldString}|{italicsString}";
        }

        public string DefaultFontName => "Verdana";

        public byte[] GetFont(string faceName)
        {


            if (FontMap.ContainsKey(faceName))
                return File.ReadAllBytes(FontMap[faceName]);


            throw new Exception($"Cannot find font {faceName}");

            //using (var ms = new MemoryStream())
            //{
            //    var assembly = typeof(FontResolver).GetTypeInfo().Assembly;
            //    var resourceName = assembly.GetManifestResourceNames().First(x => x.EndsWith(faceName));
            //    using (var rs = assembly.GetManifestResourceStream(resourceName))
            //    {
            //        rs.CopyTo(ms);
            //        ms.Position = 0;
            //        return ms.ToArray();
            //    }
            //}
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            fonts.TryFind(familyName, out var resolvedFont);
            resolvedFont.ThrowIfNull($"Cannot find font {familyName}");
            var name = getName(familyName, isBold, isItalic);
            return new FontResolverInfo(name);

        }
    }
}
