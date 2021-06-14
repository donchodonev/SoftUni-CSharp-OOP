using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        private double Length
        {
            get => length;
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        private double Width
        {
            get => width;
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        private double Height
        {
            get => height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }
        public  void SurfaceArea()
        {
            double surface = 
                2 * (Length * Width)
                + 
                2 * (Length * Height) 
                + 
                2 * (Width * Height) ;

            Console.WriteLine($"Surface Area - {surface:F2}");
        }
        public void LateralSurfaceArea()
        {
            double lateralSurface =
                2 * (Length * Height)
                +
                2 * (Width * Height);

            Console.WriteLine($"Lateral Surface Area - {lateralSurface:F2}");
        }
        public void Volume()
        {
            double volume = Length * Width * Height;
            Console.WriteLine($"Volume - {volume:F2}");
        }
    }
}
