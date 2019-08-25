using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voodoo.Reports.Models
{
    public class DefaultCellFormatOptions
    {

        public CellFormatOptions IntFormatOptions { get; set; } = new CellFormatOptions { Alignment = Alignment.Right, FormatString="#,##0" };
        public CellFormatOptions DecimalFormatOptions { get; set; } = new CellFormatOptions { Alignment = Alignment.Right, FormatString = "#,##0.00" };
        public CellFormatOptions CurrencyFormatOptions { get; set; } = new CellFormatOptions { Alignment = Alignment.Right, FormatString = "$#,##0.00" };
        public CellFormatOptions PercentFormatOptions { get; set; } = new CellFormatOptions { Alignment = Alignment.Right, FormatString = "#,##0.00%" };
        public CellFormatOptions DateFormatOptions { get; set; } = new CellFormatOptions { Alignment = Alignment.Right, FormatString = "MM/dd/yy" };
        public CellFormatOptions TimeFormatOptions { get; set; } = new CellFormatOptions { Alignment = Alignment.Right, FormatString = "HH:mm:ss" };
        public CellFormatOptions DateTimeFormatOptions { get; set; } = new CellFormatOptions { Alignment = Alignment.Right, FormatString = "MM/dd/yy HH:mm:ss" };

    }
}
