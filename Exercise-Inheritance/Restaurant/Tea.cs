﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant;

public class Tea : HotBeverage
{
    public Tea(string name, decimal prise, double milliliters) : base(name, prise, milliliters)
    {
    }
}
