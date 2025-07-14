namespace _03.Telephony
{
  public  class Program
    {
       public  static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numbers.Length; i++)
            {
                string currentNumber = numbers[i];
                if(currentNumber.Any(n=>char.IsLetter(n)))
                {
                    Console.WriteLine("Invalid number!");continue;

                }
                if (currentNumber.Length==10)
                {
                    Smartphone smartphone=new Smartphone { Number=currentNumber};
                    smartphone.Call();
                }
                else if(currentNumber.Length==7)
                {
                    StationaryPhone stationaryphone=new StationaryPhone(currentNumber);
                    stationaryphone.Call();
                }
            }
            for (int i = 0; i < websites.Length; i++)
            {
                string currentSite = websites[i];
                if (currentSite.Any(n => char.IsDigit(n)))
                {
                    Console.WriteLine("Invalid URL!"); continue;    
                }
                Smartphone smartphone=new Smartphone {Website=currentSite};
                smartphone.Brows();
            }
        
        
        }
    }
}
