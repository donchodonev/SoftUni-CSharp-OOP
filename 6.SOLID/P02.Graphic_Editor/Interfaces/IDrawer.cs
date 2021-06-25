using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Interfaces
{
    public interface IDrawer
    {
        public void Draw(IShape shape);

        public bool IsMatching(IShape shape);
    }
}