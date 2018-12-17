namespace Maps
{
    partial class SynergyExplorerDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynergyExplorerDlg));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnShareMap = new System.Windows.Forms.Button();
            this.btnRenameFile = new System.Windows.Forms.Button();
            this.btnDeletFile = new System.Windows.Forms.Button();
            this.btnNewVersion = new System.Windows.Forms.Button();
            this.btnCopyFile = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnNewFolder = new System.Windows.Forms.Button();
            this.btnShareFolder = new System.Windows.Forms.Button();
            this.btnRenameFolder = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.comboPlaces = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pictSearch = new System.Windows.Forms.PictureBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gBoxFileCommands = new System.Windows.Forms.GroupBox();
            this.gBoxFolderCommands = new System.Windows.Forms.GroupBox();
            this.btnDeleteFolder = new System.Windows.Forms.Button();
            this.btnNewPlace = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictSearch)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.gBoxFileCommands.SuspendLayout();
            this.gBoxFolderCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 1;
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(252, 365);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_closed.png");
            this.imageList1.Images.SetKeyName(1, "folder_opened.png");
            // 
            // treeView2
            // 
            this.treeView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView2.ImageIndex = 0;
            this.treeView2.ImageList = this.imageList1;
            this.treeView2.Location = new System.Drawing.Point(3, 3);
            this.treeView2.Name = "treeView2";
            this.treeView2.SelectedImageIndex = 1;
            this.treeView2.ShowLines = false;
            this.treeView2.Size = new System.Drawing.Size(252, 365);
            this.treeView2.TabIndex = 1;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(284, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(525, 262);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 30;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "File Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 280;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 30;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Locked by";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Modified";
            this.Column5.Name = "Column5";
            this.Column5.Width = 70;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(284, 396);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(530, 127);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(522, 101);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Properties";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(517, 101);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Versions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.AutoSize = true;
            this.btnAddFiles.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddFiles.FlatAppearance.BorderSize = 0;
            this.btnAddFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddFiles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFiles.ImageIndex = 0;
            this.btnAddFiles.Location = new System.Drawing.Point(20, 17);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(79, 23);
            this.btnAddFiles.TabIndex = 4;
            this.btnAddFiles.Text = "Add file(s)";
            this.btnAddFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddFiles.UseVisualStyleBackColor = false;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.AutoSize = true;
            this.btnOpenFile.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpenFile.FlatAppearance.BorderSize = 0;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFile.ImageIndex = 0;
            this.btnOpenFile.ImageList = this.imageList1;
            this.btnOpenFile.Location = new System.Drawing.Point(302, 68);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(62, 23);
            this.btnOpenFile.TabIndex = 5;
            this.btnOpenFile.Text = " Open";
            this.btnOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnShareMap
            // 
            this.btnShareMap.AutoSize = true;
            this.btnShareMap.FlatAppearance.BorderSize = 0;
            this.btnShareMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShareMap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShareMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShareMap.Location = new System.Drawing.Point(302, 93);
            this.btnShareMap.Name = "btnShareMap";
            this.btnShareMap.Size = new System.Drawing.Size(68, 23);
            this.btnShareMap.TabIndex = 6;
            this.btnShareMap.Text = "Share";
            this.btnShareMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShareMap.UseVisualStyleBackColor = true;
            // 
            // btnRenameFile
            // 
            this.btnRenameFile.AutoSize = true;
            this.btnRenameFile.FlatAppearance.BorderSize = 0;
            this.btnRenameFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenameFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRenameFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRenameFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenameFile.Location = new System.Drawing.Point(135, 17);
            this.btnRenameFile.Name = "btnRenameFile";
            this.btnRenameFile.Size = new System.Drawing.Size(69, 23);
            this.btnRenameFile.TabIndex = 7;
            this.btnRenameFile.Text = "Rename";
            this.btnRenameFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenameFile.UseVisualStyleBackColor = true;
            // 
            // btnDeletFile
            // 
            this.btnDeletFile.AutoSize = true;
            this.btnDeletFile.FlatAppearance.BorderSize = 0;
            this.btnDeletFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeletFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeletFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeletFile.Location = new System.Drawing.Point(135, 41);
            this.btnDeletFile.Name = "btnDeletFile";
            this.btnDeletFile.Size = new System.Drawing.Size(59, 23);
            this.btnDeletFile.TabIndex = 8;
            this.btnDeletFile.Text = "Delete";
            this.btnDeletFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeletFile.UseVisualStyleBackColor = true;
            // 
            // btnNewVersion
            // 
            this.btnNewVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewVersion.AutoSize = true;
            this.btnNewVersion.FlatAppearance.BorderSize = 0;
            this.btnNewVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNewVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNewVersion.Location = new System.Drawing.Point(261, 17);
            this.btnNewVersion.Name = "btnNewVersion";
            this.btnNewVersion.Size = new System.Drawing.Size(97, 23);
            this.btnNewVersion.TabIndex = 9;
            this.btnNewVersion.Text = "New version";
            this.btnNewVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewVersion.UseVisualStyleBackColor = true;
            // 
            // btnCopyFile
            // 
            this.btnCopyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyFile.AutoSize = true;
            this.btnCopyFile.FlatAppearance.BorderSize = 0;
            this.btnCopyFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCopyFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCopyFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyFile.Location = new System.Drawing.Point(266, 41);
            this.btnCopyFile.Name = "btnCopyFile";
            this.btnCopyFile.Size = new System.Drawing.Size(78, 23);
            this.btnCopyFile.TabIndex = 10;
            this.btnCopyFile.Text = "Copy to...";
            this.btnCopyFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyFile.UseVisualStyleBackColor = true;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckIn.AutoSize = true;
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCheckIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCheckIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckIn.ImageIndex = 0;
            this.btnCheckIn.ImageList = this.imageList1;
            this.btnCheckIn.Location = new System.Drawing.Point(398, 17);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(123, 23);
            this.btnCheckIn.TabIndex = 11;
            this.btnCheckIn.Text = " Check in";
            this.btnCheckIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckIn.UseVisualStyleBackColor = true;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckOut.AutoSize = true;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCheckOut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCheckOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckOut.ImageIndex = 0;
            this.btnCheckOut.ImageList = this.imageList1;
            this.btnCheckOut.Location = new System.Drawing.Point(398, 41);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(123, 23);
            this.btnCheckOut.TabIndex = 12;
            this.btnCheckOut.Text = " Check out";
            this.btnCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckOut.UseVisualStyleBackColor = true;
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.AutoSize = true;
            this.btnNewFolder.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewFolder.FlatAppearance.BorderSize = 0;
            this.btnNewFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNewFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNewFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewFolder.Location = new System.Drawing.Point(20, 41);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(78, 23);
            this.btnNewFolder.TabIndex = 13;
            this.btnNewFolder.Text = "New folder";
            this.btnNewFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewFolder.UseVisualStyleBackColor = false;
            // 
            // btnShareFolder
            // 
            this.btnShareFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShareFolder.AutoSize = true;
            this.btnShareFolder.BackColor = System.Drawing.SystemColors.Control;
            this.btnShareFolder.FlatAppearance.BorderSize = 0;
            this.btnShareFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShareFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShareFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShareFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShareFolder.Location = new System.Drawing.Point(179, 17);
            this.btnShareFolder.Name = "btnShareFolder";
            this.btnShareFolder.Size = new System.Drawing.Size(80, 23);
            this.btnShareFolder.TabIndex = 16;
            this.btnShareFolder.Text = "Share";
            this.btnShareFolder.UseVisualStyleBackColor = false;
            // 
            // btnRenameFolder
            // 
            this.btnRenameFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenameFolder.AutoSize = true;
            this.btnRenameFolder.BackColor = System.Drawing.SystemColors.Control;
            this.btnRenameFolder.FlatAppearance.BorderSize = 0;
            this.btnRenameFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenameFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRenameFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRenameFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenameFolder.Location = new System.Drawing.Point(99, 17);
            this.btnRenameFolder.Name = "btnRenameFolder";
            this.btnRenameFolder.Size = new System.Drawing.Size(63, 23);
            this.btnRenameFolder.TabIndex = 17;
            this.btnRenameFolder.Text = "Rename";
            this.btnRenameFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRenameFolder.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // comboPlaces
            // 
            this.comboPlaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboPlaces.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.comboPlaces.FormattingEnabled = true;
            this.comboPlaces.Location = new System.Drawing.Point(12, 15);
            this.comboPlaces.Name = "comboPlaces";
            this.comboPlaces.Size = new System.Drawing.Size(261, 28);
            this.comboPlaces.TabIndex = 18;
            this.comboPlaces.SelectedIndexChanged += new System.EventHandler(this.comboPlaces_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(566, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(209, 20);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.Visible = false;
            // 
            // pictSearch
            // 
            this.pictSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictSearch.Image = ((System.Drawing.Image)(resources.GetObject("pictSearch.Image")));
            this.pictSearch.Location = new System.Drawing.Point(781, 19);
            this.pictSearch.Name = "pictSearch";
            this.pictSearch.Size = new System.Drawing.Size(24, 24);
            this.pictSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictSearch.TabIndex = 56;
            this.pictSearch.TabStop = false;
            this.pictSearch.Click += new System.EventHandler(this.pictSearch_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(441, 30);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(119, 13);
            this.lblFileName.TabIndex = 57;
            this.lblFileName.Text = "Имя файла содержит:";
            this.lblFileName.Visible = false;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(12, 126);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(266, 397);
            this.tabControl2.TabIndex = 58;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.treeView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(258, 371);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Карты";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.treeView2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(258, 371);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Проекты";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gBoxFileCommands
            // 
            this.gBoxFileCommands.Controls.Add(this.btnDeletFile);
            this.gBoxFileCommands.Controls.Add(this.btnRenameFile);
            this.gBoxFileCommands.Controls.Add(this.btnCopyFile);
            this.gBoxFileCommands.Controls.Add(this.btnNewVersion);
            this.gBoxFileCommands.Controls.Add(this.btnCheckIn);
            this.gBoxFileCommands.Controls.Add(this.btnCheckOut);
            this.gBoxFileCommands.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gBoxFileCommands.ForeColor = System.Drawing.Color.Teal;
            this.gBoxFileCommands.Location = new System.Drawing.Point(284, 52);
            this.gBoxFileCommands.Name = "gBoxFileCommands";
            this.gBoxFileCommands.Size = new System.Drawing.Size(525, 70);
            this.gBoxFileCommands.TabIndex = 60;
            this.gBoxFileCommands.TabStop = false;
            this.gBoxFileCommands.Text = "File commands";
            // 
            // gBoxFolderCommands
            // 
            this.gBoxFolderCommands.Controls.Add(this.btnDeleteFolder);
            this.gBoxFolderCommands.Controls.Add(this.btnRenameFolder);
            this.gBoxFolderCommands.Controls.Add(this.btnAddFiles);
            this.gBoxFolderCommands.Controls.Add(this.btnNewFolder);
            this.gBoxFolderCommands.Controls.Add(this.btnShareFolder);
            this.gBoxFolderCommands.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gBoxFolderCommands.ForeColor = System.Drawing.Color.Teal;
            this.gBoxFolderCommands.Location = new System.Drawing.Point(12, 52);
            this.gBoxFolderCommands.Name = "gBoxFolderCommands";
            this.gBoxFolderCommands.Size = new System.Drawing.Size(261, 70);
            this.gBoxFolderCommands.TabIndex = 61;
            this.gBoxFolderCommands.TabStop = false;
            this.gBoxFolderCommands.Text = "Folder commands";
            // 
            // btnDeleteFolder
            // 
            this.btnDeleteFolder.AutoSize = true;
            this.btnDeleteFolder.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteFolder.FlatAppearance.BorderSize = 0;
            this.btnDeleteFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteFolder.Location = new System.Drawing.Point(105, 41);
            this.btnDeleteFolder.Name = "btnDeleteFolder";
            this.btnDeleteFolder.Size = new System.Drawing.Size(54, 23);
            this.btnDeleteFolder.TabIndex = 13;
            this.btnDeleteFolder.Text = "Delete";
            this.btnDeleteFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteFolder.UseVisualStyleBackColor = false;
            // 
            // btnNewPlace
            // 
            this.btnNewPlace.Location = new System.Drawing.Point(279, 14);
            this.btnNewPlace.Name = "btnNewPlace";
            this.btnNewPlace.Size = new System.Drawing.Size(91, 30);
            this.btnNewPlace.TabIndex = 62;
            this.btnNewPlace.Text = "Новое место";
            this.btnNewPlace.UseVisualStyleBackColor = true;
            // 
            // SynergyExplorerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 535);
            this.Controls.Add(this.btnNewPlace);
            this.Controls.Add(this.gBoxFolderCommands);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.pictSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.comboPlaces);
            this.Controls.Add(this.btnShareMap);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gBoxFileCommands);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SynergyExplorerDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Synergy Explorer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictSearch)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.gBoxFileCommands.ResumeLayout(false);
            this.gBoxFileCommands.PerformLayout();
            this.gBoxFolderCommands.ResumeLayout(false);
            this.gBoxFolderCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnShareMap;
        private System.Windows.Forms.Button btnRenameFile;
        private System.Windows.Forms.Button btnDeletFile;
        private System.Windows.Forms.Button btnNewVersion;
        private System.Windows.Forms.Button btnCopyFile;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnNewFolder;
        private System.Windows.Forms.Button btnShareFolder;
        private System.Windows.Forms.Button btnRenameFolder;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ComboBox comboPlaces;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pictSearch;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox gBoxFileCommands;
        private System.Windows.Forms.GroupBox gBoxFolderCommands;
        private System.Windows.Forms.Button btnDeleteFolder;
        private System.Windows.Forms.Button btnNewPlace;
    }
}