using System.Reflection.Metadata.Ecma335;

namespace _04.WildFarm
{
    public class Program
    {
        private static object cantinue;

        static void Main(string[] args)
        {
            try
            {
                List<Animal> animals = new List<Animal>();
                List<Food> foods = new List<Food>();
                string command;
                int i = 0;
                while ((command=Console.ReadLine())!="End")
                {
                    Animal animal = ProcessAnimal(command);
                    Food food = ProcessFood();
                    if (animal is null || food is null) continue;
                    animal.ProduseSoind();
                    if (animal.CanEatFood(food))
                    {
                        animal.GainWeight();
                    }
                    else
                    {
                        Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
                    }

                    animals.Add(animal);

                }
                foreach (var a in animals)
                {

                    Console.WriteLine(a.ToString());

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
        static Animal ProcessAnimal(string command)
        {
            
            string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = data[0];
            string name = data[1];
            double weight = double.Parse(data[2]);

            Animal? animal = type switch
            {
                "Hen" => new Hen(name, weight, double.Parse(data[3])),
                "Owl" => new Owl(name, weight, double.Parse(data[3])),
                "Mouse" => new Mouse(name, weight, data[3]),
                "Dog" => new Dog(name, weight, data[3]),
                "Cat" => new Cat(name, weight, data[3], data[4]),
                "Tiger" => new Tiger(name, weight, data[3], data[4]),
                _ => throw new InvalidOperationException("Invalid animal")
            };
            return animal;
 
        }

            
        
        static Food ProcessFood()
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string food = data[0];
            
            int amount = int.Parse(data[1]);
           
            Food? _food = food switch
            {
                "Vegetable" => new Vegetable { Quantity=amount },
                "Meat" => new Meat { Quantity=amount },
                "Fruit" => new Fruit { Quantity=amount },
                "Seed" => new Seeds { Quantity=amount },
                _ => throw new InvalidOperationException("Invalid Input")
            };
            return _food;
        }
    }
}