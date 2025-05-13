using System;

class Latihan
{
    static void Main()
    {
        Console.Write("masukkan nilai : ");
        int a = Convert.ToInt32(Console.ReadLine());

        for (int x = 1; x <= a; x++)
        {
            
            if (x % 3 == 0 && x % 5 == 0)
            {
                Console.WriteLine("foobar");
            }
            else if ( x % 3 == 0) 
            {
                Console.Write("foo "); //buat disatu baris sama
            }
            else if ( x % 5 == 0) 
            {
                Console.Write("bar "); 
            }
            else
            {
                Console.Write( x + " ");
            }
        }

    }
}
