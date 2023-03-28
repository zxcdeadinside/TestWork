using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWork.Engines;
using TestWork.Stands;

namespace TestWork
{
    class Program
    {
        static double I = 10;
        static List<int> M = new List<int>() { 20, 75, 100, 105, 75, 0 };
        static List<int> V = new List<int>() { 0, 75, 150, 200, 250, 300};
        static double T = 110;
        static double Hm = 0.01;
        static double Hv = 0.0001;
        static double C = 0.1;
        static void Main(string[] args)
        {
            double Tc;
            Console.Write("Введите температуру окружающей среды:\nTc = ");
            double.TryParse(Console.ReadLine(), out Tc);

            Engine engine = new Engine(I, M, V, T, Hm, Hv, C, Tc);
            TestStand stand = new TestStand();

            engine.AttachStand(stand);
            stand.RunTest(engine, Tc);
            Console.Read();
        }
    }
}
