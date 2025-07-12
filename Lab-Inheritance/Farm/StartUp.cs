namespace Farm;

public class StartUp
{
    public static void Main()
    {
        
        Dog dog=new Dog(); ;
        dog.Bark();
        dog.Eat();
        Puppy puppy=new Puppy();
        Console.WriteLine();
        puppy.Bark();
        puppy.Eat();
        puppy.Weep();

        Console.WriteLine("----");
        Cat cat = new Cat();
        cat.Eat();
         cat.Meow();
    }
}
