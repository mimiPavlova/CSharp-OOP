using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant;

public class Beverage : Product
{
    double Milliliters {  get; set; }
    public Beverage(string name, decimal prise, double milliliters) : base(name, prise)
    {
        Milliliters = milliliters;
    }
}
