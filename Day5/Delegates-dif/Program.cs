/*class Program
{
    public delegate int myNumber(int num1, int num2, int num3);
    public static int averageData(int x, int y, int z) => (x + y + z) / 3;
    public static void Main()
    {
        // CREATE A DELEGATE STATIC
        myNumber c = averageData;
        Console.Write(c(24, 35, 37));
    }
} */


/*class Program
{
    public delegate int Transformer(int y);

    public int Square(int y) => 2 * y;

    static void Main()
    {
        // CREATE A DELEGATE INSTANCE
        Program prog = new Program();
        Transformer t = prog.Square;
        Console.WriteLine(t(5)); 
    }
}
*/


/*
class Program
{
    delegate void Morn(string message);
    public static void saySomething(string message) => Console.WriteLine(message);
    static void Main()
    {
        Morn a = saySomething;
        a("Good Luck"); 
    }
}
*/



