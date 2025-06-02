using System;

class Latihan
{
    static void Main()
    {
        Console.Write("Masukkan nilai: ");
        int a = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= a; i++)
        {
            string printer = "";

            if (i % 3 == 0) printer += "foo";
            if (i % 4 == 0) printer += "baz";
            if (i % 5 == 0) printer += "bar";
            if (i % 7 == 0) printer += "jazz";
            if (i % 9 == 0) printer += "huzz";
            System.Console.Write((printer == "" ? i.ToString() : printer ) + " ");
        }

    }
}
