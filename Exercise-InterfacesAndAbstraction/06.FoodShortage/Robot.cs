using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage
{
    public class Robot : ICitizen
    {
        public string Model { get; set; }

        public string Id { get; set; }

        public Robot(string model, string id)
        {
            Model=model;
            Id=id;
        }
    }
}
