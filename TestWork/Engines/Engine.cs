using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestWork.Interfaces;
using TestWork.Stands;

namespace TestWork.Engines
{
    public class Engine : IEngine
    {
        private TestStand attachedStand = null;
        public bool isRunning { get; set; } = false;
        public int TimeRun { get; private set; } = 0;

        private double I;
        private List<int> M;
        private List<int> V;
        public double T { get; private set; }
        public double Te { get; private set; }
        public double Tc { get; private set; }
        private double Hm;
        private double Hv;
        private double C;

        private double CalculateVc()
        {
            return C * (Tc - Te);
        }
        private double CalculateVh(int index)
        {
            return M[index] * Hm + Math.Pow(V[index], 2) * Hv;
        }

        public void StartEngine(double Tc)
        {
            isRunning = true;
            this.Tc = Tc;
            this.Te = Tc;
            int index = 0;

            double m = M[0];
            double v = V[0];
            double a = m / I;

            while (isRunning)
            {
                TimeRun++;
                v += a;

                if (index < M.Count - 2)
                {
                    if (v >= M[index + 1])
                    {
                        index++;
                    }
                }

                double up = v - V[index];
                double down = V[index + 1] - V[index];
                double factor = M[index + 1] - M[index];
                m = up / down * factor + M[index];
                Te += CalculateVc() + CalculateVh(index);
                a = m / I;

                UpdateStand();
            }
        }

        public void AttachStand(TestStand stand)
        {
            attachedStand = stand;
        }

        public void DetachStand()
        {
            attachedStand = null;
        }


        public void UpdateStand()
        {
            attachedStand.Check(this);
        }

        public Engine(double I, List<int> M, List<int> V, double T, double Hm, double Hv, double C, double Tc)
        {
            this.I = I;
            this.M = M;
            this.V = V;
            this.T = T;
            this.Hm = Hm;
            this.Hv = Hv;
            this.C = C;
            this.Tc = Tc;
        }
    }
}
