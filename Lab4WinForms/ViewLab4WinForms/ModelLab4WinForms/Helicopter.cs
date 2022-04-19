using System;

namespace ModelLab4WinForms
{
    public class Helicopter : TransportBase
    {
        /// <summary>
        /// Engine type
        /// </summary>
        private EngineType _engineType;

        /// <summary>
        /// Type
        /// </summary>
        public override string Type => "Helicopter";

        /// <summary>
        /// Engine type
        /// </summary>
        public override EngineType EngineType
        {
            get => _engineType;
            set => _engineType = CheckEngine(value);
        }

        /// <summary>
        /// Max load of helicopter
        /// </summary>
        public const int MaxLoad = 2000;

        /// <summary>
        /// Min load of helicopter
        /// </summary>
        public const int MinLoad = 0;

        /// <summary>
        /// Load of helicopter
        /// </summary>
        private float _load = 100;

        /// <summary>
        /// Load of helicopter
        /// </summary>
        public float Load
        {
            get => _load;
            set => _load = CheckMinMax(MinLoad, MaxLoad, value);
        }

        /// <summary>
        /// Constructor for XML
        /// </summary>
        public Helicopter()
        {
        }

        /// <summary>
        /// Constructor for FormView
        /// </summary>
        /// <param name="consumption">Fuel consumption per 100 km</param>
        /// <param name="distance">Distance of travel</param>
        /// <param name="engine">Type of engine</param>
        public Helicopter(float consumption, float distance,
            EngineType engine) : base(consumption, distance, engine)
        {
        }

        /// <summary>
        /// Constuctor of instance helicopter
        /// </summary>
        /// <param name="consumption">Fuel consumption per 100 km</param>
        /// <param name="distance">Distance of travel</param>
        /// <param name="engine">Type of engine</param>
        /// <param name="load">Load of helicopter</param>
        public Helicopter(float consumption, float distance,
            EngineType engine, float load)
            : base(consumption, distance, engine)
        {
            Load = load;
        }

        /// <summary>
        /// Consumption of fuel
        /// </summary>
        public override float Consumption
        {
            get
            {
                float loadCoeff = 1;

                if (this.Load <= 700)
                {
                    loadCoeff = 0.8F;
                }
                else if (this.Load >= 1600)
                {
                    loadCoeff = 1.2F;
                }

                return loadCoeff * this.ConsumptionPerKm * (this.Distance / 100);
            }
        }

        /// <summary>
        /// Check type of engine
        /// </summary>
        /// <param name="engine">Engine type</param>
        /// <returns>Valid engine type</returns>
        private EngineType CheckEngine(EngineType engine)
        {
            if (engine != EngineType.GasTurbine)
            {
                throw new ArgumentException
                    ("Engine type must be Turbine for Helicopter");
            }

            return engine;
        }
    }
}
