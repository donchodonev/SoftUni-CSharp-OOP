using P02.Graphic_Editor.Interfaces;
using P02.Graphic_Editor.Models.Drawers;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        private List<IDrawer> drawers;

        public GraphicEditor()
        {
            this.drawers = new List<IDrawer>()
            {
                new CircleDrawer(),
                new RectangleDrawer(),
                new SquareDrawer(),
                new IParalelepipedDrawer()
        };
        }

        public void Draw(IShape shape)
        {
            foreach (var drawer in drawers)
            {
                if (drawer.IsMatching(shape))
                {
                    drawer.Draw(shape);
                }
            }
        }
    }
}