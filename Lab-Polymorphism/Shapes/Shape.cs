﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
   public  abstract class Shape
    {
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();
        public virtual string Draw() =>
            "Drawing ";
    }
}
