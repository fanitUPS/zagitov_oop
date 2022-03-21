using System;
using System.Collections.Generic;

namespace ModelLab3Logic
{
    /// <summary>
    /// Abstract class TransportBase
    /// </summary>
    public abstract class TransportBase
    {
        //TODO: RSDN
        /// <summary>
        /// Tranport fuel consumption per 100 km
        /// </summary>
        private float _consPerKm;

        //TODO: RSDN
        /// <summary>
        /// Tranport fuel consumption per 100 km
        /// </summary>
        public float ConsPerKm
        {
            get => _consPerKm;
            set => _consPerKm = CheckValue(value);
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
        /// Base constructor
        /// </summary>
        /// <param name="consaption">Fuel consumption per 100 km</param>
        /// <param name="distanse">Distance of travel</param>
        /// <param name="engine">Type of engine</param>
        protected TransportBase(float consaption, float distanse,
            EngineType engine)
        {
            ConsPerKm = consaption;
            Distance = distanse;
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

        //TODO: property
        /// <summary>
        /// Calculation of consupted fuel
        /// </summary>
        /// <returns>Spented fuel</returns>
        public abstract float GetConsuption();

        //TODO:
        /// <summary>
        /// Validation of engine type and transport type
        /// </summary>
        /// <param name="engine">Engine type</param>
        /// <param name="transportBase">Instance of TransportBase</param>
        /// <returns>Valid engine type</returns>
        public EngineType CheckEngine(EngineType engine,
            TransportBase transportBase)
        {
            var exceptionMessege = new Dictionary<int, string>()
            {
                {1, "Engine type must be Diesel or Petrol for Car"},
                {2, "Engine type must be Hybrid for Hybrid"},
                {3, "Engine type must be Turbine for Helicopter"},
                {4, "Unknown type of transport"}
            };

            switch (transportBase)
            {
                case Car car:
                    if (engine != EngineType.Diesel &&
                        engine != EngineType.Petrol)
                    {
                        throw new ArgumentException
                            (exceptionMessege[1]);
                    }
                    return engine;

                case Hybrid hybrid:
                    if (engine != EngineType.Hybrid)
                    {
                        throw new ArgumentException
                            (exceptionMessege[2]);
                    }
                    return engine;

                case Helicopter helicopter:
                    if (engine != EngineType.GasTurbine)
                    {
                        throw new ArgumentException
                            (exceptionMessege[3]);
                    }
                    return engine;

                default:
                    throw new ArgumentException
                        (exceptionMessege[4]);
            }
        }
    }
}


