using System;

namespace P02.Graphic_Editor
{
    internal class Program
    {
        private static void Main()
        {
            GraphicEditor editor = new GraphicEditor();
            Rectangle rec = new Rectangle();
            Square sq = new Square();
            Circle ci = new Circle();

            editor.Draw(rec);
            editor.Draw(sq);
            editor.Draw(ci);
        }
    }
}