namespace 個人申請入學志願選填
{
    partial class 校系資料管理
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnReflash = new DevComponents.DotNetBar.ButtonX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSaveAll = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.recordStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.校名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.系名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.代碼DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.組別DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名額DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.網路資訊 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recordStatusDataGridViewTextBoxColumn,
            this.uIDDataGridViewTextBoxColumn,
            this.校名DataGridViewTextBoxColumn,
            this.系名DataGridViewTextBoxColumn,
            this.代碼DataGridViewTextBoxColumn,
            this.組別DataGridViewTextBoxColumn,
            this.名額DataGridViewTextBoxColumn,
            this.網路資訊});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.HighlightSelectedColumnHeaders = false;
            this.dataGridViewX1.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersWidth = 28;
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.Size = new System.Drawing.Size(720, 389);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_CellMouseClick);
            this.dataGridViewX1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellLeave);
            this.dataGridViewX1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewX1_DefaultValuesNeeded);
            this.dataGridViewX1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewX1_CurrentCellDirtyStateChanged);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            this.dataGridViewX1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEnter);
            this.dataGridViewX1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_RowHeaderMouseClick);
            // 
            // btnReflash
            // 
            this.btnReflash.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReflash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReflash.BackColor = System.Drawing.Color.Transparent;
            this.btnReflash.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReflash.Location = new System.Drawing.Point(12, 407);
            this.btnReflash.Name = "btnReflash";
            this.btnReflash.Size = new System.Drawing.Size(75, 23);
            this.btnReflash.TabIndex = 1;
            this.btnReflash.Text = "重新整理";
            this.btnReflash.Click += new System.EventHandler(this.btnReflash_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = global::個人申請入學志願選填.Properties.Resources.loading5;
            this.pictureBox1.Image = global::個人申請入學志願選填.Properties.Resources.loading5;
            this.pictureBox1.InitialImage = global::個人申請入學志願選填.Properties.Resources.loading5;
            this.pictureBox1.Location = new System.Drawing.Point(356, 205);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveAll.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveAll.Location = new System.Drawing.Point(94, 407);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAll.TabIndex = 3;
            this.btnSaveAll.Text = "全部儲存";
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX1.BackColor = System.Drawing.Color.Transparent;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(576, 407);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "匯入";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX2.BackColor = System.Drawing.Color.Transparent;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(657, 407);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.TabIndex = 4;
            this.buttonX2.Text = "匯出";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // recordStatusDataGridViewTextBoxColumn
            // 
            this.recordStatusDataGridViewTextBoxColumn.DataPropertyName = "RecordStatus";
            this.recordStatusDataGridViewTextBoxColumn.HeaderText = "編輯狀態";
            this.recordStatusDataGridViewTextBoxColumn.Name = "recordStatusDataGridViewTextBoxColumn";
            this.recordStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.recordStatusDataGridViewTextBoxColumn.Width = 85;
            // 
            // uIDDataGridViewTextBoxColumn
            // 
            this.uIDDataGridViewTextBoxColumn.DataPropertyName = "UID";
            this.uIDDataGridViewTextBoxColumn.HeaderText = "系統編號";
            this.uIDDataGridViewTextBoxColumn.Name = "uIDDataGridViewTextBoxColumn";
            this.uIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.uIDDataGridViewTextBoxColumn.Width = 85;
            // 
            // 校名DataGridViewTextBoxColumn
            // 
            this.校名DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.校名DataGridViewTextBoxColumn.DataPropertyName = "校名";
            this.校名DataGridViewTextBoxColumn.FillWeight = 75F;
            this.校名DataGridViewTextBoxColumn.HeaderText = "校名";
            this.校名DataGridViewTextBoxColumn.MinimumWidth = 100;
            this.校名DataGridViewTextBoxColumn.Name = "校名DataGridViewTextBoxColumn";
            // 
            // 系名DataGridViewTextBoxColumn
            // 
            this.系名DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.系名DataGridViewTextBoxColumn.DataPropertyName = "系名";
            this.系名DataGridViewTextBoxColumn.HeaderText = "系名";
            this.系名DataGridViewTextBoxColumn.MinimumWidth = 100;
            this.系名DataGridViewTextBoxColumn.Name = "系名DataGridViewTextBoxColumn";
            // 
            // 代碼DataGridViewTextBoxColumn
            // 
            this.代碼DataGridViewTextBoxColumn.DataPropertyName = "代碼";
            this.代碼DataGridViewTextBoxColumn.HeaderText = "代碼";
            this.代碼DataGridViewTextBoxColumn.Name = "代碼DataGridViewTextBoxColumn";
            this.代碼DataGridViewTextBoxColumn.Width = 80;
            // 
            // 組別DataGridViewTextBoxColumn
            // 
            this.組別DataGridViewTextBoxColumn.DataPropertyName = "組別";
            this.組別DataGridViewTextBoxColumn.HeaderText = "組別";
            this.組別DataGridViewTextBoxColumn.Name = "組別DataGridViewTextBoxColumn";
            this.組別DataGridViewTextBoxColumn.Width = 60;
            // 
            // 名額DataGridViewTextBoxColumn
            // 
            this.名額DataGridViewTextBoxColumn.DataPropertyName = "名額";
            this.名額DataGridViewTextBoxColumn.HeaderText = "名額";
            this.名額DataGridViewTextBoxColumn.Name = "名額DataGridViewTextBoxColumn";
            this.名額DataGridViewTextBoxColumn.Width = 60;
            // 
            // 網路資訊
            // 
            this.網路資訊.HeaderText = "網路資訊";
            this.網路資訊.Name = "網路資訊";
            // 
            // 校系資料管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 442);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReflash);
            this.Controls.Add(this.dataGridViewX1);
            this.MaximizeBox = true;
            this.Name = "校系資料管理";
            this.Text = "校系資料管理";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX btnReflash;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.ButtonX btnSaveAll;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 校名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 系名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 代碼DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 組別DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名額DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 網路資訊;
    }
}