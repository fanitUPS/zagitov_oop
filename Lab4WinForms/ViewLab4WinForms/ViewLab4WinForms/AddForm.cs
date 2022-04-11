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
        /// Event of close form
        /// </summary>
        internal EventHandler CancelAddForm;

        /// <summary>
        /// Link to main form
        /// </summary>
        private MainForm _mainForm;

        /// <summary>
        /// Dictionary of engine types
        /// </summary>
        private Dictionary<string, EngineType> _engineTypes = 
            new Dictionary<string, EngineType>()
            {
                { "Diesel", EngineType.Diesel },
                { "Electric", EngineType.Electric },
                { "Petrol", EngineType.Petrol },
                { "Hybrid", EngineType.Hybrid },
                { "GasTurbine", EngineType.GasTurbine }
            };

        /// <summary>
        /// List of column names
        /// </summary>
        private List<string> _standardColumnNames =
            new List<string>()
            {
                "consumptionPerKm",
                "distance"
            };

        /// <summary>
        /// AddForm
        /// </summary>
        public AddForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
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
      
        //TODO: строковые ключи(убрал комбобокс на radioButton)
        /// <summary>
        /// AddForm load
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void AddFormLoad(object sender, EventArgs e)
        {
            groupBoxData.Visible = false;
            dataTable.RowHeadersVisible = false;

            foreach (var engine in _engineTypes)
            {
                comboBoxEngineType.Items.Add(engine.Value.ToString());
            }

            dataTable.RowsDefaultCellStyle.Alignment 
                = DataGridViewContentAlignment.MiddleCenter;
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

            dataTable.Columns[0].Width = 150;
            dataTable.Columns[1].Width = 55;
        }

        /// <summary>
        /// Add special columns for classes
        /// </summary>
        /// <param name="tableWidth">Width of table</param>
        /// <param name="columnName">Column name</param>
        /// <param name="columnWidth">Column width</param>
        private void AddSpecialColumn
            (int tableWidth, string columnName, int columnWidth)
        {
            dataTable.Width = tableWidth;
            dataTable.Columns.Add(columnName,
                columnName);
            dataTable.Columns[2].Width = columnWidth;
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
                var engine = _engineTypes[selectedStateEngine];
                var consumptionPerKm = GetFloatValue(0);
                var distance = GetFloatValue(1);
                if (radioButtonCar.Checked)
                {
                    var tank = GetFloatValue(2);

                    TransportAdded.Invoke(this, new TransportEventArgs
                        (new Car(consumptionPerKm, distance, engine, tank)));

                    this.Close();
                }

                if (radioButtonHybrid.Checked)
                {
                    var percentOnElectric = GetFloatValue(2);

                    TransportAdded.Invoke(this, new TransportEventArgs
                        (new Hybrid(consumptionPerKm, distance, engine, percentOnElectric)));

                    this.Close();
                }

                if (radioButtonHelicopter.Checked)
                {
                    var load = GetFloatValue(2);

                    TransportAdded.Invoke(this, new TransportEventArgs
                        (new Helicopter(consumptionPerKm, distance, engine, load)));

                    this.Close();
                }
            }
            catch (ArgumentException text)
            {
                _mainForm.ErrorMessageBox(text.Message);
            }
        }
        
        /// <summary>
        /// Click on buttonRandomData
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonRandomDataClick(object sender, EventArgs e)
        {
            if (!radioButtonCar.Checked &&
                !radioButtonHelicopter.Checked &&
                !radioButtonHybrid.Checked)
            {
                _mainForm.ErrorMessageBox("You must choose type of transport!");
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

            if (radioButtonCar.Checked)
            {
                //TODO:
                var tank = rnd.Next(500);
                var engine = engineDict[rnd.Next(2)];
                dataTable.Rows[0].Cells[2].Value =
                tank.ToString();
                comboBoxEngineType.SelectedIndex = engine;
            }

            if (radioButtonHybrid.Checked)
            {
                //TODO:
                double percentOnElectric = Math.Round(rnd.NextDouble(), 3);
                dataTable.Rows[0].Cells[2].Value = percentOnElectric.ToString();
                comboBoxEngineType.SelectedIndex = 3; //Hybrid engine
            }

            if (radioButtonHelicopter.Checked)
            {
                //TODO:
                var load = rnd.Next(Helicopter.MaxLoad);
                dataTable.Rows[0].Cells["load"].Value = load.ToString();
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
        /// RadioButtonCarCheckedChanged
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void RadioButtonCarCheckedChanged
            (object sender, EventArgs e)
        {
            AddStandartColumn(_standardColumnNames);
            AddSpecialColumn(325, "tank", 120);
        }

        /// <summary>
        /// RadioButtonHybridCheckedChanged
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void RadioButtonHybridCheckedChanged
            (object sender, EventArgs e)
        {  
            AddStandartColumn(_standardColumnNames);
            AddSpecialColumn(405, "percentOnElectric", 200);
        }

        /// <summary>
        /// RadioButtonHelicopterCheckedChanged
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void RadioButtonHelicopterCheckedChanged
            (object sender, EventArgs e)
        {
            AddStandartColumn(_standardColumnNames);
            AddSpecialColumn(335, "load", 130);
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
        /// DataTableCellLeave
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void DataTableCellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                _mainForm.ErrorMessageBox
                    ($"Data in {e.ColumnIndex + 1} cell must be not null!");
                
            }
            else if (int.TryParse(dataTable.Rows[e.RowIndex]
                .Cells[e.ColumnIndex].Value.ToString(), out int _))
            {
                return;
            }
            else if (!float.TryParse(dataTable.Rows[e.RowIndex]
                .Cells[e.ColumnIndex].Value.ToString(), out float _))
            {
                _mainForm.ErrorMessageBox
                        ($"Data in {e.ColumnIndex + 1} cell must be float!");
            }
        }

        /// <summary>
        /// Validation of radioButton and comboBox
        /// </summary>
        private bool DataTableAddValidation()
        {
            if (!radioButtonCar.Checked &&
                !radioButtonHelicopter.Checked &&
                !radioButtonHybrid.Checked)
            {
                _mainForm.ErrorMessageBox("You must choose type of transport!");
                return true;
            }

            if (comboBoxEngineType.SelectedIndex == -1)
            {
                _mainForm.ErrorMessageBox("You must choose type of engine!");
                return true;
            }
            return false;
        }
    }
}
