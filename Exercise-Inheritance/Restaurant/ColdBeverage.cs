﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant;

public class ColdBeverage : Beverage
{
    public ColdBeverage(string name, decimal prise, double milliliters) : base(name, prise, milliliters)
    {
    }
}
