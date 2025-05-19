// See https://aka.ms/new-console-template for more information

public class NumberGenerator
{
    public int number;

    public int GetNumber()
    {
        return number;
    }

    public void SetNumber(int value)
    {
        number = value;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        NumberGenerator generator = new NumberGenerator();
        generator.SetNumber(42);

        int number = generator.GetNumber();
        Console.WriteLine(number);
    }
}
