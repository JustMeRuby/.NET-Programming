
namespace SmartphoneManagement
{
    partial class FrmPhoneManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhoneManagement));
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.btnLoadSQL = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdateSource = new System.Windows.Forms.Button();
            this.dgwPhoneList = new System.Windows.Forms.DataGridView();
            this.picPhoneImage = new System.Windows.Forms.PictureBox();
            this.colSmartPhoneID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSmartPhoneName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSmartPhoneType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnnouncedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlatform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCamera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBattery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPhoneList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoneImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Location = new System.Drawing.Point(12, 12);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(168, 23);
            this.btnLoadExcel.TabIndex = 0;
            this.btnLoadExcel.Text = "Load Data From Excel";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // btnLoadSQL
            // 
            this.btnLoadSQL.Location = new System.Drawing.Point(208, 12);
            this.btnLoadSQL.Name = "btnLoadSQL";
            this.btnLoadSQL.Size = new System.Drawing.Size(168, 23);
            this.btnLoadSQL.TabIndex = 1;
            this.btnLoadSQL.Text = "Load Data From SQL";
            this.btnLoadSQL.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(36, 305);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(117, 305);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(198, 305);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSource
            // 
            this.btnUpdateSource.Location = new System.Drawing.Point(330, 305);
            this.btnUpdateSource.Name = "btnUpdateSource";
            this.btnUpdateSource.Size = new System.Drawing.Size(125, 23);
            this.btnUpdateSource.TabIndex = 5;
            this.btnUpdateSource.Text = "Update to DataSource";
            this.btnUpdateSource.UseVisualStyleBackColor = true;
            // 
            // dgwPhoneList
            // 
            this.dgwPhoneList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPhoneList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSmartPhoneID,
            this.colSmartPhoneName,
            this.colSmartPhoneType,
            this.colAnnouncedDate,
            this.colPlatform,
            this.colCamera,
            this.colRAM,
            this.colBattery,
            this.colPrice});
            this.dgwPhoneList.Location = new System.Drawing.Point(12, 44);
            this.dgwPhoneList.MultiSelect = false;
            this.dgwPhoneList.Name = "dgwPhoneList";
            this.dgwPhoneList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgwPhoneList.Size = new System.Drawing.Size(443, 255);
            this.dgwPhoneList.TabIndex = 6;
            this.dgwPhoneList.SelectionChanged += new System.EventHandler(this.dgwPhoneList_SelectionChanged);
            // 
            // picPhoneImage
            // 
            this.picPhoneImage.Image = ((System.Drawing.Image)(resources.GetObject("picPhoneImage.Image")));
            this.picPhoneImage.Location = new System.Drawing.Point(461, 103);
            this.picPhoneImage.Name = "picPhoneImage";
            this.picPhoneImage.Size = new System.Drawing.Size(205, 144);
            this.picPhoneImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoneImage.TabIndex = 7;
            this.picPhoneImage.TabStop = false;
            // 
            // colSmartPhoneID
            // 
            this.colSmartPhoneID.DataPropertyName = "SmartPhoneID";
            this.colSmartPhoneID.HeaderText = "SmartPhoneID";
            this.colSmartPhoneID.Name = "colSmartPhoneID";
            // 
            // colSmartPhoneName
            // 
            this.colSmartPhoneName.DataPropertyName = "SmartPhoneName";
            this.colSmartPhoneName.HeaderText = "SmartPhone Name";
            this.colSmartPhoneName.Name = "colSmartPhoneName";
            // 
            // colSmartPhoneType
            // 
            this.colSmartPhoneType.DataPropertyName = "SmartPhoneType";
            this.colSmartPhoneType.HeaderText = "SmartPhone Type";
            this.colSmartPhoneType.Name = "colSmartPhoneType";
            // 
            // colAnnouncedDate
            // 
            this.colAnnouncedDate.DataPropertyName = "AnnouncedDate";
            this.colAnnouncedDate.HeaderText = "Announced Date";
            this.colAnnouncedDate.Name = "colAnnouncedDate";
            // 
            // colPlatform
            // 
            this.colPlatform.DataPropertyName = "Platform";
            this.colPlatform.HeaderText = "Platform";
            this.colPlatform.Name = "colPlatform";
            // 
            // colCamera
            // 
            this.colCamera.DataPropertyName = "Camera";
            this.colCamera.HeaderText = "Camera";
            this.colCamera.Name = "colCamera";
            // 
            // colRAM
            // 
            this.colRAM.DataPropertyName = "RAM";
            this.colRAM.HeaderText = "RAM";
            this.colRAM.Name = "colRAM";
            // 
            // colBattery
            // 
            this.colBattery.DataPropertyName = "Battery";
            this.colBattery.HeaderText = "Battery";
            this.colBattery.Name = "colBattery";
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Price";
            this.colPrice.HeaderText = "Price";
            this.colPrice.Name = "colPrice";
            // 
            // FrmPhoneManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 337);
            this.Controls.Add(this.picPhoneImage);
            this.Controls.Add(this.dgwPhoneList);
            this.Controls.Add(this.btnUpdateSource);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLoadSQL);
            this.Controls.Add(this.btnLoadExcel);
            this.Name = "FrmPhoneManagement";
            this.Text = "Phone Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgwPhoneList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoneImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.Button btnLoadSQL;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdateSource;
        private System.Windows.Forms.DataGridView dgwPhoneList;
        private System.Windows.Forms.PictureBox picPhoneImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSmartPhoneID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSmartPhoneName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSmartPhoneType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnnouncedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlatform;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCamera;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBattery;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    }
}

