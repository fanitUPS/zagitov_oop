using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ModelLab4WinForms;

namespace ViewLab4WinForms
{
    /// <summary>
    /// Class AddForm
    /// </summary>
    public partial class AddForm : EventForm
    {
        /// <summary>
        /// Data source for DataGrid
        /// </summary>
        private BindingList<TransportProperties> _dataSource;

        /// <summary>
        /// Dictionary of engine types
        /// </summary>
        private readonly Dictionary<string, List<EngineType>> _engineTypes = 
            new Dictionary<string, List<EngineType>>()
            {
                { nameof(Car), new List<EngineType>() 
                    { EngineType.Diesel, EngineType.Petrol } },

                { nameof(Hybrid), new List<EngineType>() 
                    { EngineType.Hybrid } },

                { nameof(Helicopter), new List<EngineType>() 
                    { EngineType.GasTurbine } }
            };
        
        /// <summary>
        /// AddForm
        /// </summary>
        public AddForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click on cancelButton
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        internal void CancelButtonClick(object sender, EventArgs e)
        {
            CancelForm?.Invoke(sender, e);
        }
        
        /// <summary>
        /// AddForm load
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void AddFormLoad(object sender, EventArgs e)
        {
            groupBoxData.Visible = false;
            dataTable.RowHeadersVisible = false;
            
            foreach (var keyValuePair in _engineTypes)
            {
                comboBoxCarType.Items.Add(keyValuePair.Key);
            }

            dataTable.RowsDefaultCellStyle.Alignment 
                = DataGridViewContentAlignment.MiddleCenter;

            this.MaximizeBox = false;

            dataTable.Width = 450;
        }
        
        /// <summary>
        /// Click on buttonAdd
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonAddClick(object sender, EventArgs e)
        {
            if (DataTableAddValidation())
            {
                return;
            }
            
            string selectedStateEngine = comboBoxEngineType.SelectedItem.
                ToString();
            try
            {
                var engine = GetEngine(_engineTypes, selectedStateEngine);

                foreach (var keyValue in _engineTypes)
                {
                    if (keyValue.Key == comboBoxCarType.SelectedItem.ToString())
                    {
                        var transport = GetTransport(
                            keyValue.Key,
                             _dataSource.First().ConsumptionPerKm,
                             _dataSource.First().Distance,
                             engine);

                        TransportAdded.Invoke
                            (this, new TransportEventArgs(transport));
                        this.Close();
                    }
                }
            }
            catch (ArgumentException text)
            {
                MessageBoxEvent?.Invoke(text.Message, e);
            }
            catch (Exception text)
            {
                MessageBoxEvent?.Invoke(text.Message, e);
            }  
        }

        /// <summary>
        /// Get selected engine frim dictianory
        /// </summary>
        /// <param name="transportDict">Dictionary with engines</param>
        /// <param name="selectedStateEngine">Selected engine</param>
        /// <returns>EngineType, if engine not in 
        /// dict, return default engine</returns>
        /// //TODO: RSDN(+)
        private EngineType GetEngine(Dictionary<string, List<EngineType>> 
            transportDict, string selectedStateEngine)
        {
            foreach (var keyValuePair in transportDict)
            {
                foreach (var value in keyValuePair.Value)
                {
                    if (selectedStateEngine == value.ToString())
                    {
                        var engine = value;
                        return engine;
                    }
                }
            }
            return EngineType.Default;
        }

        /// <summary>
        /// Click on buttonRandomData
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonRandomDataClick(object sender, EventArgs e)
        {
            var rnd = new Random();
            
            comboBoxCarType.SelectedIndex =
                rnd.Next(comboBoxCarType.Items.Count);

            comboBoxEngineType.SelectedIndex = 
                rnd.Next(comboBoxEngineType.Items.Count);

            _dataSource = new BindingList<TransportProperties>();
            dataTable.DataSource = _dataSource;

            var selectedStateEngine = 
                comboBoxEngineType.SelectedItem.ToString();
            foreach (var keyValue in _engineTypes)
            {
                if (comboBoxCarType.SelectedItem.ToString().
                    ToString() == keyValue.Key)
                {
                    var consuptionPerKm = rnd.Next(1, 50);
                    var distance = rnd.Next(1, 1000);
                    var engine = GetEngine(_engineTypes, selectedStateEngine);

                    var transport = GetTransport
                        (keyValue.Key, consuptionPerKm,
                        distance, engine);

                    _dataSource.Add(new TransportProperties
                        (transport.ConsumptionPerKm, transport.Distance));
                }
            }
        }

        /// <summary>
        /// Create transport
        /// </summary>
        /// <param name="type">Selected item in comboBoxCarType</param>
        /// <param name="consuptionPerKm">Consuption per 100 km</param>
        /// <param name="distance">Distance</param>
        /// <param name="engine">Engine type</param>
        /// <returns>Created transport</returns>
        private TransportBase GetTransport(string type, float consuptionPerKm, 
            float distance, EngineType engine)
        {
            //TODO: RSDN(+)
            var constructorDict = new Dictionary<string, Func<TransportBase>>()
            {
                { nameof(Car), () =>
                { return new Car(consuptionPerKm, distance, engine); }
                },
                { nameof(Hybrid), () =>
                { return new Hybrid(consuptionPerKm, distance, engine); }
                },
                { nameof(Helicopter), () =>
                { return new Helicopter(consuptionPerKm, distance, engine); }
                }
            };
            return constructorDict[type].Invoke();
        }
        
        /// <summary>
        /// Event of close form
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void AddFormFormClosed
            (object sender, FormClosedEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }
        
        /// <summary>
        /// Validation dataTable comboBox
        /// </summary>
        private bool DataTableAddValidation()
        {
            //TODO: EventArgs.Empty(+)
            if (comboBoxCarType.SelectedIndex == -1)
            {
                MessageBoxEvent?.Invoke
                    ("You must choose type of transport", EventArgs.Empty);
                return true;
            }

            if (comboBoxEngineType.SelectedIndex == -1)
            {
                MessageBoxEvent?.Invoke
                    ("You must choose type of engine", EventArgs.Empty);
                return true;
            }

            foreach (DataGridViewColumn column in dataTable.Columns)
            {
                if (dataTable.Rows[0].Cells[column.Index].Value == null)
                {
                    MessageBoxEvent?.Invoke
                        ("Data in cells must be not null", EventArgs.Empty);
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Combo box changes
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void ComboBoxCarTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            _dataSource = new BindingList<TransportProperties>();
            dataTable.DataSource = _dataSource;
            _dataSource.Add(TransportProperties.EmptyInstance());
            groupBoxData.Visible = true;

            foreach (DataGridViewColumn column in dataTable.Columns)
            {
                column.Width = dataTable.Width / dataTable.ColumnCount;
            }

            comboBoxEngineType.Items.Clear();
            foreach (var valuePair in _engineTypes)
            {
                if (comboBoxCarType.SelectedItem.ToString() != 
                    valuePair.Key) continue;
                
                foreach (var engine in valuePair.Value)
                {
                    comboBoxEngineType.Items.Add(engine.ToString());
                }
            }
        }
        
        /// <summary>
        /// DataTableCellMouseLeave
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void DataTableCellMouseLeave
            (object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.FormattedValue as string))
            {
                e.Cancel = true;
                MessageBoxEvent?.Invoke
                    ($"Data in {e.ColumnIndex + 1} cell must be not null", e);
            }
            else if (int.TryParse(e.FormattedValue as string, out int intValue))
            {
                if (intValue < 0)
                {
                    e.Cancel = true;
                    MessageBoxEvent?.Invoke
                        ($"Data in {e.ColumnIndex + 1} cell must be positive", e);
                }
            }
            else if (!float.TryParse
                (e.FormattedValue as string, out float floatValue))
            {
                e.Cancel = true;
                MessageBoxEvent?.Invoke
                        ($"Data in {e.ColumnIndex + 1} cell must be float", e);
            }
            else if (floatValue < 0F)
            {
                e.Cancel = true;
                MessageBoxEvent?.Invoke
                    ($"Data in {e.ColumnIndex + 1} cell must be positive", e);
            }
        }
    }
}
