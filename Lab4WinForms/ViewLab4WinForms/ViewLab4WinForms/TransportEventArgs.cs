using ModelLab4WinForms;

namespace ViewLab4WinForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class TransportEventArgs: EventArgs
    {
        public TransportBase Transport { get; }

        public TransportEventArgs(TransportBase transport)
        {
            Transport = transport;
        }

    }
}
