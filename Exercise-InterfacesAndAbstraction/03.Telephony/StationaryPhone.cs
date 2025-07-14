using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony;

public class StationaryPhone : ICalling
{
    public string Number { get; set; }

    public StationaryPhone(string number)
    {
        if(number!=null&&number.Length==7)
        Number=number;
    }

    public void Call()
    {
        Console.WriteLine($"Dialing... {Number}");
    }
}
