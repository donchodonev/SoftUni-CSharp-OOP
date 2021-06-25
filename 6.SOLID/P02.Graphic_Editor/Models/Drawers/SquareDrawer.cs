using P02.Graphic_Editor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Models.Drawers
{
    internal class SquareDrawer : IDrawer
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("Drawing square");
        }

        public bool IsMatching(IShape shape)
        {
            return shape is Square;
        }
    }
}