# Thread
3. apa itu signaling 
7. thread safety, shared state, exception why so crucial to avoid bugs ?
8. synchronization ? 
9. concurrent execution ? 
10. thread priority, signaling, thread pooling 

---

# Concurrency and Asynchrony

**Concurrecy => Run multiple task in the same time. 
**Asynchrony => Running at the same time. 
**Synchrony => Running proceduraally. 

--- 
## Concurrency 
gimana caranya melakukan eksekusi ini dalam C# ?

1. Threading 
- Thread is unit of process for execute application code. 
- every program have one Thread, its called 'Main Thread'
- kenapa kita menggunakna thread dalam sebuah program ?
you can achieve parallelism, improve responsiveness, and handle multiple tasks at once, by using thread on program. 
- Threading by default is Foreground threads. 
- Foreground = prevent the application from exiting as long as any of them are running. 

-can to background threads use ... .IsBackground = true; 
... . Start(); 

- Creating Thread in C# using 'Thread' class, and manage by using 'system.Threading', and started using 'start'

```csharp
Thread t1 = new Thread(Method1) {name = "coba"};
Thread t2 = new Thread(OtherMethod);
Console.WriteLine("Thread t has ended!");

t1.Start(); // buat memulai 
Console.WriteLine(Thread.CurrentThread.Name) //mendapatkan informasi properti yang dimiliki Thread saat ini, untuk identifikasi dan debugging,
t1.IsAlive // indicates whether the thread is still running or not. 
t1.Join // wait for a thread to finish before continuing with your program.
t2.Join; 
Thread.Sleep(); //pause all thread execution for a certain period  <10000 miliseconds, ini bisa diset; 
```
---
**Properti yang dimiliki Thread contoh : 
IsAlive → Menunjukkan apakah thread masih aktif.

ThreadState → Status saat ini dari thread (Running, Suspended, blocking dll.).

Priority → Mengatur prioritas eksekusi thread (Highest, Normal, Lowest, dll.).

ManagedThreadId → ID unik yang ditetapkan oleh sistem untuk thread.

--- 
managing shared state -> use
lead to data corupption and race conditions, by using synctonization techniques (lock)
```csharp
class ThreadSafe {
    static bool _done; 
    static readonly object _locker = new object(); 

    static void Main(){
        new Thread(Go).Start(); 
        Go(); 
    }

    static void Go(){
        lock (_locker) {
            if (!_done) { Console.WriteLine("Done"); _done = true; }
        }
    }
}
```
--- 
Exception Handling 
-
