using System.Data.SqlTypes;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        Console.WriteLine("move red ball to redroom and blue ball to blueroom in order to win");
        var start = new GameEngine();
        start.Run();
    }

}