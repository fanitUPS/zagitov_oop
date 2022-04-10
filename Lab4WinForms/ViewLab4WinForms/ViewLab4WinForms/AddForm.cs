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

        private Dictionary<EngineType, string> _engineTypes = 
            new Dictionary<EngineType, string>()
            {
                { EngineType.Diesel, "Diesel"  },
                { EngineType.Electric, "Electric" },
                { EngineType.Petrol ,"Petrol" },
                { EngineType.Hybrid, "Hybrid" },
                { EngineType.GasTurbine, "GasTurbine" }
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
            //TODO: нарушение инкапсуляции(+)
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
            //TODO: строковые ключи
            groupBoxData.Visible = false;
            dataGridViewAddData.RowHeadersVisible = false;

            //var engine

            comboBoxEngineType.Items.Add("Diesel");
            comboBoxEngineType.Items.Add("Electric");
            comboBoxEngineType.Items.Add("Petrol");
            comboBoxEngineType.Items.Add("Hybrid");
            comboBoxEngineType.Items.Add("GasTurbine");

            dataGridViewAddData.RowsDefaultCellStyle.Alignment 
                = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Add common column for classes
        /// </summary>
        private void AddStandartColumn()
        {
            dataGridViewAddData.Rows.Clear();
            dataGridViewAddData.Columns.Clear();
            dataGridViewAddData.Refresh();
            groupBoxData.Visible = true;
            //TODO: строковые ключи
            dataGridViewAddData.Columns.Add("consumptionPerKm",
                "Consumption per 100 km");
            dataGridViewAddData.Columns[0].Width = 150;
            dataGridViewAddData.Columns.Add("distance", "Distance");
            dataGridViewAddData.Columns[1].Width = 55;
        }

        private void AddSpecialColumn
            (int tableWidth, string columnName, int columnWidth)
        {
            dataGridViewAddData.Width = tableWidth;
            dataGridViewAddData.Columns.Add(columnName,
                columnName);
            dataGridViewAddData.Columns[2].Width = columnWidth;
        }
        
        /// <summary>
        /// Click on buttonAdd
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonAddClick(object sender, EventArgs e)
        {
            /*
            if (comboBoxTransportType.SelectedIndex == -1)
            {
                _mainForm.ErrorMessageBox("You must choose type of transport!");
                return;
            }

            if (comboBoxEngineType.SelectedIndex == -1)
            {
                _mainForm.ErrorMessageBox("You must choose type of engine!");
                return;
            }

            //TODO: строковые ключи
            if (dataGridViewAddData.Rows[0].Cells["consumptionPerKm"].Value == null
                || dataGridViewAddData.Rows[0].Cells["distance"].Value == null)
            {
                _mainForm.ErrorMessageBox("Data must be not null!");
                return;
            }

            MainForm mainForm = this.Owner as MainForm;

            try
            {
                string selectedStateTransport = comboBoxTransportType.SelectedItem.
                    ToString();
                string selectedStateEngine = comboBoxEngineType.SelectedItem.
                    ToString();

                //TODO: нарушение инкапсуляции
                


                //TODO: строковые ключи
                FloatException(float.TryParse(dataGridViewAddData.Rows[0]
                    .Cells["consumptionPerKm"].Value.ToString(),
                    out float consumptionPerKm));

                FloatException(float.TryParse(dataGridViewAddData.Rows[0]
                    .Cells["distance"].Value.ToString(),
                    out float distance));

                var engine = engineTypes[selectedStateEngine];

                switch (selectedStateTransport)
                {
                    //TODO: строковые ключи
                    case "Car":
                        if (dataGridViewAddData.Rows[0].Cells["tank"].Value == null)
                        {
                            _mainForm.ErrorMessageBox("Data must be not null!");
                            return;
                        }

                        FloatException(float.TryParse(dataGridViewAddData.Rows[0]
                            .Cells["tank"].Value.ToString(), out float tank));
                                              
                        var car = new Car(consumptionPerKm, distance, 
                            engine, tank);
                        
                        //mainForm.TransportList = car;
                        break;

                    case "Hybrid":
                        if (dataGridViewAddData.Rows[0].Cells["percentOnElectric"].Value
                            == null)
                        {
                            _mainForm.ErrorMessageBox("Data must be not null!");
                            return;
                        }

                        FloatException(float.TryParse(dataGridViewAddData.Rows[0]
                            .Cells["percentOnElectric"].Value.ToString(), out float percentOnElectric));

                        var hybrid = new Hybrid(consumptionPerKm, distance, 
                            engine, percentOnElectric);

                        //mainForm.TransportList = hybrid;
                        break;

                    case "Helicopter":
                        if (dataGridViewAddData.Rows[0].Cells["load"].Value == null)
                        {
                            _mainForm.ErrorMessageBox("Data must be not null!");
                            return;
                        }

                        FloatException(float.TryParse(dataGridViewAddData.Rows[0]
                            .Cells["load"].Value.ToString(), out float load));

                        var helicopter = new Helicopter(consumptionPerKm, distance,
                            engine, load);

                        //mainForm.TransportList = helicopter;
                        break;
                }
                TransportAdded.Invoke(this, new TransportEventArgs(new Car()));
                mainForm.Show();
                this.Close();

            }
            catch (ArgumentException argumentError)
            {
                _mainForm.ErrorMessageBox(argumentError.Message);
            }
            catch (System.NullReferenceException nullError)
            {
                _mainForm.ErrorMessageBox(nullError.Message);
            }
            */
        }
        
        /// <summary>
        /// Throw new Exception
        /// </summary>
        /// <param name="flag">Bool</param>
        internal void FloatException(bool flag)
        {
            if (!flag)
            {
                throw new ArgumentException
                    ("You must input float data!");
            }
        }

        //TODO: RSDN(+)
        /// <summary>
        /// Click on buttonRandomData
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonRandomDataClick(object sender, EventArgs e)
        {
            /*
            if (comboBoxTransportType.SelectedIndex == -1)
            {
                _mainForm.ErrorMessageBox("You must choose type of transport!");
                return;
            }

            string selectedStateTransport = comboBoxTransportType.SelectedItem.
                ToString();

            var engineDict = new Dictionary<int, int>
            {
                {0, 0 }, //Diesel
                {1, 2 }  //Petrol
            };

            var rnd = new Random();

            var consuptionPerKm = rnd.Next(1, 50);
            var distance = rnd.Next(1, 1000);

            dataGridViewAddData.Rows[0].Cells["consumptionPerKm"].Value =
                consuptionPerKm.ToString();
            dataGridViewAddData.Rows[0].Cells["distance"].Value =
               distance.ToString();

            switch (selectedStateTransport)
            {
                //TODO: строковые ключи
                case "Car":
                    var tank = rnd.Next(500);
                    var engine = engineDict[rnd.Next(2)];

                    dataGridViewAddData.Rows[0].Cells["tank"].Value =
                        tank.ToString();
                    comboBoxEngineType.SelectedIndex = engine;
                    break;

                case "Hybrid":
                    double percentOnElectric = Math.Round(rnd.NextDouble(), 3);
                    dataGridViewAddData.Rows[0].Cells["percentOnElectric"].Value =
                        percentOnElectric.ToString();
                    comboBoxEngineType.SelectedIndex = 3; //Hybrid engine
                    break;

                case "Helicopter":
                    var load = rnd.Next(Helicopter.MaxLoad);
                    dataGridViewAddData.Rows[0].Cells["load"].Value = load.ToString();
                    comboBoxEngineType.SelectedIndex = 4; //Helicopter engine
                    break;
            }
            */
        }

        //TODO: duplication(+)
        /// <summary>
        /// Event of close form
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void AddFormFormClosed(object sender, FormClosedEventArgs e)
        {
            CloseAddForm?.Invoke(sender, e);
        }

        private void RadioButtonCarCheckedChanged(object sender, EventArgs e)
        {
            AddStandartColumn();
            AddSpecialColumn(325, "tank", 120);
        }

        private void RadioButtonHybridCheckedChanged(object sender, EventArgs e)
        {  
            AddStandartColumn();
            AddSpecialColumn(405, "percentOnElectric", 200);
        }

        private void RadioButtonHelicopterCheckedChanged(object sender, EventArgs e)
        {
            AddStandartColumn();
            AddSpecialColumn(335, "load", 130);
        }
    }
}
