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
        /// AddForm
        /// </summary>
        public AddForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clicl on cancelButton
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        internal void cancelButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = this.Owner as MainForm;
            mainForm.Show();
            this.Close();
        }

        /// <summary>
        /// Change comboBox
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void comboBoxTransportType_SelectedIndexChanged(object sender,
            EventArgs e)
        {
            dataGridViewAddData.RowHeadersVisible = false;

            string selectedState = comboBoxTransportType.SelectedItem.
                ToString();

            switch (selectedState)
            {
                case "Car":
                    groupBoxData.Visible = true;
                    AddStandartColumn();
   
                    dataGridViewAddData.Width = 325;
                    dataGridViewAddData.Columns.Add("tank",
                        "Gas tank volume");
                    dataGridViewAddData.Columns[2].Width = 120;
                    break;

                case "Hybrid":
                    groupBoxData.Visible = true;
                    AddStandartColumn();

                    dataGridViewAddData.Width = 405;
                    dataGridViewAddData.Columns.Add("percentOnElectric",
                        "Percent distance on electric engine");
                    dataGridViewAddData.Columns[2].Width = 200;
                    break;

                case "Helicopter":
                    groupBoxData.Visible = true;
                    AddStandartColumn();

                    dataGridViewAddData.Width = 335;
                    dataGridViewAddData.Columns.Add("load",
                        "Load of helicopter");
                    dataGridViewAddData.Columns[2].Width = 130;
                    break;
            }
        }

        /// <summary>
        /// AddForm load
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void AddForm_Load(object sender, EventArgs e)
        {
            comboBoxTransportType.Items.Add("Car");
            comboBoxTransportType.Items.Add("Hybrid");
            comboBoxTransportType.Items.Add("Helicopter");

            groupBoxData.Visible = false;

            comboBoxEngineType.Items.Add("Diesel");
            comboBoxEngineType.Items.Add("Electric");
            comboBoxEngineType.Items.Add("Petrol");
            comboBoxEngineType.Items.Add("Hybrid");
            comboBoxEngineType.Items.Add("GasTurbine");
        }

        /// <summary>
        /// Add common column for classes
        /// </summary>
        private void AddStandartColumn()
        {
            dataGridViewAddData.Rows.Clear();
            dataGridViewAddData.Columns.Clear();
            dataGridViewAddData.Refresh();

            dataGridViewAddData.Columns.Add("consumptionPerKm",
                "Consumption per 100 km");
            dataGridViewAddData.Columns[0].Width = 150;
            dataGridViewAddData.Columns.Add("distance", "Distance");
            dataGridViewAddData.Columns[1].Width = 55;
        }

        /// <summary>
        /// Click on buttonAdd
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxTransportType.SelectedIndex == -1)
            {
                ErrorMessageBox("You must choose type of transport!");
                return;
            }

            if (comboBoxEngineType.SelectedIndex == -1)
            {
                ErrorMessageBox("You must choose type of engine!");
                return;
            }

            if (dataGridViewAddData.Rows[0].Cells["consumptionPerKm"].Value == null
                || dataGridViewAddData.Rows[0].Cells["distance"].Value == null)
            {
                ErrorMessageBox("Data must be not null!");
                return;
            }

            MainForm mainForm = this.Owner as MainForm;

            try
            {
                string selectedStateTransport = comboBoxTransportType.SelectedItem.
                    ToString();
                string selectedStateEngine = comboBoxEngineType.SelectedItem.
                    ToString();

                var engineTypes = new Dictionary<string, EngineType>()
                {
                    { "Diesel", EngineType.Diesel },
                    { "Electric", EngineType.Electric },
                    { "Petrol", EngineType.Petrol },
                    { "Hybrid", EngineType.Hybrid },
                    { "GasTurbine", EngineType.GasTurbine }
                };

                float consumptionPerKm;
                float distance;
                float tank;
                float percentOnElectric;
                float load;

                FloatException(float.TryParse(dataGridViewAddData.Rows[0]
                    .Cells["consumptionPerKm"].Value.ToString(),
                    out consumptionPerKm));

                FloatException(float.TryParse(dataGridViewAddData.Rows[0]
                    .Cells["distance"].Value.ToString(),
                    out distance));

                var engine = engineTypes[selectedStateEngine];

                switch (selectedStateTransport)
                {
                    case "Car":
                        if (dataGridViewAddData.Rows[0].Cells["tank"].Value == null)
                        {
                            ErrorMessageBox("Data must be not null!");
                            return;
                        }

                        FloatException(float.TryParse(dataGridViewAddData.Rows[0]
                            .Cells["tank"].Value.ToString(), out tank));
                                              
                        var car = new Car(consumptionPerKm, distance, 
                            engine, tank);
                        
                        mainForm.TransportList = car;
                        break;

                    case "Hybrid":
                        if (dataGridViewAddData.Rows[0].Cells["percentOnElectric"].Value
                            == null)
                        {
                            ErrorMessageBox("Data must be not null!");
                            return;
                        }

                        FloatException(float.TryParse(dataGridViewAddData.Rows[0]
                            .Cells["percentOnElectric"].Value.ToString(), out percentOnElectric));

                        var hybrid = new Hybrid(consumptionPerKm, distance, 
                            engine, percentOnElectric);

                        mainForm.TransportList = hybrid;
                        break;

                    case "Helicopter":
                        if (dataGridViewAddData.Rows[0].Cells["load"].Value == null)
                        {
                            ErrorMessageBox("Data must be not null!");
                            return;
                        }

                        FloatException(float.TryParse(dataGridViewAddData.Rows[0]
                            .Cells["load"].Value.ToString(), out load));

                        var helicopter = new Helicopter(consumptionPerKm, distance,
                            engine, load);

                        mainForm.TransportList = helicopter;
                        break;
                }

                mainForm.Show();
                this.Close();
            }
            catch (ArgumentException argumentError)
            {
                ErrorMessageBox(argumentError.Message);
            }
            catch (System.NullReferenceException nullError)
            {
                ErrorMessageBox(nullError.Message);
            }
            
        }

        /// <summary>
        /// Throw new Exception
        /// </summary>
        /// <param name="flag">Bool</param>
        private void FloatException(bool flag)
        {
            if (!flag)
            {
                throw new ArgumentException
                    ("You must input float data!");
            }
        }

        /// <summary>
        /// Click on buttonRandomData
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void buttonRandomData_Click(object sender, EventArgs e)
        {
            string selectedStateTransport = comboBoxTransportType.SelectedItem.
                ToString();

            var engineDict = new Dictionary<int, int>
            {
                {0, 0 }, //Diesel
                {1, 2 }  //Petrol
            };

            var rnd = new Random();

            var consuptionPerKm = rnd.Next(50);
            var distance = rnd.Next(1000);

            dataGridViewAddData.Rows[0].Cells["consumptionPerKm"].Value =
                consuptionPerKm.ToString();
            dataGridViewAddData.Rows[0].Cells["distance"].Value =
               distance.ToString();

            switch (selectedStateTransport)
            {
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
        }

        /// <summary>
        /// Show MessageBox
        /// </summary>
        /// <param name="text">Text of error</param>
        private void ErrorMessageBox(string text)
        {
            MessageBox.Show(text,
                        "Error!",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
