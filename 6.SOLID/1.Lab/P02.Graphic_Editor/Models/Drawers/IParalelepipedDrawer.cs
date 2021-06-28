using P02.Graphic_Editor.Interfaces;
using P02.Graphic_Editor.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Models.Drawers
{
    public class IParalelepipedDrawer : IDrawer
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("Drawing Paralelepiped");
        }

        public bool IsMatching(IShape shape)
        {
            return shape is Paralelepiped;
        }
    }
}