namespace _04.BorderControl;

public  class Program
{
    static void Main(string[] args)
    {
        List<ICitizen>citizens = new List<ICitizen>();
        string command;
        while ((command=Console.ReadLine())!="End")
        {
            string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (data.Length ==3)
            {
                ICitizen person = new Human(data[0], int.Parse(data[1]), data[2]);
                citizens.Add(person);
            }
            else if(data.Length ==2)
            {
                ICitizen robot = new Robot(data[0], data[1]);
                citizens.Add(robot);
            }
            else { continue; }
        }
        string lastNumberOfFakeIds = Console.ReadLine();



        foreach (var c in citizens)
        {
            if (c.Id.EndsWith(lastNumberOfFakeIds))
            {
                Console.WriteLine(c.Id);
            }
        }
        
    }
}
