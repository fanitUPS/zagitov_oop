using System;

namespace ModelLab3Logic
{
    /// <summary>
    /// Car class
    /// </summary>
    public class Car : TransportBase
    {
        /// <summary>
        /// Gas tank volume
        /// </summary>
        private float _gasTankVolume;

        /// <summary>
        /// Engine type
        /// </summary>
        private EngineType _engineType;

        /// <summary>
        /// Engine type
        /// </summary>
        public override EngineType EngineType
        {
            get => _engineType;
            set => _engineType = CheckEngine(value);
        }

        /// <summary>
        /// Gas tank volume
        /// </summary>
        public float GasTankVolume
        {
            get => _gasTankVolume;
            set => _gasTankVolume = CheckValue(value);
        }

        /// <summary>
        /// Constuctor of instance Car
        /// </summary>
        /// <param name="consumption">Fuel consumption per 100 km</param>
        /// <param name="distance">Distance of travel</param>
        /// <param name="engine">Type of engine</param>
        /// <param name="tank">Gas tank volume</param>
        public Car(float consumption, float distance,
            EngineType engine, float tank)
            : base (consumption, distance, engine)
        {
            GasTankVolume = tank;
        }

        /// <summary>
        /// Consumption of fuel
        /// </summary>
        public override float Consumption
        {
            get 
            {
                float engineCoeff = 1;

                if (this.EngineType == EngineType.Diesel)
                {
                    engineCoeff = 0.8F;
                }

                return engineCoeff * this.ConsumptionPerKm * (this.Distance / 100);
            }
        }

        /// <summary>
        /// Check type of engine
        /// </summary>
        /// <param name="engine">Engine type</param>
        /// <returns>Valid engine type</returns>
        private EngineType CheckEngine(EngineType engine)
        {
            if (engine != EngineType.Diesel &&
                engine != EngineType.Petrol)
            {
                throw new ArgumentException
                    ("Engine type must be Diesel or Petrol for Car");
            }

            return engine;
        }
    }
}
