using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant;

public class Coffee : HotBeverage
{

    private const decimal _prise = 3.5m;
    private const double _mililiters = 50;
    public double Caffeine {  get; set; }
    public Coffee(string name, double coffeine) : base(name, _prise, _mililiters)
    {
        this.Caffeine = coffeine;
    }
}
