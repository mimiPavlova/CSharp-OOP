using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    public interface IVehicle
    {
        double Fuel {  get;  }
        double Consumption {  get;  }
        public double TankCapacity { get; }
        void Drive(double distance);
        void Refuel(double fuel);

    }
}
