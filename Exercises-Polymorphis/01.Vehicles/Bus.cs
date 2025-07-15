using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles;

public class Bus : IVehicle
{
    public double increasing = 1.4;
    public double Fuel {  get; private set; }

    public double Consumption {  get; private set; }

    public double TankCapacity {  get; private set; }

    public Bus(double fuel, double consumption, double tankCapacity)
    {
        if (fuel>tankCapacity) fuel=0;
        else Fuel=fuel;
        Consumption=consumption;
        TankCapacity=tankCapacity;
    }

    public void Drive(double distance)
    {
        double neededFuel = distance*(Consumption+increasing);
        if (neededFuel >Fuel)
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        else
        {

            Fuel -= neededFuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");

        }
    }
    public void DriveEmpty(double distance)
    {
        double neededFuel = distance*Consumption;
        if (neededFuel >Fuel)
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        else
        {

            Fuel -= neededFuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");

        }
    }
    public void Refuel(double fuel)
    {
        if (fuel<=0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else if (Fuel+fuel>this.TankCapacity)
        {
            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
        }
        else
        {
            Fuel+=fuel;
        }
    }
}

