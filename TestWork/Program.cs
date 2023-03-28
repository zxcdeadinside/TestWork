using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Tc;
            Console.Write("Введите температуру окружающей среды:\nTc = ");
            double.TryParse(Console.ReadLine(), out Tc);
        }
    }
}
