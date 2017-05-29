using System;

namespace Voodoo.Reports.Adapters.ClosedXml
{
    public static class ColumnHelper
    {
        public static string GetColumnName(int columnNumber)
        {
            var dividend = columnNumber;
            var columnName = String.Empty;
            var modulo = 0;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int) ((dividend - modulo) / 26);
            }

            return columnName;
        }
    }
}