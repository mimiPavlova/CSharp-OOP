using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed;

public class Vehicle
{
    private const double DefaultFuelConsumption = 1.25;

   public virtual double FuelConsumption { get; set; } =
    DefaultFuelConsumption;
     public double Fuel {  get; set; }
    public int HorsePower {  get; set; }

    public Vehicle(int horsePower, double fuel)
    {
        Fuel=fuel;
        HorsePower=horsePower;
    }
    public virtual void Drive(double kilometers)
    {
        double needetFuel=kilometers*FuelConsumption;
        if (needetFuel<=Fuel)
        {
            Fuel-=needetFuel;
        }
    }
}
