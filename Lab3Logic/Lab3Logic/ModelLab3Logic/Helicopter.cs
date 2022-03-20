namespace ModelLab3Logic
{
    public class Helicopter : TransportBase
    {
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
            set => _engineType = CheckEngine(value, this);
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
        private float _load;

        /// <summary>
        /// Load of helicopter
        /// </summary>
        public float Load
        {
            get => _load;
            set => _load = CheckMinMax(MinLoad, MaxLoad, value);
        }

        /// <summary>
        /// Constuctor of instance helicopter
        /// </summary>
        /// <param name="consaption">Fuel consumption per 100 km</param>
        /// <param name="distanse">Distance of travel</param>
        /// <param name="engine">Type of engine</param>
        /// <param name="load">Load of helicopter</param>
        public Helicopter(float consaption, float distanse,
            EngineType engine, float load)
            : base(consaption, distanse, engine)
        {
            Load = load;
        }

        /// <summary>
        /// Calculation of consupted fuel
        /// </summary>
        /// <returns>Consupted fuel</returns>
        public override float GetConsuption()
        {
            float fuelCoeff = 1;

            if (this.Load <= 700)
            {
                fuelCoeff = 0.8F;
            }
            else if (this.Load >= 1600)
            {
                fuelCoeff = 1.2F;
            }

            return fuelCoeff * this.ConsPerKm * (this.Distance / 100);
        }
    }
}
