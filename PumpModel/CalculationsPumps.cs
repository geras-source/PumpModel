namespace PumpModel
{
    class CalculationsPumps : ICalculationPumps
    {
        public double CalculateOfPistonPump(double f, double s, double n, double nV)
        {
            return f * s * n * nV;
        }

        public double CalculateOFTwinPistonPump(double F, double f, double s, double n)
        {
            return (2 * F - f) * s * n;
        }

        public double CalculationOfGearPumps(double f, int z, double b, double n, double nV)
        {
            return 2 * f * z * n * b * nV;
        }

        public double calculationOfScrewPumps(double e, double d, double t, double n, double nV)
        {
            return 4 * e * d * t * n * nV;
        }
    }
}
