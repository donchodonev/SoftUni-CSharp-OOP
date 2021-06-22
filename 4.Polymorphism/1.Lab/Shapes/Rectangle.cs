using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        private double Height { get; set; }
        private double Width { get; set; }
        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
            return (2D * Height) + (2D * Width);
        }
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
