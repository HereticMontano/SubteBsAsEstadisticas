using System;
using System.Net.Http;

namespace ConsoleSubteEstadisticas
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Process.ProcessRepositories().Wait();
            Console.ReadKey();
        }
    }
}
