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
        //TODO: XML
        internal EventHandler<GetTransportListEventArgs> TransportListEvent;

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

        /// <summary>
        /// MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Load of MainForm
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void MainFormLoad(object sender, EventArgs e)
        {
            dataGridViewData.RowHeadersVisible = false;
            dataGridViewData.Width = 466;
            
            dataGridViewData.DataSource = _transportList;
            dataGridViewData.Columns[0].Width = 150;
            dataGridViewData.Columns[1].Width = 55;
            dataGridViewData.Columns[2].Width = 80;
            dataGridViewData.Columns[3].Width = 80;
            dataGridViewData.Columns[4].Width = 100;
            dataGridViewData.RowsDefaultCellStyle.Alignment 
                = DataGridViewContentAlignment.MiddleCenter;

            this.MaximizeBox = false;
        }
        
        /// <summary>
        /// Click on button addTransport
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void AddTransportClick(object sender, EventArgs e)
        {
            var addForm = new AddForm();
            addForm.StartPosition = FormStartPosition.CenterScreen;
            addForm.Show();

            this.Hide();
            
            addForm.CloseAddForm += (o, args) =>
            {
                this.Show();
            };

            addForm.CancelAddForm += (o, args) =>
            {
                addForm.Close();
                this.Show();
            };

            addForm.TransportAdded += (o, args) =>
            {
                _transportList.Add(args.Transport);
            };

            addForm.MessageBox += (o, args) =>
            {
                this.ErrorMessageBox(o.ToString());
            };
        }
        
        /// <summary>
        /// Click on button Remove
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonRemoveClick(object sender, EventArgs e)
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
                ErrorMessageBox("Removed row doesn't selected");
                return;
            }
            
            _transportList.RemoveAt(selectedIndex);   
            
            if (dataGridViewData.RowCount != 0)
            {
                dataGridViewData.Rows[0].Selected = true;
            }
        }
        
        /// <summary>
        /// Event click on cell
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void DataGridViewDataCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridViewData.Rows[e.RowIndex].Selected = true;
            }
            catch (ArgumentOutOfRangeException _)
            {
                ErrorMessageBox("Try to choose row instead of a column");
            } 
        }
        
        /// <summary>
        /// Click on buttonSearch
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonSearchClick(object sender, EventArgs e)
        {
            var searchForm = new SearchForm(this);
            searchForm.StartPosition = FormStartPosition.CenterScreen;
            searchForm.Show();
            this.Hide();
            
            searchForm.CloseSearchForm += (o, args) =>
            {
                this.Show();
            };
            
            searchForm.CancelSearchForm += (o, args) =>
            {
                searchForm.Close();
                this.Show();
            };

            TransportListEvent?.Invoke(sender, new GetTransportListEventArgs(_transportList));

            searchForm.MessageBox += (o, args) =>
            {
                this.ErrorMessageBox(o.ToString());
            };
        }

        /// <summary>
        /// Click on buttonSave
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonSaveClick(object sender, EventArgs e)
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

            using (FileStream fileWriter = new FileStream(path, FileMode.Create))
            {
                xmlSerialaizer.Serialize(fileWriter, _transportList);
            };
        }
        
        /// <summary>
        /// Click on buttonLoad
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonLoadClick(object sender, EventArgs e)
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

            try
            {
                //TODO: RSDN(+)
                using (FileStream fileReader = new FileStream(path, FileMode.Open))
                {
                    _transportList = (BindingList<TransportBase>)
                        xmlSerialaizer.Deserialize(fileReader);
                };

                dataGridViewData.DataSource = _transportList;
            }
            catch (InvalidOperationException _)
            {
                ErrorMessageBox("Loaded file damaged");
            }
        }

        //TODO: Нарушение инкапсуляции -> private 
        /// <summary>
        /// Show MessageBox
        /// </summary>
        /// <param name="text">Text of error</param>
        private void ErrorMessageBox(string text)
        {
            MessageBox.Show(this,
                text,
                "Error!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
        }
    }
}
