using ModelLab4WinForms;
using System;
using System.ComponentModel;

namespace ViewLab4WinForms
{
    //TODO: XML(+)
    //TODO: RSDN(+)
    /// <summary>
    /// GetTransportListEvent
    /// </summary>
    internal class GetTransportListEventArgs : EventArgs
    {
        /// <summary>
        /// Get TransportList
        /// </summary>
        public BindingList<TransportBase> GetTransportList { get; }

        /// <summary>
        /// GetTransportListEventArgs constructor
        /// </summary>
        /// <param name="transportList">Transport list</param>
        public GetTransportListEventArgs(BindingList<TransportBase> transportList)
        {
            GetTransportList = transportList;
        }
    }
}
