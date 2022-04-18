using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// Dictionary of engine types
        /// </summary>
        private Dictionary<string, List<EngineType>> _engineTypes = 
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
        /// List of column names
        /// </summary>
        private List<string> _standardColumnNames =
            new List<string>()
            {
                "Consumption per 100 km",
                "Distance"
            };

        //TODO: XML
        private List<string> _specialColumnNames =
            new List<string>()
            {
                "Tank",
                "Percent on e-engine",
                "Load"
            };

        //TODO: XML
        private BindingList<TransportBase> _dataSource =
            new BindingList<TransportBase>();

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
        /// Add common column for classes
        /// </summary>
        private void AddStandartColumn(List<string> columnNames)
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
        /// Add special columns for classes
        /// </summary>
        /// <param name="tableWidth">Width of table</param>
        /// <param name="columnName">Column name</param>
        /// <param name="columnWidth">Column width</param>
        private void AddSpecialColumn(string columnName)
        {
            dataTable.Columns.Add(columnName,
                columnName);
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
            /*
            try
            {
                var engine = GetEngine(_engineTypes, selectedStateEngine);
                var consumptionPerKm = GetFloatValue(0);
                var distance = GetFloatValue(1);
                if (comboBoxCarType.SelectedItem.ToString() == "Car")
                {
                    var tank = GetFloatValue(2);

                    TransportAdded.Invoke(this, new TransportEventArgs
                        (new Car(consumptionPerKm, distance, engine, tank)));

                    this.Close();
                }

                if (comboBoxCarType.SelectedItem.ToString() == "Hybrid")
                {
                    var percentOnElectric = GetFloatValue(2);

                    TransportAdded.Invoke(this, new TransportEventArgs
                        (new Hybrid(consumptionPerKm, distance, engine, percentOnElectric)));

                    this.Close();
                }

                if (comboBoxCarType.SelectedItem.ToString() == "Helicopter")
                {
                    var load = GetFloatValue(2);

                    TransportAdded.Invoke(this, new TransportEventArgs
                        (new Helicopter(consumptionPerKm, distance, engine, load)));

                    this.Close();
                }
            }
            catch (ArgumentException text)
            {
                MessageBox?.Invoke(text.Message, e);
            }
            */
        }

        /// <summary>
        /// Get selected engine frim dictianory
        /// </summary>
        /// <param name="transportDict">Dictionary with engines</param>
        /// <param name="selectedStateEngine">Selected engine</param>
        /// <returns>EngineType, if engine not in dict, return default engine</returns>
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

            comboBoxCarType.SelectedIndex = rnd.Next(comboBoxCarType.Items.Count);

            var consuptionPerKm = rnd.Next(1, 50);
            var distance = rnd.Next(1, 1000);

            //TODO:
            dataTable.Rows[0].Cells[0].Value =
               consuptionPerKm.ToString();
            dataTable.Rows[0].Cells[1].Value =
               distance.ToString();

            foreach (var keyValue in _constructorDict)
            {
                if (comboBoxCarType.SelectedItem.ToString() == keyValue.Key)
                {
                    keyValue.Value.Invoke();

                }
            }

            if (comboBoxCarType.SelectedItem.ToString() == "Car")
            {
                //TODO:
                var tank = rnd.Next(500);
                dataTable.Rows[0].Cells[2].Value =
                tank.ToString();
                comboBoxEngineType.SelectedIndex = rnd.Next(2);
            }

            if (comboBoxCarType.SelectedItem.ToString() == "Hybrid")
            {
                //TODO:
                double percentOnElectric = Math.Round(rnd.NextDouble(), 3);
                dataTable.Rows[0].Cells[2].Value = percentOnElectric.ToString();
                comboBoxEngineType.SelectedIndex = 0; //Hybrid engine
            }

            if (comboBoxCarType.SelectedItem.ToString() == "Helicopter")
            {
                //TODO:
                var load = rnd.Next(Helicopter.MaxLoad);
                dataTable.Rows[0].Cells[2].Value = load.ToString();
                comboBoxEngineType.SelectedIndex = 0; //Helicopter engine
            }
        }

        /// <summary>
        /// Create transport
        /// </summary>
        /// <param name="type">Selectet item in comboBoxCarType</param>
        /// <param name="consuptionPerKm">consuptionPerKm</param>
        /// <param name="distance">distance</param>
        /// <param name="specialAttribute">specialAttribute</param>
        /// <param name="engine">engine</param>
        /// <returns>Transport</returns>
        private void GetTransport(string type, float consuptionPerKm, 
            float distance, float specialAttribute, EngineType engine)
        {
            TransportBase transport;
            //TODO: func
            Dictionary<string, Action> _constructorDict =
                new Dictionary<string, Action>()
            {
                { "Car", () => {transport = new Car(consuptionPerKm, distance, engine, specialAttribute); } },
                { "Hybrid", () => {transport = new Hybrid(consuptionPerKm, distance, engine, specialAttribute); } },
                { "Helicopter", () => {transport = new Helicopter(consuptionPerKm, distance, engine, specialAttribute); }}
            };

            _constructorDict[type].Invoke();
            _dataSource.Add(transport); 
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
        /// Validation of radioButton and comboBox
        /// </summary>
        private bool DataTableAddValidation()
        {
            if (comboBoxCarType.SelectedIndex == -1)
            {
                MessageBox?.Invoke("You must choose type of transport", new EventArgs());
                return true;
            }

            if (comboBoxEngineType.SelectedIndex == -1)
            {
                MessageBox?.Invoke("You must choose type of engine", new EventArgs());
                return true;
            }
            foreach (DataGridViewColumn column in dataTable.Columns)
            {
                if (dataTable.Rows[0].Cells[column.Index].Value == null)
                {
                    MessageBox?.Invoke("Data in cells must be not null", new EventArgs());
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
            AddStandartColumn(_standardColumnNames);
            comboBoxEngineType.Items.Clear();
            int i = 0;
            foreach (var keyValuePair in _engineTypes)
            {
                if (comboBoxCarType.SelectedItem.ToString() == keyValuePair.Key)
                {
                    AddSpecialColumn(_specialColumnNames[i]);
                }
                i++;
            }

            foreach (var valuePair in _engineTypes)
            {
                if (comboBoxCarType.SelectedItem.ToString() == valuePair.Key)
                {
                    foreach (var engine in valuePair.Value)
                    {
                        comboBoxEngineType.Items.Add(engine.ToString());
                    }
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
        private void DataTableCellMouseLeave(object sender, DataGridViewCellValidatingEventArgs e)
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
            else if (!float.TryParse(e.FormattedValue as string, out float floatValue))
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
