namespace _01.Vehicles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] BusData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicle car = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));
            IVehicle truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));
            Bus buss = new Bus(double.Parse(BusData[1]), double.Parse(BusData[2]), double.Parse(BusData[3]));
            int n=int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                double value=double.Parse(data[2]);
                if (data[0]=="Drive")
                {
                    
                    if (data[1]=="Car")
                    {
                        car.Drive(value);
                    }
                    else if (data[1]=="Truck")
                    {
                        truck.Drive(value);
                    }
                    else if (data[1]=="Bus")
                    {
                        buss.Drive(value);
                    }
                }
                else if (data[0]=="DriveEmpty")
                {
                  
                    buss.DriveEmpty(value);
                }
                else if (data[0]=="Refuel")
                {
                
                    if (data[1]=="Car")
                    {
                        car.Refuel(value);
                    }
                    else if (data[1]=="Truck")
                    {
                        truck.Refuel(value);
                    }
                    else if (data[1]=="Bus")
                    {
                        buss.Refuel(value);
                    }
                }
            }
            Console.WriteLine($"Car: {car.Fuel:f2}");
            Console.WriteLine($"Truck: {truck.Fuel:f2}");
            Console.WriteLine($"Bus: {buss.Fuel:f2}");


        }
    }
}
