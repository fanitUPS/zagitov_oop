namespace ModelLab3Logic
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
        /// Engine type
        /// </summary>
        public override EngineType EngineType
        {
            get => _engineType;
            set => _engineType = CheckEngine(value, this);
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
        private float _percentOnElectric;

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
        /// Constuctor of hybrid instance
        /// </summary>
        /// <param name="consaption">Fuel consumption per 100 km</param>
        /// <param name="distanse">Distance of travel</param>
        /// <param name="engine">Type of engine</param>
        /// <param name="percentOnElectric">Percent distance on electric engine</param>
        public Hybrid(float consaption, float distanse,
            EngineType engine, float percentOnElectric)
            : base(consaption, distanse, engine)
        {
            PercentOnElectric = percentOnElectric;
        }

        /// <summary>
        /// Calculation of consupted fuel
        /// </summary>
        /// <returns>Consupted fuel</returns>
        public override float GetConsuption()
        {
            float fuelCoeff = 1;

            return (fuelCoeff - this.PercentOnElectric) * this.ConsPerKm
                * (this.Distance / 100);
        }
    }
}
