using System;
using System.Collections.Generic;
using System.Text;
using FISCA.UDT;

namespace 個人申請入學志願選填
{
    class 匯入推甄學生資料 : SmartSchool.API.PlugIn.Import.Importer
    {
        public 匯入推甄學生資料()
        {
            this.Text = "匯入推甄學生資料";
        }

        public override void InitializeImport(SmartSchool.API.PlugIn.Import.ImportWizard wizard)
        {
            List<推甄學生資料> importRecords = new List<推甄學生資料>();
            List<string> validatedID = new List<string>();
            //可以匯入這麼多欄位喔~
            wizard.ImportableFields.AddRange("排名", "總分", "成績內容", "分發校系代碼", "分發學校", "分發科系", "確定分發結果", "組別", "梯次", "備註");
            //開始驗證前先收集一些資訊於驗證過程中使用
            wizard.ValidateStart += delegate(object sender, SmartSchool.API.PlugIn.Import.ValidateStartEventArgs e)
            {
                FISCA.UDT.Condition.InCondition condition = new FISCA.UDT.Condition.InCondition();
                condition.Field = "RefStudentID";
                condition.Values.AddRange(e.List);
                importRecords = new AccessHelper().Select<推甄學生資料>(condition);
                importRecords.取得志願組();
            };
            //每一列資料會觸發一次驗證
            wizard.ValidateRow += delegate(object sender, SmartSchool.API.PlugIn.Import.ValidateRowEventArgs e)
            {
                if (validatedID.Contains(e.Data.ID))
                {
                    e.ErrorMessage = "同一學生不應出現兩筆資料。";
                }
                else
                {
                    #region 驗證各欄位資料
                    validatedID.Add(e.Data.ID);
                    foreach (var field in e.SelectFields)
                    {
                        string value = e.Data[field];
                        switch (field)
                        {
                            case "排名":
                                int i = 0;
                                if (!int.TryParse(value, out i) || i <= 0)
                                    e.ErrorFields.Add(field, "必需是大於0之整數。");
                                break;
                            case "總分":
                                decimal d;
                                if (e.Data[field] != "" && (!decimal.TryParse(value, out d) || d < 0m))
                                {
                                    e.ErrorFields.Add(field, "必需為空白或大於等於0之數字。");
                                }
                                break;
                            case "成績內容":
                                break;
                            case "分發校系代碼":
                                if (value != "")
                                {
                                    if (!校系資料庫.Items.ContainsKey(value))
                                        e.ErrorFields.Add(field, "查無此校系代碼。");
                                    else
                                    {
                                        bool match = false;
                                        foreach (var data in importRecords)
                                        {
                                            if (data.StudentRecord.ID == e.Data.ID)
                                            {
                                                foreach (var wish in data.志願組)
                                                {
                                                    if (wish.校系資料.代碼 == value)
                                                    {
                                                        match = true;
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        if (!match)
                                        {
                                            e.WarningFields.Add(field, "此分發結果不在該學生的志願中，可能導致統計數字錯誤。");
                                        }
                                    }
                                }
                                break;
                            case "分發學校":
                                if (!e.SelectFields.Contains("分發校系代碼"))
                                {
                                    e.ErrorFields.Add(field, "分發結果必須以校系代碼為主，無法單獨由分發學校判斷。");
                                }
                                else
                                {
                                    if (校系資料庫.Items.ContainsKey(e.Data["分發校系代碼"]) && 校系資料庫.Items[e.Data["分發校系代碼"]].校名 != value)
                                    {
                                        e.ErrorFields.Add(field, "校名與校系代碼不相同。");
                                    }
                                }
                                break;
                            case "分發科系":
                                if (!e.SelectFields.Contains("分發校系代碼"))
                                {
                                    e.ErrorFields.Add(field, "分發結果必須以校系代碼為主，無法單獨由分發科系判斷。");
                                }
                                else
                                {
                                    if (校系資料庫.Items.ContainsKey(e.Data["分發校系代碼"]) && 校系資料庫.Items[e.Data["分發校系代碼"]].系名 != value)
                                    {
                                        e.ErrorFields.Add(field, "系名與校系代碼不相同。");
                                    }
                                }
                                break;
                            case "確定分發結果":
                                if (value != "" && value != "是" && value != "否" && value.ToLower() != "true" && value.ToLower() != "false")
                                {
                                    e.ErrorFields.Add(field, "輸入值不允許，請輸入是或否，若保留空白則視為否。");
                                }
                                break;
                            case "梯次":
                                int j = 0;
                                if (value != "" && !int.TryParse(value, out j) || j <= 0)
                                    e.ErrorFields.Add(field, "必需是大於0之整數或空白。");
                                break;
                            case "備註":
                                break;
                            default:
                                break;
                        }
                    }
                    #endregion
                }
            };
            //匯入會一次切一個package做批次，每次只處理package的資料匯入即可
            wizard.ImportPackage += delegate(object sender, SmartSchool.API.PlugIn.Import.ImportPackageEventArgs e)
            {
                List<推甄學生資料> importPackage = new List<推甄學生資料>();
                foreach (var rowData in e.Items)
                {
                    推甄學生資料 targetData = null;
                    foreach (var rec in importRecords)
                    {
                        if (rec.StudentRecord.ID == rowData.ID)
                        {
                            targetData = rec;
                            break;
                        }
                    }
                    if (targetData == null)
                    {
                        targetData = new 推甄學生資料();
                        targetData.StudentRecord = K12.Data.Student.SelectByID(rowData.ID);
                    }
                    importPackage.Add(targetData);
                    #region 填入資料
                    foreach (var field in e.ImportFields)
                    {
                        string value = rowData[field];
                        switch (field)
                        {
                            case "排名":
                                targetData.排名 = int.Parse(value);
                                break;
                            case "總分":
                                targetData.總分 = (value == "" ? null : new decimal?(decimal.Parse(value)));
                                break;
                            case "成績內容":
                                targetData.成績內容 = value;
                                break;
                            case "分發校系代碼":
                                targetData.分發結果 = (value == "" ? null : 校系資料庫.Items[value]);
                                break;
                            case "分發學校":
                                break;
                            case "分發科系":
                                break;
                            case "確定分發結果":
                                targetData.確定分發結果 = ((value == "" || value == "否" || value.ToLower() == "false") ? false : true);
                                break;
                            case "組別":
                                targetData.組別 = value;
                                break;
                            case "梯次":
                                targetData.梯次 = (value == "" ? null : new int?(int.Parse(value)));
                                break;
                            case "備註":
                                targetData.備註 = value;
                                break;
                            default:
                                break;
                        }
                    }
                    #endregion
                }
                importPackage.SaveAll();
            };
        }
    }
}

