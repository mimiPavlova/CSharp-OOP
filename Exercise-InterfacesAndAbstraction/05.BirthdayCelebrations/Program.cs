using System.Net.Http.Headers;

namespace _05.BirthdayCelebrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ICitizen> citizens = new List<ICitizen>();
            List<IBirthdate>birthdates = new List<IBirthdate>();
            string command;
            while ((command=Console.ReadLine())!="End")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (data[0]=="Citizen")
                {
                   IBirthdate person = new Human(data[1], int.Parse(data[2]), data[3], data[4]);

                    birthdates.Add(person);
                }
                else if (data[0]=="Robot")
                {
                    ICitizen robot = new Robot(data[1], data[2]);
                    citizens.Add(robot);
                }
                else if (data[0]=="Pet")
                {
                    Pet pet = new Pet(data[1], data[2]);
                    birthdates.Add (pet);
                }
                else { continue; }
            }
            string year = Console.ReadLine();



            foreach (var c in birthdates)
            {
                if (c.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(c.Birthdate);
                }
            }

        }
    }
}
