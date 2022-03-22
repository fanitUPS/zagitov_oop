using ModelLab3Logic;
using System;
using System.Collections.Generic;

namespace ViewLab3Logic
{
    /// <summary>
    /// Class program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of application
        /// </summary>
        /// <param name="args">Command line arguments</param>
        private static void Main(string[] args)
        {
            var transportList = new List<TransportBase>()
            {
                new Car(7, 500, EngineType.Diesel, 200),
                new Car(7, 500, EngineType.Electric, 200),
                new Hybrid(7, 500, EngineType.Hybrid, 0.7F),
                new Helicopter(200, 500, EngineType.GasTurbine, 1800)
            };

            foreach (var transport in transportList)
            {
                Console.WriteLine(transport.Consumption);
            }

            Console.ReadKey();
        }
    }
}
