﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals;

public class Dog:Animal
{
    public Dog(string name, string food) : base(name, food)
    {
    }

    public override string ExplainSelf()
    => base.ExplainSelf()+"DJAAF";
}
