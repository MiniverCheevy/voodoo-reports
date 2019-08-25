using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voodoo.Reports.Models;

namespace Voodoo.Reports.Tests.Formatting
{
    [TestClass]
    public class DefaultFormatStringTests
    {
        public DefaultCellFormatOptions options = new DefaultCellFormatOptions();

        [TestMethod]
        public void IntFormatOptionsTests()
        {
            var value = 1;
            var formatted = value.ToString(options.IntFormatOptions.FormatString);
            formatted.Should().Be("1");
            value = 1000;
            formatted = value.ToString(options.IntFormatOptions.FormatString);
            formatted.Should().Be("1,000");
            value = 1000000;
            formatted = value.ToString(options.IntFormatOptions.FormatString);
            formatted.Should().Be("1,000,000");

            var fragment = new Fragment { FormatString = options.IntFormatOptions.FormatString, Value = value };
            fragment.Text.Should().Be("1,000,000");
        }

        [TestMethod]
        public void DecimalFormatOptionsTests()
        {
            var value = 1;
            var formatted = value.ToString(options.DecimalFormatOptions.FormatString);
            formatted.Should().Be("1.00");
            value = 1000;
            formatted = value.ToString(options.DecimalFormatOptions.FormatString);
            formatted.Should().Be("1,000.00");
            value = 1000000;
            formatted = value.ToString(options.DecimalFormatOptions.FormatString);
            formatted.Should().Be("1,000,000.00");
        }
        [TestMethod]
        public void CurrencyFormatOptionsTests()
        {
            var value = 1;
            var formatted = value.ToString(options.CurrencyFormatOptions.FormatString);
            formatted.Should().Be("$1.00");
            value = 1000;
            formatted = value.ToString(options.CurrencyFormatOptions.FormatString);
            formatted.Should().Be("$1,000.00");
            value = 1000000;
            formatted = value.ToString(options.CurrencyFormatOptions.FormatString);
            formatted.Should().Be("$1,000,000.00");
        }

        [TestMethod]
        public void PercentFormatOptionsTests()
        {
            var value = 1;
            var formatted = value.ToString(options.PercentFormatOptions.FormatString);
            formatted.Should().Be("100.00%");
            value = 1000;
            formatted = value.ToString(options.PercentFormatOptions.FormatString);
            formatted.Should().Be("100,000.00%");
            value = 1000000;
            formatted = value.ToString(options.PercentFormatOptions.FormatString);
            formatted.Should().Be("100,000,000.00%");
        }

        [TestMethod]
        public void DateFormatOptionsTests()
        {
            var value = "1/1/1970".To<DateTime>();
            var formatted = value.ToString(options.DateFormatOptions.FormatString);
            formatted.Should().Be("01/01/70");
            
        }

        [TestMethod]
        public void TimeFormatOptionsTests()
        {
            var value = "1/1/1970 1:14:15 PM".To<DateTime>();
            var formatted = value.ToString(options.TimeFormatOptions.FormatString);
            formatted.Should().Be("13:14:15");

        }


        [TestMethod]
        public void DateTimeFormatOptionsTests()
        {
            var value = "1/1/1970 13:14:15".To<DateTime>();
            var formatted = value.ToString(options.DateTimeFormatOptions.FormatString);
            formatted.Should().Be("01/01/70 13:14:15");

        }
    }
}
