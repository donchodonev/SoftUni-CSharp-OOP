using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger.Layouts.Interfaces
{
    public interface ILayout
    {
        public string LayoutFormat { get; }
    }
}