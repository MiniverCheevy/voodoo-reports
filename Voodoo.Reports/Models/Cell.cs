using System;
using System.Collections.Generic;
using System.Drawing;

namespace Voodoo.Reports.Models
{
    public class Cell : Part, ITabularObject
    {
        
        public Fragment[] Children()
        {
            return fragments.ToArray();
        }
        private List<Fragment> fragments = new List<Fragment>();
        public int Rows { get; set; } = 1;
        public int Columns { get; set; } = 1;

        public decimal Width { get; set; }
        public Fragment AddFragment(string text)
        {
            return AddFragment(new Fragment { Text = text });
        }
        public Fragment AddFragment(Fragment fragment)
        {
            fragment.Parent = this;
            this.fragments.Add(fragment);
            return fragment;
        }
        public Cell ColSpan(int colSpan)
        {
            this.Columns = colSpan;
            return this;
        }
        public Cell RowSpan(int rowSpan)
        {
            this.Rows = rowSpan;
            return this;
        }
        public Cell UseNonBreakingSpaces()
        {
            this.HasNonBreakingSpaces = true;
            return this;
        }
        public Cell[] GetAllCells()
        {
            return new Cell[] { this };
        }
        public bool HasNonBreakingSpaces { get; set; }
        public override string ToString()
        {
            return string.Join(" ", fragments);
        }
        public Row Row => Parent as Row;
    }
    public class Fragment : Part
    {

        public Cell Cell => Parent as Cell;
        public bool IsPageNumber { get; set; }
        public bool IsNumberOfPages { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
       
    }
    
    public class ImageCell
    {
        Image Image { get; set; }
    }
}