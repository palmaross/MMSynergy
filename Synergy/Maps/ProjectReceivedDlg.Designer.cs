namespace Maps
{
    partial class ProjectReceivedDlg
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
            this.lblProject = new System.Windows.Forms.Label();
            this.comboPlace = new System.Windows.Forms.ComboBox();
            this.linkNewPlace = new System.Windows.Forms.LinkLabel();
            this.lblOr = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(9, 16);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(245, 13);
            this.lblProject.TabIndex = 1;
            this.lblProject.Text = "Выберите место, в которое поместить проект:";
            // 
            // comboPlace
            // 
            this.comboPlace.FormattingEnabled = true;
            this.comboPlace.Location = new System.Drawing.Point(12, 41);
            this.comboPlace.Name = "comboPlace";
            this.comboPlace.Size = new System.Drawing.Size(238, 21);
            this.comboPlace.TabIndex = 4;
            // 
            // linkNewPlace
            // 
            this.linkNewPlace.Location = new System.Drawing.Point(51, 101);
            this.linkNewPlace.Name = "linkNewPlace";
            this.linkNewPlace.Size = new System.Drawing.Size(159, 18);
            this.linkNewPlace.TabIndex = 31;
            this.linkNewPlace.TabStop = true;
            this.linkNewPlace.Text = "Create New Place";
            this.linkNewPlace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOr
            // 
            this.lblOr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOr.AutoSize = true;
            this.lblOr.Location = new System.Drawing.Point(124, 79);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(16, 13);
            this.lblOr.TabIndex = 30;
            this.lblOr.Text = "or";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(175, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(12, 135);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 32;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // ProjectReceivedDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 170);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.linkNewPlace);
            this.Controls.Add(this.lblOr);
            this.Controls.Add(this.comboPlace);
            this.Controls.Add(this.lblProject);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectReceivedDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Прием проекта";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProject;
        public System.Windows.Forms.ComboBox comboPlace;
        private System.Windows.Forms.LinkLabel linkNewPlace;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.HelpProvider aHelpProvider;
    }
}