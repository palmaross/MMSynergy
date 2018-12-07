namespace Login
{
    partial class LogOutDlg
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
            this.btnExit = new System.Windows.Forms.Button();
            this.checkBoxForgetMe = new System.Windows.Forms.CheckBox();
            this.tltForgetMe = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExit.Location = new System.Drawing.Point(12, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(161, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Выйти из Synergy";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // checkBoxForgetMe
            // 
            this.checkBoxForgetMe.AutoSize = true;
            this.checkBoxForgetMe.Location = new System.Drawing.Point(13, 41);
            this.checkBoxForgetMe.Name = "checkBoxForgetMe";
            this.checkBoxForgetMe.Size = new System.Drawing.Size(73, 17);
            this.checkBoxForgetMe.TabIndex = 2;
            this.checkBoxForgetMe.Text = "Forget me";
            this.checkBoxForgetMe.UseVisualStyleBackColor = true;
            // 
            // LogOutDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 69);
            this.Controls.Add(this.checkBoxForgetMe);
            this.Controls.Add(this.btnExit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogOutDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LogOut";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox checkBoxForgetMe;
        private System.Windows.Forms.ToolTip tltForgetMe;
    }
}