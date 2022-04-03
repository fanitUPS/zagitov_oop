using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using ModelLab4WinForms;

namespace ViewLab4WinForms
{
    /// <summary>
    /// Class MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// List of BaseTransport
        /// </summary>
        private BindingList<TransportBase> _transportList =
            new BindingList<TransportBase>()
            {
                new Car(8, 550, EngineType.Diesel,500),
                new Hybrid(10, 333, EngineType.Hybrid, 0.5F),
                new Helicopter(200, 1000, EngineType.GasTurbine, 1000)
            };

        internal BindingList<TransportBase> GetTransportBases
        {
            get => _transportList;
        }

        /// <summary>
        /// Add Transport in list
        /// </summary>
        internal TransportBase TransportList
        {
            set
            {
                _transportList.Add(value);
            }
        }

        /// <summary>
        /// MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load of MainForm
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridViewData.RowHeadersVisible = false;
            dataGridViewData.Width = 466;
            dataGridViewData.Columns.Add("type",
                "Transport type");
            dataGridViewData.Columns[0].Width = 100;
            dataGridViewData.DataSource = _transportList;
            dataGridViewData.Columns[1].Width = 150;
            dataGridViewData.Columns[2].Width = 55;
            dataGridViewData.Columns[3].Width = 80;
            dataGridViewData.Columns[4].Width = 80;
            dataGridViewData.RowsDefaultCellStyle.Alignment 
                = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Click on button addTransport
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void addTransport_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Owner = this;
            addForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Click on button Remove
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void button2_Click(object sender, EventArgs e)
        {
            var selectedIndex = -1;
            for (int i = 0; i < dataGridViewData.Rows.Count; i++)
            {
                if (dataGridViewData.Rows[i].Selected)
                {
                    selectedIndex = i;
                }
            }
            
            if (selectedIndex == -1)
            {
                MessageBox.Show("Removed row doesn't selected",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            
            _transportList.RemoveAt(selectedIndex);            
        }

        /// <summary>
        /// Event click on cell
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void dataGridViewData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewData.Rows[e.RowIndex].Selected = true;
        }

        /// <summary>
        /// Click on buttonSearch
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Owner = this;
            searchForm.Show();
            this.Hide();
        }

        /// <summary>
        /// DataBindingComplete
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void dataGridViewData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridViewData.Rows.Count; i++)
            {
                dataGridViewData.Rows[i].Cells["type"].Value =
                    _transportList[i].Type;
            }
        }

        /// <summary>
        /// Click on buttonSave
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            var fileBrowser = new SaveFileDialog();
            fileBrowser.Filter = "TransportBase (*.trnbs)|*.trnbs";
            fileBrowser.ShowDialog();
            string path = fileBrowser.FileName;

            XmlSerializer xmlSerialaizer = 
                new XmlSerializer(typeof(BindingList<TransportBase>));

            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            
            FileStream fw = new FileStream(path, FileMode.Create);
            xmlSerialaizer.Serialize(fw, _transportList);
            fw.Close();
        }

        /// <summary>
        /// Click on buttonLoad
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var fileBrowser = new OpenFileDialog();
            fileBrowser.Filter = "TransportBase (*.trnbs)|*.trnbs";
            fileBrowser.ShowDialog();

            string path = fileBrowser.FileName;

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            XmlSerializer xmlSerialaizer = 
                new XmlSerializer(typeof(BindingList<TransportBase>));

            FileStream fr = new FileStream(path, FileMode.Open);

            _transportList = (BindingList<TransportBase>)
                xmlSerialaizer.Deserialize(fr);

            fr.Close();
            dataGridViewData.DataSource = _transportList;
        }
    }
}
