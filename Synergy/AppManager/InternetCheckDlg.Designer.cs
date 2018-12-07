namespace SynManager
{
    partial class InternetCheckDlg
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
            this.lblInternet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInternet
            // 
            this.lblInternet.AutoSize = true;
            this.lblInternet.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInternet.ForeColor = System.Drawing.Color.Red;
            this.lblInternet.Location = new System.Drawing.Point(0, 2);
            this.lblInternet.Name = "lblInternet";
            this.lblInternet.Size = new System.Drawing.Size(119, 13);
            this.lblInternet.TabIndex = 0;
            this.lblInternet.Text = "Проверка интернета";
            // 
            // InternetCheckDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(125, 20);
            this.ControlBox = false;
            this.Controls.Add(this.lblInternet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InternetCheckDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.VisibleChanged += new System.EventHandler(this.InternetCheckDlg_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInternet;
    }
}