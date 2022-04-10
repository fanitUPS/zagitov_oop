using ModelLab4WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ViewLab4WinForms
{
    public partial class SearchForm : Form
    {
        /// <summary>
        /// EventHandler
        /// </summary>
        internal EventHandler CloseSearchForm;

        /// <summary>
        /// EventHandler
        /// </summary>
        internal EventHandler CancelSearchForm;

        /// <summary>
        /// Link to mainForm
        /// </summary>
        private MainForm _mainForm;

        /// <summary>
        /// DataSource
        /// </summary>
        private BindingList<TransportBase> _dataSource = 
            new BindingList<TransportBase>();

        /// <summary>
        /// InitializeComponent of SearchForm
        /// </summary>
        public SearchForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        /// <summary>
        /// SearchForm load event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void SearchFormLoad(object sender, EventArgs e)
        {
            comboBoxSearch.Items.Add("ConsumptionPerKm");
            comboBoxSearch.Items.Add("Distance");
            comboBoxSearch.Items.Add("EngineType");
            comboBoxSearch.Items.Add("Type");
            comboBoxSearch.Items.Add("Consumption");

            dataGridViewSearch.RowsDefaultCellStyle.Alignment
                = DataGridViewContentAlignment.MiddleCenter;

            _mainForm.TransportListEvent += (o, args) =>
            {
                foreach (var transport in args.GetTransportList)
                {
                    _dataSource.Add(transport);
                }    
            };

            dataGridViewSearch.RowHeadersVisible = false;
            dataGridViewSearch.Width = 466;
            dataGridViewSearch.DataSource = _dataSource;    
            dataGridViewSearch.Columns[0].Width = 150;
            dataGridViewSearch.Columns[1].Width = 55;
            dataGridViewSearch.Columns[2].Width = 80;
            dataGridViewSearch.Columns[3].Width = 80;
            dataGridViewSearch.Columns[4].Width = 100;
        }

        //TODO: RSDN(+)
        /// <summary>
        /// Click on buttonCancel 
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            //TODO: нарушение инкапсуляции(+)
            CancelSearchForm?.Invoke(sender, e);
        }

        //TODO: RSDN(+)
        /// <summary>
        /// Click on buttonSearch 
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonSearchClick(object sender, EventArgs e)
        {
            //TODO:(+)
            var selectedState = "";
            if (comboBoxSearch.SelectedIndex != -1)
            {
                selectedState = comboBoxSearch.SelectedItem.ToString();
                SearchObject(textBoxValue.Text, selectedState); 
            }
            else
            {
                _mainForm.ErrorMessageBox("Choose item in comboBox");
            }
        }

        /// <summary>
        /// Search object in DataGridView
        /// </summary>
        /// <param name="value">Seach value</param>
        /// <param name="columnName">Search column</param>
        private void SearchObject(string value, string columnName)
        {
            //TODO: нарушение инкапсуляции(+)
            dataGridViewSearch.DataSource = _dataSource;
            var foundTransport = new List<TransportBase>();

            var indexOfFoundTransport = new List<int>();

            for (int i = 0; i < dataGridViewSearch.Rows.Count; i++)
            {
                if (dataGridViewSearch.Rows[i].Cells[columnName]
                    .Value.ToString() == value)
                {
                    indexOfFoundTransport.Add(i);
                }
            }
            foreach (var index in indexOfFoundTransport)
            {
                foundTransport.Add(_dataSource[index]);
            }
            dataGridViewSearch.DataSource = foundTransport;
        }

        //TODO: duplication(+)

        /// <summary>
        /// Event to close form
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void SearchFormFormClosed(object sender, FormClosedEventArgs e)
        {
            CloseSearchForm?.Invoke(sender, e);
        }
    }
}
