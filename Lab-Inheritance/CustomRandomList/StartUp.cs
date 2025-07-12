namespace CustomRandomList
{
    public  class StartUp
    {
        public static void Main()
        {
           RandomList list = new RandomList();
            list.Add("Hello,");
            list.Add("Word!");
            Console.WriteLine(list.RandomString());
        }
    }
}
