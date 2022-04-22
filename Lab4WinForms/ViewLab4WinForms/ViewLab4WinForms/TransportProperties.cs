namespace ViewLab4WinForms
{
    internal class TransportProperties
    {
        /// <summary>
        /// Transport fuel consumption per 100 km
        /// </summary>
        public float ConsumptionPerKm { get; set; }

        /// <summary>
        /// Distance of travel on transport
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// Construction of transport property instance
        /// </summary>
        /// <param name="consumptionPerKm">Fuel consumption per 100 km</param>
        /// <param name="distance">Distance of travel</param>
        public TransportProperties (float consumptionPerKm, float distance)
        {
            ConsumptionPerKm = consumptionPerKm;
            Distance = distance;
        }

        /// <summary>
        /// Empty instance of TransportProperties
        /// </summary>
        /// <returns>Empty instance of TransportProperties</returns>
        static internal TransportProperties EmptyInstance()
        {
            return new TransportProperties(0, 0);
        }
    }
}
