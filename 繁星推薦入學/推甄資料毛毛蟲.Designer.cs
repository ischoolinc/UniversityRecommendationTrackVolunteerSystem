namespace 繁星推薦入學校內志願選填
{
    partial class 推甄資料毛毛蟲
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txt梯次 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt組別 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt總分 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt排名 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.comboTree1 = new DevComponents.DotNetBar.Controls.ComboTree();
            this.校系 = new DevComponents.AdvTree.ColumnHeader();
            this.代碼 = new DevComponents.AdvTree.ColumnHeader();
            this.chk確定分發 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.txt成績內容 = new System.Windows.Forms.RichTextBox();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txt備註 = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(40, 94);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "總分：";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(299, 94);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(47, 21);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "排名：";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(299, 64);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(47, 21);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "組別：";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(40, 64);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(47, 21);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "梯次：";
            // 
            // txt梯次
            // 
            // 
            // 
            // 
            this.txt梯次.Border.Class = "TextBoxBorder";
            this.txt梯次.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt梯次.Location = new System.Drawing.Point(87, 62);
            this.txt梯次.Name = "txt梯次";
            this.txt梯次.Size = new System.Drawing.Size(100, 25);
            this.txt梯次.TabIndex = 1;
            this.txt梯次.TextChanged += new System.EventHandler(this.CheckChanged);
            // 
            // txt組別
            // 
            // 
            // 
            // 
            this.txt組別.Border.Class = "TextBoxBorder";
            this.txt組別.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt組別.Location = new System.Drawing.Point(352, 62);
            this.txt組別.Name = "txt組別";
            this.txt組別.Size = new System.Drawing.Size(100, 25);
            this.txt組別.TabIndex = 1;
            this.txt組別.TextChanged += new System.EventHandler(this.CheckChanged);
            // 
            // txt總分
            // 
            // 
            // 
            // 
            this.txt總分.Border.Class = "TextBoxBorder";
            this.txt總分.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt總分.Location = new System.Drawing.Point(87, 92);
            this.txt總分.Name = "txt總分";
            this.txt總分.Size = new System.Drawing.Size(100, 25);
            this.txt總分.TabIndex = 1;
            this.txt總分.TextChanged += new System.EventHandler(this.CheckChanged);
            // 
            // txt排名
            // 
            // 
            // 
            // 
            this.txt排名.Border.Class = "TextBoxBorder";
            this.txt排名.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt排名.Location = new System.Drawing.Point(352, 92);
            this.txt排名.Name = "txt排名";
            this.txt排名.Size = new System.Drawing.Size(100, 25);
            this.txt排名.TabIndex = 1;
            this.txt排名.TextChanged += new System.EventHandler(this.CheckChanged);
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(13, 152);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(74, 21);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "成績內容：";
            this.labelX5.DoubleClick += new System.EventHandler(this.labelX5_DoubleClick);
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(13, 8);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(74, 21);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "分發結果：";
            // 
            // comboTree1
            // 
            this.comboTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.comboTree1.BackgroundStyle.Class = "TextBoxBorder";
            this.comboTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.comboTree1.ButtonDropDown.Visible = true;
            this.comboTree1.Columns.Add(this.校系);
            this.comboTree1.Columns.Add(this.代碼);
            this.comboTree1.DropDownWidth = 275;
            this.comboTree1.FormatString = "代碼";
            this.comboTree1.FormattingEnabled = true;
            this.comboTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.comboTree1.Location = new System.Drawing.Point(87, 8);
            this.comboTree1.Name = "comboTree1";
            this.comboTree1.Size = new System.Drawing.Size(210, 23);
            this.comboTree1.TabIndex = 2;
            this.comboTree1.SelectionChanging += new DevComponents.AdvTree.AdvTreeNodeCancelEventHandler(this.comboTree1_SelectionChanging);
            this.comboTree1.SelectedIndexChanged += new System.EventHandler(this.CheckChanged);
            this.comboTree1.PopupClose += new System.EventHandler(this.comboTree1_PopupClose);
            this.comboTree1.PopupShowing += new System.EventHandler(this.comboTree1_PopupShowing);
            // 
            // 校系
            // 
            this.校系.ColumnName = "校系";
            this.校系.DataFieldName = "校系";
            this.校系.Editable = false;
            this.校系.MinimumWidth = 150;
            this.校系.Name = "校系";
            this.校系.Text = "校系";
            this.校系.Width.Absolute = 180;
            // 
            // 代碼
            // 
            this.代碼.ColumnName = "代碼";
            this.代碼.Editable = false;
            this.代碼.MinimumWidth = 75;
            this.代碼.Name = "代碼";
            this.代碼.Text = "代碼";
            this.代碼.Width.Absolute = 90;
            // 
            // chk確定分發
            // 
            this.chk確定分發.AutoSize = true;
            // 
            // 
            // 
            this.chk確定分發.BackgroundStyle.Class = "";
            this.chk確定分發.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk確定分發.Location = new System.Drawing.Point(87, 36);
            this.chk確定分發.Name = "chk確定分發";
            this.chk確定分發.Size = new System.Drawing.Size(80, 21);
            this.chk確定分發.TabIndex = 3;
            this.chk確定分發.Text = "確定分發";
            this.chk確定分發.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 0;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // txt成績內容
            // 
            this.txt成績內容.HideSelection = false;
            this.txt成績內容.Location = new System.Drawing.Point(87, 152);
            this.txt成績內容.Name = "txt成績內容";
            this.txt成績內容.Size = new System.Drawing.Size(450, 172);
            this.txt成績內容.TabIndex = 4;
            this.txt成績內容.Text = "";
            this.txt成績內容.TextChanged += new System.EventHandler(this.CheckChanged);
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(40, 124);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(47, 21);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "備註：";
            // 
            // txt備註
            // 
            // 
            // 
            // 
            this.txt備註.Border.Class = "TextBoxBorder";
            this.txt備註.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt備註.Location = new System.Drawing.Point(87, 122);
            this.txt備註.Name = "txt備註";
            this.txt備註.Size = new System.Drawing.Size(100, 25);
            this.txt備註.TabIndex = 1;
            this.txt備註.TextChanged += new System.EventHandler(this.CheckChanged);
            // 
            // 推甄資料毛毛蟲
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chk確定分發);
            this.Controls.Add(this.comboTree1);
            this.Controls.Add(this.txt排名);
            this.Controls.Add(this.txt組別);
            this.Controls.Add(this.txt備註);
            this.Controls.Add(this.txt總分);
            this.Controls.Add(this.txt梯次);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txt成績內容);
            this.Group = "繁星推薦入學-推甄資料";
            this.Name = "推甄資料毛毛蟲";
            this.Size = new System.Drawing.Size(550, 335);
            this.PrimaryKeyChanged += new System.EventHandler(this.推甄資料毛毛蟲_PrimaryKeyChanged);
            this.SaveButtonClick += new System.EventHandler(this.推甄資料毛毛蟲_SaveButtonClick);
            this.CancelButtonClick += new System.EventHandler(this.推甄資料毛毛蟲_CancelButtonClick);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txt梯次;
        private DevComponents.DotNetBar.Controls.TextBoxX txt組別;
        private DevComponents.DotNetBar.Controls.TextBoxX txt總分;
        private DevComponents.DotNetBar.Controls.TextBoxX txt排名;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboTree comboTree1;
        private DevComponents.AdvTree.ColumnHeader 校系;
        private DevComponents.AdvTree.ColumnHeader 代碼;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk確定分發;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.RichTextBox txt成績內容;
        private DevComponents.DotNetBar.Controls.TextBoxX txt備註;
        private DevComponents.DotNetBar.LabelX labelX7;
    }
}
