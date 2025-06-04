# Day 21 

## Stream 
- stream is a sequence of bytes that flows in or out of a program. 

- by using System.IO.Stream

- file handling 
~ Filestream => read or write to a file on disk. 
~ Memorystream => read or write to a block of memoery 
~ Networkstream => read or write to a network socket.
~ BufferedStream => wraps another streams and provides buffer for optimizing. 

- stream adapters => Typed methods for dealing such as  string and xml. 

> using Streams:
    
    1. abstract stream class is base for all streams   
    2. using async method for slow streams (network I/O).
