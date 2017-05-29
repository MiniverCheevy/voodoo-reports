using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voodoo.Reports
{
    public class RenderOptions
    {
        public RenderOptions()
        {
            Excel = new ExcelRenderOptions();
            Pdf = new PdfRenderOptions();
            Csv = new CsvRenderOptions();
            Html = new HtmlRenderOptions();
        }

        public ExcelRenderOptions Excel { get; private set; }
        public PdfRenderOptions Pdf { get; private set; }
        public CsvRenderOptions Csv { get; private set; }
        public HtmlRenderOptions Html { get; private set; }
    }

    public class ExcelRenderOptions
    {
        //public bool RenderEachTableInADifferentWorksheet { get; set; }

        public int VerticleUnitsPerInch { get; set; } = 90;
        public int HorizontalUnitsPerInch { get; set; } = 20;
    }

    public enum ExcelNoBorderOptions
    {
        Thin = 1,
        None = 2
    }

    public class PdfRenderOptions
    {
    }

    public class CsvRenderOptions
    {
        public bool IncludeHeaders { get; set; } = true;
    }

    public class HtmlRenderOptions
    {
        public string CssHref { get; set; }
        public string TableCssClass { get; set; }
        public string TableHeaderCssClass { get; set; }
        public string TableRowCssClass { get; set; }
        public string TableCellCssClass { get; set; }
    }
}