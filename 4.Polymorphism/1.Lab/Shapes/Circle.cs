using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        private double Radius { get; set; }
        public override double CalculateArea()
        {
            return Math.PI * (Radius * Radius); 
        }

        public override double CalculatePerimeter()
        {
            return (2D * Radius) * Math.PI;
        }
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
