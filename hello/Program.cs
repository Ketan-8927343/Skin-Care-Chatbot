public class Program
{
    // Properties
    private string Name = "Ketan Patel";

    public string Displayname()
    {
        return Name;
    }

    static void Main(string[] args)
    {

        Console.WriteLine("Screenshot for Developement Enviornment:");
        Program instance = new Program();
        Console.WriteLine(instance.Displayname() + " from section 4");
    }
}