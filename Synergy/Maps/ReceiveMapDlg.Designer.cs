namespace Maps
{
    partial class MapReceivedDlg
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
            this.btnOK = new System.Windows.Forms.Button();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbtnPlace = new System.Windows.Forms.RadioButton();
            this.rbtnProject = new System.Windows.Forms.RadioButton();
            this.comboProjects = new System.Windows.Forms.ComboBox();
            this.rbtnLeaveInPlace = new System.Windows.Forms.RadioButton();
            this.HelpRecommend = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HelpPlace = new System.Windows.Forms.PictureBox();
            this.comboPlaces = new System.Windows.Forms.ComboBox();
            this.lblPlace = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkNewPlace = new System.Windows.Forms.LinkLabel();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWhatToDo = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblReceivedFolderPath = new System.Windows.Forms.Label();
            this.HelpWhatToDo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HelpRecommend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpWhatToDo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(11, 371);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(248, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // rbtnPlace
            // 
            this.rbtnPlace.AutoSize = true;
            this.rbtnPlace.Location = new System.Drawing.Point(12, 239);
            this.rbtnPlace.Name = "rbtnPlace";
            this.rbtnPlace.Size = new System.Drawing.Size(275, 17);
            this.rbtnPlace.TabIndex = 30;
            this.rbtnPlace.TabStop = true;
            this.rbtnPlace.Text = "Переместить карту в Место (в отдельные карты)";
            this.rbtnPlace.UseVisualStyleBackColor = true;
            // 
            // rbtnProject
            // 
            this.rbtnProject.AutoSize = true;
            this.rbtnProject.Location = new System.Drawing.Point(12, 304);
            this.rbtnProject.Name = "rbtnProject";
            this.rbtnProject.Size = new System.Drawing.Size(176, 17);
            this.rbtnProject.TabIndex = 31;
            this.rbtnProject.TabStop = true;
            this.rbtnProject.Text = "Переместить карту в Проект:";
            this.rbtnProject.UseVisualStyleBackColor = true;
            // 
            // comboProjects
            // 
            this.comboProjects.FormattingEnabled = true;
            this.comboProjects.Location = new System.Drawing.Point(12, 326);
            this.comboProjects.Name = "comboProjects";
            this.comboProjects.Size = new System.Drawing.Size(311, 21);
            this.comboProjects.TabIndex = 32;
            // 
            // rbtnLeaveInPlace
            // 
            this.rbtnLeaveInPlace.AutoSize = true;
            this.rbtnLeaveInPlace.Location = new System.Drawing.Point(12, 272);
            this.rbtnLeaveInPlace.Name = "rbtnLeaveInPlace";
            this.rbtnLeaveInPlace.Size = new System.Drawing.Size(261, 17);
            this.rbtnLeaveInPlace.TabIndex = 33;
            this.rbtnLeaveInPlace.TabStop = true;
            this.rbtnLeaveInPlace.Text = "Оставить карту на месте (РЕКОМЕНДУЕТСЯ)";
            this.rbtnLeaveInPlace.UseVisualStyleBackColor = true;
            // 
            // HelpRecommend
            // 
            this.HelpRecommend.Image = global::Synergy19.Properties.Resources.question;
            this.HelpRecommend.Location = new System.Drawing.Point(299, 272);
            this.HelpRecommend.Name = "HelpRecommend";
            this.HelpRecommend.Size = new System.Drawing.Size(16, 16);
            this.HelpRecommend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.HelpRecommend.TabIndex = 34;
            this.HelpRecommend.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(160, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "1";
            // 
            // HelpPlace
            // 
            this.HelpPlace.Image = global::Synergy19.Properties.Resources.question;
            this.HelpPlace.Location = new System.Drawing.Point(299, 34);
            this.HelpPlace.Name = "HelpPlace";
            this.HelpPlace.Size = new System.Drawing.Size(16, 16);
            this.HelpPlace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.HelpPlace.TabIndex = 38;
            this.HelpPlace.TabStop = false;
            // 
            // comboPlaces
            // 
            this.comboPlaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPlaces.FormattingEnabled = true;
            this.comboPlaces.Location = new System.Drawing.Point(11, 55);
            this.comboPlaces.Name = "comboPlaces";
            this.comboPlaces.Size = new System.Drawing.Size(312, 21);
            this.comboPlaces.TabIndex = 37;
            this.comboPlaces.SelectedIndexChanged += new System.EventHandler(this.ComboPlaces_SelectedIndexChanged);
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(8, 37);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(275, 13);
            this.lblPlace.TabIndex = 36;
            this.lblPlace.Text = "В каком Общем Месте находится полученная карта:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(160, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "2";
            // 
            // linkNewPlace
            // 
            this.linkNewPlace.AutoSize = true;
            this.linkNewPlace.Location = new System.Drawing.Point(9, 77);
            this.linkNewPlace.Name = "linkNewPlace";
            this.linkNewPlace.Size = new System.Drawing.Size(218, 13);
            this.linkNewPlace.TabIndex = 40;
            this.linkNewPlace.TabStop = true;
            this.linkNewPlace.Text = "Еще нет этого места? Создайте сейчас...";
            this.linkNewPlace.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkNewPlace_LinkClicked);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(11, 151);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(271, 20);
            this.txtFolderPath.TabIndex = 42;
            this.txtFolderPath.Click += new System.EventHandler(this.TxtFolderPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(160, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "3";
            // 
            // lblWhatToDo
            // 
            this.lblWhatToDo.AutoSize = true;
            this.lblWhatToDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWhatToDo.Location = new System.Drawing.Point(9, 216);
            this.lblWhatToDo.Name = "lblWhatToDo";
            this.lblWhatToDo.Size = new System.Drawing.Size(216, 13);
            this.lblWhatToDo.TabIndex = 44;
            this.lblWhatToDo.Text = "Что сделать с полученной картой?";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(288, 149);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(35, 23);
            this.btnBrowse.TabIndex = 45;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // lblReceivedFolderPath
            // 
            this.lblReceivedFolderPath.AutoSize = true;
            this.lblReceivedFolderPath.Location = new System.Drawing.Point(8, 134);
            this.lblReceivedFolderPath.Name = "lblReceivedFolderPath";
            this.lblReceivedFolderPath.Size = new System.Drawing.Size(318, 13);
            this.lblReceivedFolderPath.TabIndex = 46;
            this.lblReceivedFolderPath.Text = "Укажите путь к полученной ПАПКЕ (вставьте или выберите):";
            // 
            // HelpWhatToDo
            // 
            this.HelpWhatToDo.Image = global::Synergy19.Properties.Resources.question;
            this.HelpWhatToDo.Location = new System.Drawing.Point(299, 213);
            this.HelpWhatToDo.Name = "HelpWhatToDo";
            this.HelpWhatToDo.Size = new System.Drawing.Size(16, 16);
            this.HelpWhatToDo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.HelpWhatToDo.TabIndex = 47;
            this.HelpWhatToDo.TabStop = false;
            // 
            // MapReceivedDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 404);
            this.ControlBox = false;
            this.Controls.Add(this.HelpWhatToDo);
            this.Controls.Add(this.lblReceivedFolderPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblWhatToDo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.linkNewPlace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HelpPlace);
            this.Controls.Add(this.comboPlaces);
            this.Controls.Add(this.lblPlace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HelpRecommend);
            this.Controls.Add(this.rbtnLeaveInPlace);
            this.Controls.Add(this.comboProjects);
            this.Controls.Add(this.rbtnProject);
            this.Controls.Add(this.rbtnPlace);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapReceivedDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Прием карты";
            ((System.ComponentModel.ISupportInitialize)(this.HelpRecommend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpWhatToDo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.HelpProvider aHelpProvider;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbtnPlace;
        private System.Windows.Forms.RadioButton rbtnProject;
        public System.Windows.Forms.ComboBox comboProjects;
        private System.Windows.Forms.RadioButton rbtnLeaveInPlace;
        private System.Windows.Forms.PictureBox HelpRecommend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox HelpPlace;
        private System.Windows.Forms.ComboBox comboPlaces;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkNewPlace;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWhatToDo;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblReceivedFolderPath;
        private System.Windows.Forms.PictureBox HelpWhatToDo;
    }
}