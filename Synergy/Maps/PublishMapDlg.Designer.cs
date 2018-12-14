
namespace Maps
{
    partial class PublishMaptDlg
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
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboMyProjects = new System.Windows.Forms.ComboBox();
            this.lblPickProject = new System.Windows.Forms.Label();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.lblPickPlace = new System.Windows.Forms.Label();
            this.comboMyPlaces = new System.Windows.Forms.ComboBox();
            this.chBoxSingleMap = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(14, 212);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(98, 23);
            this.btnPublish.TabIndex = 5;
            this.btnPublish.Text = "Publish Map";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(250, 212);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // comboMyProjects
            // 
            this.comboMyProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMyProjects.FormattingEnabled = true;
            this.comboMyProjects.Location = new System.Drawing.Point(297, 4);
            this.comboMyProjects.Name = "comboMyProjects";
            this.comboMyProjects.Size = new System.Drawing.Size(321, 21);
            this.comboMyProjects.TabIndex = 13;
            this.comboMyProjects.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboboxReadonly_KeyPress);
            // 
            // lblPickProject
            // 
            this.lblPickProject.AutoSize = true;
            this.lblPickProject.Location = new System.Drawing.Point(403, 129);
            this.lblPickProject.Name = "lblPickProject";
            this.lblPickProject.Size = new System.Drawing.Size(114, 13);
            this.lblPickProject.TabIndex = 28;
            this.lblPickProject.Text = "Project to publish map:";
            // 
            // lblPickPlace
            // 
            this.lblPickPlace.AutoSize = true;
            this.lblPickPlace.Location = new System.Drawing.Point(387, 74);
            this.lblPickPlace.Name = "lblPickPlace";
            this.lblPickPlace.Size = new System.Drawing.Size(108, 13);
            this.lblPickPlace.TabIndex = 30;
            this.lblPickPlace.Text = "Place to publish map:";
            // 
            // comboMyPlaces
            // 
            this.comboMyPlaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMyPlaces.FormattingEnabled = true;
            this.comboMyPlaces.Location = new System.Drawing.Point(367, 28);
            this.comboMyPlaces.Name = "comboMyPlaces";
            this.comboMyPlaces.Size = new System.Drawing.Size(264, 21);
            this.comboMyPlaces.TabIndex = 29;
            this.comboMyPlaces.SelectedIndexChanged += new System.EventHandler(this.ComboMyPlaces_SelectedIndexChanged);
            this.comboMyPlaces.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboboxReadonly_KeyPress);
            // 
            // chBoxSingleMap
            // 
            this.chBoxSingleMap.AutoSize = true;
            this.chBoxSingleMap.Location = new System.Drawing.Point(390, 182);
            this.chBoxSingleMap.Name = "chBoxSingleMap";
            this.chBoxSingleMap.Size = new System.Drawing.Size(127, 17);
            this.chBoxSingleMap.TabIndex = 31;
            this.chBoxSingleMap.Text = "Карта уже на месте";
            this.chBoxSingleMap.UseVisualStyleBackColor = true;
            this.chBoxSingleMap.CheckedChanged += new System.EventHandler(this.ChBoxSingleMap_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(308, 166);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(40, 22);
            this.btnBrowse.TabIndex = 33;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(14, 167);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(288, 20);
            this.txtFolderPath.TabIndex = 32;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(14, 108);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(301, 17);
            this.radioButton2.TabIndex = 37;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Publish map on cloud storage (Dropbox, Google Disk, etc.)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(14, 144);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(160, 17);
            this.radioButton3.TabIndex = 38;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Publish map on network disk";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(14, 69);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(177, 17);
            this.radioButton1.TabIndex = 39;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Publish map on Synergy website";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // PublishMaptDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(482, 257);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.chBoxSingleMap);
            this.Controls.Add(this.lblPickPlace);
            this.Controls.Add(this.comboMyPlaces);
            this.Controls.Add(this.lblPickProject);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.comboMyProjects);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PublishMaptDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publish map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox comboMyProjects;
        private System.Windows.Forms.Label lblPickProject;
        private System.Windows.Forms.HelpProvider aHelpProvider;
        private System.Windows.Forms.Label lblPickPlace;
        private System.Windows.Forms.ComboBox comboMyPlaces;
        private System.Windows.Forms.CheckBox chBoxSingleMap;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}