using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FISCA.UDT;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.Controls;

namespace 個人申請入學志願選填
{
    public partial class 選填志願毛毛蟲 : FISCA.Presentation.DetailContent
    {
        private BackgroundWorker _BKW = new BackgroundWorker();
        private string _RunningID = "";
        private AccessHelper _AccessHelper = new AccessHelper();
        private test t = null;
        private List<志願> list = new List<志願>();

        public 選填志願毛毛蟲()
        {
            InitializeComponent();


            advTree1.DoubleClick += delegate
            {
                list.Add(new 志願());
                advTree1.DataSource = list;
            };
            _BKW.DoWork += delegate
            {
                list = _AccessHelper.Select<志願>("RefStudentID='" + _RunningID + "'");
                list.Sort(delegate (志願 o1, 志願 o2)
                {
                    return o1.志願排序.CompareTo(o2.志願排序);
                });
                var l = 校系資料庫.Items;
            };
            _BKW.RunWorkerCompleted += delegate
            {
                if (t == null) t = new test();
                if (_RunningID == PrimaryKey)
                {
                    //list.Add(new 志願() { StudentRecord = K12.Data.Student.SelectByID(PrimaryKey), 校系資料 = null });
                    advTree1.DataSource = list;
                    this.SaveButtonVisible = this.CancelButtonVisible = this.Loading = false;
                }
                else
                {
                    _RunningID = PrimaryKey;
                    _BKW.RunWorkerAsync();
                }
            };
        }

        private void 選填志願毛毛蟲_PrimaryKeyChanged(object sender, EventArgs e)
        {
            this.Loading = true;
            this.SaveButtonVisible = this.CancelButtonVisible = false;
            if (!_BKW.IsBusy)
            {
                _RunningID = PrimaryKey;
                _BKW.RunWorkerAsync();
            }
        }

        private void advTree1_ProvideCustomCellEditor(object sender, CustomCellEditorEventArgs e)
        {
                e.EditControl = t;
        }
        Node InsertNode = null;
        private void advTree1_DataNodeCreated(object sender, DataNodeEventArgs e)
        {
            e.Node.Cells[1].CheckBoxVisible = true;
            e.Node.Cells[1].CheckBoxAlignment = eCellPartAlignment.NearCenter;
            e.Node.Cells[1].CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
            e.Node.Cells[1].Checked = ((個人申請入學志願選填.志願)e.Node.DataKey).忽略;
            e.Node.Cells[1].Text = "";
            if (((個人申請入學志願選填.志願)e.Node.DataKey).RecordStatus == RecordStatus.Insert)
            {
                InsertNode = e.Node;
            }
        }

        private void advTree1_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.SelectedCell.IsEditable)
            {
                e.Node.BeginEdit(e.Node.Cells.IndexOf(e.Node.SelectedCell));
            }
        }

        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (!e.Node.SelectedCell.IsEditable)
            {
                e.Node.SelectedCell.Checked = (!e.Node.SelectedCell.Checked);
            }
        }

        private void advTree1_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            CheckChanged();
        }

        private void advTree1_AfterNodeDrop(object sender, TreeDragDropEventArgs e)
        {
            CheckChanged();
        }

        private void advTree1_AfterCellEditComplete(object sender, CellEditEventArgs e)
        {
            #region 如果是最底下的空結點被編輯就再補一個空結點上去
            if (e.Cell.Parent == InsertNode && InsertNode.Cells[0].Text != "")
            {
                志願 newItem = new 志願() { StudentRecord = K12.Data.Student.SelectByID(PrimaryKey), 校系資料 = null };
                InsertNode = new Node();
                InsertNode.DataKey = newItem;
                InsertNode.Cells.Clear();
                InsertNode.Cells.Add(new Cell());
                InsertNode.Cells.Add(new Cell());
                InsertNode.Cells.Add(new Cell());

                InsertNode.Cells[1].CheckBoxVisible = true;
                InsertNode.Cells[1].CheckBoxAlignment = eCellPartAlignment.NearCenter;
                InsertNode.Cells[1].CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                InsertNode.Cells[1].Checked = newItem.忽略;
                InsertNode.Cells[1].Text = "";

                advTree1.Nodes.Add(InsertNode);
            }
            if (e.Cell.Parent != InsertNode && e.Cell.Parent.Cells.IndexOf(e.Cell) == 0 && e.Cell.Text == "")
            {
                advTree1.Nodes.Remove(e.Cell.Parent);
            }
            #endregion
            CheckChanged();
        }

        private void CheckChanged()
        {
            int wishOrder = 1;
            bool hasChanged = false;
            foreach (Node item in advTree1.Nodes)
            {
                if (item == InsertNode) continue;//空結點當沒看到，就算你給我搬到最上面還是沒看到，反正就是沒看到，拉拉拉拉拉.....
                if (item.Cells[0].Text == "") continue;
                if (wishOrder > list.Count)
                {
                    hasChanged = true;
                    break;
                }
                if (item.Cells[0].Text != ("" + list[wishOrder - 1].校系資料))
                {
                    hasChanged = true;
                    break;
                }
                if (item.Cells[1].Checked != list[wishOrder - 1].忽略)
                {
                    hasChanged = true;
                    break;
                }
                if (item.Cells[2].Text != list[wishOrder - 1].忽略原因)
                {
                    hasChanged = true;
                    break;
                }
                wishOrder++;
            }
            if (wishOrder < list.Count)
                hasChanged = true;
            this.SaveButtonVisible = this.CancelButtonVisible = hasChanged;
        }

        private void 選填志願毛毛蟲_CancelButtonClick(object sender, EventArgs e)
        {
            this.選填志願毛毛蟲_PrimaryKeyChanged(null, null);
        }

        private void 選填志願毛毛蟲_SaveButtonClick(object sender, EventArgs e)
        {
            foreach (Node node in advTree1.Nodes)
                node.EndEdit(false);
            int wishOrder = 1;
            foreach (var item in list)
            {
                item.Deleted = true;
            }
            foreach (Node node in advTree1.Nodes)
            {
                if (node == InsertNode) continue;//空結點當沒看到，就算你給我搬到最上面還是沒看到，反正就是沒看到，拉拉拉拉拉.....
                foreach (var item in 校系資料庫.Items.Values)
                {
                    if (item.ToString() == node.Cells[0].Text)
                    {
                        list.Add(
                            new 志願()
                            {
                                StudentRecord = K12.Data.Student.SelectByID(PrimaryKey),
                                志願排序 = wishOrder++,
                                校系資料 = item,
                                忽略 = node.Cells[1].Checked,
                                忽略原因 = node.Cells[2].Text
                            });
                    }
                }
            }
            list.SaveAll();
            this.選填志願毛毛蟲_PrimaryKeyChanged(null, null);
        }
    }
    public class test : ComboTree, ICellEditControl
    {
        private DevComponents.AdvTree.ColumnHeader 校系;
        private DevComponents.AdvTree.ColumnHeader 代碼;

        public test()
        {
            //this.DropDownStyle = ComboBoxStyle.DropDownList;
            //this.FlatStyle = FlatStyle.Standard;
            //this.Items.Clear();
            //this.Items.Add("");
            //this.Items.AddRange(new List<校系資料>(校系資料庫.Items.Values).ToArray());
            this.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.校系 = new DevComponents.AdvTree.ColumnHeader();
            this.代碼 = new DevComponents.AdvTree.ColumnHeader();
            this.ButtonDropDown.Visible = true;
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
            this.Columns.Add(this.校系);
            this.Columns.Add(this.代碼);

            Dictionary<string, List<校系資料>> schoolGroup = new Dictionary<string, List<校系資料>>();
            foreach (var item in 校系資料庫.Items.Values)
            {
                if (!schoolGroup.ContainsKey(item.校名))
                {
                    schoolGroup.Add(item.校名, new List<校系資料>());
                }
                schoolGroup[item.校名].Add(item);
            }
            List<Node> schoolNodes = new List<Node>();
            foreach (var school in schoolGroup.Keys)
            {
                Node schoolNode = new Node();
                schoolNode.Cells.Clear();
                schoolNodes.Add(schoolNode);
                schoolNode.Cells.Add(new DevComponents.AdvTree.Cell(school));
                schoolNode.Cells.Add(new DevComponents.AdvTree.Cell(""));
                List<Node> nodes = new List<Node>();
                foreach (var item in schoolGroup[school])
                {
                    Node node = new Node();
                    node.Cells.Clear();
                    nodes.Add(node);
                    node.Cells.Add(new DevComponents.AdvTree.Cell(item.系名));
                    node.Cells.Add(new DevComponents.AdvTree.Cell(item.代碼));
                    node.Tag = item;
                    //if (item == _CurrentData.分發結果)
                    //{
                    //    selectedNode = node;
                    //}
                };
                schoolNode.Nodes.AddRange(nodes.ToArray());
            }
            Nodes.AddRange(schoolNodes.ToArray());
            this.SelectionChanging += delegate (object sender, AdvTreeNodeCancelEventArgs e)
            {
                e.Cancel = (e.Node != null && e.Node.Tag == null);
                if (e.Cancel)
                {
                    if (e.Node != null && e.Action != eTreeAction.Code)
                    {
                        e.Node.Toggle(eTreeAction.Code);
                    }
                    if (SelectedNode != null && SelectedNode.Parent != null && !SelectedNode.Parent.Expanded)
                        SelectedNode = null;
                }
            };
            this.PopupClose += delegate
            {
                this.校系.Width.Absolute = 300;
                if (SelectedNode != null)
                {
                    SelectedNode.Cells[1].Text = "";
                    SelectedNode.Cells[0].Text = ((校系資料)SelectedNode.Tag).校名 + " " + ((校系資料)SelectedNode.Tag).系名;
                }
                //if (EditComplete != null)
                //{
                //    EditComplete(this, new EventArgs());
                //}
            };
            this.PopupShowing += delegate
            {
                this.校系.Width.Absolute = 180;
                if (SelectedNode != null)
                {
                    校系資料 item = (校系資料)SelectedNode.Tag;
                    SelectedNode.Cells[1].Text = item.代碼;
                    SelectedNode.Cells[0].Text = item.系名;
                }
            };
        }

        #region ICellEditControl 成員

        public void BeginEdit()
        {
            this.ShowDropDown();//this.DroppedDown = true;
        }

        public event EventHandler CancelEdit;

        public object CurrentValue
        {
            get
            {
                return (SelectedNode == null ? "" : ("" + (校系資料)SelectedNode.Tag));
            }
            set
            {
                SelectedNode = null;
                foreach (Node item in Nodes)
                {
                    foreach (Node n in item.Nodes)
                    {
                        校系資料 d = (校系資料)n.Tag;
                        if ((d.校名 + " " + d.系名) == ("" + value))
                        {
                            SelectedNode = n;
                            break;
                        }
                    }
                }
            }
        }

        public event EventHandler EditComplete;

        public bool EditWordWrap
        {
            get;
            set;
        }

        public void EndEdit()
        {
            this.CloseDropDown();
        }

        #endregion
    }

}
