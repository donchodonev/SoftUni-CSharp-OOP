using CustomLogger.Layouts.Interfaces;

namespace CustomLogger.Layouts.Models
{
    public class SimpleLayout : ILayout
    {
        public string LayoutFormat => "{0} - {1} - {2}";
    }
}