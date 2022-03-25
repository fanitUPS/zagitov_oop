using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ModelLab4WinForms;

namespace ViewLab4WinForms
{
    public partial class MainForm : Form
    {
        private BindingList<TransportBase> _transportList =
            new BindingList<TransportBase>()
            {
                new Car(7, 550, EngineType.Diesel,500)
            };

        internal TransportBase TransportList
        {
            set
            {
                _transportList.Add(value);
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridViewData.RowHeadersVisible = false;
            dataGridViewData.Width = 466;
            dataGridViewData.DataSource = _transportList;
            dataGridViewData.Columns[0].Width = 150;
            dataGridViewData.Columns[1].Width = 55;
            dataGridViewData.Columns[2].Width = 80;
            dataGridViewData.Columns[3].Width = 80;
            dataGridViewData.Columns.Add("type",
                "Transport type");
            dataGridViewData.Columns[4].Width = 100;


        }

        private void addTransport_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Owner = this;
            addForm.Show();
            this.Hide();
        }

        private void buttonShowTransport_Click(object sender, EventArgs e)
        {
            var transportTypeDict = new Dictionary<string, string>
            {
                {"ModelLab4WinForms.Car", "Car" },
                {"ModelLab4WinForms.Hybrid", "Hybrid" },
                {"ModelLab4WinForms.Helicopter", "Helicopter" }
            };

            for (int i = 0; i < dataGridViewData.Rows.Count; i++)
            {
                dataGridViewData.Rows[i].Cells["type"].Value = 
                    transportTypeDict[_transportList[i].GetType().ToString()];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedIndex = 0;
            for (int i = 0; i < dataGridViewData.Rows.Count; i++)
            {
                if (dataGridViewData.Rows[i].Selected)
                {
                    selectedIndex = i;
                }
                else
                {
                    MessageBox.Show("Removed row doesn't selected",
                                "Error!",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error,
                              MessageBoxDefaultButton.Button1,
                              MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }
            }
            _transportList.RemoveAt(selectedIndex);            
        }
    }
}
