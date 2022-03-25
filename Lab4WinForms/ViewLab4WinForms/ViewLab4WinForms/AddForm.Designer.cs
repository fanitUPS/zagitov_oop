
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
            this.dataGridViewAddData = new System.Windows.Forms.DataGridView();
            this.comboBoxTransportType = new System.Windows.Forms.ComboBox();
            this.comboBoxEngineType = new System.Windows.Forms.ComboBox();
            this.labelEngineType = new System.Windows.Forms.Label();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRandomData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddData)).BeginInit();
            this.groupBoxData.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(112, 171);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // dataGridViewAddData
            // 
            this.dataGridViewAddData.AllowUserToDeleteRows = false;
            this.dataGridViewAddData.AllowUserToResizeColumns = false;
            this.dataGridViewAddData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddData.Location = new System.Drawing.Point(133, 29);
            this.dataGridViewAddData.Name = "dataGridViewAddData";
            this.dataGridViewAddData.RowHeadersWidth = 25;
            this.dataGridViewAddData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewAddData.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewAddData.Size = new System.Drawing.Size(291, 43);
            this.dataGridViewAddData.TabIndex = 1;
            // 
            // comboBoxTransportType
            // 
            this.comboBoxTransportType.FormattingEnabled = true;
            this.comboBoxTransportType.Location = new System.Drawing.Point(31, 39);
            this.comboBoxTransportType.Name = "comboBoxTransportType";
            this.comboBoxTransportType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTransportType.TabIndex = 2;
            this.comboBoxTransportType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransportType_SelectedIndexChanged);
            // 
            // comboBoxEngineType
            // 
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
            this.groupBoxData.Controls.Add(this.dataGridViewAddData);
            this.groupBoxData.Controls.Add(this.labelEngineType);
            this.groupBoxData.Controls.Add(this.comboBoxEngineType);
            this.groupBoxData.Location = new System.Drawing.Point(31, 76);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(545, 89);
            this.groupBoxData.TabIndex = 5;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Input data";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(31, 171);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add transport";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Type of transport";
            // 
            // buttonRandomData
            // 
            this.buttonRandomData.Location = new System.Drawing.Point(193, 171);
            this.buttonRandomData.Name = "buttonRandomData";
            this.buttonRandomData.Size = new System.Drawing.Size(79, 23);
            this.buttonRandomData.TabIndex = 8;
            this.buttonRandomData.Text = "Random data";
            this.buttonRandomData.UseVisualStyleBackColor = true;
            this.buttonRandomData.Click += new System.EventHandler(this.buttonRandomData_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 206);
            this.Controls.Add(this.buttonRandomData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.comboBoxTransportType);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddForm";
            this.Text = "AddTransportForm";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddData)).EndInit();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridView dataGridViewAddData;
        private System.Windows.Forms.ComboBox comboBoxTransportType;
        private System.Windows.Forms.ComboBox comboBoxEngineType;
        private System.Windows.Forms.Label labelEngineType;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRandomData;
    }
}