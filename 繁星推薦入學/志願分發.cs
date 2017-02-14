using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using FISCA.Presentation;

namespace 繁星推薦入學校內志願選填
{
    public partial class 志願分發 : BaseForm
    {
        private AccessHelper _AccessHelper = new AccessHelper();
        private List<推甄學生資料> _分發學生 = null;
        public 志願分發()
        {
            InitializeComponent();
        }

        private void 志願分發_Load(object sender, EventArgs e)
        {
            _分發學生 = _AccessHelper.Select<推甄學生資料>();
            List<int?> ladders = new List<int?>();
            foreach (var item in _分發學生)
            {
                if (!item.確定分發結果 && !ladders.Contains(item.梯次))
                    ladders.Add(item.梯次);
            }
            ladders.Sort();
            if (ladders.Count > 0)
            {
                foreach (var item in ladders)
                {
                    comboBoxEx1.Items.Add("" + item);
                }
                comboBoxEx1.SelectedIndex = 0;
            }
        }

        private void buttonX1_Click(object xxcxcz, EventArgs zcxzczxce)
        {
            string selectValue = comboBoxEx1.Text;
            if (DevComponents.DotNetBar.MessageBoxEx.Show(selectValue == "" ? "進行分發作業?" : ("進行第" + selectValue + "梯次分發作業?"), "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();

                BackgroundWorker bkw = new BackgroundWorker();
                bkw.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    Dictionary<校系資料, int> 配額 = new Dictionary<校系資料, int>();
                    List<推甄學生資料> 分發對像 = new List<推甄學生資料>();
                    foreach (var item in 校系資料庫.Items.Values)
                    {
                        配額.Add(item, item.名額);
                    }
                    foreach (var item in _分發學生)
                    {
                        if (item.確定分發結果 && item.分發結果 != null)
                        {
                            配額[item.分發結果]--;
                        }
                        if (!item.確定分發結果 && ("" + item.梯次) == selectValue)
                        {
                            分發對像.Add(item);
                        }
                    }
                    Dictionary<校系資料, 推甄學生資料[]> 蘿蔔坑 = new Dictionary<校系資料, 推甄學生資料[]>();
                    foreach (var item in 配額)
                    {
                        蘿蔔坑.Add(item.Key, new 推甄學生資料[item.Value]);
                    }
                    分發對像.取得志願組();
                    分發對像.Sort(delegate(推甄學生資料 o1, 推甄學生資料 o2)
                    {
                        return o1.排名.CompareTo(o2.排名);
                    });
                    foreach (var item in 分發對像)
                    {
                        分發學生(item, 蘿蔔坑);
                    }
                    分發對像.SaveAll();
                    e.Result = 分發對像;
                };
                bkw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    MotherForm.SetStatusBarMessage(selectValue == "" ? "分發完成。" : ("第" + selectValue + "梯次分發完成。"));
                    new 統計分發結果(selectValue == "" ? "分發內容" : ("第" + selectValue + "梯次分發內容。"), (List<推甄學生資料>)e.Result).Show();
                };

                bkw.RunWorkerAsync();
                MotherForm.SetStatusBarMessage(selectValue == "" ? "分發中..." : ("第" + selectValue + "梯次分發中..."));
            }
        }

        private void 分發學生(推甄學生資料 學生, Dictionary<校系資料, 推甄學生資料[]> 蘿蔔坑)
        {
            學生.分發結果 = null;
            foreach (var item in 學生.志願組)
            {
                if (!item.忽略 && 蘿蔔坑.ContainsKey(item.校系資料))
                {
                    推甄學生資料 現實很殘酷 = null;
                    for (int i = 0; i < 蘿蔔坑[item.校系資料].Length; i++)
                    {
                        if (蘿蔔坑[item.校系資料][i] == null)
                        {
                            蘿蔔坑[item.校系資料][i] = 學生;
                            學生.分發結果 = item.校系資料;
                            現實很殘酷 = null;
                            break;
                        }
                        else
                        {
                            if (蘿蔔坑[item.校系資料][i].排名 > 學生.排名)
                            {
                                現實很殘酷 = 蘿蔔坑[item.校系資料][i];
                            }
                            else if (蘿蔔坑[item.校系資料][i].排名 == 學生.排名 && item.校系資料.組別 == 學生.組別 && item.校系資料.組別 != 蘿蔔坑[item.校系資料][i].組別)
                            {
                                現實很殘酷 = 蘿蔔坑[item.校系資料][i];
                            }
                        }
                    }
                    if (現實很殘酷 != null)
                    {
                        學生.分發結果 = item.校系資料;
                        for (int i = 0; i < 蘿蔔坑[item.校系資料].Length; i++)
                        {
                            if (蘿蔔坑[item.校系資料][i] == 現實很殘酷)
                            {
                                蘿蔔坑[item.校系資料][i] = 學生;
                                分發學生(現實很殘酷, 蘿蔔坑);
                                break;
                            }
                        }
                    }
                }
                if (學生.分發結果 != null)
                    break;
            }
        }
    }
}
