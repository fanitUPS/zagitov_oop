using System;

namespace ViewLab4WinForms
{
    internal class TransportProperties
    {
        /// <summary>
        /// Transport fuel consumption per 100 km
        /// </summary>
        private float _consumptionPerKm;

        /// <summary>
        /// Transport fuel consumption per 100 km
        /// </summary>
        public float ConsumptionPerKm
        {
            get => _consumptionPerKm;
            set => _consumptionPerKm = CheckValue(value);
        }

        /// <summary>
        /// Distance of travel on transport
        /// </summary>
        private float _distance;

        /// <summary>
        /// Distance of travel on transport
        /// </summary>
        public float Distance
        {
            get => _distance;
            set => _distance = CheckValue(value);
        }

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
        internal static TransportProperties EmptyInstance()
        {
            return new TransportProperties(1, 1);
        }

        /// <summary>
        /// Method of validation values
        /// </summary>
        /// <param name="value">Input value</param>
        /// <returns>Valid value</returns>
        public float CheckValue(float value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Value must positive.");
            }

            if (value == float.NaN)
            {
                throw new ArgumentException("Value must be not NaN.");
            }
            
            return value;
        }
    }
}
