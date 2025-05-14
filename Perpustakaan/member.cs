namespace member; 
public class Pengunjung
{
    public string Name {get; set;}
    public string MemberID {get; set;}
    public Pengunjung (string name, string memberId)
    {
        Name = name;
        MemberID = memberId;
    }
    public void InfoPengunjung()
	{
		Console.WriteLine($"Nama: {Name}, Member ID : {MemberID}");
	}
}
