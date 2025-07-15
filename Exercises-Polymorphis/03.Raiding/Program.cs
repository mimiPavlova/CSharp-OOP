namespace _03.Raiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero>heroes = new List<BaseHero>();
            int n=int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string role=Console.ReadLine();
                BaseHero? hero = role switch
                {
                    "Druid" => new Druid(name),
                    "Paladin" => new Paladin(name),
                    "Rogue" => new Rogue(name),
                    "Warrior" => new Warrior(name),
                    _ => null
                };
                if(hero is null)
                {
                    Console.WriteLine("Invalid hero!");
                    i--; continue;

                }
                else
                {
                  heroes.Add(hero);
                }
                    
            }
            int bossPower=int.Parse(Console.ReadLine());

            int tottalPower = 0;
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                tottalPower+=hero.Power;
            }
            if(tottalPower>= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
