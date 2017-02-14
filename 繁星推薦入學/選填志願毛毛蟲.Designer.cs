namespace 繁星推薦入學校內志願選填
{
    partial class 選填志願毛毛蟲
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
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.SuspendLayout();
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.AllowDrop = true;
            this.advTree1.AllowUserToResizeColumns = false;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.CellEdit = true;
            this.advTree1.Columns.Add(this.columnHeader1);
            this.advTree1.Columns.Add(this.columnHeader2);
            this.advTree1.Columns.Add(this.columnHeader3);
            this.advTree1.GridColumnLines = false;
            this.advTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree1.Location = new System.Drawing.Point(13, 8);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(524, 179);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.Styles.Add(this.elementStyle2);
            this.advTree1.TabIndex = 0;
            this.advTree1.Text = "advTree1";
            this.advTree1.AfterCheck += new DevComponents.AdvTree.AdvTreeCellEventHandler(this.advTree1_AfterCheck);
            this.advTree1.AfterCellEditComplete += new DevComponents.AdvTree.CellEditEventHandler(this.advTree1_AfterCellEditComplete);
            this.advTree1.AfterNodeDrop += new DevComponents.AdvTree.TreeDragDropEventHandler(this.advTree1_AfterNodeDrop);
            this.advTree1.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeClick);
            this.advTree1.NodeDoubleClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeDoubleClick);
            this.advTree1.ProvideCustomCellEditor += new DevComponents.AdvTree.CustomCellEditorEventHandler(this.advTree1_ProvideCustomCellEditor);
            this.advTree1.DataNodeCreated += new DevComponents.DotNetBar.Controls.DataNodeEventHandler(this.advTree1_DataNodeCreated);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DataFieldName = "校系資料";
            this.columnHeader1.DoubleClickAutoSize = false;
            this.columnHeader1.Editable = false;
            this.columnHeader1.EditorType = DevComponents.AdvTree.eCellEditorType.Custom;
            this.columnHeader1.MinimumWidth = 290;
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "校系資料";
            this.columnHeader1.Width.Absolute = 290;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DataFieldName = "忽略";
            this.columnHeader2.DoubleClickAutoSize = false;
            this.columnHeader2.Editable = false;
            this.columnHeader2.MinimumWidth = 60;
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "忽略";
            this.columnHeader2.Width.Absolute = 60;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DataFieldName = "忽略原因";
            this.columnHeader3.DoubleClickAutoSize = false;
            this.columnHeader3.MinimumWidth = 140;
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "忽略原因";
            this.columnHeader3.Width.Absolute = 140;
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Class = "";
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.Class = "";
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            // 
            // 選填志願毛毛蟲
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.advTree1);
            this.Group = "繁星推薦入學-志願選填";
            this.Name = "選填志願毛毛蟲";
            this.Size = new System.Drawing.Size(550, 195);
            this.PrimaryKeyChanged += new System.EventHandler(this.選填志願毛毛蟲_PrimaryKeyChanged);
            this.SaveButtonClick += new System.EventHandler(this.選填志願毛毛蟲_SaveButtonClick);
            this.CancelButtonClick += new System.EventHandler(this.選填志願毛毛蟲_CancelButtonClick);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;


    }
}
