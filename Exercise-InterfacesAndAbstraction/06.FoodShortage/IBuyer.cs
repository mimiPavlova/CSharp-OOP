﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage
{
    public  interface IBuyer
    {
        int Food {  get;  }
        void BuyFood();
    }
}
