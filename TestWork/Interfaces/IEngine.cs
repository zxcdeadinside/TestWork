using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWork.Stands;

namespace TestWork.Interfaces
{
    public interface IEngine
    {
        bool isRunning { get; set; }
        void StartEngine(double Tc);
        void AttachStand(TestStand stand);
        void DetachStand();
        void UpdateStand();
    }
}
