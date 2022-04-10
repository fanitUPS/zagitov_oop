
namespace ViewLab4WinForms
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.comboBoxEngineType = new System.Windows.Forms.ComboBox();
            this.labelEngineType = new System.Windows.Forms.Label();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRandomData = new System.Windows.Forms.Button();
            this.radioButtonCar = new System.Windows.Forms.RadioButton();
            this.radioButtonHybrid = new System.Windows.Forms.RadioButton();
            this.radioButtonHelicopter = new System.Windows.Forms.RadioButton();
            this.groupBoxRadioButtons = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.groupBoxData.SuspendLayout();
            this.groupBoxRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(112, 202);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // dataTable
            // 
            this.dataTable.AllowUserToDeleteRows = false;
            this.dataTable.AllowUserToResizeColumns = false;
            this.dataTable.AllowUserToResizeRows = false;
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Location = new System.Drawing.Point(133, 29);
            this.dataTable.Name = "dataTable";
            this.dataTable.RowHeadersWidth = 25;
            this.dataTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataTable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataTable.Size = new System.Drawing.Size(291, 43);
            this.dataTable.TabIndex = 1;
            this.dataTable.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataTableCellLeave);
            // 
            // comboBoxEngineType
            // 
            this.comboBoxEngineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEngineType.FormattingEnabled = true;
            this.comboBoxEngineType.Location = new System.Drawing.Point(6, 51);
            this.comboBoxEngineType.Name = "comboBoxEngineType";
            this.comboBoxEngineType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEngineType.TabIndex = 3;
            // 
            // labelEngineType
            // 
            this.labelEngineType.AutoSize = true;
            this.labelEngineType.Location = new System.Drawing.Point(8, 29);
            this.labelEngineType.Name = "labelEngineType";
            this.labelEngineType.Size = new System.Drawing.Size(67, 13);
            this.labelEngineType.TabIndex = 4;
            this.labelEngineType.Text = "Engine Type";
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.dataTable);
            this.groupBoxData.Controls.Add(this.labelEngineType);
            this.groupBoxData.Controls.Add(this.comboBoxEngineType);
            this.groupBoxData.Location = new System.Drawing.Point(31, 107);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(545, 89);
            this.groupBoxData.TabIndex = 5;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Input data";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(31, 202);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add transport";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Type of transport";
            // 
            // buttonRandomData
            // 
            this.buttonRandomData.Location = new System.Drawing.Point(193, 202);
            this.buttonRandomData.Name = "buttonRandomData";
            this.buttonRandomData.Size = new System.Drawing.Size(79, 23);
            this.buttonRandomData.TabIndex = 8;
            this.buttonRandomData.Text = "Random data";
            this.buttonRandomData.UseVisualStyleBackColor = true;
            this.buttonRandomData.Click += new System.EventHandler(this.ButtonRandomDataClick);
            // 
            // radioButtonCar
            // 
            this.radioButtonCar.AutoSize = true;
            this.radioButtonCar.Location = new System.Drawing.Point(15, 19);
            this.radioButtonCar.Name = "radioButtonCar";
            this.radioButtonCar.Size = new System.Drawing.Size(41, 17);
            this.radioButtonCar.TabIndex = 9;
            this.radioButtonCar.TabStop = true;
            this.radioButtonCar.Text = "Car";
            this.radioButtonCar.UseVisualStyleBackColor = true;
            this.radioButtonCar.CheckedChanged += new System.EventHandler(this.RadioButtonCarCheckedChanged);
            // 
            // radioButtonHybrid
            // 
            this.radioButtonHybrid.AutoSize = true;
            this.radioButtonHybrid.Location = new System.Drawing.Point(71, 19);
            this.radioButtonHybrid.Name = "radioButtonHybrid";
            this.radioButtonHybrid.Size = new System.Drawing.Size(55, 17);
            this.radioButtonHybrid.TabIndex = 10;
            this.radioButtonHybrid.TabStop = true;
            this.radioButtonHybrid.Text = "Hybrid";
            this.radioButtonHybrid.UseVisualStyleBackColor = true;
            this.radioButtonHybrid.CheckedChanged += new System.EventHandler(this.RadioButtonHybridCheckedChanged);
            // 
            // radioButtonHelicopter
            // 
            this.radioButtonHelicopter.AutoSize = true;
            this.radioButtonHelicopter.Location = new System.Drawing.Point(132, 19);
            this.radioButtonHelicopter.Name = "radioButtonHelicopter";
            this.radioButtonHelicopter.Size = new System.Drawing.Size(73, 17);
            this.radioButtonHelicopter.TabIndex = 11;
            this.radioButtonHelicopter.TabStop = true;
            this.radioButtonHelicopter.Text = "Helicopter";
            this.radioButtonHelicopter.UseVisualStyleBackColor = true;
            this.radioButtonHelicopter.CheckedChanged += new System.EventHandler(this.RadioButtonHelicopterCheckedChanged);
            // 
            // groupBoxRadioButtons
            // 
            this.groupBoxRadioButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBoxRadioButtons.Controls.Add(this.radioButtonCar);
            this.groupBoxRadioButtons.Controls.Add(this.radioButtonHelicopter);
            this.groupBoxRadioButtons.Controls.Add(this.radioButtonHybrid);
            this.groupBoxRadioButtons.Location = new System.Drawing.Point(31, 39);
            this.groupBoxRadioButtons.Name = "groupBoxRadioButtons";
            this.groupBoxRadioButtons.Size = new System.Drawing.Size(333, 53);
            this.groupBoxRadioButtons.TabIndex = 12;
            this.groupBoxRadioButtons.TabStop = false;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 237);
            this.Controls.Add(this.groupBoxRadioButtons);
            this.Controls.Add(this.buttonRandomData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddForm";
            this.Text = "AddTransportForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddFormFormClosed);
            this.Load += new System.EventHandler(this.AddFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.groupBoxRadioButtons.ResumeLayout(false);
            this.groupBoxRadioButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.ComboBox comboBoxEngineType;
        private System.Windows.Forms.Label labelEngineType;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRandomData;
        private System.Windows.Forms.RadioButton radioButtonCar;
        private System.Windows.Forms.RadioButton radioButtonHybrid;
        private System.Windows.Forms.RadioButton radioButtonHelicopter;
        private System.Windows.Forms.GroupBox groupBoxRadioButtons;
    }
}