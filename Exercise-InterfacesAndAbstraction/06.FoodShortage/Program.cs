namespace _06.FoodShortage;

internal class Program
{
    static void Main(string[] args)
    {
        int n=int.Parse(Console.ReadLine());
       Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (data.Length==4)
            {
                IBuyer buyer = new Human(data[0], data[2], int.Parse(data[1]), data[3]);
                buyers.Add(data[0], buyer);
            }
            else if (data.Length==3)
            {
                IBuyer buyer = new Rebel(data[0], int.Parse(data[1]), data[2]);
                buyers.Add(data[0], buyer);
            }
        }
        string command;
        while ((command=Console.ReadLine())!="End")
        {
            if (!buyers.ContainsKey(command)) continue;
            buyers[command].BuyFood();
        }
        int foodTotalAmount=buyers.Values.Sum(f=>f.Food);
        Console.WriteLine(foodTotalAmount);
    }

}