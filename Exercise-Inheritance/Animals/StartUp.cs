using System;

namespace Animals;

public class StartUp
{
    public static void Main(string[] args)
    {
        string animalType;
        while ((animalType=Console.ReadLine())!="Beast!")
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = data[0];
            int age = int.Parse(data[1]);
            string gender = data[2];

            try
            {
                if (animalType==nameof(Dog))
                {
                    Dog dog = new Dog(name, age, gender);
                    Console.WriteLine(dog);
                }
                else if (animalType==nameof(Cat))
                {
                    Cat cat = new Cat(name, age, gender);
                    Console.WriteLine(cat);
                }
                else if (animalType==nameof(Frog))
                {
                    Frog frog = new Frog(name, age, gender);
                    Console.WriteLine(frog);
                }
                else if (animalType==nameof(Kitten))
                {
                    Kitten kitten = new Kitten(name, age);
                    Console.WriteLine(kitten);
                }
                else if (animalType==nameof(Tomcat))
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    Console.WriteLine(tomcat);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);


            }

        }
    }
}
