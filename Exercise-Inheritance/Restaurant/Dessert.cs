﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant;


public class Dessert : Food
{
    public double Calories { get; set; }
    public Dessert(string name, decimal prise, double grams, double calories) : base(name, prise, grams)
    {
        Calories=calories;
    }
}
