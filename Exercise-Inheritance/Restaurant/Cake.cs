using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant;

public class Cake : Dessert
{
    private const decimal _prise= 5;
    private const double _grams = 250;
    private const double _calories = 1000;
    public Cake(string name) : base(name, _prise, _grams, _calories)
    {
    }
}
