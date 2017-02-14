using System;
using System.Collections.Generic;
using System.Text;
using FISCA.UDT;

namespace 個人申請入學志願選填
{
    class 匯出學生選填志願 : SmartSchool.API.PlugIn.Export.Exporter
    {
        public 匯出學生選填志願()
        {
            this.Path = "";
            this.Text = "匯出學生選填志願";
        }
        private FISCA.UDT.AccessHelper _AccessHelper = new AccessHelper();
        public override void InitializeExport(SmartSchool.API.PlugIn.Export.ExportWizard wizard)
        {
            var 匯出代碼 = new SmartSchool.API.PlugIn.VirtualRadioButton("匯出校系代碼", true);
            var 匯出校系名稱 = new SmartSchool.API.PlugIn.VirtualRadioButton("匯出校系名稱", false);
            wizard.Options.Add(匯出代碼);
            wizard.Options.Add(匯出校系名稱);
            int wishLimint = 5;
            List<分發設定> list = _AccessHelper.Select<分發設定>();
            if (list.Count > 0)
            {
                wishLimint = list[0].志願上限;
            }
            for (int i = 1; i <= wishLimint; i++)
            {
                wizard.ExportableFields.Add("第" + i + "志願");
            }
            wizard.PackageLimit = 200;
            wizard.ExportPackage += delegate(object sender, SmartSchool.API.PlugIn.Export.ExportPackageEventArgs e)
            {
                Dictionary<string, SmartSchool.API.PlugIn.RowData> dicRowDatas = new Dictionary<string, SmartSchool.API.PlugIn.RowData>();
                foreach (var refStudentID in e.List)
                {
                    SmartSchool.API.PlugIn.RowData rowData = new SmartSchool.API.PlugIn.RowData();
                    rowData.ID = refStudentID;
                    dicRowDatas.Add(refStudentID, rowData);
                    e.Items.Add(rowData);
                }
                FISCA.UDT.Condition.InCondition condition = new FISCA.UDT.Condition.InCondition();
                condition.Field = "RefStudentID";
                condition.Values.AddRange(e.List);
                var datas = _AccessHelper.Select<推甄學生資料>(condition);
                datas.取得志願組();
                foreach (var item in datas)
                {
                    int index = 1;
                    foreach (var wish in item.志願組)
                    {
                        dicRowDatas[item.StudentRecord.ID].Add("第" + index + "志願", (wish.校系資料 == null ? "校系資料已遺失" : (匯出代碼.Checked ? wish.校系資料.代碼 : (wish.校系資料.校名 + " " + wish.校系資料.系名))));
                        index++;
                    }
                }
                foreach (var item in dicRowDatas.Values)
                {
                    for (int i = 1; i <= wishLimint; i++)
                    {
                        if (!item.ContainsKey("第" + i + "志願"))
                            item.Add("第" + i + "志願", "");
                    }
                }
            };
        }
    }
}
