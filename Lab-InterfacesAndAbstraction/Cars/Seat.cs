using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars;

public class Seat:ICar
{
    public Seat(string model, string color)
    {
        this.Model= model;
        this.Color= color;
    }

    public string Model { get; set; }
    public string Color { get; set; }

    public string Start()
    {
        throw new NotImplementedException();
    }

    public string Stop()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    => $"{Color} Seat {Model}";
}
