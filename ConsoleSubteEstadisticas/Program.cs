using System;
using System.Net.Http;
using System.Threading;

namespace ConsoleSubteEstadisticas
{
    class Program
    {        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("pRICIPIO");                                
                ProcessEstadoSubte.ProcessEstado().Wait();   
                Console.WriteLine("fIN");                
                Thread.Sleep(new TimeSpan(0,5,0));
            }
            
        }
    }
}
