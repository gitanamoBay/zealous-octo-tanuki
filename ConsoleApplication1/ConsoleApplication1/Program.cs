using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Hello, what is your name?");

            var name =  Console.ReadLine();


            Random rng = new Random();



            Console.WriteLine(name + (rng.Next(1) == 1?", twat!":", you are a set of cunt flaps"));



            Console.ReadLine();
        }
    }
}
