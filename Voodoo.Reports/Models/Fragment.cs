namespace Voodoo.Reports.Models
{
    public class Fragment : Part
    {
        internal int StartIndex { get; set; }
        internal int Length => Text.To<string>().Length;
        public Cell Cell => Parent as Cell;
        public bool IsPageNumber { get; set; }
        public bool IsNumberOfPages { get; set; }

        private string _text;
        public string Text
        {
            get
            {
                if (Value != null)
                {
                    if (FormatString != null)
                        return string.Format("{0:"+FormatString+"}", Value);
                    return Value.ToString();
                }
                if (_text == null)
                    return string.Empty;
                return _text;
            }
            set { _text = value; }
        }
        public object Value { get; set; }
        /// <summary>
        /// Formats the value, if exporting to excel will be embeded in the cell as a format.  Note that not all .net format strings will work as expected in excedl
        /// </summary>
        public string FormatString { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}