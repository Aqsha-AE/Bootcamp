using System;

public delegate void Notify();

public class Publisher
{
    public event Notify ProcessCompleted;

    public void StartProcess()
    {
        Console.WriteLine("Process started!");
        OnProcessCompleted();
    }

    protected virtual void OnProcessCompleted()
    {
        ProcessCompleted?.Invoke();
    }
}

public class Subscriber
{
    public void OnProcessCompleted()
    {
        Console.WriteLine("Subscriber: Process completed!");
    }
}

class Program
{
    static void Main()
    {
        Publisher publisher = new Publisher();
        Subscriber subscriber = new Subscriber();

        publisher.ProcessCompleted += subscriber.OnProcessCompleted;
        publisher.StartProcess();
        publisher.ProcessCompleted -= subscriber.OnProcessCompleted;
        publisher.StartProcess();
    }
}