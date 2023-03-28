using System;
using TestWork.Engines;
using TestWork.Interfaces;

namespace TestWork.Stands
{
    public class TestStand : IStand
    {
        private int maxTime = 1000000;
        public void RunTest(Engine engine, double Tc)
        {
            engine.AttachStand(this);
            engine.StartEngine(Tc);
        }

        public void Check(Engine engine)
        {
            double eps = engine.T - engine.Te;
            engine.isRunning = eps > 10e-1 && engine.TimeRun < maxTime;

            if (!engine.isRunning)
            {
                Console.WriteLine(((engine.TimeRun < maxTime) ? "Двигатель не прошел тест, время = " + engine.TimeRun + " сек" : "Двигатель прошел тест"));
            }
        }

    }
}
