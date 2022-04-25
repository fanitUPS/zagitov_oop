using System;
using System.Xml.Serialization;

namespace ModelLab4WinForms
{
    /// <summary>
    /// Abstract class TransportBase
    /// </summary>
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Helicopter))]
    [XmlInclude(typeof(Hybrid))]
    public abstract class TransportBase
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
        /// Enum of engine types
        /// </summary>
        public abstract EngineType EngineType { get; set; }

        /// <summary>
        /// Constructor for XML
        /// </summary>
        protected TransportBase()
        {
        }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="consumptionPerKm">Fuel consumption per 100 km</param>
        /// <param name="distance">Distance of travel</param>
        /// <param name="engine">Type of engine</param>
        protected TransportBase(float consumptionPerKm, float distance,
            EngineType engine)
        {
            ConsumptionPerKm = consumptionPerKm;
            Distance = distance;
            EngineType = engine;
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
                throw new ArgumentException("Value must be not zero.");
            }

            if (value == float.NaN)
            {
                throw new ArgumentException("Value must be not NaN.");
            }

            return value;
        }

        /// <summary>
        /// Check value
        /// </summary>
        /// <param name="min">Min</param>
        /// <param name="max">Max</param>
        /// <param name="value">Value</param>
        /// <returns>Valid value</returns>
        public float CheckMinMax(float min, float max, float value)
        {
            if (min > value || value > max)
            {
                throw new ArgumentException
                    ($"Percents distance on electric engine must" +
                    $" be > {min} and < {max}");
            }

            return value;
        }

        /// <summary>
        /// Type of transport
        /// </summary>
        public abstract string Type { get; }

        /// <summary>
        /// Consumption of fuel
        /// </summary>
        public abstract float Consumption { get; }
    }
}


