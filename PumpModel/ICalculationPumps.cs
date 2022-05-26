using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpModel
{
    public interface ICalculationPumps
    {
        public double CalculateOfPistonPump(double f, double s, double n, double nV);
        public double CalculateOFTwinPistonPump(double F, double f, double s, double nV);
        public double CalculationOfGearPumps(double f, int z, double b, double n, double nV);
        public double calculationOfScrewPumps(double e, double d, double t, double n, double nV);
    }
}
