using System;
using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using Voodoo.Reports.Models;

namespace Voodoo.Reports.Adapters.ClosedXml.Styles
{
    public abstract class StyleHandler
    {
        protected Report report;
        public abstract void ApplyStyle(IXLCell cell, Fragment fragment = null);

        protected StyleHandler(Report report)
        {
            this.report = report;
        }

        /// <summary>
        /// Does not apply, do nothing
        /// </summary>
        public void NoOp()
        {
        }
    }
}