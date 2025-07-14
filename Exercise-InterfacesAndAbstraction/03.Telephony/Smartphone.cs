using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public string Number {  get; set; }
        public string Website { get; set; }
      
        public void Brows()
        {
            if(Website!=null) 
            Console.WriteLine($"Browsing: {Website}!");
        }

        public void Call()
        {
            if(Number!=null&&Number.Length==10)
            Console.WriteLine($"Calling... {Number}");
        }
    }
}
