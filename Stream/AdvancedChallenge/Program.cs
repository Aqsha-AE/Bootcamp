/*
Add a new model class (e.g., University) and serialize it
Implement custom JSON converters for specific formatting
Create a method that determines the best serialization format based on use case
Add encryption to the binary serialization process
Implement XML schema validation
*/

using System;
using System.IO;
using System.Text.Json;

public class University
{
    public char Grade { get; set; }
    public string Name { get; set; }
}

class Program
{
    static void Main()
    {
        University fk = new University { Grade = 'A', Name = "UGM" };

        string jsonString


        // Konversi objek ke format JSON
        string jsonString = JsonSerializer.Serialize(t1);

        // Simpan ke file
        File.WriteAllText("Example.json", jsonString);

        Console.WriteLine("Serialization completed: Example.json");
    }
}
