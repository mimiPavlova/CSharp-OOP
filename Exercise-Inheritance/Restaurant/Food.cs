﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant;


public class Food : Product
{

    public double Grams { get; set; }
    public Food(string name, decimal prise, double grams) : base(name, prise)
    {
        Grams = grams;
    }


}
