using P02.Graphic_Editor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Models.Drawers
{
    internal class CircleDrawer : IDrawer
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("Drawing circle");
        }

        public bool IsMatching(IShape drawable)
        {
            return drawable is Circle;
        }
    }
}