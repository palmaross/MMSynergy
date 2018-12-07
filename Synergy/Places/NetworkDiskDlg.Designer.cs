namespace Places
{
    partial class NetworkDiskDlg
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
            this.lblPlace = new System.Windows.Forms.Label();
            this.txtNetworkDiskName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPlaceNameExists = new System.Windows.Forms.Label();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.btnAddNewDisk = new System.Windows.Forms.Button();
            this.comboDisks = new System.Windows.Forms.ComboBox();
            this.lblChooseND = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(9, 68);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(189, 13);
            this.lblPlace.TabIndex = 0;
            this.lblPlace.Text = "Имя Места на этом сетевом диске:";
            // 
            // txtNetworkDiskName
            // 
            this.txtNetworkDiskName.Location = new System.Drawing.Point(12, 84);
            this.txtNetworkDiskName.Name = "txtNetworkDiskName";
            this.txtNetworkDiskName.Size = new System.Drawing.Size(268, 20);
            this.txtNetworkDiskName.TabIndex = 1;
            this.txtNetworkDiskName.Click += new System.EventHandler(this.txtNetworkDiskName_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(43, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnBack.Location = new System.Drawing.Point(124, 137);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(205, 137);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblPlaceNameExists
            // 
            this.lblPlaceNameExists.AutoSize = true;
            this.lblPlaceNameExists.ForeColor = System.Drawing.Color.Red;
            this.lblPlaceNameExists.Location = new System.Drawing.Point(8, 107);
            this.lblPlaceNameExists.Name = "lblPlaceNameExists";
            this.lblPlaceNameExists.Size = new System.Drawing.Size(59, 13);
            this.lblPlaceNameExists.TabIndex = 9;
            this.lblPlaceNameExists.Text = "placeexists";
            // 
            // btnAddNewDisk
            // 
            this.btnAddNewDisk.Location = new System.Drawing.Point(214, 33);
            this.btnAddNewDisk.Name = "btnAddNewDisk";
            this.btnAddNewDisk.Size = new System.Drawing.Size(68, 23);
            this.btnAddNewDisk.TabIndex = 12;
            this.btnAddNewDisk.Text = "Add";
            this.btnAddNewDisk.UseVisualStyleBackColor = true;
            this.btnAddNewDisk.Click += new System.EventHandler(this.btnAddNewDisk_Click);
            // 
            // comboDisks
            // 
            this.comboDisks.FormattingEnabled = true;
            this.comboDisks.Location = new System.Drawing.Point(12, 33);
            this.comboDisks.Name = "comboDisks";
            this.comboDisks.Size = new System.Drawing.Size(196, 21);
            this.comboDisks.TabIndex = 11;
            // 
            // lblChooseND
            // 
            this.lblChooseND.AutoSize = true;
            this.lblChooseND.Location = new System.Drawing.Point(8, 17);
            this.lblChooseND.Name = "lblChooseND";
            this.lblChooseND.Size = new System.Drawing.Size(237, 13);
            this.lblChooseND.TabIndex = 10;
            this.lblChooseND.Text = "Выберите сетевой диск или добавьте новый:";
            // 
            // NetworkDiskDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 171);
            this.Controls.Add(this.btnAddNewDisk);
            this.Controls.Add(this.comboDisks);
            this.Controls.Add(this.lblChooseND);
            this.Controls.Add(this.lblPlaceNameExists);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtNetworkDiskName);
            this.Controls.Add(this.lblPlace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NetworkDiskDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новое место: имя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.TextBox txtNetworkDiskName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPlaceNameExists;
        private System.Windows.Forms.HelpProvider aHelpProvider;
        private System.Windows.Forms.Button btnAddNewDisk;
        public System.Windows.Forms.ComboBox comboDisks;
        private System.Windows.Forms.Label lblChooseND;
    }
}