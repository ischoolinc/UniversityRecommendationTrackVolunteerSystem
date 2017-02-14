using System;
using System.Collections.Generic;
using System.Text;
using FISCA.UDT;

namespace 繁星推薦入學校內志願選填
{
    class 匯出推甄學生資料 : SmartSchool.API.PlugIn.Export.Exporter
    {
        public 匯出推甄學生資料()
        {
            this.Path = "";
            this.Text = "匯出推甄資料";
        }
        private AccessHelper _AccessHelper = new AccessHelper();
        public override void InitializeExport(SmartSchool.API.PlugIn.Export.ExportWizard wizard)
        {
            wizard.ExportableFields.AddRange("身分證號", "排名", "總分", "成績內容", "分發校系代碼", "分發學校", "分發科系", "確定分發結果", "組別", "梯次", "備註");
            wizard.PackageLimit = 200;
            wizard.ExportPackage += delegate (object sender, SmartSchool.API.PlugIn.Export.ExportPackageEventArgs e)
            {
                FISCA.UDT.Condition.InCondition condition = new FISCA.UDT.Condition.InCondition();
                condition.Field = "RefStudentID";
                condition.Values.AddRange(e.List);
                var datas = _AccessHelper.Select<推甄學生資料>(condition);
                foreach (var refStudentID in e.List)
                {
                    SmartSchool.API.PlugIn.RowData rowData = new SmartSchool.API.PlugIn.RowData();
                    rowData.ID = refStudentID;
                    #region 寫入預設值
                    foreach (var field in e.ExportFields)
                    {
                        switch (field)
                        {
                            case "排名":
                                rowData.Add(field, "");
                                break;
                            case "總分":
                                rowData.Add(field, "");
                                break;
                            case "身分證號":
                                rowData.Add(field, "");
                                break;
                            case "成績內容":
                                rowData.Add(field, "");
                                break;
                            case "分發校系代碼":
                                rowData.Add(field, "");
                                break;
                            case "分發學校":
                                rowData.Add(field, "");
                                break;
                            case "分發科系":
                                rowData.Add(field, "");
                                break;
                            case "確定分發結果":
                                rowData.Add(field, "");
                                break;
                            case "組別":
                                rowData.Add(field, "");
                                break;
                            case "梯次":
                                rowData.Add(field, "");
                                break;
                            case "備註":
                                rowData.Add(field, "");
                                break;
                        }
                    }
                    #endregion
                    foreach (var item in datas)
                    {
                        if (item.StudentRecord.ID == refStudentID)
                        {
                            #region 填入真值
                            foreach (var field in e.ExportFields)
                            {
                                switch (field)
                                {
                                    case "排名":
                                        rowData[field] = "" + item.排名;
                                        break;
                                    case "總分":
                                        rowData[field] = "" + item.總分;
                                        break;
                                    case "身分證號":
                                        rowData[field] = item.StudentRecord.IDNumber;
                                        break;
                                    case "成績內容":
                                        rowData[field] = item.成績內容;
                                        break;
                                    case "分發校系代碼":
                                        rowData[field] = (item.分發結果 == null ? "" : item.分發結果.代碼);
                                        break;
                                    case "分發學校":
                                        rowData[field] = (item.分發結果 == null ? "" : item.分發結果.校名);
                                        break;
                                    case "分發科系":
                                        rowData[field] = (item.分發結果 == null ? "" : item.分發結果.系名);
                                        break;
                                    case "確定分發結果":
                                        rowData[field] = (item.確定分發結果 ? "是" : "否");
                                        break;
                                    case "組別":
                                        rowData[field] = "" + item.組別;
                                        break;
                                    case "梯次":
                                        rowData[field] = "" + item.梯次;
                                        break;
                                    case "備註":
                                        rowData[field] = item.備註;
                                        break;
                                }
                            }
                            #endregion
                            break;
                        }
                    }
                    e.Items.Add(rowData);
                }
            };
        }
    }
}
