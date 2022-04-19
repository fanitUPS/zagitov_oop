using System;

namespace ModelLab4WinForms
{
    /// <summary>
    /// Class Hybrid
    /// </summary>
    public class Hybrid : TransportBase
    {
        /// <summary>
        /// Engine type
        /// </summary>
        private EngineType _engineType;

        /// <summary>
        /// Type
        /// </summary>
        public override string Type => "Hybrid";

        /// <summary>
        /// Engine type
        /// </summary>
        public override EngineType EngineType
        {
            get => _engineType;
            set => _engineType = CheckEngine(value);
        }

        /// <summary>
        /// Max percent distance on electric engine
        /// </summary>
        public const int MaxPercent = 1;

        /// <summary>
        /// Min percent distance on electric engine
        /// </summary>
        public const int MinPercent = 0;

        /// <summary>
        /// Percent distance on electric engine
        /// </summary>
        private float _percentOnElectric = 0.5f;

        /// <summary>
        /// Percent distance on electric engine
        /// </summary>
        public float PercentOnElectric
        {
            get => _percentOnElectric;
            set => _percentOnElectric = CheckMinMax
                (MinPercent, MaxPercent, value);
        }

        /// <summary>
        /// Constructor for XML
        /// </summary>
        public Hybrid()
        {
        }

        /// <summary>
        /// Constructor for FormView
        /// </summary>
        /// <param name="consumption">Fuel consumption per 100 km</param>
        /// <param name="distance">Distance of travel</param>
        /// <param name="engine">Type of engine</param>
        public Hybrid(float consumption, float distance,
            EngineType engine) : base(consumption, distance, engine)
        {
        }

        /// <summary>
        /// Constuctor of hybrid instance
        /// </summary>
        /// <param name="consumption">Fuel consumption per 100 km</param>
        /// <param name="distance">Distance of travel</param>
        /// <param name="engine">Type of engine</param>
        /// <param name="percentOnElectric">Percent distance on electric engine</param>
        public Hybrid(float consumption, float distance,
            EngineType engine, float percentOnElectric)
            : base(consumption, distance, engine)
        {
            PercentOnElectric = percentOnElectric;
        }

        /// <summary>
        /// Consumption of fuel
        /// </summary>
        public override float Consumption
        {
            get
            {
                float engineCoeff = 1;

                return (engineCoeff - this.PercentOnElectric) * this.ConsumptionPerKm
                    * (this.Distance / 100);
            }
        }

        /// <summary>
        /// Check type of engine
        /// </summary>
        /// <param name="engine">Engine type</param>
        /// <returns>Valid engine type</returns>
        private EngineType CheckEngine(EngineType engine)
        {
            if (engine != EngineType.Hybrid)
            {
                throw new ArgumentException
                    ("Engine type must be Hybrid for Hybrid");
            }
            
            return engine;
        }
    }
}
