enum Months
{
    January, February, March, April, May, June,
    July, August, September, October, November, December
}
public enum LargeValues : long
{
    Small = 1,
    Medium = 10000000000L,
    Large = long.MaxValue
}

class Program
{
    static void Main()
    {
        Months bulanIni = Months.May;
        Console.WriteLine(bulanIni);

        Months myBirthMonth = Months.September;
        Console.WriteLine(myBirthMonth);

        Months January = Months.January;
        bool isJanuary = (January == Months.January);
        Console.WriteLine(isJanuary);

        long myValue = (long)LargeValues.Large;
        Console.WriteLine(myValue);
        
    }
}