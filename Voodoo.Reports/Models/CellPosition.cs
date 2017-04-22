namespace Voodoo.Reports.Models
{
    public struct CellPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public override string ToString()
        {
            return $"Row={Row} Column={Column}".PadRight(20);
        }
    }
}