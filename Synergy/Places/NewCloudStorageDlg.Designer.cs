namespace Places
{
    partial class NewCloudStorageDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCloudStorageDlg));
            this.lblPlaceName = new System.Windows.Forms.Label();
            this.txtPlaceName = new System.Windows.Forms.TextBox();
            this.lblProcess = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.helpProcess = new System.Windows.Forms.PictureBox();
            this.lblNameExists = new System.Windows.Forms.Label();
            this.helpPath = new System.Windows.Forms.PictureBox();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblPlaceTaken = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBoxProcesses = new System.Windows.Forms.ComboBox();
            this.txtStorageName = new System.Windows.Forms.TextBox();
            this.lblStorageName = new System.Windows.Forms.Label();
            this.helpStorage = new System.Windows.Forms.PictureBox();
            this.helpPlaceName = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.helpProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPlaceName)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlaceName
            // 
            this.lblPlaceName.AutoSize = true;
            this.lblPlaceName.Location = new System.Drawing.Point(12, 66);
            this.lblPlaceName.Name = "lblPlaceName";
            this.lblPlaceName.Size = new System.Drawing.Size(66, 13);
            this.lblPlaceName.TabIndex = 0;
            this.lblPlaceName.Text = "Имя места:";
            // 
            // txtPlaceName
            // 
            this.txtPlaceName.Location = new System.Drawing.Point(15, 83);
            this.txtPlaceName.Name = "txtPlaceName";
            this.txtPlaceName.Size = new System.Drawing.Size(267, 20);
            this.txtPlaceName.TabIndex = 1;
            this.txtPlaceName.Click += new System.EventHandler(this.txtPlaceName_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(12, 183);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(248, 13);
            this.lblProcess.TabIndex = 2;
            this.lblProcess.Text = "Исполняемый файл/процесс этого хранилища:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(15, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnBack.Location = new System.Drawing.Point(126, 242);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(231, 242);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // helpProcess
            // 
            this.helpProcess.Image = ((System.Drawing.Image)(resources.GetObject("helpProcess.Image")));
            this.helpProcess.Location = new System.Drawing.Point(289, 205);
            this.helpProcess.Name = "helpProcess";
            this.helpProcess.Size = new System.Drawing.Size(16, 16);
            this.helpProcess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.helpProcess.TabIndex = 49;
            this.helpProcess.TabStop = false;
            // 
            // lblNameExists
            // 
            this.lblNameExists.AutoSize = true;
            this.lblNameExists.ForeColor = System.Drawing.Color.Red;
            this.lblNameExists.Location = new System.Drawing.Point(12, 105);
            this.lblNameExists.Name = "lblNameExists";
            this.lblNameExists.Size = new System.Drawing.Size(59, 13);
            this.lblNameExists.TabIndex = 50;
            this.lblNameExists.Text = "placeexists";
            // 
            // helpPath
            // 
            this.helpPath.Image = ((System.Drawing.Image)(resources.GetObject("helpPath.Image")));
            this.helpPath.Location = new System.Drawing.Point(289, 147);
            this.helpPath.Name = "helpPath";
            this.helpPath.Size = new System.Drawing.Size(16, 16);
            this.helpPath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.helpPath.TabIndex = 53;
            this.helpPath.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(249, 141);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(31, 22);
            this.btnBrowse.TabIndex = 55;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(14, 142);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(229, 20);
            this.txtFolderPath.TabIndex = 54;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(11, 124);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(76, 13);
            this.lblPath.TabIndex = 56;
            this.lblPath.Text = "Путь к месту:";
            // 
            // lblPlaceTaken
            // 
            this.lblPlaceTaken.AutoSize = true;
            this.lblPlaceTaken.ForeColor = System.Drawing.Color.Red;
            this.lblPlaceTaken.Location = new System.Drawing.Point(12, 164);
            this.lblPlaceTaken.Name = "lblPlaceTaken";
            this.lblPlaceTaken.Size = new System.Drawing.Size(67, 13);
            this.lblPlaceTaken.TabIndex = 57;
            this.lblPlaceTaken.Text = "placeistaken";
            // 
            // comboBoxProcesses
            // 
            this.comboBoxProcesses.FormattingEnabled = true;
            this.comboBoxProcesses.Location = new System.Drawing.Point(14, 200);
            this.comboBoxProcesses.Name = "comboBoxProcesses";
            this.comboBoxProcesses.Size = new System.Drawing.Size(266, 21);
            this.comboBoxProcesses.TabIndex = 58;
            // 
            // txtStorageName
            // 
            this.txtStorageName.Location = new System.Drawing.Point(15, 30);
            this.txtStorageName.Name = "txtStorageName";
            this.txtStorageName.Size = new System.Drawing.Size(267, 20);
            this.txtStorageName.TabIndex = 60;
            this.txtStorageName.Click += new System.EventHandler(this.txtStorageName_Click);
            // 
            // lblStorageName
            // 
            this.lblStorageName.AutoSize = true;
            this.lblStorageName.Location = new System.Drawing.Point(12, 13);
            this.lblStorageName.Name = "lblStorageName";
            this.lblStorageName.Size = new System.Drawing.Size(224, 13);
            this.lblStorageName.TabIndex = 59;
            this.lblStorageName.Text = "Принятое название облачного хранилища:";
            // 
            // helpStorage
            // 
            this.helpStorage.Image = ((System.Drawing.Image)(resources.GetObject("helpStorage.Image")));
            this.helpStorage.Location = new System.Drawing.Point(289, 34);
            this.helpStorage.Name = "helpStorage";
            this.helpStorage.Size = new System.Drawing.Size(16, 16);
            this.helpStorage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.helpStorage.TabIndex = 61;
            this.helpStorage.TabStop = false;
            // 
            // helpPlaceName
            // 
            this.helpPlaceName.Image = ((System.Drawing.Image)(resources.GetObject("helpPlaceName.Image")));
            this.helpPlaceName.Location = new System.Drawing.Point(288, 87);
            this.helpPlaceName.Name = "helpPlaceName";
            this.helpPlaceName.Size = new System.Drawing.Size(16, 16);
            this.helpPlaceName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.helpPlaceName.TabIndex = 62;
            this.helpPlaceName.TabStop = false;
            // 
            // NewCloudStorageDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 280);
            this.Controls.Add(this.helpPlaceName);
            this.Controls.Add(this.helpStorage);
            this.Controls.Add(this.txtStorageName);
            this.Controls.Add(this.lblStorageName);
            this.Controls.Add(this.comboBoxProcesses);
            this.Controls.Add(this.lblPlaceTaken);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.helpPath);
            this.Controls.Add(this.lblNameExists);
            this.Controls.Add(this.helpProcess);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.txtPlaceName);
            this.Controls.Add(this.lblPlaceName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewCloudStorageDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новое место: облачное хранилище";
            ((System.ComponentModel.ISupportInitialize)(this.helpProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpPlaceName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlaceName;
        public System.Windows.Forms.TextBox txtPlaceName;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.PictureBox helpProcess;
        private System.Windows.Forms.Label lblNameExists;
        private System.Windows.Forms.PictureBox helpPath;
        private System.Windows.Forms.HelpProvider aHelpProvider;
        private System.Windows.Forms.Button btnBrowse;
        public System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblPlaceTaken;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ComboBox comboBoxProcesses;
        public System.Windows.Forms.TextBox txtStorageName;
        private System.Windows.Forms.Label lblStorageName;
        private System.Windows.Forms.PictureBox helpStorage;
        private System.Windows.Forms.PictureBox helpPlaceName;
    }
}