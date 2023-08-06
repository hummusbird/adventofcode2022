namespace advent_7;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        ElfDirectory root = new ElfDirectory
        {
            Filename = "/",
        };

        foreach (string cmd in System.IO.File.ReadAllLines("test.txt"))
        {
            
        }
    }
}

class ElfFile
{
    public int Size { get; set; }
    public string? Filename { get; set; }
}

class ElfDirectory : ElfFile
{
    public string? DirectoryName { get; set; }
    public List<ElfFile> Contents = new();
}
