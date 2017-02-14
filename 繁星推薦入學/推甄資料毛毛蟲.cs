using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FISCA.UDT;
using DevComponents.AdvTree;

namespace 繁星推薦入學校內志願選填
{
    public partial class 推甄資料毛毛蟲 : FISCA.Presentation.DetailContent
    {
        private BackgroundWorker _BKW = new BackgroundWorker();

        private string _RunningID = "";

        private 推甄學生資料 _CurrentData = null;

        private AccessHelper _AccessHelper = new AccessHelper();

        public 推甄資料毛毛蟲()
        {
            InitializeComponent();
            comboTree1.AdvTree.VisibleChanged += delegate
            {
                if (comboTree1.AdvTree.Visible)
                    comboTree1.AdvTree.Focus();
            };
            _BKW.DoWork += delegate
            {
                var list = 校系資料庫.Items;

                var items = _AccessHelper.Select<推甄學生資料>(new FISCA.UDT.Condition.EqualsCondition() { Field = "RefStudentID", Value = _RunningID });
                if (items.Count == 0)
                    _CurrentData = new 推甄學生資料() { StudentRecord = K12.Data.Student.SelectByID(_RunningID) };
                else
                {
                    _CurrentData = items[0];
                    if (items.Count > 1)
                    {
                        items.RemoveAt(0);
                        foreach (var item in items)
                        {
                            item.Deleted = true;
                        }
                        items.SaveAll();
                    }
                }


            };
            _BKW.RunWorkerCompleted += delegate
            {
                if (_RunningID != PrimaryKey)
                {
                    _RunningID = PrimaryKey;
                    _BKW.RunWorkerAsync();
                }
                else
                {
                    Node selectedNode = null;
                    Dictionary<string, List<校系資料>> schoolGroup = new Dictionary<string, List<校系資料>>();
                    foreach (var item in 校系資料庫.Items.Values)
                    {
                        if (!schoolGroup.ContainsKey(item.校名))
                            schoolGroup.Add(item.校名, new List<校系資料>());
                        schoolGroup[item.校名].Add(item);
                    }
                    comboTree1.Nodes.Clear();
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
                            if (item == _CurrentData.分發結果)
                            {
                                selectedNode = node;
                            }
                        };
                        schoolNode.Nodes.AddRange(nodes.ToArray());
                    }
                    comboTree1.Nodes.AddRange(schoolNodes.ToArray());

                    errorProvider1.Clear();
                    comboTree1.Tag = comboTree1.SelectedNode = selectedNode;
                    comboTree1_PopupClose(null, null);
                    chk確定分發.Tag = chk確定分發.Checked = _CurrentData.確定分發結果;
                    txt梯次.Tag = txt梯次.Text = "" + _CurrentData.梯次;
                    txt組別.Tag = txt組別.Text = _CurrentData.組別;
                    txt總分.Tag = txt總分.Text = "" + _CurrentData.總分;
                    txt備註.Tag = txt備註.Text = "" + _CurrentData.備註;
                    txt排名.Tag = txt排名.Text = "" + _CurrentData.排名;
                    txt成績內容.Tag = txt成績內容.Text = _CurrentData.成績內容;
                    this.Loading = false;
                }
            };
        }

        private void 推甄資料毛毛蟲_PrimaryKeyChanged(object sender, EventArgs e)
        {
            this.Loading = true;
            this.SaveButtonVisible = this.CancelButtonVisible = false;
            comboTree1.SelectedNode = null;
            errorProvider1.Clear();
            foreach (Control item in new Control[] { txt成績內容, txt排名, txt梯次, txt組別, txt總分, txt備註 })
            {
                item.Text = "";
            }
            if (!_BKW.IsBusy)
            {
                _RunningID = PrimaryKey;
                _BKW.RunWorkerAsync();
            }
        }

        private void CheckChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            errorProvider1.Clear();
            bool hasChanged = false;
            bool allValueValidated = true;
            if (comboTree1.SelectedNode != (Node)comboTree1.Tag)
            {
                hasChanged = true;
            }
            if (chk確定分發.Checked != (bool)chk確定分發.Tag)
            {
                hasChanged = true;
            }
            if (txt梯次.Text != (string)txt梯次.Tag)
            {
                hasChanged = true;
                int i;
                if (txt梯次.Text != "" && (int.TryParse(txt梯次.Text, out i) == false || i < 0))
                {
                    allValueValidated = false;
                    errorProvider1.SetError(txt梯次, "請輸入大於或等於零之整數。如不分梯次請保留空白");
                }
            }
            if (txt組別.Text != (string)txt組別.Tag)
            {
                hasChanged = true;
            }
            if (txt總分.Text != (string)txt總分.Tag)
            {
                hasChanged = true;
                decimal d;
                if (txt總分.Text != "" && !decimal.TryParse(txt總分.Text, out d))
                {

                    allValueValidated = false;
                    errorProvider1.SetError(txt總分, "請輸入數值或保留空白。");
                }
            }
            if (txt備註.Text != (string)txt備註.Tag)
            {
                hasChanged = true;
            }
            if (txt排名.Text != (string)txt排名.Tag)
            {
                hasChanged = true;
                int i;
                if (int.TryParse(txt排名.Text, out i) == false || i < 0)
                {
                    allValueValidated = false;
                    errorProvider1.SetError(txt排名, "請輸入大於或等於零之整數。");
                }
            }
            if (txt成績內容.Text != (string)txt成績內容.Tag)
            {
                hasChanged = true;
            }
            this.SaveButtonVisible = this.CancelButtonVisible = hasChanged;
            this.ContentValidated = allValueValidated;
        }

        private void 推甄資料毛毛蟲_CancelButtonClick(object sender, EventArgs e)
        {
            comboTree1.SelectedNode = (Node)comboTree1.Tag;
            comboTree1_PopupClose(null, null);
            chk確定分發.Checked = (bool)chk確定分發.Tag;
            txt梯次.Text = (string)txt梯次.Tag;
            txt組別.Text = (string)txt組別.Tag;
            txt總分.Text = (string)txt總分.Tag;
            txt排名.Text = (string)txt排名.Tag;
            txt備註.Text = (string)txt備註.Tag;
            txt成績內容.Text = (string)txt成績內容.Tag;
        }

        private void 推甄資料毛毛蟲_SaveButtonClick(object sender, EventArgs e)
        {

            int i = 0;
            decimal d = 0m;

            this.Loading = true;
            _CurrentData.分發結果 = (comboTree1.SelectedNode == null ? null : (校系資料)comboTree1.SelectedNode.Tag);
            _CurrentData.確定分發結果 = chk確定分發.Checked;
            _CurrentData.梯次 = (int.TryParse(txt梯次.Text, out i) ? new int?(i) : null);
            _CurrentData.組別 = txt組別.Text;
            _CurrentData.備註 = txt備註.Text;
            _CurrentData.總分 = (decimal.TryParse(txt總分.Text, out d) ? new decimal?(d) : null);
            _CurrentData.排名 = int.Parse(txt排名.Text);
            _CurrentData.成績內容 = txt成績內容.Text;
            _CurrentData.Save();
            this.推甄資料毛毛蟲_PrimaryKeyChanged(null, null);
        }

        private void comboTree1_PopupShowing(object sender, EventArgs e)
        {
            this.校系.Width.Absolute = 180;
            if (comboTree1.SelectedNode != null)
            {
                校系資料 item = (校系資料)comboTree1.SelectedNode.Tag;
                comboTree1.SelectedNode.Cells[1].Text = item.代碼;
                comboTree1.SelectedNode.Cells[0].Text = item.系名;
            }
        }

        private void comboTree1_PopupClose(object sender, EventArgs e)
        {
            this.校系.Width.Absolute = 300;
            if (comboTree1.SelectedNode != null)
            {
                comboTree1.SelectedNode.Cells[1].Text = "";
                comboTree1.SelectedNode.Cells[0].Text = ((校系資料)comboTree1.SelectedNode.Tag).校名 + " " + ((校系資料)comboTree1.SelectedNode.Tag).系名;
            }
        }

        private void comboTree1_SelectionChanging(object sender, AdvTreeNodeCancelEventArgs e)
        {
            e.Cancel = (e.Node != null && e.Node.Tag == null);
            if (e.Cancel)
            {
                if (e.Node != null && e.Action != eTreeAction.Code)
                {
                    e.Node.Toggle(eTreeAction.Code);
                }
                if (comboTree1.SelectedNode != null && comboTree1.SelectedNode.Parent != null && !comboTree1.SelectedNode.Parent.Expanded)
                    comboTree1.SelectedNode = null;
            }
        }

        private void labelX5_DoubleClick(object sender, EventArgs e)
        {
            var d = new System.Xml.XmlDocument();
            d.Load(System.Windows.Forms.Application.StartupPath + "\\Exception\\" + "RequestContent.Xml");
        }

    }
}
