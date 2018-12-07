namespace Projects
{
    partial class CreateProjectDlg
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
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblPlace = new System.Windows.Forms.Label();
            this.comboPlaces = new System.Windows.Forms.ComboBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblProjectNameError = new System.Windows.Forms.Label();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(14, 64);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(74, 13);
            this.lblProjectName.TabIndex = 36;
            this.lblProjectName.Text = "Project Name:";
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(14, 28);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(74, 13);
            this.lblPlace.TabIndex = 35;
            this.lblPlace.Text = "Shared Place:";
            // 
            // comboPlaces
            // 
            this.comboPlaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPlaces.FormattingEnabled = true;
            this.comboPlaces.Location = new System.Drawing.Point(104, 25);
            this.comboPlaces.Name = "comboPlaces";
            this.comboPlaces.Size = new System.Drawing.Size(218, 21);
            this.comboPlaces.TabIndex = 29;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(104, 61);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(218, 20);
            this.txtProjectName.TabIndex = 33;
            this.txtProjectName.Click += new System.EventHandler(this.txtProjectName_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(15, 141);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 37;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(247, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblProjectNameError
            // 
            this.lblProjectNameError.AutoSize = true;
            this.lblProjectNameError.ForeColor = System.Drawing.Color.Red;
            this.lblProjectNameError.Location = new System.Drawing.Point(101, 82);
            this.lblProjectNameError.Name = "lblProjectNameError";
            this.lblProjectNameError.Size = new System.Drawing.Size(89, 13);
            this.lblProjectNameError.TabIndex = 39;
            this.lblProjectNameError.Text = "projectname error";
            // 
            // CreateProjectDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 177);
            this.Controls.Add(this.lblProjectNameError);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.lblPlace);
            this.Controls.Add(this.comboPlaces);
            this.Controls.Add(this.txtProjectName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateProjectDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.ComboBox comboPlaces;
        public System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblProjectNameError;
        private System.Windows.Forms.HelpProvider aHelpProvider;

    }
}