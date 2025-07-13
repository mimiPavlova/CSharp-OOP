using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBoxDataм
{
    public class Box
    {
        public double Length {  get; set; }
        public double Width {  get; set; }
        public double Height { get; set; }

        public Box(double l, double w, double h) 
        {
            if(l <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");

            }
            Length = l;
            if(w <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            Width = w;
            if(h <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            Height = h;

        }
        public double SurfaceArea()
        => 2*Length*Width + 2*Length*Height + 2*Width*Height;

        public double LateralSurfaceArea()
            => 2*Length*Height+2*Width*Height;

        public double Volume()
            => Length*Width*Height;
    }
}
