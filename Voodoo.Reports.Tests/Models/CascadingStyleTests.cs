﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voodoo.Reports.Models;

namespace Voodoo.Reports.Tests.Models
{
    [TestClass]
    public class CascadingStyleTests
    {
        [TestMethod]
        public void ParentIsBold_NotExcluded_IsBold()
        {
            var section = new Section();
            section.Bold();
            var table = section.AddTable();
            var hasBold = table.GetCalculatedStyles().Any(c => c is Bold);
            Assert.IsTrue(hasBold);
        }

        [TestMethod]
        public void ParentIsBold_Excluded_IsBold()
        {
            var section = new Section();
            section.Bold();
            var table = section.AddTable();
            table.NotBold();
            var hasBold = table.GetCalculatedStyles().Any(c => c is Bold);
            Assert.IsFalse(hasBold);
        }
    }
}