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

namespace 個人申請入學志願選填
{
    public partial class 分發設定管理 : BaseForm
    {
        AccessHelper _AccessHelper = new AccessHelper();
        public 分發設定管理()
        {
            InitializeComponent();
        }

        private void 分發設定管理_Load(object sender, EventArgs e)
        {
            List<分發設定> list = _AccessHelper.Select<分發設定>();
            if (list.Count > 0)
            {
                integerInput1.Value = list[0].志願上限;
                if (list[0].開放時間 == null)
                    dateTimeInput1.IsEmpty = true;
                else
                    dateTimeInput1.Value = list[0].開放時間.Value;

                if (list[0].結束時間 == null)
                    dateTimeInput2.IsEmpty = true;
                else
                    dateTimeInput2.Value = list[0].結束時間.Value;

                if (list[0].開放梯次 == null)
                    integerInput2.IsEmpty = true;
                else
                    integerInput2.Value = list[0].開放梯次.Value;

                checkBoxX1.Checked = list[0].允許跨組;

                checkBoxX2.Checked = list[0].禁止學生互查;

                richTextBox1.Text = list[0].發佈訊息;

                textBoxX1.Text = list[0].跳出訊息;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            List<分發設定> list = _AccessHelper.Select<分發設定>();
            foreach (var item in list)
            {
                item.Deleted = true;
            }

            list.Add(new 分發設定()
            {
                允許跨組 = checkBoxX1.Checked,
                志願上限 = integerInput1.Value,
                跳出訊息 = textBoxX1.Text,
                發佈訊息 = richTextBox1.Text,
                結束時間 = (dateTimeInput2.IsEmpty ? null : new DateTime?(dateTimeInput2.Value)),
                開放時間 = (dateTimeInput1.IsEmpty ? null : new DateTime?(dateTimeInput1.Value)),
                開放梯次 = (integerInput2.IsEmpty ? null : new int?(integerInput2.Value)),
                禁止學生互查 = checkBoxX2.Checked
            });
            list.SaveAll();
            this.Close();
            MotherForm.SetStatusBarMessage("設定已儲存。");
        }
    }
}
