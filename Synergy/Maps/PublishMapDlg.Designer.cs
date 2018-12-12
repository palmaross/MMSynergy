
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
            this.SuspendLayout();
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(14, 151);
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
            this.btnCancel.Location = new System.Drawing.Point(180, 151);
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
            this.comboMyProjects.Location = new System.Drawing.Point(14, 109);
            this.comboMyProjects.Name = "comboMyProjects";
            this.comboMyProjects.Size = new System.Drawing.Size(264, 21);
            this.comboMyProjects.TabIndex = 13;
            this.comboMyProjects.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboboxReadonly_KeyPress);
            // 
            // lblPickProject
            // 
            this.lblPickProject.AutoSize = true;
            this.lblPickProject.Location = new System.Drawing.Point(11, 90);
            this.lblPickProject.Name = "lblPickProject";
            this.lblPickProject.Size = new System.Drawing.Size(132, 13);
            this.lblPickProject.TabIndex = 28;
            this.lblPickProject.Text = "Publish map in the Project:";
            // 
            // lblPickPlace
            // 
            this.lblPickPlace.AutoSize = true;
            this.lblPickPlace.Location = new System.Drawing.Point(11, 13);
            this.lblPickPlace.Name = "lblPickPlace";
            this.lblPickPlace.Size = new System.Drawing.Size(108, 13);
            this.lblPickPlace.TabIndex = 30;
            this.lblPickPlace.Text = "Place to publish map:";
            // 
            // comboMyPlaces
            // 
            this.comboMyPlaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMyPlaces.FormattingEnabled = true;
            this.comboMyPlaces.Location = new System.Drawing.Point(14, 31);
            this.comboMyPlaces.Name = "comboMyPlaces";
            this.comboMyPlaces.Size = new System.Drawing.Size(264, 21);
            this.comboMyPlaces.TabIndex = 29;
            this.comboMyPlaces.SelectedIndexChanged += new System.EventHandler(this.ComboMyPlaces_SelectedIndexChanged);
            this.comboMyPlaces.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboboxReadonly_KeyPress);
            // 
            // chBoxSingleMap
            // 
            this.chBoxSingleMap.AutoSize = true;
            this.chBoxSingleMap.Location = new System.Drawing.Point(14, 59);
            this.chBoxSingleMap.Name = "chBoxSingleMap";
            this.chBoxSingleMap.Size = new System.Drawing.Size(250, 17);
            this.chBoxSingleMap.TabIndex = 31;
            this.chBoxSingleMap.Text = "Опубликовать карту отдельно в этом месте";
            this.chBoxSingleMap.UseVisualStyleBackColor = true;
            this.chBoxSingleMap.CheckedChanged += new System.EventHandler(this.ChBoxSingleMap_CheckedChanged);
            // 
            // PublishMaptDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(294, 190);
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
    }
}