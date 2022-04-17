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
        /// List of transport types
        /// </summary>
        private List<string> _carType =
            new List<string>()
            {
                "Car",
                "Hybrid",
                "Helicopter"
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
      
        //TODO: строковые ключи(+)
        /// <summary>
        /// AddForm load
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void AddFormLoad(object sender, EventArgs e)
        {
            groupBoxData.Visible = false;
            dataTable.RowHeadersVisible = false;

            foreach (var car in _carType)
            {
                comboBoxCarType.Items.Add(car);
            }

            dataTable.RowsDefaultCellStyle.Alignment 
                = DataGridViewContentAlignment.MiddleCenter;

            this.MaximizeBox = false;

            dataTable.Width = 410;
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
            /*
            if (DataTableAddValidation())
            {
                return;
            }

            string selectedStateEngine = comboBoxEngineType.SelectedItem.
                ToString();

            try
            {
                var engine = _engineTypes[selectedStateEngine];
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
        /// Click on buttonRandomData
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonRandomDataClick(object sender, EventArgs e)
        {
            if (comboBoxCarType.SelectedIndex == -1)
            {
                MessageBox?.Invoke("You must choose type of transport!", e);
                return;
            }

            var engineDict = new Dictionary<int, int>
            {
                {0, 0 }, //Diesel
                {1, 2 }  //Petrol
            };

            var rnd = new Random();

            var consuptionPerKm = rnd.Next(1, 50);
            var distance = rnd.Next(1, 1000);
            
            //TODO:
            dataTable.Rows[0].Cells[0].Value =
               consuptionPerKm.ToString();
            dataTable.Rows[0].Cells[1].Value =
               distance.ToString();

            if (comboBoxCarType.SelectedItem.ToString() == "Car")
            {
                //TODO:
                var tank = rnd.Next(500);
                var engine = engineDict[rnd.Next(2)];
                dataTable.Rows[0].Cells[2].Value =
                tank.ToString();
                comboBoxEngineType.SelectedIndex = engine;
            }

            if (comboBoxCarType.SelectedItem.ToString() == "Hybrid")
            {
                //TODO:
                double percentOnElectric = Math.Round(rnd.NextDouble(), 3);
                dataTable.Rows[0].Cells[2].Value = percentOnElectric.ToString();
                comboBoxEngineType.SelectedIndex = 3; //Hybrid engine
            }

            if (comboBoxCarType.SelectedItem.ToString() == "Helicopter")
            {
                //TODO:
                var load = rnd.Next(Helicopter.MaxLoad);
                dataTable.Rows[0].Cells[2].Value = load.ToString();
                comboBoxEngineType.SelectedIndex = 4; //Helicopter engine
            }
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
        /// Try parse float value
        /// </summary>
        /// <param name="indexColumn">index of column with number</param>
        /// <returns>Float value</returns>
        private float GetFloatValue(int indexColumn)
        {
            if (dataTable.Rows[0].Cells[indexColumn].Value == null)
            {
                throw new ArgumentException
                    ($"Data in {indexColumn + 1} cell must be float!");
            }

            float.TryParse(dataTable.Rows[0].Cells[indexColumn].Value.ToString(),
                out float value);
            return value;
        }

        /// <summary>
        /// Validation of radioButton and comboBox
        /// </summary>
        private bool DataTableAddValidation()
        {
            if (comboBoxCarType.SelectedIndex == -1)
            {
                MessageBox?.Invoke("You must choose type of transport!", new EventArgs());
                return true;
            }

            if (comboBoxEngineType.SelectedIndex == -1)
            {
                MessageBox?.Invoke("You must choose type of engine!", new EventArgs());
                return true;
            }
            return false;
        }

        private void comboBoxCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddStandartColumn(_standardColumnNames);
            comboBoxEngineType.Items.Clear();
            if (comboBoxCarType.SelectedItem.ToString() == "Car")
            {
                AddSpecialColumn("Tank");
            }

            if (comboBoxCarType.SelectedItem.ToString() == "Hybrid")
            {
                AddSpecialColumn("Percent on electric engine");
            }

            if (comboBoxCarType.SelectedItem.ToString() == "Helicopter")
            {
                AddSpecialColumn("Load");
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
        }

        private void dataTable_CellMouseLeave(object sender, DataGridViewCellValidatingEventArgs e)
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
        }
    }
}
