using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;

namespace 個人申請入學志願選填
{
    public partial class 確定分發 : BaseForm
    {
        private AccessHelper _AccessHelper = new AccessHelper();
        private List<推甄學生資料> _分發學生 = null;
        public 確定分發()
        {
            InitializeComponent();
        }
        private void 確定分發_Load(object sender, EventArgs e)
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string selectValue = comboBoxEx1.Text;
            bool 結果 = this.checkBoxX1.Checked;
            this.Close();
            foreach (var item in _分發學生)
            {
                if (selectValue == "" + item.梯次)
                {
                    item.確定分發結果 = 結果;
                }
            }
            _分發學生.SaveAll();
        }

    }
}
