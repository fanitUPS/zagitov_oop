using ModelLab4WinForms;
using System;
using System.ComponentModel;

namespace ViewLab4WinForms
{
    class GetTransportListEventArgs : EventArgs
    {
        /// <summary>
        /// Binding list
        /// </summary>
        private BindingList<TransportBase> _getTransportList =
            new BindingList<TransportBase>();

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
            foreach (var transport in transportList)
            {
                _getTransportList.Add(transport);
            }

            GetTransportList = _getTransportList;
        }
    }
}
