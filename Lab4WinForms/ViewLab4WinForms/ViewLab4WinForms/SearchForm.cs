using ModelLab4WinForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ViewLab4WinForms
{
    public partial class SearchForm : Form
    {
        /// <summary>
        /// InitializeComponent of SearchForm
        /// </summary>
        public SearchForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// SearchForm load event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void SearchForm_Load(object sender, EventArgs e)
        {
            comboBoxSearch.Items.Add("ConsumptionPerKm");
            comboBoxSearch.Items.Add("Distance");
            comboBoxSearch.Items.Add("EngineType");
            comboBoxSearch.Items.Add("Type");
            comboBoxSearch.Items.Add("Consumption");

            dataGridViewSearch.RowsDefaultCellStyle.Alignment
                = DataGridViewContentAlignment.MiddleCenter;
        }

        //TODO: RSDN
        /// <summary>
        /// Click on buttonCancel 
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //TODO: нарушение инкапсуляции
            MainForm mainForm = this.Owner as MainForm;
            mainForm.Show();
            this.Close();
        }

        //TODO: RSDN
        /// <summary>
        /// Click on buttonSearch 
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //TODO:
            var selectedState = "Uknown";

            if (comboBoxSearch.SelectedIndex != -1)
            {
                selectedState = comboBoxSearch.SelectedItem.ToString();
                // if (selectedState == "Uknown")
                // {
                //     ErrorMessageBox("Choose item in comboBox");
                // }
                // else
                // {
                //     SearchObject(textBoxValue.Text, selectedState);
                // }
            }

            switch (selectedState)
            {
                case "ConsumptionPerKm":
                    SearchObject(textBoxValue.Text, "ConsumptionPerKm");
                    break;

                case "Distance":
                    SearchObject(textBoxValue.Text, "Distance");
                    break;

                case "EngineType":
                    SearchObject(textBoxValue.Text, "EngineType");
                    break;

                case "Type":
                    SearchObject(textBoxValue.Text, "Type");
                    break;

                case "Consumption":
                    SearchObject(textBoxValue.Text, "Consumption");
                    break;

                case "Uknown":
                    ErrorMessageBox("Choose item in comboBox");
                    break;
            }
        }

        /// <summary>
        /// Search object in DataGridView
        /// </summary>
        /// <param name="value">Seach value</param>
        /// <param name="columnName">Search column</param>
        private void SearchObject(string value, string columnName)
        {
            //TODO: нарушение инкапсуляции
            MainForm mainForm = this.Owner as MainForm;
            FillDataGridView(mainForm.GetTransportBases);

            for (int i = 0; i < dataGridViewSearch.Rows.Count; i++)
            {
                if (dataGridViewSearch.Rows[i].Cells[columnName]
                    .Value.ToString() != value)
                {
                    dataGridViewSearch.Rows.RemoveAt(i);
                    if (i != 0)
                    {
                        i--;
                    }
                    dataGridViewSearch.Refresh();
                }
            }
        }

        /// <summary>
        /// Fill DataGridView with data from mainForm
        /// </summary>
        /// <param name="source">Data source</param>
        private void FillDataGridView(BindingList<TransportBase> source)
        {
            dataGridViewSearch.Rows.Clear();
            dataGridViewSearch.Columns.Clear();
            dataGridViewSearch.Refresh();

            dataGridViewSearch.RowHeadersVisible = false;
            dataGridViewSearch.Width = 466;

            //TODO: строковые ключи, поубирать
            dataGridViewSearch.Columns.Add
                ("ConsumptionPerKm", "Consumption per 100 km");
            dataGridViewSearch.Columns[0].Width = 150;

            dataGridViewSearch.Columns.Add
                ("Distance", "Distance");
            dataGridViewSearch.Columns[1].Width = 55;

            dataGridViewSearch.Columns.Add
                ("EngineType", "Engine type");
            dataGridViewSearch.Columns[2].Width = 80;

            dataGridViewSearch.Columns.Add
                ("Consumption", "Consumption");
            dataGridViewSearch.Columns[3].Width = 80;

            dataGridViewSearch.Columns.Add
                ("Type", "Transport type");
            dataGridViewSearch.Columns[4].Width = 100;

            for (int i = 0; i < source.Count; i++)
            {
                dataGridViewSearch.Rows.Add();
            }

            //TODO: строковые ключи, поубирать
            for (int i = 0; i < dataGridViewSearch.Rows.Count; i++)
            {
                dataGridViewSearch.Rows[i].Cells["ConsumptionPerKm"].Value =
                    source[i].ConsumptionPerKm;
                dataGridViewSearch.Rows[i].Cells["Distance"].Value =
                    source[i].Distance;
                dataGridViewSearch.Rows[i].Cells["EngineType"].Value =
                    source[i].EngineType;
                dataGridViewSearch.Rows[i].Cells["Consumption"].Value =
                    source[i].Consumption;
                dataGridViewSearch.Rows[i].Cells["Type"].Value =
                    source[i].Type;
            }
        }

        //TODO: duplication
        /// <summary>
        /// Show MessageBox
        /// </summary>
        /// <param name="text">Text of error</param>
        internal void ErrorMessageBox(string text)
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
