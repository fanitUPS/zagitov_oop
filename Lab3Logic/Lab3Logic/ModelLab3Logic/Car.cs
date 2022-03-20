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
            set => _engineType = CheckEngine(value, this);
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
        /// <param name="consaption">Fuel consumption per 100 km</param>
        /// <param name="distanse">Distance of travel</param>
        /// <param name="engine">Type of engine</param>
        /// <param name="tank">Gas tank volume</param>
        public Car(float consaption, float distanse,
            EngineType engine, float tank)
            : base (consaption, distanse, engine)
        {
            GasTankVolume = tank;
        }

        /// <summary>
        /// Calculation of consupted fuel
        /// </summary>
        /// <returns>Consupted fuel</returns>
        public override float GetConsuption()
        {
            float coeff = 1;

            if (this.EngineType == EngineType.Diesel)
            {
                coeff = 0.8F;
            }
            
            return coeff * this.ConsPerKm * (this.Distance / 100);
        }
    }
}
