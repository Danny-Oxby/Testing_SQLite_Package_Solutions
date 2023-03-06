namespace MyProject;
class Program
{
    static void Main(string[] args)
    {
        //string returnlist = ClassLibrary1.Class1.CreateDB(); // the SQLcore library
        string returnlist = SQLitePlcLibrary.Class1.CreateDB();
        Console.WriteLine(returnlist);
    }
}