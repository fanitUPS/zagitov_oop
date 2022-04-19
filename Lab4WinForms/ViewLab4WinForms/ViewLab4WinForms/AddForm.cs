using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ModelLab4WinForms;

namespace ViewLab4WinForms
{
    /// <summary>
    /// Class AddForm
    /// </summary>
    public partial class AddForm : Form
    {
        /// <summary>
        /// Event of AddTransport
        /// </summary>
        internal EventHandler<TransportEventArgs> TransportAdded;

        /// <summary>
        /// Event of close form
        /// </summary>
        internal EventHandler CloseAddForm;

        /// <summary>
        /// EventHandler
        /// </summary>
        internal EventHandler CancelAddForm;

        /// <summary>
        /// EventHandler
        /// </summary>
        internal EventHandler MessageBox;

        /// <summary>
        /// List of column names
        /// </summary>
        private readonly List<string> _standardColumnNames =
            new List<string>()
            {
                "Consumption per 100 km",
                "Distance"
            };

        /// <summary>
        /// Dictionary of engine types
        /// </summary>
        private readonly Dictionary<string, List<EngineType>> _engineTypes = 
            new Dictionary<string, List<EngineType>>()
            {
                { "Car", new List<EngineType>() 
                    { EngineType.Diesel, EngineType.Petrol } },

                { "Hybrid", new List<EngineType>() 
                    { EngineType.Hybrid } },

                { "Helicopter", new List<EngineType>() 
                    { EngineType.GasTurbine } }
            };

        /// <summary>
        /// Width of Data table
        /// </summary>
        private const int _tableWidth = 450;

        /// <summary>
        /// Index of column with consumption
        /// </summary>
        private const int _consumptionColumn = 0;

        /// <summary>
        /// Index of column with distance
        /// </summary>
        private const int _distanceColumn = 1;

        /// <summary>
        /// Index of used row
        /// </summary>
        private const int _row = 0;

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
            CancelAddForm?.Invoke(sender, e);
        }

        /// <summary>
        /// Add common column for classes
        /// </summary>
        private void AddStandardColumn(List<string> columnNames)
        {
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();
            dataTable.Refresh();
            groupBoxData.Visible = true;

            foreach (var name in columnNames)
            {
                dataTable.Columns.Add(name, name);
            }
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

            dataTable.Width = _tableWidth;
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
                    foreach (DataGridViewColumn column in dataTable.Columns)
                    {
                        if (keyValue.Key == comboBoxCarType.SelectedItem.ToString())
                        {
                            float.TryParse
                                (dataTable.Rows[_row].Cells[_consumptionColumn].
                                Value.ToString(), out float consuptionPerKm);

                            float.TryParse
                                (dataTable.Rows[_row].Cells[_distanceColumn].
                                Value.ToString(), out float distance);

                            var transport = GetTransport
                                (keyValue.Key,
                                 consuptionPerKm,
                                 distance,
                                 engine);

                            TransportAdded.Invoke
                                (this, new TransportEventArgs(transport));

                            this.Close();
                        }
                    }
                }
            }
            catch (ArgumentException text)
            {
                MessageBox?.Invoke(text.Message, e);
            }
            catch (Exception text1)
            {
                MessageBox?.Invoke(text1.Message, e);
            }  
        }

        /// <summary>
        /// Get selected engine frim dictianory
        /// </summary>
        /// <param name="transportDict">Dictionary with engines</param>
        /// <param name="selectedStateEngine">Selected engine</param>
        /// <returns>EngineType, if engine not in dict, return default engine</returns>
        /// //TODO: RSDN
        private EngineType GetEngine(Dictionary<string, List<EngineType>> transportDict, string selectedStateEngine)
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

                    dataTable.Rows[_row].Cells[_consumptionColumn].Value = 
                        transport.ConsumptionPerKm.ToString();

                    dataTable.Rows[_row].Cells[_distanceColumn].Value = 
                        transport.Distance.ToString();
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
            //TODO: RSDN
            var _constructorDict = new Dictionary<string, Func<TransportBase>>()
            {
                { "Car", () =>
                { return new Car(consuptionPerKm, distance, engine); }
                },
                { "Hybrid", () =>
                { return new Hybrid(consuptionPerKm, distance, engine); }
                },
                { "Helicopter", () =>
                { return new Helicopter(consuptionPerKm, distance, engine); }
                }
            };
            return _constructorDict[type].Invoke();
        }
        
        /// <summary>
        /// Event of close form
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void AddFormFormClosed
            (object sender, FormClosedEventArgs e)
        {
            CloseAddForm?.Invoke(sender, e);
        }
        
        /// <summary>
        /// Validation dataTable comboBox
        /// </summary>
        private bool DataTableAddValidation()
        {
            //TODO: EventArgs.Empty
            if (comboBoxCarType.SelectedIndex == -1)
            {
                MessageBox?.Invoke
                    ("You must choose type of transport", new EventArgs());
                return true;
            }

            if (comboBoxEngineType.SelectedIndex == -1)
            {
                MessageBox?.Invoke
                    ("You must choose type of engine", new EventArgs());
                return true;
            }

            foreach (DataGridViewColumn column in dataTable.Columns)
            {
                if (dataTable.Rows[0].Cells[column.Index].Value == null)
                {
                    MessageBox?.Invoke
                        ("Data in cells must be not null", new EventArgs());
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
            AddStandardColumn(_standardColumnNames);

            comboBoxEngineType.Items.Clear();
            foreach (var valuePair in _engineTypes)
            {
                if (comboBoxCarType.SelectedItem.ToString() != valuePair.Key) continue;
                
                foreach (var engine in valuePair.Value)
                {
                    comboBoxEngineType.Items.Add(engine.ToString());
                }
            }

            foreach (DataGridViewColumn column in dataTable.Columns)
            {
                column.Width = dataTable.Width / dataTable.ColumnCount;
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
                MessageBox?.Invoke
                    ($"Data in {e.ColumnIndex + 1} cell must be not null", e);
            }
            else if (int.TryParse(e.FormattedValue as string, out int intValue))
            {
                if (intValue < 0)
                {
                    e.Cancel = true;
                    MessageBox?.Invoke
                        ($"Data in {e.ColumnIndex + 1} cell must be positive", e);
                }
            }
            else if (!float.TryParse
                (e.FormattedValue as string, out float floatValue))
            {
                e.Cancel = true;
                MessageBox?.Invoke
                        ($"Data in {e.ColumnIndex + 1} cell must be float", e);
            }
            else if (floatValue < 0F)
            {
                e.Cancel = true;
                MessageBox?.Invoke
                    ($"Data in {e.ColumnIndex + 1} cell must be positive", e);
            }
        }
    }
}
