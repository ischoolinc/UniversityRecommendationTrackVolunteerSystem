using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.Presentation;

namespace 繁星推薦入學校內志願選填
{
    public partial class 統計分發結果 : BaseForm
    {
        private List<推甄學生資料> _List = new List<推甄學生資料>();
        public 統計分發結果(string title, List<推甄學生資料> 分發內容)
        {
            InitializeComponent();
            this.Text = title;
            _List = 分發內容;
            linkLabel1.Text = "" + _List.Count;
            int count = 0;
            foreach (var item in _List)
            {
                if (item.志願組.Count == 0)
                    count++;
            }
            linkLabel2.Text = "" + count;
            count = 0;
            foreach (var item in _List)
            {
                if (item.分發結果 == null)
                    count++;
            }
            linkLabel3.Text = "" + count;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> list = new List<string>();
            foreach (var item in _List)
            {
                list.Add(item.StudentRecord.ID);
            }
            設定待處理學生(list);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> list = new List<string>();
            foreach (var item in _List)
            {
                if (item.志願組.Count == 0)
                    list.Add(item.StudentRecord.ID);
            }
            設定待處理學生(list);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> list = new List<string>();
            foreach (var item in _List)
            {
                if (item.分發結果 == null)
                    list.Add(item.StudentRecord.ID);
            }
            設定待處理學生(list);
        }

        private void 設定待處理學生(List<string> value)
        {
            List<string> list = new List<string>();
            List<string> insertList = new List<string>();
            List<string> removeList = new List<string>();
            foreach (string var in value)
            {
                list.Add(var);
                if (!K12.Presentation.NLDPanels.Student.TempSource.Contains(var))
                    insertList.Add(var);
            }
            foreach (var item in K12.Presentation.NLDPanels.Student.TempSource)
            {
                if (!list.Contains(item))
                    removeList.Add(item);
            }
            K12.Presentation.NLDPanels.Student.AddToTemp(insertList);
            K12.Presentation.NLDPanels.Student.RemoveFromTemp(removeList);
            K12.Presentation.NLDPanels.Student.DisplayStatus = DisplayStatus.Temp;
            if (K12.Presentation.NLDPanels.Student.DisplayStatus == DisplayStatus.Temp)
                K12.Presentation.NLDPanels.Student.SelectAll();
        }
    }
}
