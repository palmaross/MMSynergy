namespace Maps
{
    partial class MapExistsDlg
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
            this.lblMapExists = new System.Windows.Forms.Label();
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // lblMapExists
            // 
            this.lblMapExists.Location = new System.Drawing.Point(12, 9);
            this.lblMapExists.Name = "lblMapExists";
            this.lblMapExists.Size = new System.Drawing.Size(285, 40);
            this.lblMapExists.TabIndex = 0;
            this.lblMapExists.Text = "Карта с именем \"{0}\" уже есть в этом {1}. \r\nЕсли это другая карта, то измените ее" +
    " имя:";
            // 
            // txtMapName
            // 
            this.txtMapName.Location = new System.Drawing.Point(15, 59);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(278, 20);
            this.txtMapName.TabIndex = 1;
            this.txtMapName.Click += new System.EventHandler(this.txtMapName_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(15, 103);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(218, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // MapExistsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 138);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.lblMapExists);
            this.Name = "MapExistsDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Карта  существует";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMapExists;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.HelpProvider aHelpProvider;
    }
}