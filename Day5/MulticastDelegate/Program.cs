/*delegate void Word(string name);

class Program
{
    public static void saySomething(string name) => Console.WriteLine($"Hai {name}");
    public static void saySomethingElse(string name) => Console.WriteLine("spirit" + name + " and Good Luck");
    public static void sayGoodbye(string name) => Console.WriteLine("Good Bye" + name);

    static void Main()
    {
        Word a = saySomething;
        a += saySomethingElse;
        a += sayGoodbye;

        //remove the first method
        a -= saySomethingElse;

        a("John");

    }

} */



class Program
{
    Action<int> operations;
    static void DoubleAndPrint(int x) => Console.WriteLine($"Double: {x * 2}");
    static void TripleAndPrint(int x) => Console.WriteLine($"Triple: {x * 3}");

    static void Main()
    {
        // Create multicast Action delegate
        Action<int> operations = DoubleAndPrint;
        operations += TripleAndPrint;  // Add another method

        // Invoke all methods in the delegate
        operations(5); 
    }
}
