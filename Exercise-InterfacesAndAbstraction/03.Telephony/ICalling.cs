﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public interface ICalling
    {
        string Number { get; set; }
       void Call();
    }
}
