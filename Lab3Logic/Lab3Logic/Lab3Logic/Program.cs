using ModelLab3Logic;
using System;

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
            var carD = new Car(7, 500, EngineType.Diesel, 200);

            var carP = new Car(7, 500, EngineType.Petrol, 200);

            var hybrid = new Hybrid(8, 500, EngineType.Hybrid, 0.5F);

            var helicopter = new Helicopter(200, 500, EngineType.GasTurbine, 1800);

            Console.WriteLine(carD.GetConsuption());
            Console.WriteLine(carP.GetConsuption());
            Console.WriteLine(hybrid.GetConsuption());
            Console.WriteLine(helicopter.GetConsuption());

            Console.ReadKey();
        }
    }
}
