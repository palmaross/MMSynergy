
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
            this.aHelpProvider = new System.Windows.Forms.HelpProvider();
            this.comboPlaces = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lblPickFolder = new System.Windows.Forms.Label();
            this.lblPickPlace = new System.Windows.Forms.Label();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(14, 328);
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
            this.btnCancel.Location = new System.Drawing.Point(354, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 21);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // comboPlaces
            // 
            this.comboPlaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPlaces.FormattingEnabled = true;
            this.comboPlaces.Location = new System.Drawing.Point(188, 20);
            this.comboPlaces.Name = "comboPlaces";
            this.comboPlaces.Size = new System.Drawing.Size(264, 21);
            this.comboPlaces.TabIndex = 29;
            this.comboPlaces.SelectedIndexChanged += new System.EventHandler(this.ComboMyPlaces_SelectedIndexChanged);
            this.comboPlaces.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboboxReadonly_KeyPress);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 75);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(213, 234);
            this.treeView1.TabIndex = 36;
            // 
            // lblPickFolder
            // 
            this.lblPickFolder.AutoSize = true;
            this.lblPickFolder.Location = new System.Drawing.Point(11, 57);
            this.lblPickFolder.Name = "lblPickFolder";
            this.lblPickFolder.Size = new System.Drawing.Size(221, 13);
            this.lblPickFolder.TabIndex = 37;
            this.lblPickFolder.Text = "Выберите папку, в которой опубликовать:";
            // 
            // lblPickPlace
            // 
            this.lblPickPlace.AutoSize = true;
            this.lblPickPlace.Location = new System.Drawing.Point(11, 23);
            this.lblPickPlace.Name = "lblPickPlace";
            this.lblPickPlace.Size = new System.Drawing.Size(169, 13);
            this.lblPickPlace.TabIndex = 38;
            this.lblPickPlace.Text = "Место, где опубликовать карту:";
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(239, 75);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(213, 234);
            this.treeView2.TabIndex = 39;
            // 
            // PublishMaptDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(464, 361);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.lblPickPlace);
            this.Controls.Add(this.comboPlaces);
            this.Controls.Add(this.lblPickFolder);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPublish);
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
        private System.Windows.Forms.HelpProvider aHelpProvider;
        private System.Windows.Forms.ComboBox comboPlaces;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label lblPickFolder;
        private System.Windows.Forms.Label lblPickPlace;
        private System.Windows.Forms.TreeView treeView2;
    }
}