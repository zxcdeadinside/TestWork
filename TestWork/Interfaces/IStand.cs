using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWork.Engines;

namespace TestWork.Interfaces
{
    public interface IStand
    {
        void Check(Engine engine);
        void RunTest(Engine engine, double Tc);
    }
}
