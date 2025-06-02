using System;
using System.Threading;

class Program
{
    static void Main()
    {

        Thread t1 = new Thread(Method);
        t1.Start();

        Thread t2 = new Thread(Method2);
        t2.Start();

        //Main thread doing something in parallel
        for (int i = 0; i < 9; i++)
        {
            System.Console.WriteLine("Main thread doing something " + i);
        }

        // thread punya propery lainnya 
        Thread t3 = new Thread(Method) { Name = "Sinta" };
        t3.Start();
        System.Console.WriteLine(Thread.CurrentThread.Name); // akan null, karena main thread tidak punya nama

        // thread properti isAlive, kalau diset sebelum start, akan false, 
        // dan akan trurn setelah thread start
        Thread t4 = new Thread(Method3) { Name = "Siti" };
        System.Console.WriteLine("Thread Siti is alive: " + t4.IsAlive);
        t4.Start();
        System.Console.WriteLine("Thread Siti is alive: " + t4.IsAlive);

        Thread.Sleep(1000); // tunggu 1 detik agar semua thread selesai

        //Passing Data to Threads
        // lambda expression
        Thread t5 = new Thread(() => Print1("Hantu"));
        t5.Start();
        //with arguments
        Thread t6 = new Thread(Print2);
        t6.Start("Pocong");

    }

    static void Method()
    {
        System.Console.WriteLine("Hantu nya ada disini, namanya");
    }

    static void Method2()
    {
        System.Console.WriteLine("kuntilanak kalau disini");
    }
    static void Method3()
    {
        System.Console.WriteLine("pocong juga ada");
    }
    static void Print1(string pesan)
    {
        System.Console.WriteLine(pesan);
    }
    static void Print2(object pesan)
    {
        string realpesan = (string)pesan;
        System.Console.WriteLine(realpesan);
    }
}
