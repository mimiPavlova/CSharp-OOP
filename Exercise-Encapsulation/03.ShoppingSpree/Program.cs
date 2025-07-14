namespace _03.ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Dictionary<string, Person> people = ReadPeople().ToDictionary(x => x.Name);

                Dictionary<string, Product> products = ReadProducts().ToDictionary(x => x.Name);

                ProcessCommand(people, products);
                PrintOutput(people);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static Person[] ReadPeople()
        {
            string[] peopleData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            Person[] people = new Person[peopleData.Length];
            for (int i = 0; i < peopleData.Length; i++)
            {

                string[] personData = peopleData[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = personData[0];
                double money = double.Parse(personData[1]);
                Person person = new Person(name, money);
                people[i] =person;
            }
            return people;
        }

        static Product[] ReadProducts()
        {
            string[] productsData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            Product[] products = new Product[productsData.Length];
            for (int i = 0; i < productsData.Length; i++)
            {

                string[] productData = productsData[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string productName = productData[0];
                double cost = double.Parse(productData[1]);

                Product product = new Product(productName, cost);
                products[i]=product;
            }
            return products;

        }
        static void ProcessCommand(Dictionary<string, Person> people, Dictionary<string, Product> products)
        {
            string command;
            while ((command=Console.ReadLine())!="END")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                string product = data[1];

                if (!products.ContainsKey(product)||!people.ContainsKey(name))
                {
                    continue;
                }
                people[name].Buy(products[product]);

            }
        }
        static void PrintOutput(Dictionary<string, Person> people)
        {
            foreach (Person p in people.Values)
            {
                if (p.Products.Count==0)
                {
                    Console.WriteLine($"{p.Name} - Nothing bought");
                }
                else
                {

                    Console.WriteLine($"{p.Name} - {string.Join(", ", p.Products.Select(pr => pr.Name))}");


                }
            }

        }
    }
}
