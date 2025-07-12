namespace CustomStack
{
   public  class StartUp
    {
        public static void Main()
        {
            StackOfStrings strings=new StackOfStrings();
            strings.Push("Hello,");
            strings.Push("Word!");
            strings.AddRange(new string[] { "My", "name", "is..." });

            Console.WriteLine(string.Join("\n", strings));
        }
    }
}
