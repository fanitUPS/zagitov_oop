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
            //TODO: где полиморфизм?
            var carDiesel = new Car(7, 500, EngineType.Diesel, 200);

            var carPetrol = new Car(7, 500, EngineType.Petrol, 200);

            var hybrid = new Hybrid(7, 500, EngineType.Hybrid, 0.7F);

            var helicopter = new Helicopter(200, 500, EngineType.GasTurbine, 1800);

            Console.WriteLine(carDiesel.GetConsuption());
            Console.WriteLine(carPetrol.GetConsuption());
            Console.WriteLine(hybrid.GetConsuption());
            Console.WriteLine(helicopter.GetConsuption());

            Console.ReadKey();
        }
    }
}
