using CustomLogger.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger.Layouts.Models
{
    public class SimpleLayout : ILayout
    {
        public string LayoutFormat => "{0} - {1} - {2}";
    }
}