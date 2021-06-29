using CustomLogger.Layouts.Interfaces;

namespace CustomLogger.Layouts.Models
{
    public class XMLLayout : ILayout
    {
        public string LayoutFormat =>
@"<log>
     <date>{0}</date>
     <level>{1}</level>
     <message>{2}</message>
</log>";
    }
}