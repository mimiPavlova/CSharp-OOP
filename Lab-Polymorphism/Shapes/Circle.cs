using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes;

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius=radius;
    }

    public override double CalculateArea()
        =>Math.PI * radius*radius;


    public override double CalculatePerimeter()
    => 2*Math.PI * radius;

    public override string Draw()
    {
        return base.Draw()+this.GetType().Name;
    }
}
