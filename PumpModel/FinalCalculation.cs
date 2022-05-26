using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpModel
{
    class FinalCalculation
    {
        private ICalculationPumps _calculationPumps { get; }
        private double _p { get; }
        private double _g { get; }
        private double _p1 { get; }
        private double _p2 { get; }
        private double _hr { get; }
        private double _hp { get; }

        internal FinalCalculation(double p1, double p2, double hr, double hp, ICalculationPumps calculationPumps)
        {
            _p = 1020;
            _g = 9.81;
            _p1 = p1;
            _p2 = p2;
            _hr = hr;
            _hp = hp;
            _calculationPumps = calculationPumps;
        }
        private double CalculateOfHead()
        {
            return (_p2 - _p1) / (_p * _g) + _hr + _hp;
        }
        internal double CalculateOfPower(int choicePump)
        {
            int z;
            double h = CalculateOfHead();
            double q = 0;
            double f, F, s, n, nV, b, e, d, t;
            switch (choicePump)
            {
                case 1:
                    Console.WriteLine("f:\ts:\tn:\tnV:");
                    f = Convert.ToDouble(Console.ReadLine());
                    s = Convert.ToDouble(Console.ReadLine());
                    n = Convert.ToDouble(Console.ReadLine());
                    nV = Convert.ToDouble(Console.ReadLine());
                    q = _calculationPumps.CalculateOfPistonPump(f, s, n, nV);
                    break;
                case 2:
                    Console.WriteLine("F:\ts:\tn:\tnV:");
                    F = Convert.ToDouble(Console.ReadLine());
                    f = Convert.ToDouble(Console.ReadLine());
                    s = Convert.ToDouble(Console.ReadLine());
                    nV = Convert.ToDouble(Console.ReadLine());
                    q = _calculationPumps.CalculateOFTwinPistonPump(F, f, s, nV);
                    break;
                case 3:
                    Console.WriteLine("f:\tz:\tb:\tn:\tnV:");
                    f = Convert.ToDouble(Console.ReadLine());
                    z = Convert.ToInt32(Console.ReadLine());
                    b = Convert.ToInt32(Console.ReadLine());
                    n = Convert.ToInt32(Console.ReadLine());
                    nV = Convert.ToDouble(Console.ReadLine());
                    q = _calculationPumps.CalculationOfGearPumps(f, z, b, n, nV);
                    break;
                case 4:
                    Console.WriteLine("e:\td:\tt:\tn:\tnV:");
                    e = Convert.ToDouble(Console.ReadLine());
                    d = Convert.ToDouble(Console.ReadLine());
                    t = Convert.ToDouble(Console.ReadLine());
                    n = Convert.ToDouble(Console.ReadLine());
                    nV = Convert.ToDouble(Console.ReadLine());
                    q = _calculationPumps.calculationOfScrewPumps(e, d, t, n, nV);
                    break;
            }
            return _p * _g * q * h;
        }
    }
}