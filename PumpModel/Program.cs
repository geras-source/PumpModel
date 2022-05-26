using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace PumpModel
{
    class Program
    {
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    //add service registrations
                    services.AddSingleton<ICalculationPumps, CalculationsPumps>();
                });

            return hostBuilder;
        }
        static void Main(string[] args)
        {
            int choice;
            double p1 = 1.2;
            double p2 = 2.5;
            double hr = 8;
            double hp = 2.54;
            var host = CreateHostBuilder(args).Build();
            var calculationPumps = host.Services.GetService<ICalculationPumps>();
            FinalCalculation finalCalculation = new FinalCalculation(p1, p2, hr, hp, calculationPumps);

            Console.WriteLine("Choise pump:");
            choice = Convert.ToInt32(Console.ReadLine());

            double n = finalCalculation.CalculateOfPower(choice);
            Console.WriteLine($"Pump power consumption is {n}");
        }
    }
}
