using System;
using System.Collections.Generic;
using System.Drawing;
using Voodoo;

namespace Voodoo.Reports.Models
{
    public class Cell : Part, ITabularObject
    {
        public Fragment[] Children()
        {
            return fragments.ToArray();
        }

        private List<Fragment> fragments = new List<Fragment>();
        internal byte[] imageBytes;
        internal double? imageHeight;

        /// <summary>
        /// Related to rowspan
        /// </summary>
        public int Rows { get; set; } = 1;
        /// <summary>
        /// related to colspan
        /// </summary>
        public int Columns { get; set; } = 1;

        public decimal Width { get; set; }

        public Fragment AddFragment(string text)
        {
            return AddFragment(new Fragment {Text = text});
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
            return new Cell[] {this};
        }

        public bool HasNonBreakingSpaces { get; set; }

        public override string ToString()
        {
            return string.Join(" ", fragments);
        }

        public Row Row => Parent as Row;

        public Cell AddPageNumber()
        {
            this.AddFragment(new Fragment {IsPageNumber = true});
            return this;
        }

        public Cell AddNumberOfPages()
        {
            this.AddFragment(new Fragment {IsNumberOfPages = true});
            return this;
        }

        public Cell AddPageOfPagesString()
        {
            this.AddFragment("Page ");
            this.AddFragment(new Fragment {IsPageNumber = true});
            this.AddFragment(" Of ");
            this.AddFragment(new Fragment {IsNumberOfPages = true});
            return this;
        }

        public Cell AddImage(byte[] bytes, double? heightInInches=null)
        {
            this.imageBytes = bytes;
            this.imageHeight = heightInInches;
            return this;
        }
    }
}