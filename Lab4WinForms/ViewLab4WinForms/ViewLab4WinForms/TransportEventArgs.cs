using ModelLab4WinForms;
using System;

namespace ViewLab4WinForms
{
    /// <summary>
    /// Class TransportEventArgs
    /// </summary>
    internal class TransportEventArgs: EventArgs
    {
        /// <summary>
        /// Get added transport
        /// </summary>
        public TransportBase Transport { get; }

        /// <summary>
        /// Constructor of TransportEventArgs
        /// </summary>
        /// <param name="transport">Add transport</param>
        public TransportEventArgs(TransportBase transport)
        {
            Transport = transport;
        }
    }
}
