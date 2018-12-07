namespace Places
{
    partial class CloudStorageDlg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloudStorageDlg));
            this.lblChooseStorage = new System.Windows.Forms.Label();
            this.comboStorageName = new System.Windows.Forms.ComboBox();
            this.btnAddNewStorage = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPlaceName = new System.Windows.Forms.Label();
            this.txtPlaceName = new System.Windows.Forms.TextBox();
            this.help = new System.Windows.Forms.PictureBox();
            this.tltPlaceName = new System.Windows.Forms.ToolTip(this.components);
            this.lblPlaceNameExists = new System.Windows.Forms.Label();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.help)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChooseStorage
            // 
            this.lblChooseStorage.AutoSize = true;
            this.lblChooseStorage.Location = new System.Drawing.Point(8, 17);
            this.lblChooseStorage.Name = "lblChooseStorage";
            this.lblChooseStorage.Size = new System.Drawing.Size(273, 13);
            this.lblChooseStorage.TabIndex = 0;
            this.lblChooseStorage.Text = "Выберите облачное хранилище или добавьте новое:";
            // 
            // comboStorageName
            // 
            this.comboStorageName.FormattingEnabled = true;
            this.comboStorageName.Location = new System.Drawing.Point(12, 33);
            this.comboStorageName.Name = "comboStorageName";
            this.comboStorageName.Size = new System.Drawing.Size(196, 21);
            this.comboStorageName.TabIndex = 1;
            this.comboStorageName.SelectedIndexChanged += new System.EventHandler(this.comboStorageName_SelectedIndexChanged);
            // 
            // btnAddNewStorage
            // 
            this.btnAddNewStorage.Location = new System.Drawing.Point(214, 32);
            this.btnAddNewStorage.Name = "btnAddNewStorage";
            this.btnAddNewStorage.Size = new System.Drawing.Size(68, 23);
            this.btnAddNewStorage.TabIndex = 2;
            this.btnAddNewStorage.Text = "Add";
            this.btnAddNewStorage.UseVisualStyleBackColor = true;
            this.btnAddNewStorage.Click += new System.EventHandler(this.btnAddNewStorage_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(207, 136);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnBack.Location = new System.Drawing.Point(126, 136);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(45, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblPlaceName
            // 
            this.lblPlaceName.AutoSize = true;
            this.lblPlaceName.Location = new System.Drawing.Point(9, 68);
            this.lblPlaceName.Name = "lblPlaceName";
            this.lblPlaceName.Size = new System.Drawing.Size(158, 13);
            this.lblPlaceName.TabIndex = 6;
            this.lblPlaceName.Text = "Это Место будет называться:";
            // 
            // txtPlaceName
            // 
            this.txtPlaceName.Location = new System.Drawing.Point(12, 84);
            this.txtPlaceName.Name = "txtPlaceName";
            this.txtPlaceName.Size = new System.Drawing.Size(270, 20);
            this.txtPlaceName.TabIndex = 7;
            this.txtPlaceName.Click += new System.EventHandler(this.txtPlaceName_Click);
            // 
            // help
            // 
            this.help.Image = ((System.Drawing.Image)(resources.GetObject("help.Image")));
            this.help.Location = new System.Drawing.Point(264, 65);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(16, 16);
            this.help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.help.TabIndex = 49;
            this.help.TabStop = false;
            // 
            // lblPlaceNameExists
            // 
            this.lblPlaceNameExists.AutoSize = true;
            this.lblPlaceNameExists.ForeColor = System.Drawing.Color.Red;
            this.lblPlaceNameExists.Location = new System.Drawing.Point(8, 107);
            this.lblPlaceNameExists.Name = "lblPlaceNameExists";
            this.lblPlaceNameExists.Size = new System.Drawing.Size(59, 13);
            this.lblPlaceNameExists.TabIndex = 50;
            this.lblPlaceNameExists.Text = "placeexists";
            // 
            // CloudStorageDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 171);
            this.Controls.Add(this.lblPlaceNameExists);
            this.Controls.Add(this.help);
            this.Controls.Add(this.txtPlaceName);
            this.Controls.Add(this.lblPlaceName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnAddNewStorage);
            this.Controls.Add(this.comboStorageName);
            this.Controls.Add(this.lblChooseStorage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CloudStorageDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новое общее место: имя";
            ((System.ComponentModel.ISupportInitialize)(this.help)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChooseStorage;
        public System.Windows.Forms.ComboBox comboStorageName;
        private System.Windows.Forms.Button btnAddNewStorage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPlaceName;
        private System.Windows.Forms.TextBox txtPlaceName;
        private System.Windows.Forms.PictureBox help;
        private System.Windows.Forms.ToolTip tltPlaceName;
        private System.Windows.Forms.Label lblPlaceNameExists;
        private System.Windows.Forms.HelpProvider aHelpProvider;
    }
}