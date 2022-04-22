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
        internal EventHandler MessageBox;

        /// <summary>
        /// EventHandler
        /// </summary>
        internal EventHandler CancelSearchForm;

        /// <summary>
        /// DataSource
        /// </summary>
        private readonly BindingList<TransportBase> _dataSource;

        /// <summary>
        /// InitializeComponent of SearchForm
        /// </summary>
        public SearchForm(BindingList<TransportBase> dataSource)
        {
            InitializeComponent();
            _dataSource = dataSource;
        }

        /// <summary>
        /// SearchForm load event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void SearchFormLoad(object sender, EventArgs e)
        {
            dataGridViewSearch.RowsDefaultCellStyle.Alignment
                = DataGridViewContentAlignment.MiddleCenter;
           
            dataGridViewSearch.RowHeadersVisible = false;
            dataGridViewSearch.Width = 466;
            dataGridViewSearch.DataSource = _dataSource;
            dataGridViewSearch.Columns[0].Width = 150;
            dataGridViewSearch.Columns[1].Width = 55;
            dataGridViewSearch.Columns[2].Width = 80;
            dataGridViewSearch.Columns[3].Width = 80;
            dataGridViewSearch.Columns[4].Width = 100;

            foreach (DataGridViewColumn col in dataGridViewSearch.Columns)
            {
                comboBoxSearch.Items.Add(col.Name);
            }

            this.MaximizeBox = false;
        }
        
        /// <summary>
        /// Click on buttonCancel 
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            CancelSearchForm?.Invoke(sender, e);
        }
        
        /// <summary>
        /// Click on buttonSearch 
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonSearchClick(object sender, EventArgs e)
        {
            var selectedState = "";
            if (comboBoxSearch.SelectedIndex != -1)
            {
                selectedState = comboBoxSearch.SelectedItem.ToString();
                SearchObject(textBoxValue.Text, selectedState); 
            }
            else
            {
                MessageBox?.Invoke("Choose item in comboBox", e);
            }
        }

        /// <summary>
        /// Search object in DataGridView
        /// </summary>
        /// <param name="value">Seach value</param>
        /// <param name="property">Search column</param>
        private void SearchObject(string value, string property)
        {
            dataGridViewSearch.DataSource = _dataSource;

            var foundTransport = new List<TransportBase>();
            if (_dataSource.Count == 0)
            {
                MessageBox?.Invoke("Table empty", EventArgs.Empty);
            }
            
            foreach (var transport in _dataSource)
            {
                if (typeof(TransportBase).GetProperty(property).
                    GetValue(transport).ToString() == value)
                {
                    foundTransport.Add(transport);
                }
            }

            dataGridViewSearch.DataSource = foundTransport;
        }

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
