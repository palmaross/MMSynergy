namespace Maps
{
    partial class MapUsersDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapUsersDlg));
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.tltHelpOffline = new System.Windows.Forms.ToolTip(this.components);
            this.tltHelpWait = new System.Windows.Forms.ToolTip(this.components);
            this.tltHelpLocked = new System.Windows.Forms.ToolTip(this.components);
            this.indBlack = new System.Windows.Forms.PictureBox();
            this.pHelp = new System.Windows.Forms.PictureBox();
            this.indYellow = new System.Windows.Forms.PictureBox();
            this.indRed = new System.Windows.Forms.PictureBox();
            this.indGreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.indBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indGreen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.ForeColor = System.Drawing.Color.Olive;
            this.lblStatus.Location = new System.Drawing.Point(25, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(113, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Ожидание онлайн";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(2, 26);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(113, 13);
            this.lblTip.TabIndex = 0;
            this.lblTip.Text = "Не изменяйте карту!";
            this.lblTip.Click += new System.EventHandler(this.label1_Click);
            // 
            // tltHelpOffline
            // 
            this.tltHelpOffline.AutoPopDelay = 5000;
            this.tltHelpOffline.InitialDelay = 100;
            this.tltHelpOffline.ReshowDelay = 100;
            // 
            // indBlack
            // 
            this.indBlack.Image = ((System.Drawing.Image)(resources.GetObject("indBlack.Image")));
            this.indBlack.Location = new System.Drawing.Point(5, 4);
            this.indBlack.Name = "indBlack";
            this.indBlack.Size = new System.Drawing.Size(16, 16);
            this.indBlack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.indBlack.TabIndex = 7;
            this.indBlack.TabStop = false;
            // 
            // pHelp
            // 
            this.pHelp.Image = ((System.Drawing.Image)(resources.GetObject("pHelp.Image")));
            this.pHelp.Location = new System.Drawing.Point(142, 4);
            this.pHelp.Name = "pHelp";
            this.pHelp.Size = new System.Drawing.Size(16, 16);
            this.pHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pHelp.TabIndex = 6;
            this.pHelp.TabStop = false;
            // 
            // indYellow
            // 
            this.indYellow.Image = ((System.Drawing.Image)(resources.GetObject("indYellow.Image")));
            this.indYellow.Location = new System.Drawing.Point(5, 4);
            this.indYellow.Name = "indYellow";
            this.indYellow.Size = new System.Drawing.Size(16, 16);
            this.indYellow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.indYellow.TabIndex = 4;
            this.indYellow.TabStop = false;
            // 
            // indRed
            // 
            this.indRed.Image = ((System.Drawing.Image)(resources.GetObject("indRed.Image")));
            this.indRed.Location = new System.Drawing.Point(5, 4);
            this.indRed.Name = "indRed";
            this.indRed.Size = new System.Drawing.Size(16, 16);
            this.indRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.indRed.TabIndex = 3;
            this.indRed.TabStop = false;
            // 
            // indGreen
            // 
            this.indGreen.Image = ((System.Drawing.Image)(resources.GetObject("indGreen.Image")));
            this.indGreen.Location = new System.Drawing.Point(5, 4);
            this.indGreen.Name = "indGreen";
            this.indGreen.Size = new System.Drawing.Size(16, 16);
            this.indGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.indGreen.TabIndex = 2;
            this.indGreen.TabStop = false;
            // 
            // MapUsersDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(169, 45);
            this.ControlBox = false;
            this.Controls.Add(this.indBlack);
            this.Controls.Add(this.pHelp);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.indYellow);
            this.Controls.Add(this.indRed);
            this.Controls.Add(this.indGreen);
            this.Controls.Add(this.lblTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MapUsersDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.VisibleChanged += new System.EventHandler(this.MapUsersDlg_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.indBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indGreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox indGreen;
        private System.Windows.Forms.PictureBox indRed;
        private System.Windows.Forms.PictureBox indYellow;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.PictureBox pHelp;
        private System.Windows.Forms.ToolTip tltHelpOffline;
        private System.Windows.Forms.ToolTip tltHelpWait;
        private System.Windows.Forms.ToolTip tltHelpLocked;
        private System.Windows.Forms.PictureBox indBlack;
    }
}