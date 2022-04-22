using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using ModelLab4WinForms;

namespace ViewLab4WinForms
{
    /// <summary>
    /// Class for events
    /// </summary>
    public class EventForm : Form
    {
        /// <summary>
        /// Event of AddTransport
        /// </summary>
        internal EventHandler<TransportEventArgs> TransportAdded;

        /// <summary>
        /// Event of close form
        /// </summary>
        internal EventHandler CloseForm;

        /// <summary>
        /// EventHandler
        /// </summary>
        internal EventHandler CancelForm;

        /// <summary>
        /// EventHandler
        /// </summary>
        internal EventHandler MessageBoxEvent;
    }
}
