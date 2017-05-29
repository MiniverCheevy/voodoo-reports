namespace Voodoo.Reports.Models
{
    public class Fragment : Part
    {
        internal int StartIndex { get; set; }
        internal int Length => Text.To<string>().Length;
        public Cell Cell => Parent as Cell;
        public bool IsPageNumber { get; set; }
        public bool IsNumberOfPages { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}