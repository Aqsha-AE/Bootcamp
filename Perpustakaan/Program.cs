using koleksi; 
using member;

namespace MyProject;
class Program
{
    static void Main(string[] args) 
    {
        Book buku1 = new Book("Harry Potter", "J.K. Rowling", "Biru");
        buku1.InfoBuku();

        Pengunjung pengunjung1 = new Pengunjung("John Doe", "M001");
        pengunjung1.InfoPengunjung();

        Console.WriteLine("Selamat datang di Perpustakaan!");
    }
}