using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FISCA;
using FISCA.Presentation;
using FISCA.UDT;
using K12.Data;
using System.Diagnostics;

namespace 繁星推薦入學校內志願選填
{
    public static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [MainMethod]
        public static void Main()
        {
            { //同步Schema
                var schemaManager = new SchemaManager(new FISCA.DSAUtil.DSConnection(FISCA.Authentication.DSAServices.DefaultDataSource));
                schemaManager.SyncSchema(new 分發設定());
                schemaManager.SyncSchema(new 志願());
                schemaManager.SyncSchema(new 推甄學生資料());
                schemaManager.SyncSchema(new 校系資料());
            }

            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["教務作業"].Add(new FISCA.Permission.RibbonFeature("D2A76B72-F552-48C4-A2F9-273DCE5BE74F", "志願選填開放設定"));
                MotherForm.RibbonBarItems["教務作業", "繁星推薦入學校內志願選填"]["志願選填開放設定"].Enable = FISCA.Permission.UserAcl.Current["D2A76B72-F552-48C4-A2F9-273DCE5BE74F"].Executable;
                MotherForm.RibbonBarItems["教務作業", "繁星推薦入學校內志願選填"]["志願選填開放設定"].Click += delegate
                {
                    new 分發設定管理().ShowDialog();
                };
            }
            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["教務作業"].Add(new FISCA.Permission.RibbonFeature("51E6F9F8-B54A-44F9-A1D1-C7477C04CE94", "推甄校系管理"));
                MotherForm.RibbonBarItems["教務作業", "繁星推薦入學校內志願選填"]["推甄校系管理"].Enable = FISCA.Permission.UserAcl.Current["51E6F9F8-B54A-44F9-A1D1-C7477C04CE94"].Executable;
                MotherForm.RibbonBarItems["教務作業", "繁星推薦入學校內志願選填"]["推甄校系管理"].Click += delegate
                {
                    new 校系資料管理().ShowDialog();
                };
            }
            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["教務作業"].Add(new FISCA.Permission.RibbonFeature("30992865-DC6B-4FCA-A77A-108B0E96556D", "志願分發"));
                MotherForm.RibbonBarItems["教務作業", "繁星推薦入學校內志願選填"]["志願分發"].Enable = FISCA.Permission.UserAcl.Current["30992865-DC6B-4FCA-A77A-108B0E96556D"].Executable;
                MotherForm.RibbonBarItems["教務作業", "繁星推薦入學校內志願選填"]["志願分發"].Click += delegate
                {
                    new 志願分發().ShowDialog();
                };
            }
            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["教務作業"].Add(new FISCA.Permission.RibbonFeature("A69E899A-4A7E-4DC4-A066-9AA2646595A3", "確定分發"));
                MotherForm.RibbonBarItems["教務作業", "繁星推薦入學校內志願選填"]["確定分發"].Enable = FISCA.Permission.UserAcl.Current["A69E899A-4A7E-4DC4-A066-9AA2646595A3"].Executable;
                MotherForm.RibbonBarItems["教務作業", "繁星推薦入學校內志願選填"]["確定分發"].Click += delegate
                {
                    new 確定分發().ShowDialog();
                };
            }
            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["系統選單"].Add(new FISCA.Permission.RibbonFeature("606F0ED4-8575-4BF3-91D9-383CA53A6CB0", "系統設定"));
                MotherForm.StartMenu["繁星推薦入學校內志願選填"]["系統設定"].Enable = FISCA.Permission.UserAcl.Current["606F0ED4-8575-4BF3-91D9-383CA53A6CB0"].Executable;
                MotherForm.StartMenu["繁星推薦入學校內志願選填"]["系統設定"].Click += delegate
                {
                    new 分發設定管理().ShowDialog();
                };
            }
            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["系統選單"].Add(new FISCA.Permission.RibbonFeature("1A7CEB76-98D4-4730-B10E-CFCD592CC23E", "清除所有分發結果"));
                MotherForm.StartMenu["繁星推薦入學校內志願選填"]["清除所有分發結果"].Enable = FISCA.Permission.UserAcl.Current["1A7CEB76-98D4-4730-B10E-CFCD592CC23E"].Executable;
                MotherForm.StartMenu["繁星推薦入學校內志願選填"]["清除所有分發結果"].Click += delegate
                {
                    List<推甄學生資料> list2 = new AccessHelper().Select<推甄學生資料>();
                    foreach (var item in list2)
                    {
                        item.確定分發結果 = false;
                        item.分發結果 = null;
                    }
                    list2.SaveAll();
                };
            }
            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["系統選單"].Add(new FISCA.Permission.RibbonFeature("9E1C96F2-9048-4E20-AF9B-94E75D27A3C2", "清除所有選填志願"));
                MotherForm.StartMenu["繁星推薦入學校內志願選填"]["清除所有選填志願"].Enable = FISCA.Permission.UserAcl.Current["9E1C96F2-9048-4E20-AF9B-94E75D27A3C2"].Executable;
                MotherForm.StartMenu["繁星推薦入學校內志願選填"]["清除所有選填志願"].Click += delegate
                {
                    List<志願> list = new AccessHelper().Select<志願>();
                    foreach (var item in list)
                    {
                        item.Deleted = true;
                    }
                    list.SaveAll();
                };
            }
            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["系統選單"].Add(new FISCA.Permission.RibbonFeature("D414FC5B-D2B4-4715-B2A3-DBA0B5BE4464", "刪除所有學生資料"));
                MotherForm.StartMenu["繁星推薦入學校內志願選填"]["刪除所有學生資料"].Enable = FISCA.Permission.UserAcl.Current["D414FC5B-D2B4-4715-B2A3-DBA0B5BE4464"].Executable;
                MotherForm.StartMenu["繁星推薦入學校內志願選填"]["刪除所有學生資料"].Click += delegate
                {
                    List<推甄學生資料> list2 = new AccessHelper().Select<推甄學生資料>();
                    foreach (var item in list2)
                    {
                        item.Deleted = true;
                    }
                    list2.SaveAll();
                };
            }
            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["學生資料項目"].Add(new FISCA.Permission.RibbonFeature("BA63DF20-1B0E-458E-B0D3-D09E4DDE204C", "推甄資料"));
                if (FISCA.Permission.UserAcl.Current["BA63DF20-1B0E-458E-B0D3-D09E4DDE204C"].Executable)
                    K12.Presentation.NLDPanels.Student.AddDetailBulider<推甄資料毛毛蟲>();
            }
            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["學生資料項目"].Add(new FISCA.Permission.RibbonFeature("D60F9D70-86BF-4F03-B8AE-FB87B91AD94F", "選填志願"));
                if (FISCA.Permission.UserAcl.Current["D60F9D70-86BF-4F03-B8AE-FB87B91AD94F"].Executable)
                    K12.Presentation.NLDPanels.Student.AddDetailBulider<選填志願毛毛蟲>();
            }

            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["學生功能按鈕"].Add(new FISCA.Permission.RibbonFeature("16F49DC4-FC80-4A33-B8F7-19321D085803", "匯出推甄學生資料"));
                K12.Presentation.NLDPanels.Student.RibbonBarItems["資料統計"]["匯出"]["繁星推薦入學校內志願選填"]["匯出推甄學生資料"].Enable = FISCA.Permission.UserAcl.Current["16F49DC4-FC80-4A33-B8F7-19321D085803"].Executable;
                K12.Presentation.NLDPanels.Student.RibbonBarItems["資料統計"]["匯出"]["繁星推薦入學校內志願選填"]["匯出推甄學生資料"].Click += delegate
                {
                    var exporter = new 匯出推甄學生資料();
                    SmartSchool.StudentRelated.RibbonBars.Import.ExportStudentV2 wizard = new SmartSchool.StudentRelated.RibbonBars.Import.ExportStudentV2(exporter.Text, exporter.Image);
                    exporter.InitializeExport(wizard);
                    wizard.ShowDialog();
                };
            }
            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["學生功能按鈕"].Add(new FISCA.Permission.RibbonFeature("6B2CED74-F39E-42F9-8158-C1117FCD896A", "匯出學生選填志願"));
                K12.Presentation.NLDPanels.Student.RibbonBarItems["資料統計"]["匯出"]["繁星推薦入學校內志願選填"]["匯出學生選填志願"].Enable = FISCA.Permission.UserAcl.Current["6B2CED74-F39E-42F9-8158-C1117FCD896A"].Executable;
                K12.Presentation.NLDPanels.Student.RibbonBarItems["資料統計"]["匯出"]["繁星推薦入學校內志願選填"]["匯出學生選填志願"].Click += delegate
                {
                    var exporter = new 匯出學生選填志願();
                    SmartSchool.StudentRelated.RibbonBars.Import.ExportStudentV2 wizard = new SmartSchool.StudentRelated.RibbonBars.Import.ExportStudentV2(exporter.Text, exporter.Image);
                    exporter.InitializeExport(wizard);
                    wizard.ShowDialog();
                };
            }
            {
                FISCA.Permission.RoleAclSource.Instance["繁星推薦入學校內志願選填"]["學生功能按鈕"].Add(new FISCA.Permission.RibbonFeature("5E00AFE4-34B7-4D35-AB8F-2C53EC2FE147", "匯入推甄學生資料"));
                K12.Presentation.NLDPanels.Student.RibbonBarItems["資料統計"]["匯入"]["繁星推薦入學校內志願選填"]["匯入推甄學生資料"].Enable = FISCA.Permission.UserAcl.Current["5E00AFE4-34B7-4D35-AB8F-2C53EC2FE147"].Executable;
                K12.Presentation.NLDPanels.Student.RibbonBarItems["資料統計"]["匯入"]["繁星推薦入學校內志願選填"]["匯入推甄學生資料"].Click += delegate
                {
                    var exporter = new 匯入推甄學生資料();
                    SmartSchool.StudentRelated.RibbonBars.Import.ImportStudentV2 wizard = new SmartSchool.StudentRelated.RibbonBars.Import.ImportStudentV2(exporter.Text, exporter.Image);
                    exporter.InitializeImport(wizard);
                    wizard.ShowDialog();
                };
            }
        }

        static void Program_Click3(object sender, EventArgs e)
        {
            List<分發設定> list = new AccessHelper().Select<分發設定>();
            foreach (var item in list)
            {
                item.Deleted = true;
            }
            list.Add(new 分發設定() { 允許跨組 = true, 志願上限 = 5, 發佈訊息 = "哇哈哈哈哈哈", 結束時間 = new DateTime(2009, 12, 31), 開放時間 = new DateTime(2009, 12, 1), 開放梯次 = 3 });
            list.SaveAll();
        }

        static void Program_Click2(object sender, EventArgs e)
        {
            List<StudentRecord> students = K12.Data.Student.SelectAll();
            AccessHelper accessHelper = new AccessHelper();
            List<推甄學生資料> list = accessHelper.Select<推甄學生資料>();
            foreach (var item in list)
                item.Deleted = true;
            #region 就是寫這麼多行才是大師
            #region 大師的秘密配方
            //="foreach (var student in students)
            //{
            //    if (student.StudentNumber == !@#"&A2&"!@#)
            //    {
            //          list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = !@#"&IF(I2<>"",$I$1&"："&I2&"\n","")&IF(J2<>"",$J$1&"："&J2&"\n","")&IF(K2<>"",$K$1&"："&K2&"\n","")&IF(L2<>"",$L$1&"："&L2&"\n","")&IF(M2<>"",$M$1&"："&M2&"\n","")&IF(N2<>"",$N$1&"："&N2&"\n","")&IF(O2<>"",$O$1&"："&O2&"\n","")&IF(P2<>"",$P$1&"："&P2&"\n","")&IF(Q2<>"",$Q$1&"："&Q2&"\n","")&"!@#, 排名 ="&G2&", 組別 = !@#"&E2&"!@#, 總分 = new decimal?("&H2&"m), 備註=!@#"&F2&"!@#, 梯次=new int?("&R2&")} );
            //        break;
            //    }
            //}"
            #endregion
            foreach (var student in students)
            {
                if (student.StudentNumber == "619002")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：67\n英文：43.75\n數學：54.25\n歷史：70\n地理：70.25\n公民：78.75", 排名 = 63, 組別 = "社會組", 總分 = new decimal?(384m), 備註 = "53193101", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619121")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：69.75\n英文：67.25\n數學：56\n歷史：64.5\n地理：71\n公民：77", 排名 = 53, 組別 = "社會組", 總分 = new decimal?(405.5m), 備註 = "53193102", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619005")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：67.5\n英文：56.75\n數學：75.75\n歷史：75.5\n地理：84.25\n公民：84.25", 排名 = 26, 組別 = "社會組", 總分 = new decimal?(444m), 備註 = "53193103", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619006")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：67.75\n英文：48\n數學：53.75\n歷史：72.75\n地理：75\n公民：77.25", 排名 = 59, 組別 = "社會組", 總分 = new decimal?(394.5m), 備註 = "53193104", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619009")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：72.75\n英文：61\n數學：62.75\n歷史：72.75\n地理：78.25\n公民：85.25", 排名 = 36, 組別 = "社會組", 總分 = new decimal?(432.75m), 備註 = "53193105", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619013")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：77\n英文：65\n數學：60.25\n歷史：73\n地理：75.75\n公民：81.25", 排名 = 38, 組別 = "社會組", 總分 = new decimal?(432.25m), 備註 = "53193106", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619014")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：82.75\n英文：68.25\n數學：67.25\n歷史：77.25\n地理：78.75\n公民：84.5", 排名 = 7, 組別 = "社會組", 總分 = new decimal?(458.75m), 備註 = "53193107", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619134")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：76.75\n英文：66\n數學：40.75\n歷史：67\n地理：67.75\n公民：82.75", 排名 = 56, 組別 = "社會組", 總分 = new decimal?(401m), 備註 = "53193108", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619016")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：75.25\n英文：76.25\n數學：65.25\n歷史：74.25\n地理：80.5\n公民：84.5", 排名 = 13, 組別 = "社會組", 總分 = new decimal?(456m), 備註 = "53193109", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619017")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：69.5\n英文：61\n數學：42.75\n歷史：61.25\n地理：72.75\n公民：82.75", 排名 = 60, 組別 = "社會組", 總分 = new decimal?(390m), 備註 = "53193110", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619019")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：80\n英文：77.75\n數學：63.25\n歷史：71\n地理：71.75\n公民：85.5", 排名 = 19, 組別 = "社會組", 總分 = new decimal?(449.25m), 備註 = "53193111", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619022")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：74.25\n英文：77\n數學：61.5\n歷史：72.5\n地理：77.5\n公民：85.25", 排名 = 20, 組別 = "社會組", 總分 = new decimal?(448m), 備註 = "53193112", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619023")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：82.5\n英文：62.75\n數學：64.75\n歷史：74\n地理：78.5\n公民：84", 排名 = 23, 組別 = "社會組", 總分 = new decimal?(446.5m), 備註 = "53193113", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619025")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：72.5\n英文：63.75\n數學：68\n歷史：65.5\n地理：76.75\n公民：80", 排名 = 43, 組別 = "社會組", 總分 = new decimal?(426.5m), 備註 = "53193114", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619027")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：80.75\n英文：70.5\n數學：64.25\n歷史：78.25\n地理：78.25\n公民：81", 排名 = 15, 組別 = "社會組", 總分 = new decimal?(453m), 備註 = "53193115", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619029")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：73.5\n英文：72\n數學：47.75\n歷史：65.25\n地理：68.75\n公民：79.25", 排名 = 52, 組別 = "社會組", 總分 = new decimal?(406.5m), 備註 = "53193116", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619031")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：67.75\n英文：72.5\n數學：64\n歷史：64.25\n地理：73\n公民：81", 排名 = 47, 組別 = "社會組", 總分 = new decimal?(422.5m), 備註 = "53193117", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619104")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：77\n英文：66.75\n數學：68.75\n歷史：74\n地理：75\n公民：82.5", 排名 = 25, 組別 = "社會組", 總分 = new decimal?(444m), 備註 = "53193118", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619032")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：75\n英文：69\n數學：71.5\n歷史：72.5\n地理：75.25\n公民：81.25", 排名 = 24, 組別 = "社會組", 總分 = new decimal?(444.5m), 備註 = "53193119", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619107")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：74\n英文：74.25\n數學：62.25\n歷史：67\n地理：67.75\n公民：80", 排名 = 44, 組別 = "社會組", 總分 = new decimal?(425.25m), 備註 = "53193120", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619034")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：77.5\n英文：75.5\n數學：73.25\n歷史：71.5\n地理：78.75\n公民：81", 排名 = 11, 組別 = "社會組", 總分 = new decimal?(457.5m), 備註 = "53193121", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619108")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：78.25\n英文：79\n數學：77.75\n歷史：73.25\n地理：78\n公民：84.5", 排名 = 4, 組別 = "社會組", 總分 = new decimal?(470.75m), 備註 = "53193122", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619147")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：67.5\n英文：63.75\n數學：55.75\n歷史：63\n地理：66.25\n公民：81.75", 排名 = 57, 組別 = "社會組", 總分 = new decimal?(398m), 備註 = "53193123", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619149")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：79.5\n英文：70.25\n數學：46.25\n歷史：76.25\n地理：74\n公民：85.25", 排名 = 39, 組別 = "社會組", 總分 = new decimal?(431.5m), 備註 = "53193124", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619035")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：76.25\n英文：65\n數學：62\n歷史：73.25\n地理：75\n公民：82.75", 排名 = 33, 組別 = "社會組", 總分 = new decimal?(434.25m), 備註 = "53193125", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619111")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：77.25\n英文：84.75\n數學：59.5\n歷史：73.75\n地理：78.25\n公民：78.25", 排名 = 17, 組別 = "社會組", 總分 = new decimal?(451.75m), 備註 = "53193126", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619113")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：81.25\n英文：71.25\n數學：64.75\n歷史：70.25\n地理：75.5\n公民：80.5", 排名 = 27, 組別 = "社會組", 總分 = new decimal?(443.5m), 備註 = "53193127", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619153")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：83.5\n英文：80\n數學：73.75\n歷史：81\n地理：78.25\n公民：87", 排名 = 3, 組別 = "社會組", 總分 = new decimal?(483.5m), 備註 = "53193128", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619037")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：72.25\n英文：53.5\n數學：46\n歷史：66.25\n地理：66\n公民：81.5", 排名 = 62, 組別 = "社會組", 總分 = new decimal?(385.5m), 備註 = "53193129", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619038")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：71.5\n英文：70.75\n數學：54.25\n歷史：64.5\n地理：73\n公民：82.5", 排名 = 49, 組別 = "社會組", 總分 = new decimal?(416.5m), 備註 = "53193130", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619156")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：77.5\n英文：78.5\n數學：64\n歷史：73\n地理：77.75\n公民：86.75", 排名 = 10, 組別 = "社會組", 總分 = new decimal?(457.5m), 備註 = "53193131", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619157")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：70.5\n英文：76.25\n數學：56.25\n歷史：68.5\n地理：70.25\n公民：82", 排名 = 45, 組別 = "社會組", 總分 = new decimal?(423.75m), 備註 = "53193132", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619039")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：79\n英文：73.5\n數學：63.25\n歷史：75\n地理：77.25\n公民：82.5", 排名 = 18, 組別 = "社會組", 總分 = new decimal?(450.5m), 備註 = "53193133", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619119")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：76.25\n英文：69.25\n數學：62.25\n歷史：72.25\n地理：78.75\n公民：84", 排名 = 28, 組別 = "社會組", 總分 = new decimal?(442.75m), 備註 = "53193134", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619045")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：58.25\n英文：41.75\n數學：46.75\n歷史：63.75\n地理：62.5\n公民：75", 排名 = 68, 組別 = "社會組", 總分 = new decimal?(348m), 備註 = "53193135", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619122")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：67\n英文：53\n數學：59.5\n歷史：64.75\n地理：65.75\n公民：80", 排名 = 61, 組別 = "社會組", 總分 = new decimal?(390m), 備註 = "53193201", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619083")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：66.25\n英文：55.5\n數學：42.25\n歷史：65.25\n地理：66.25\n公民：76.5", 排名 = 66, 組別 = "社會組", 總分 = new decimal?(372m), 備註 = "53193202", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619084")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：60.75\n英文：49.25\n數學：52\n歷史：68.75\n地理：68\n公民：75.25", 排名 = 65, 組別 = "社會組", 總分 = new decimal?(374m), 備註 = "53193203", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619043")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：76.25\n英文：72.25\n數學：67.75\n歷史：81.25\n地理：77.5\n公民：85.25", 排名 = 5, 組別 = "社會組", 總分 = new decimal?(460.25m), 備註 = "53193204", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619049")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：76.75\n英文：84\n數學：60\n歷史：76\n地理：77.5\n公民：84.5", 排名 = 6, 組別 = "社會組", 總分 = new decimal?(458.75m), 備註 = "53193205", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619053")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：67.75\n英文：63.75\n數學：53\n歷史：68.5\n地理：69\n公民：80.75", 排名 = 54, 組別 = "社會組", 總分 = new decimal?(402.75m), 備註 = "53193206", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619093")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：81.25\n英文：80\n數學：68.5\n歷史：74.5\n地理：73\n公民：81.25", 排名 = 8, 組別 = "社會組", 總分 = new decimal?(458.5m), 備註 = "53193207", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619054")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：75.75\n英文：66.25\n數學：57.5\n歷史：77\n地理：70.5\n公民：85.25", 排名 = 37, 組別 = "社會組", 總分 = new decimal?(432.25m), 備註 = "53193208", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619097")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：78.25\n英文：67.5\n數學：61.5\n歷史：70.25\n地理：68.5\n公民：81.25", 排名 = 41, 組別 = "社會組", 總分 = new decimal?(427.25m), 備註 = "53193209", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619135")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：54.5\n英文：38.75\n數學：41.25\n歷史：54.25\n地理：58.75\n公民：77", 排名 = 69, 組別 = "社會組", 總分 = new decimal?(324.5m), 備註 = "53193210", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619058")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：75.75\n英文：71.75\n數學：71.25\n歷史：70.25\n地理：75.5\n公民：82.5", 排名 = 22, 組別 = "社會組", 總分 = new decimal?(447m), 備註 = "53193211", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619136")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：75\n英文：66.75\n數學：60.25\n歷史：72.75\n地理：68\n公民：84", 排名 = 42, 組別 = "社會組", 總分 = new decimal?(426.75m), 備註 = "53193212", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619059")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：77\n英文：73.5\n數學：68\n歷史：74\n地理：77.25\n公民：86.25", 排名 = 14, 組別 = "社會組", 總分 = new decimal?(456m), 備註 = "53193213", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619101")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：76.75\n英文：81\n數學：65\n歷史：72.25\n地理：73.75\n公民：83.25", 排名 = 16, 組別 = "社會組", 總分 = new decimal?(452m), 備註 = "53193214", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619139")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：70.5\n英文：68\n數學：58.25\n歷史：66\n地理：67.75\n公民：78.25", 排名 = 51, 組別 = "社會組", 總分 = new decimal?(408.75m), 備註 = "53193215", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619141")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：75.25\n英文：72.75\n數學：50.5\n歷史：73.75\n地理：66.5\n公民：84", 排名 = 46, 組別 = "社會組", 總分 = new decimal?(422.75m), 備註 = "53193216", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619061")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：84\n英文：83.5\n數學：70.25\n歷史：81.5\n地理：79.25\n公民：85.5", 排名 = 2, 組別 = "社會組", 總分 = new decimal?(484m), 備註 = "53193217", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619102")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：73.25\n英文：72\n數學：69\n歷史：68.75\n地理：73.5\n公民：84.25", 排名 = 29, 組別 = "社會組", 總分 = new decimal?(440.75m), 備註 = "53193218", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619063")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：79\n英文：87\n數學：90.5\n歷史：78.25\n地理：75.5\n公民：83.75", 排名 = 1, 組別 = "社會組", 總分 = new decimal?(494m), 備註 = "53193219", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619103")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：75.25\n英文：62.25\n數學：59.25\n歷史：67.25\n地理：73.5\n公民：81.75", 排名 = 48, 組別 = "社會組", 總分 = new decimal?(419.25m), 備註 = "53193220", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619066")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：77.5\n英文：56\n數學：61.75\n歷史：76.75\n地理：76.75\n公民：85", 排名 = 34, 組別 = "社會組", 總分 = new decimal?(433.75m), 備註 = "53193221", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619067")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：71\n英文：75\n數學：72\n歷史：73\n地理：73.25\n公民：83", 排名 = 21, 組別 = "社會組", 總分 = new decimal?(447.25m), 備註 = "53193222", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619068")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：61.75\n英文：57.5\n數學：46.5\n歷史：71.25\n地理：67.5\n公民：78", 排名 = 64, 組別 = "社會組", 總分 = new decimal?(382.5m), 備註 = "53193223", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619069")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：76.75\n英文：73.75\n數學：69.75\n歷史：78\n地理：73.25\n公民：84.75", 排名 = 12, 組別 = "社會組", 總分 = new decimal?(456.25m), 備註 = "53193224", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619109")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：71.25\n英文：76.75\n數學：57.5\n歷史：72.75\n地理：75.75\n公民：83", 排名 = 31, 組別 = "社會組", 總分 = new decimal?(437m), 備註 = "53193225", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619071")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：70.75\n英文：72.25\n數學：48.25\n歷史：69\n地理：67\n公民：81.75", 排名 = 50, 組別 = "社會組", 總分 = new decimal?(409m), 備註 = "53193226", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619072")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：67.5\n英文：57.75\n數學：51.25\n歷史：71.75\n地理：70.75\n公民：83.25", 排名 = 55, 組別 = "社會組", 總分 = new decimal?(402.25m), 備註 = "53193227", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619150")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：78.75\n英文：67.75\n數學：57.25\n歷史：73.5\n地理：69\n公民：84.5", 排名 = 40, 組別 = "社會組", 總分 = new decimal?(430.75m), 備註 = "53193228", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619073")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：76.75\n英文：70.25\n數學：56\n歷史：77.25\n地理：71\n公民：83.5", 排名 = 32, 組別 = "社會組", 總分 = new decimal?(434.75m), 備註 = "53193229", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619075")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：76.75\n英文：71.5\n數學：77.5\n歷史：71.5\n地理：75.5\n公民：85.5", 排名 = 9, 組別 = "社會組", 總分 = new decimal?(458.25m), 備註 = "53193230", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619115")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：78.25\n英文：66.25\n數學：59.5\n歷史：73.25\n地理：77.75\n公民：84.5", 排名 = 30, 組別 = "社會組", 總分 = new decimal?(439.5m), 備註 = "53193231", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619116")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：68.25\n英文：78.75\n數學：48\n歷史：60\n地理：65.25\n公民：77", 排名 = 58, 組別 = "社會組", 總分 = new decimal?(397.25m), 備註 = "53193232", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619078")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：69.75\n英文：80.5\n數學：59.25\n歷史：73.5\n地理：69\n公民：80.75", 排名 = 35, 組別 = "社會組", 總分 = new decimal?(432.75m), 備註 = "53193233", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619079")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：59.75\n英文：55.25\n數學：47.75\n歷史：65\n地理：65.75\n公民：76.75", 排名 = 67, 組別 = "社會組", 總分 = new decimal?(370.25m), 備註 = "53193234", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619001")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：71\n英文：70.25\n數學：68.25\n物理：68.75\n化學：70.5\n生物：70.33", 排名 = 43, 組別 = "自然組", 總分 = new decimal?(419.08m), 備註 = "53193301", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619081")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：66.25\n英文：50\n數學：47.25\n物理：57.25\n化學：55.25\n生物：61.67", 排名 = 86, 組別 = "自然組", 總分 = new decimal?(337.67m), 備註 = "53193302", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619082")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：71.75\n英文：71\n數學：81.5\n物理：91.5\n化學：83.25\n生物：65.67", 排名 = 12, 組別 = "自然組", 總分 = new decimal?(464.67m), 備註 = "53193303", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619041")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：66.25\n英文：61\n數學：57\n物理：62.25\n化學：60\n生物：68", 排名 = 74, 組別 = "自然組", 總分 = new decimal?(374.5m), 備註 = "53193304", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619085")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：68.75\n英文：57.75\n數學：74\n物理：68\n化學：62.75\n生物：66", 排名 = 58, 組別 = "自然組", 總分 = new decimal?(397.25m), 備註 = "53193305", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619044")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：61.75\n英文：63.25\n數學：44.5\n物理：46\n化學：63.25\n生物：71.33", 排名 = 82, 組別 = "自然組", 總分 = new decimal?(350.08m), 備註 = "53193306", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619086")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：67.5\n英文：51\n數學：83.75\n物理：78\n化學：63.5\n生物：64.67", 排名 = 46, 組別 = "自然組", 總分 = new decimal?(408.42m), 備註 = "53193307", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619046")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：55.5\n英文：44.5\n數學：45\n物理：52.5\n化學：53.5\n生物：59", 排名 = 89, 組別 = "自然組", 總分 = new decimal?(310m), 備註 = "53193309", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619087")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：72.25\n英文：47.5\n數學：53.5\n物理：64.25\n化學：59\n生物：74.67", 排名 = 76, 組別 = "自然組", 總分 = new decimal?(371.17m), 備註 = "53193310", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619048")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：70.5\n英文：66\n數學：72.75\n物理：75.5\n化學：73\n生物：61.67", 排名 = 42, 組別 = "自然組", 總分 = new decimal?(419.42m), 備註 = "53193311", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619088")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：69.25\n英文：61.5\n數學：66\n物理：71.75\n化學：62.75\n生物：66.33", 排名 = 56, 組別 = "自然組", 總分 = new decimal?(397.58m), 備註 = "53193312", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619089")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：72\n英文：40.5\n數學：56.25\n物理：59\n化學：61\n生物：59", 排名 = 84, 組別 = "自然組", 總分 = new decimal?(347.75m), 備註 = "53193313", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619090")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：73\n英文：71\n數學：80.75\n物理：79.75\n化學：78.5\n生物：78", 排名 = 15, 組別 = "自然組", 總分 = new decimal?(461m), 備註 = "53193314", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619091")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：68.75\n英文：62\n數學：64.5\n物理：64.25\n化學：65.5\n生物：70.33", 排名 = 59, 組別 = "自然組", 總分 = new decimal?(395.33m), 備註 = "53193315", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619010")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：60.75\n英文：68.75\n數學：73\n物理：63.75\n化學：63.5\n生物：58.67", 排名 = 68, 組別 = "自然組", 總分 = new decimal?(388.42m), 備註 = "53193316", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619050")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：66\n英文：61.25\n數學：68.5\n物理：72.25\n化學：66.5\n生物：69.33", 排名 = 51, 組別 = "自然組", 總分 = new decimal?(403.83m), 備註 = "53193317", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619092")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：70.75\n英文：66.5\n數學：63\n物理：64\n化學：60.25\n生物：64.67", 排名 = 65, 組別 = "自然組", 總分 = new decimal?(389.17m), 備註 = "53193318", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619094")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：68\n英文：66.75\n數學：64.5\n物理：70\n化學：66.25\n生物：71", 排名 = 48, 組別 = "自然組", 總分 = new decimal?(406.5m), 備註 = "53193319", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619015")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：70\n英文：63.5\n數學：56.25\n物理：57.75\n化學：64.25\n生物：65.67", 排名 = 72, 組別 = "自然組", 總分 = new decimal?(377.42m), 備註 = "53193320", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619095")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：74.25\n英文：72.25\n數學：69.75\n物理：74.25\n化學：74\n生物：69", 排名 = 30, 組別 = "自然組", 總分 = new decimal?(433.5m), 備註 = "53193321", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619055")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：71\n英文：70.25\n數學：68\n物理：72.25\n化學：80.25\n生物：83", 排名 = 22, 組別 = "自然組", 總分 = new decimal?(444.75m), 備註 = "53193322", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619096")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：67.75\n英文：65.75\n數學：67.75\n物理：70.25\n化學：72.25\n生物：72", 排名 = 44, 組別 = "自然組", 總分 = new decimal?(415.75m), 備註 = "53193323", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619056")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：56.5\n英文：56\n數學：46.75\n物理：46.25\n化學：50.5\n生物：60.67", 排名 = 88, 組別 = "自然組", 總分 = new decimal?(316.67m), 備註 = "53193324", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619018")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：80\n英文：82\n數學：80.5\n物理：86\n化學：82.25\n生物：82.67", 排名 = 1, 組別 = "自然組", 總分 = new decimal?(493.42m), 備註 = "53193325", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619098")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：74.5\n英文：89\n數學：80.75\n物理：75.75\n化學：76.75\n生物：67", 排名 = 13, 組別 = "自然組", 總分 = new decimal?(463.75m), 備註 = "53193326", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619099")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：78\n英文：81.25\n數學：73.25\n物理：88\n化學：81\n生物：81.33", 排名 = 5, 組別 = "自然組", 總分 = new decimal?(482.83m), 備註 = "53193327", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619020")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：73.25\n英文：63\n數學：52\n物理：58.5\n化學：70.25\n生物：72", 排名 = 67, 組別 = "自然組", 總分 = new decimal?(389m), 備註 = "53193328", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619021")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：63\n英文：56.75\n數學：50\n物理：60.25\n化學：61.5\n生物：63", 排名 = 80, 組別 = "自然組", 總分 = new decimal?(354.5m), 備註 = "53193329", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619100")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：75\n英文：77.75\n數學：84\n物理：80.5\n化學：75.25\n生物：75", 排名 = 11, 組別 = "自然組", 總分 = new decimal?(467.5m), 備註 = "53193330", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619024")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：74.5\n英文：65.25\n數學：71.5\n物理：70.75\n化學：71.25\n生物：73", 排名 = 37, 組別 = "自然組", 總分 = new decimal?(426.25m), 備註 = "53193331", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619028")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：72.5\n英文：70.5\n數學：81.25\n物理：70.5\n化學：79.5\n生物：88", 排名 = 14, 組別 = "自然組", 總分 = new decimal?(462.25m), 備註 = "53193332", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619062")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：62.75\n英文：54.75\n數學：51.75\n物理：54.25\n化學：58.5\n生物：61.33", 排名 = 85, 組別 = "自然組", 總分 = new decimal?(343.33m), 備註 = "53193333", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619064")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：68.5\n英文：79.5\n數學：55.25\n物理：54.25\n化學：64\n生物：63.67", 排名 = 69, 組別 = "自然組", 總分 = new decimal?(385.17m), 備註 = "53193334", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619105")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：78\n英文：82.75\n數學：68.75\n物理：74\n化學：71.25\n生物：79.33", 排名 = 19, 組別 = "自然組", 總分 = new decimal?(454.08m), 備註 = "53193335", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619106")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：68\n英文：68.5\n數學：69.25\n物理：65.25\n化學：64.75\n生物：67.33", 排名 = 53, 組別 = "自然組", 總分 = new decimal?(403.08m), 備註 = "53193336", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619033")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：74\n英文：73.5\n數學：64.75\n物理：74.75\n化學：73.25\n生物：74.33", 排名 = 28, 組別 = "自然組", 總分 = new decimal?(434.58m), 備註 = "53193337", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619110")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：70.25\n英文：62\n數學：76\n物理：78.25\n化學：74.5\n生物：73", 排名 = 29, 組別 = "自然組", 總分 = new decimal?(434m), 備註 = "53193338", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619112")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：70.5\n英文：71\n數學：66.25\n物理：81.25\n化學：73.5\n生物：69.33", 排名 = 32, 組別 = "自然組", 總分 = new decimal?(431.83m), 備註 = "53193339", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619036")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：74\n英文：69.5\n數學：71.25\n物理：78.5\n化學：79.75\n生物：77", 排名 = 21, 組別 = "自然組", 總分 = new decimal?(450m), 備註 = "53193340", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619117")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：70.75\n英文：72\n數學：73.5\n物理：73.25\n化學：72\n生物：68.33", 排名 = 35, 組別 = "自然組", 總分 = new decimal?(429.83m), 備註 = "53193341", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619077")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：66.75\n英文：66.25\n數學：60.25\n物理：67.5\n化學：68.25\n生物：68.33", 排名 = 57, 組別 = "自然組", 總分 = new decimal?(397.33m), 備註 = "53193342", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619080")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：75.75\n英文：79.5\n數學：71.5\n物理：64\n化學：70\n生物：75.67", 排名 = 27, 組別 = "自然組", 總分 = new decimal?(436.42m), 備註 = "53193343", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619118")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：69\n英文：61\n數學：68.5\n物理：62.25\n化學：61.75\n生物：67", 排名 = 64, 組別 = "自然組", 總分 = new decimal?(389.5m), 備註 = "53193344", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619120")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：63.5\n英文：62.25\n數學：54.5\n物理：62\n化學：64.25\n生物：70", 排名 = 73, 組別 = "自然組", 總分 = new decimal?(376.5m), 備註 = "53193345", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619003")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：61.25\n英文：53.5\n數學：51.5\n物理：65.25\n化學：57.75\n生物：58.67", 排名 = 83, 組別 = "自然組", 總分 = new decimal?(347.92m), 備註 = "53193401", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619123")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：78\n英文：80\n數學：71.75\n物理：78.25\n化學：83.75\n生物：83.33", 排名 = 9, 組別 = "自然組", 總分 = new decimal?(475.08m), 備註 = "53193402", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619124")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：68.25\n英文：64.25\n數學：50.25\n物理：66.75\n化學：71.25\n生物：68.33", 排名 = 66, 組別 = "自然組", 總分 = new decimal?(389.08m), 備註 = "53193403", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619125")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：60.75\n英文：50.75\n數學：58\n物理：72.25\n化學：70.75\n生物：66.33", 排名 = 70, 組別 = "自然組", 總分 = new decimal?(378.83m), 備註 = "53193404", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619042")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：60.5\n英文：46.75\n數學：47\n物理：64\n化學：61\n生物：72", 排名 = 81, 組別 = "自然組", 總分 = new decimal?(351.25m), 備註 = "53193405", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619004")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：76.75\n英文：71.25\n數學：59\n物理：75.5\n化學：69.75\n生物：73", 排名 = 39, 組別 = "自然組", 總分 = new decimal?(425.25m), 備註 = "53193406", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619126")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：66.25\n英文：55\n數學：61.5\n物理：70.5\n化學：77\n生物：64.67", 排名 = 60, 組別 = "自然組", 總分 = new decimal?(394.92m), 備註 = "53193407", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619127")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：69.25\n英文：46.25\n數學：63.25\n物理：72.75\n化學：88.25\n生物：87", 排名 = 36, 組別 = "自然組", 總分 = new decimal?(426.75m), 備註 = "53193408", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619007")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：73.75\n英文：63.5\n數學：54.25\n物理：63.75\n化學：67.25\n生物：71.33", 排名 = 61, 組別 = "自然組", 總分 = new decimal?(393.83m), 備註 = "53193409", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619008")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：64\n英文：56\n數學：48.25\n物理：60.75\n化學：58.5\n生物：69.67", 排名 = 79, 組別 = "自然組", 總分 = new decimal?(357.17m), 備註 = "53193410", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619047")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：74.25\n英文：74.25\n數學：79.25\n物理：87\n化學：88\n生物：81", 排名 = 4, 組別 = "自然組", 總分 = new decimal?(483.75m), 備註 = "53193411", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619011")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：72.5\n英文：69.5\n數學：66.75\n物理：76.5\n化學：72.25\n生物：75", 排名 = 31, 組別 = "自然組", 總分 = new decimal?(432.5m), 備註 = "53193412", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619128")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：72\n英文：63.75\n數學：54\n物理：68.5\n化學：74.5\n生物：74.67", 排名 = 47, 組別 = "自然組", 總分 = new decimal?(407.42m), 備註 = "53193413", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619051")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：62.5\n英文：55.5\n數學：65.75\n物理：78.25\n化學：70.5\n生物：66.67", 排名 = 55, 組別 = "自然組", 總分 = new decimal?(399.17m), 備註 = "53193414", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619129")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：79\n英文：78.25\n數學：81.25\n物理：80.75\n化學：87\n生物：75", 排名 = 7, 組別 = "自然組", 總分 = new decimal?(481.25m), 備註 = "53193415", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619052")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：60.25\n英文：63.25\n數學：32\n物理：43.75\n化學：58.25\n生物：60.33", 排名 = 87, 組別 = "自然組", 總分 = new decimal?(317.83m), 備註 = "53193416", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619130")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：68.5\n英文：64\n數學：53.75\n物理：72.75\n化學：73.75\n生物：70.33", 排名 = 54, 組別 = "自然組", 總分 = new decimal?(403.08m), 備註 = "53193417", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619131")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：65.75\n英文：60.5\n數學：87\n物理：80.75\n化學：76\n生物：66.67", 排名 = 26, 組別 = "自然組", 總分 = new decimal?(436.67m), 備註 = "53193418", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619012")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：62.75\n英文：50\n數學：50.75\n物理：66.25\n化學：62.5\n生物：67.67", 排名 = 78, 組別 = "自然組", 總分 = new decimal?(359.92m), 備註 = "53193419", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619132")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：80.75\n英文：83.75\n數學：76\n物理：84.75\n化學：81.75\n生物：74.33", 排名 = 6, 組別 = "自然組", 總分 = new decimal?(481.33m), 備註 = "53193420", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619133")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：72.75\n英文：69.25\n數學：52\n物理：67.25\n化學：68.5\n生物：74", 排名 = 52, 組別 = "自然組", 總分 = new decimal?(403.75m), 備註 = "53193421", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619057")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：73\n英文：59.5\n數學：47\n物理：58\n化學：65\n生物：68.33", 排名 = 77, 組別 = "自然組", 總分 = new decimal?(370.83m), 備註 = "53193422", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619137")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：75.5\n英文：84\n數學：70.5\n物理：83.25\n化學：83\n生物：75", 排名 = 10, 組別 = "自然組", 總分 = new decimal?(471.25m), 備註 = "53193423", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619138")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：74.75\n英文：76.25\n數學：66\n物理：82\n化學：81.25\n生物：75", 排名 = 18, 組別 = "自然組", 總分 = new decimal?(455.25m), 備註 = "53193424", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619140")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：67.5\n英文：70\n數學：54\n物理：67\n化學：70\n生物：63.67", 排名 = 62, 組別 = "自然組", 總分 = new decimal?(392.17m), 備註 = "53193425", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619026")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：76\n英文：73.5\n數學：64.25\n物理：68.75\n化學：71.25\n生物：72.33", 排名 = 38, 組別 = "自然組", 總分 = new decimal?(426.08m), 備註 = "53193426", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619060")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：61.75\n英文：62.75\n數學：51.5\n物理：63.75\n化學：66.25\n生物：67.33", 排名 = 75, 組別 = "自然組", 總分 = new decimal?(373.33m), 備註 = "53193427", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619030")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：78.25\n英文：62\n數學：68.75\n物理：69\n化學：72.5\n生物：71.67", 排名 = 41, 組別 = "自然組", 總分 = new decimal?(422.17m), 備註 = "53193428", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619142")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：72.5\n英文：68.75\n數學：47.25\n物理：70.75\n化學：66.25\n生物：66.67", 排名 = 63, 組別 = "自然組", 總分 = new decimal?(392.17m), 備註 = "53193429", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619065")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：65.25\n英文：65\n數學：49.25\n物理：61.25\n化學：65.75\n生物：71", 排名 = 71, 組別 = "自然組", 總分 = new decimal?(377.5m), 備註 = "53193430", 梯次 = new int?(3) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619143")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：79.75\n英文：79.5\n數學：77.75\n物理：85.75\n化學：85.75\n生物：80.67", 排名 = 2, 組別 = "自然組", 總分 = new decimal?(489.17m), 備註 = "53193431", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619144")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：81\n英文：85.75\n數學：73.5\n物理：81.25\n化學：84.75\n生物：79.33", 排名 = 3, 組別 = "自然組", 總分 = new decimal?(485.58m), 備註 = "53193432", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619145")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：79\n英文：87.25\n數學：68.75\n物理：74.75\n化學：77.5\n生物：73", 排名 = 16, 組別 = "自然組", 總分 = new decimal?(460.25m), 備註 = "53193433", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619146")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：73.5\n英文：67\n數學：49.25\n物理：67.75\n化學：77.5\n生物：74.67", 排名 = 45, 組別 = "自然組", 總分 = new decimal?(409.67m), 備註 = "53193434", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619148")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：76.75\n英文：67\n數學：60\n物理：75\n化學：77.5\n生物：75", 排名 = 33, 組別 = "自然組", 總分 = new decimal?(431.25m), 備註 = "53193435", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619070")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：72.5\n英文：72.75\n數學：61.5\n物理：71.5\n化學：73.25\n生物：71.33", 排名 = 40, 組別 = "自然組", 總分 = new decimal?(422.83m), 備註 = "53193436", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619151")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：77\n英文：74.75\n數學：68\n物理：78.25\n化學：83.25\n生物：78", 排名 = 17, 組別 = "自然組", 總分 = new decimal?(459.25m), 備註 = "53193437", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619152")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：77.25\n英文：75\n數學：59\n物理：78\n化學：74\n生物：76.33", 排名 = 25, 組別 = "自然組", 總分 = new decimal?(439.58m), 備註 = "53193438", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619074")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：81.5\n英文：76.75\n數學：62.25\n物理：70.25\n化學：75.75\n生物：73.67", 排名 = 24, 組別 = "自然組", 總分 = new decimal?(440.17m), 備註 = "53193439", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619154")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：79\n英文：79.75\n數學：62.5\n物理：69.75\n化學：78.75\n生物：73.67", 排名 = 23, 組別 = "自然組", 總分 = new decimal?(443.42m), 備註 = "53193440", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619114")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：73.25\n英文：76\n數學：75.75\n物理：77.25\n化學：78.25\n生物：69.67", 排名 = 20, 組別 = "自然組", 總分 = new decimal?(450.17m), 備註 = "53193441", 梯次 = new int?(1) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619155")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：75.5\n英文：67.25\n數學：60\n物理：72.5\n化學：79.5\n生物：76", 排名 = 34, 組別 = "自然組", 總分 = new decimal?(430.75m), 備註 = "53193442", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619076")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：68\n英文：66.5\n數學：65\n物理：68.5\n化學：66.5\n生物：71", 排名 = 49, 組別 = "自然組", 總分 = new decimal?(405.5m), 備註 = "53193443", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619159")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：78\n英文：66.75\n數學：53.75\n物理：63.5\n化學：74.25\n生物：67.67", 排名 = 50, 組別 = "自然組", 總分 = new decimal?(403.92m), 備註 = "53193444", 梯次 = new int?(2) });
                    break;
                }
            }
            foreach (var student in students)
            {
                if (student.StudentNumber == "619040")
                {
                    list.Add(new 推甄學生資料() { StudentRecord = student, 成績內容 = "國文：79\n英文：87.25\n數學：72.25\n物理：79\n化學：81.75\n生物：78", 排名 = 8, 組別 = "自然組", 總分 = new decimal?(477.25m), 備註 = "53193445", 梯次 = new int?(1) });
                    break;
                }
            }


            #endregion
            list.SaveAll();
        }

        static void Program_Click(object sender, EventArgs e)
        {

            List<校系資料> defaultList = new List<校系資料>();
            #region 就是寫這麼多行才是大師
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "中國文學系", 代碼 = "001011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "外國語文學系", 代碼 = "001021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "歷史學系", 代碼 = "001031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "哲學系", 代碼 = "001041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "人類學系", 代碼 = "001051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "圖書資訊學系", 代碼 = "001061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "日本語文學系", 代碼 = "001071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "戲劇學系", 代碼 = "001081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "數學系", 代碼 = "001091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "物理學系", 代碼 = "001101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "化學系", 代碼 = "001111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "地質科學系", 代碼 = "001121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "心理學系", 代碼 = "001131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "地理環境資源學系", 代碼 = "001141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "大氣科學系", 代碼 = "001151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "政治學系政治理論組", 代碼 = "001161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "政治學系國際關係組", 代碼 = "001171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "政治學系公共行政組", 代碼 = "001181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "經濟學系", 代碼 = "001191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "社會學系", 代碼 = "001201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "社會工作學系", 代碼 = "001211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "醫學系", 代碼 = "001221", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "牙醫學系", 代碼 = "001231", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "藥學系", 代碼 = "001241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "醫學檢驗暨生物技術學系", 代碼 = "001251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "護理學系", 代碼 = "001261", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "物理治療學系", 代碼 = "001271", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "職能治療學系", 代碼 = "001281", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "農藝學系", 代碼 = "001341", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "生物環境系統工程學系", 代碼 = "001351", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "農業化學系", 代碼 = "001361", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "森林環境暨資源學系", 代碼 = "001371", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "動物科學技術學系", 代碼 = "001381", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "農業經濟學系", 代碼 = "001391", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "園藝學系", 代碼 = "001401", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "獸醫學系", 代碼 = "001411", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "生物產業傳播暨發展學系", 代碼 = "001421", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "生物產業機電工程學系", 代碼 = "001431", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "植物病理與微生物學系", 代碼 = "001451", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "工商管理學系企業管理組", 代碼 = "001461", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "工商管理學系科技管理組", 代碼 = "001471", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "會計學系", 代碼 = "001481", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "財務金融學系", 代碼 = "001491", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "國際企業學系", 代碼 = "001501", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "公共衛生學系", 代碼 = "001521", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "電機工程學系", 代碼 = "001531", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "法律學系法學組", 代碼 = "001551", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "法律學系司法組", 代碼 = "001561", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "法律學系財經法學組", 代碼 = "001571", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "生命科學系", 代碼 = "001581", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣大學", 系名 = "生化科技學系", 代碼 = "001591", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "教育學系", 代碼 = "002011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "特殊教育學系", 代碼 = "002081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "物理學系", 代碼 = "002141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "化學系", 代碼 = "002151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "生命科學系", 代碼 = "002161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "地球科學系", 代碼 = "002171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "工業教育學系室內設計組", 代碼 = "002191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "圖文傳播學系", 代碼 = "002211", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "機電科技學系", 代碼 = "002221", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "應用電子科技學系", 代碼 = "002231", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "應用華語文學系", 代碼 = "002241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "東亞文化暨發展學系", 代碼 = "002251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "企業管理學士學位學程", 代碼 = "002261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣師範大學", 系名 = "視覺設計學系", 代碼 = "002301", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "中國文學系", 代碼 = "003011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "外國語文學系", 代碼 = "003021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "歷史學系", 代碼 = "003031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "財務金融學系", 代碼 = "003041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "企業管理學系", 代碼 = "003051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "法律學系", 代碼 = "003061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "會計學系", 代碼 = "003081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "行銷學系", 代碼 = "003091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "化學系", 代碼 = "003101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "物理學系一般物理組", 代碼 = "003111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "物理學系光電物理組", 代碼 = "003121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "應用數學系", 代碼 = "003131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "資訊科學與工程學系", 代碼 = "003141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "機械工程學系", 代碼 = "003151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "土木工程學系", 代碼 = "003161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "環境工程學系", 代碼 = "003171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "電機工程學系", 代碼 = "003181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "化學工程學系", 代碼 = "003191", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "材料科學與工程學系", 代碼 = "003201", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "食品暨應用生物科技學系", 代碼 = "003211", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "農藝學系", 代碼 = "003221", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "應用經濟學系", 代碼 = "003241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "森林學系林學組", 代碼 = "003251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "森林學系木材科學組", 代碼 = "003261", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "植物病理學系", 代碼 = "003271", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "昆蟲學系", 代碼 = "003281", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "動物科學系", 代碼 = "003291", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "土壤環境科學系", 代碼 = "003301", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "生物產業機電工程學系", 代碼 = "003311", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "水土保持學系", 代碼 = "003321", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "生命科學系", 代碼 = "003351", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中興大學", 系名 = "獸醫學系", 代碼 = "003361", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "中國文學系", 代碼 = "004011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "外國語文學系", 代碼 = "004021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "歷史學系", 代碼 = "004031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "台灣文學系", 代碼 = "004041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "物理學系物理組", 代碼 = "004061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "物理學系光電科學組", 代碼 = "004071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "化學系", 代碼 = "004081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "地球科學系", 代碼 = "004091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "機械工程學系", 代碼 = "004101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "化學工程學系", 代碼 = "004111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "材料科學及工程學系", 代碼 = "004121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "資源工程學系", 代碼 = "004131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "水利及海洋工程學系", 代碼 = "004151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "系統及船舶機電工程學系", 代碼 = "004171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "航空太空工程學系", 代碼 = "004181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "環境工程學系", 代碼 = "004191", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "測量及空間資訊學系", 代碼 = "004201", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "工業與資訊管理學系", 代碼 = "004211", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "交通管理科學系", 代碼 = "004221", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "企業管理學系", 代碼 = "004231", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "統計學系", 代碼 = "004241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "會計學系", 代碼 = "004251", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "醫學系", 代碼 = "004261", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "醫學檢驗生物技術學系", 代碼 = "004271", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "護理學系", 代碼 = "004281", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "物理治療學系", 代碼 = "004301", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "政治學系", 代碼 = "004311", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "經濟學系", 代碼 = "004321", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "法律學系", 代碼 = "004331", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "心理學系", 代碼 = "004341", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "資訊工程學系", 代碼 = "004361", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "光電工程學系", 代碼 = "004371", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "建築學系", 代碼 = "004381", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "都市計劃學系", 代碼 = "004391", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "工業設計學系", 代碼 = "004401", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立成功大學", 系名 = "生命科學系", 代碼 = "004411", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東吳大學", 系名 = "中國文學系", 代碼 = "005011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東吳大學", 系名 = "政治學系", 代碼 = "005031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東吳大學", 系名 = "英文學系", 代碼 = "005061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東吳大學", 系名 = "日本語文學系", 代碼 = "005071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東吳大學", 系名 = "法律學系", 代碼 = "005101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東吳大學", 系名 = "會計學系", 代碼 = "005121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東吳大學", 系名 = "國際經營與貿易學系", 代碼 = "005131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東吳大學", 系名 = "財務工程與精算數學系", 代碼 = "005141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "中國文學系", 代碼 = "006011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "歷史學系", 代碼 = "006021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "教育學系", 代碼 = "006041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "政治學系", 代碼 = "006051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "社會學系", 代碼 = "006061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "財政學系", 代碼 = "006071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "經濟學系", 代碼 = "006121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "民族學系", 代碼 = "006131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "新聞學系", 代碼 = "006241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "廣告學系", 代碼 = "006251", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "廣播電視學系", 代碼 = "006261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "傳播學院傳播學士學位學程", 代碼 = "006271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "斯拉夫語文學系", 代碼 = "006301", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "日本語文學系", 代碼 = "006311", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "土耳其語文學系", 代碼 = "006331", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "應用數學系", 代碼 = "006381", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立政治大學", 系名 = "心理學系", 代碼 = "006391", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "醫學系", 代碼 = "007011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "運動醫學系", 代碼 = "007021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "呼吸治療學系", 代碼 = "007031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "牙醫學系", 代碼 = "007041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "口腔衛生學系", 代碼 = "007051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "藥學系", 代碼 = "007061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "香粧品學系", 代碼 = "007071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "護理學系", 代碼 = "007081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "醫學影像暨放射科學系", 代碼 = "007101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "心理學系", 代碼 = "007121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "職能治療學系", 代碼 = "007131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "物理治療學系", 代碼 = "007141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "醫藥暨應用化學系醫藥化學組", 代碼 = "007171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "醫藥暨應用化學系應用化學組", 代碼 = "007181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "高雄醫學大學", 系名 = "生物科技學系", 代碼 = "007201", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "心理學系", 代碼 = "008061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "機械工程學系", 代碼 = "008101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "生物醫學工程學系", 代碼 = "008111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "電機工程學系", 代碼 = "008171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "企業管理學系", 代碼 = "008181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "國際貿易學系", 代碼 = "008191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "會計學系", 代碼 = "008201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "資訊管理學系", 代碼 = "008211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "財務金融學系", 代碼 = "008221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "建築學系", 代碼 = "008241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "室內設計學系", 代碼 = "008251", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "商業設計學系", 代碼 = "008261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中原大學", 系名 = "景觀學系", 代碼 = "008271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "中國文學系", 代碼 = "009011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "外國語文學系", 代碼 = "009021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "歷史學系", 代碼 = "009031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "日本語文學系", 代碼 = "009041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "哲學系", 代碼 = "009051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "物理學系物理組", 代碼 = "009061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "物理學系應用物理組", 代碼 = "009071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "化學系化學組", 代碼 = "009081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "化學系化學生物組", 代碼 = "009091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "生命科學系生物醫學組", 代碼 = "009101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "生命科學系生態暨生物多樣性組", 代碼 = "009111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "數學系", 代碼 = "009121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "化學工程與材料工程學系", 代碼 = "009131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "工業工程與經營資訊學系", 代碼 = "009141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "環境科學與工程學系", 代碼 = "009151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "資訊工程學系資電工程組", 代碼 = "009161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "資訊工程學系軟體工程組", 代碼 = "009171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "資訊工程學系數位創意組", 代碼 = "009181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "電機工程學系", 代碼 = "009191", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "企業管理學系", 代碼 = "009201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "國際貿易學系", 代碼 = "009211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "會計學系", 代碼 = "009221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "財務金融學系", 代碼 = "009231", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "統計學系(自然組)", 代碼 = "009241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "統計學系(社會組)", 代碼 = "009251", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "資訊管理學系", 代碼 = "009261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "經濟學系一般經濟組", 代碼 = "009271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "經濟學系產業經濟組", 代碼 = "009281", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "政治學系政治理論組", 代碼 = "009291", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "政治學系國際關係組", 代碼 = "009301", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "行政管理暨政策學系", 代碼 = "009311", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "社會學系", 代碼 = "009321", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "社會工作學系", 代碼 = "009331", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "畜產與生物科技學系", 代碼 = "009341", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "食品科學系", 代碼 = "009351", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "餐旅管理學系", 代碼 = "009361", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "建築學系", 代碼 = "009371", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "工業設計學系", 代碼 = "009381", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "景觀學系", 代碼 = "009391", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "法律學系", 代碼 = "009401", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "東海大學", 系名 = "美術學系", 代碼 = "009421", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "中國文學系", 代碼 = "011011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "外國語文學系", 代碼 = "011021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "人文社會學院學士班", 代碼 = "011031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "數學系應用數學組", 代碼 = "011041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "數學系純粹數學組", 代碼 = "011051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "物理學系物理組", 代碼 = "011061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "化學系", 代碼 = "011081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "生命科學系", 代碼 = "011091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "生醫工程與環境科學系", 代碼 = "011101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "計量財務金融學系", 代碼 = "011111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "動力機械工程學系", 代碼 = "011131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "材料科學工程學系", 代碼 = "011141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "工業工程與工程管理學系", 代碼 = "011151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "電機工程學系", 代碼 = "011161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "工程與系統科學系", 代碼 = "011171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "資訊工程學系", 代碼 = "011181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "經濟學系", 代碼 = "011191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "理學院學士班", 代碼 = "011201", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "科技管理學院學士班", 代碼 = "011211", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "電機資訊學院學士班", 代碼 = "011221", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "工學院學士班", 代碼 = "011241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "生命科學院學士班", 代碼 = "011251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立清華大學", 系名 = "原子科學院學士班", 代碼 = "011261", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "牙醫學系", 代碼 = "012011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "醫學系", 代碼 = "012021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "中醫學系甲組", 代碼 = "012031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "中醫學系乙組", 代碼 = "012041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "藥學系", 代碼 = "012051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "公共衛生學系", 代碼 = "012061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "護理學系", 代碼 = "012071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "醫學檢驗生物技術學系", 代碼 = "012081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "營養學系", 代碼 = "012091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "物理治療學系", 代碼 = "012101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "生物科技學系", 代碼 = "012111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "運動醫學系", 代碼 = "012121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "中國藥學暨中藥資源學系", 代碼 = "012131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "醫務管理學系", 代碼 = "012141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "職業安全與衛生學系", 代碼 = "012151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "藥用化妝品學系", 代碼 = "012161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "健康風險管理學系", 代碼 = "012171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "生物醫學影像暨放射科學學系", 代碼 = "012181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國醫藥大學", 系名 = "口腔衛生學系", 代碼 = "012191", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "電機資訊學士班", 代碼 = "013011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "奈米科學及工程學士學位學程", 代碼 = "013021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "理學院科學學士學位學程(乙組)", 代碼 = "013031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "理學院科學學士學位學程(丙組)", 代碼 = "013041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "電子工程學系(乙組)", 代碼 = "013061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "電機工程學系(乙組)", 代碼 = "013081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "光電工程學系", 代碼 = "013091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "資訊工程學系資訊工程組", 代碼 = "013111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "材料科學與工程學系", 代碼 = "013131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "機械工程學系", 代碼 = "013141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "土木工程學系", 代碼 = "013151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "電子物理學系光電與奈米科學組", 代碼 = "013161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "電子物理學系電子物理組", 代碼 = "013171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "應用化學系", 代碼 = "013181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "應用數學系", 代碼 = "013191", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "生物科技學系", 代碼 = "013201", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "管理科學系", 代碼 = "013221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "運輸科技與管理學系", 代碼 = "013231", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "工業工程與管理學系", 代碼 = "013241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "傳播與科技學系", 代碼 = "013251", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "外國語文學系", 代碼 = "013261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立交通大學", 系名 = "人文社會學系", 代碼 = "013271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "中國文學學系", 代碼 = "014011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "歷史學系", 代碼 = "014021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "資訊與圖書館學系", 代碼 = "014031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "大眾傳播學系", 代碼 = "014041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "資訊傳播學系", 代碼 = "014051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "教育科技學系", 代碼 = "014061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "英文學系", 代碼 = "014071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "法國語文學系", 代碼 = "014081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "德國語文學系", 代碼 = "014091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "西班牙語文學系", 代碼 = "014101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "日本語文學系", 代碼 = "014111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "俄國語文學系", 代碼 = "014121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "財務金融學系", 代碼 = "014131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "產業經濟學系", 代碼 = "014141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "保險學系", 代碼 = "014161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "經濟學系", 代碼 = "014171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "會計學系", 代碼 = "014181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "企業管理學系", 代碼 = "014191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "統計學系", 代碼 = "014201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "資訊管理學系", 代碼 = "014211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "運輸管理學系", 代碼 = "014221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "公共行政學系", 代碼 = "014231", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "經營決策學系", 代碼 = "014241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "數學學系數學組", 代碼 = "014251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "數學學系資料科學與數理統計組", 代碼 = "014261", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "化學學系化學與生物化學組", 代碼 = "014271", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "化學學系材料化學組", 代碼 = "014281", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "物理學系光電物理組", 代碼 = "014291", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "物理學系應用物理組", 代碼 = "014301", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "建築學系", 代碼 = "014311", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "土木工程學系工程設施組", 代碼 = "014321", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "土木工程學系營建企業組", 代碼 = "014331", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "資訊工程學系", 代碼 = "014341", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "機械與機電工程學系光機電整合組", 代碼 = "014351", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "機械與機電工程學系精密機械組", 代碼 = "014361", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "電機工程學系電子資訊組", 代碼 = "014371", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "電機工程學系電子通訊組", 代碼 = "014381", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "電機工程學系電機與系統組", 代碼 = "014391", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "化學工程與材料工程學系", 代碼 = "014401", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "航空太空工程學系", 代碼 = "014411", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "淡江大學", 系名 = "水資源及環境工程學系", 代碼 = "014421", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "機械與電腦輔助工程學系", 代碼 = "015011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "工業工程與系統管理學系", 代碼 = "015031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "化學工程學系", 代碼 = "015041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "航太與系統工程學系", 代碼 = "015051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "會計學系", 代碼 = "015061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "國際貿易學系", 代碼 = "015071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "財稅學系", 代碼 = "015081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "合作經濟學系", 代碼 = "015091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "經濟學系", 代碼 = "015111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "企業管理學系", 代碼 = "015121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "行銷學系", 代碼 = "015141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "應用數學系", 代碼 = "015151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "材料科學與工程學系", 代碼 = "015161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "光電學系", 代碼 = "015181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "資訊工程學系", 代碼 = "015211", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "電子工程學系", 代碼 = "015221", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "電機工程學系", 代碼 = "015231", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "自動控制工程學系", 代碼 = "015241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "資訊電機學院不分系榮譽班", 代碼 = "015251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "通訊工程學系", 代碼 = "015261", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "土木工程學系", 代碼 = "015271", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "水利工程與資源保育學系", 代碼 = "015281", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "建築學系", 代碼 = "015291", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "都市計畫與空間資訊學系都市計畫組", 代碼 = "015301", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "都市計畫與空間資訊學系空間資訊組", 代碼 = "015311", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "運輸科技與管理學系", 代碼 = "015321", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "逢甲大學", 系名 = "土地管理學系", 代碼 = "015331", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "中國文學系", 代碼 = "016011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "法國語文學系", 代碼 = "016031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "物理學系", 代碼 = "016051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "化學學系", 代碼 = "016061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "生命科學系", 代碼 = "016071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "土木工程學系", 代碼 = "016091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "機械工程學系光機電工程組", 代碼 = "016101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "機械工程學系先進材料與精密製造組", 代碼 = "016111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "機械工程學系設計與分析組", 代碼 = "016121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "化學工程與材料工程學系", 代碼 = "016131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "電機工程學系", 代碼 = "016181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "資訊工程學系", 代碼 = "016191", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "通訊工程學系", 代碼 = "016201", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "大氣科學學系大氣組", 代碼 = "016211", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "大氣科學學系太空組", 代碼 = "016221", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中央大學", 系名 = "地球科學學系", 代碼 = "016231", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "中國文學系中國文學組", 代碼 = "017021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "中國文學系文藝創作組", 代碼 = "017031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "史學系", 代碼 = "017041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "日本語文學系", 代碼 = "017051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "韓國語文學系", 代碼 = "017061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "俄國語文學系", 代碼 = "017071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "英國語文學系", 代碼 = "017081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "法國語文學系", 代碼 = "017091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "德國語文學系", 代碼 = "017101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "物理學系", 代碼 = "017121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "化學系", 代碼 = "017131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "地理學系", 代碼 = "017141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "大氣科學系", 代碼 = "017151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "地質學系", 代碼 = "017161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "生命科學系", 代碼 = "017171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "政治學系", 代碼 = "017201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "動物科學系", 代碼 = "017271", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "森林暨自然保育學系", 代碼 = "017281", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "生活應用科學系", 代碼 = "017301", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "化學工程與材料工程學系", 代碼 = "017321", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "電機工程學系", 代碼 = "017331", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "機械工程學系", 代碼 = "017341", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "紡織工程學系", 代碼 = "017351", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "資訊科學系", 代碼 = "017361", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "國際貿易學系", 代碼 = "017371", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "國際企業管理學系", 代碼 = "017381", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "會計學系", 代碼 = "017391", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "觀光事業學系", 代碼 = "017401", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "資訊管理學系", 代碼 = "017411", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "財務金融學系", 代碼 = "017421", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "市政暨環境規劃學系", 代碼 = "017481", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "建築及都市設計學系", 代碼 = "017491", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "景觀學系", 代碼 = "017501", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中國文化大學", 系名 = "教育學系", 代碼 = "017511", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "英國語文學系", 代碼 = "018011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "西班牙語文學系", 代碼 = "018021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "日本語文學系", 代碼 = "018031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "中國文學系", 代碼 = "018041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "社會工作與兒童少年福利學系", 代碼 = "018051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "台灣文學系", 代碼 = "018061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "法律學系", 代碼 = "018071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "生態學系", 代碼 = "018081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "大眾傳播學系", 代碼 = "018091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "財務與計算數學系計算數學組", 代碼 = "018101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "財務與計算數學系財務工程組", 代碼 = "018111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "應用化學系", 代碼 = "018121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "食品營養學系營養與保健組", 代碼 = "018131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "食品營養學系食品與生物技術組", 代碼 = "018141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "化粧品科學系", 代碼 = "018151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "統計資訊學系", 代碼 = "018161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "企業管理學系", 代碼 = "018171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "國際企業學系", 代碼 = "018181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "會計學系", 代碼 = "018191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "觀光事業學系", 代碼 = "018201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "財務金融學系", 代碼 = "018211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "資訊管理學系", 代碼 = "018221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "資訊工程學系", 代碼 = "018231", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "靜宜大學", 系名 = "資訊傳播工程學系", 代碼 = "018241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大同大學", 系名 = "機械工程學系電子機械組", 代碼 = "019011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大同大學", 系名 = "機械工程學系精密機械組", 代碼 = "019021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大同大學", 系名 = "電機工程學系", 代碼 = "019031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大同大學", 系名 = "化學工程學系", 代碼 = "019041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大同大學", 系名 = "工業設計學系", 代碼 = "019051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大同大學", 系名 = "事業經營學系", 代碼 = "019061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大同大學", 系名 = "資訊工程學系", 代碼 = "019071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大同大學", 系名 = "材料工程學系", 代碼 = "019081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "中國文學系", 代碼 = "020011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "歷史學系", 代碼 = "020021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "哲學系", 代碼 = "020031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "圖書資訊學系", 代碼 = "020041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "景觀設計學系", 代碼 = "020081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "護理學系", 代碼 = "020091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "公共衛生學系", 代碼 = "020101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "醫學系", 代碼 = "020111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "臨床心理學系", 代碼 = "020131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "呼吸治療學系", 代碼 = "020141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "心理學系", 代碼 = "020181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "資訊工程學系", 代碼 = "020191", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "電機工程學系電腦與通訊工程組", 代碼 = "020231", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "電機工程學系系統與晶片設計組", 代碼 = "020241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "英國語文學系", 代碼 = "020251", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "法國語文學系", 代碼 = "020261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "西班牙語文學系", 代碼 = "020271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "義大利語文學系", 代碼 = "020291", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "德語語文學系", 代碼 = "020301", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "食品科學系", 代碼 = "020361", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "營養科學系", 代碼 = "020371", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "財經法律學系", 代碼 = "020381", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "社會學系", 代碼 = "020441", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "社會工作學系", 代碼 = "020451", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "應用美術學系", 代碼 = "020501", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "體育學系體育學組", 代碼 = "020511", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "輔仁大學", 系名 = "體育學系運動健康管理組", 代碼 = "020521", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣海洋大學", 系名 = "商船學系", 代碼 = "021011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣海洋大學", 系名 = "航運管理學系", 代碼 = "021021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣海洋大學", 系名 = "運輸科學系", 代碼 = "021051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣海洋大學", 系名 = "食品科學系食品科學組", 代碼 = "021061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣海洋大學", 系名 = "食品科學系生物科技組", 代碼 = "021071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣海洋大學", 系名 = "生命科學系", 代碼 = "021091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣海洋大學", 系名 = "系統工程暨造船學系", 代碼 = "021101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣海洋大學", 系名 = "河海工程學系", 代碼 = "021111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣海洋大學", 系名 = "環境生物與漁業科學學系", 代碼 = "021141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄師範大學", 系名 = "物理學系", 代碼 = "022041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄師範大學", 系名 = "生物科技系", 代碼 = "022051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄師範大學", 系名 = "工業科技教育學系", 代碼 = "022061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄師範大學", 系名 = "電子工程學系", 代碼 = "022091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄師範大學", 系名 = "美術學系", 代碼 = "022131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄師範大學", 系名 = "視覺設計學系", 代碼 = "022141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄師範大學", 系名 = "體育學系", 代碼 = "022151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立彰化師範大學", 系名 = "輔導與諮商學系學校輔導與學生事務組", 代碼 = "023011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立彰化師範大學", 系名 = "輔導與諮商學系社區諮商與社會工作組", 代碼 = "023021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立彰化師範大學", 系名 = "特殊教育學系", 代碼 = "023031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立彰化師範大學", 系名 = "機電工程學系", 代碼 = "023121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立彰化師範大學", 系名 = "企業管理學系", 代碼 = "023161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立彰化師範大學", 系名 = "會計學系", 代碼 = "023171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立彰化師範大學", 系名 = "資訊管理學系資訊管理組", 代碼 = "023181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立彰化師範大學", 系名 = "資訊管理學系數位內容科技與管理組", 代碼 = "023191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立陽明大學", 系名 = "醫學系自費", 代碼 = "025011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立陽明大學", 系名 = "牙醫學系", 代碼 = "025061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立陽明大學", 系名 = "護理學系", 代碼 = "025071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中山醫學大學", 系名 = "醫學系", 代碼 = "026011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中山醫學大學", 系名 = "護理學系", 代碼 = "026051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中山醫學大學", 系名 = "物理治療學系", 代碼 = "026061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中山醫學大學", 系名 = "職業安全衛生學系", 代碼 = "026131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中山醫學大學", 系名 = "應用化學系", 代碼 = "026141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中山醫學大學", 系名 = "心理學系", 代碼 = "026151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中山醫學大學", 系名 = "語言治療與聽力學系語言治療組", 代碼 = "026241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中山醫學大學", 系名 = "語言治療與聽力學系聽力組", 代碼 = "026251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中山醫學大學", 系名 = "營養學系", 代碼 = "026261", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中山大學", 系名 = "中國文學系", 代碼 = "027011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中山大學", 系名 = "劇場藝術學系", 代碼 = "027031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中山大學", 系名 = "生物科學系", 代碼 = "027041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中山大學", 系名 = "化學系", 代碼 = "027051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中山大學", 系名 = "應用數學系", 代碼 = "027071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中山大學", 系名 = "電機工程學系", 代碼 = "027081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中山大學", 系名 = "機械與機電工程學系", 代碼 = "027091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中山大學", 系名 = "材料與光電科學學系", 代碼 = "027111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中山大學", 系名 = "海洋生物科技暨資源學系", 代碼 = "027161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中山大學", 系名 = "海洋環境及工程學系", 代碼 = "027171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中山大學", 系名 = "海洋科學學士學位學程", 代碼 = "027181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中山大學", 系名 = "政治經濟學系", 代碼 = "027191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "醫學系", 代碼 = "030011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "中醫學系", 代碼 = "030021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "護理學系", 代碼 = "030031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "醫學生物技術暨檢驗學系", 代碼 = "030041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "醫學影像暨放射科學系", 代碼 = "030051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "物理治療學系", 代碼 = "030061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "職能治療學系", 代碼 = "030071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "生物醫學系", 代碼 = "030081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "呼吸照護學系", 代碼 = "030091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "電機工程學系系統與晶片設計組", 代碼 = "030101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "電機工程學系通訊組", 代碼 = "030111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "機械工程學系", 代碼 = "030121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "化工與材料工程學系", 代碼 = "030131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "電子工程學系", 代碼 = "030141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "資訊工程學系", 代碼 = "030151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "醫務管理學系(自然組)", 代碼 = "030161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "醫務管理學系(社會組)", 代碼 = "030171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "工商管理學系(自然組)", 代碼 = "030181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "工商管理學系(社會組)", 代碼 = "030191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "工業設計學系媒體與傳達設計組", 代碼 = "030201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "工業設計學系產品設計組", 代碼 = "030211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長庚大學", 系名 = "資訊管理學系", 代碼 = "030221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺中教育大學", 系名 = "教育學系", 代碼 = "031011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺中教育大學", 系名 = "幼兒教育學系", 代碼 = "031021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺中教育大學", 系名 = "語文教育學系", 代碼 = "031031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺中教育大學", 系名 = "區域與社會發展學系", 代碼 = "031041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺中教育大學", 系名 = "臺灣語文學系", 代碼 = "031051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺中教育大學", 系名 = "英語學系", 代碼 = "031061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺中教育大學", 系名 = "數學教育學系", 代碼 = "031071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺中教育大學", 系名 = "科學應用與推廣學系", 代碼 = "031081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺中教育大學", 系名 = "資訊科學學系", 代碼 = "031091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺中教育大學", 系名 = "國際企業學系", 代碼 = "031101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺中教育大學", 系名 = "美術學系", 代碼 = "031131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北教育大學", 系名 = "語文與創作學系(語文師資組)", 代碼 = "032011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北教育大學", 系名 = "語文與創作學系(文學創作組)", 代碼 = "032021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北教育大學", 系名 = "心理與諮商學系", 代碼 = "032041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北教育大學", 系名 = "特殊教育學系", 代碼 = "032051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北教育大學", 系名 = "幼兒與家庭教育學系", 代碼 = "032061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北教育大學", 系名 = "文化創意產業經營學系", 代碼 = "032071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北教育大學", 系名 = "藝術與造形設計學系設計組", 代碼 = "032081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北教育大學", 系名 = "自然科學教育學系", 代碼 = "032091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北教育大學", 系名 = "資訊科學系", 代碼 = "032101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北教育大學", 系名 = "數位科技設計學系", 代碼 = "032111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北教育大學", 系名 = "藝術與造形設計學系藝術組", 代碼 = "032141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "教育學系", 代碼 = "033011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "特殊教育學系", 代碼 = "033021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "諮商與輔導學系", 代碼 = "033041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "國語文學系", 代碼 = "033051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "英語學系", 代碼 = "033061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "經營與管理學系", 代碼 = "033081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "數位學習科技學系", 代碼 = "033091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "資訊工程學系", 代碼 = "033101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "電機工程學系", 代碼 = "033111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "材料科學系", 代碼 = "033121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "綠色能源科技學系", 代碼 = "033131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "生物科技學系", 代碼 = "033141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "生態科學與技術學系", 代碼 = "033151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "戲劇創作與應用學系", 代碼 = "033161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南大學", 系名 = "美術學系", 代碼 = "033181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "資訊工程學系", 代碼 = "034031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "生命科學系", 代碼 = "034041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "光電工程學系", 代碼 = "034091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "企業管理學系", 代碼 = "034101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "會計學系", 代碼 = "034111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "華文文學系", 代碼 = "034161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "英美語文學系", 代碼 = "034171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "歷史學系", 代碼 = "034191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "族群關係與文化學系", 代碼 = "034211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "自然資源與環境學系", 代碼 = "034221", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "幼兒教育學系", 代碼 = "034241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "特殊教育學系", 代碼 = "034251", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "教育行政與管理學系", 代碼 = "034261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "中國語文學系", 代碼 = "034271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "臺灣文化學系", 代碼 = "034281", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "藝術與設計學系", 代碼 = "034311", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "藝術創意產業學系", 代碼 = "034321", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立東華大學", 系名 = "體育學系", 代碼 = "034331", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北市立教育大學", 系名 = "幼兒教育學系", 代碼 = "035021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北市立教育大學", 系名 = "社會暨公共事務學系", 代碼 = "035031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北市立教育大學", 系名 = "自然科學系應用物理暨化學組", 代碼 = "035041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北市立教育大學", 系名 = "自然科學系地球環境及生物資源組", 代碼 = "035051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北市立教育大學", 系名 = "數學資訊教育學系", 代碼 = "035061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北市立教育大學", 系名 = "體育學系", 代碼 = "035091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立屏東教育大學", 系名 = "中國語文學系", 代碼 = "036021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立屏東教育大學", 系名 = "化學生物系", 代碼 = "036031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立屏東教育大學", 系名 = "社會發展學系", 代碼 = "036041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立屏東教育大學", 系名 = "特殊教育學系", 代碼 = "036061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立屏東教育大學", 系名 = "資訊科學系", 代碼 = "036071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立屏東教育大學", 系名 = "英語學系", 代碼 = "036081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立屏東教育大學", 系名 = "應用物理系", 代碼 = "036091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立屏東教育大學", 系名 = "文化創意產業學系", 代碼 = "036101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立屏東教育大學", 系名 = "視覺藝術學系", 代碼 = "036161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立新竹教育大學", 系名 = "教育學系", 代碼 = "037011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立新竹教育大學", 系名 = "幼兒教育學系", 代碼 = "037021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立新竹教育大學", 系名 = "教育心理與諮商學系", 代碼 = "037031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立新竹教育大學", 系名 = "應用科學系生命科學組", 代碼 = "037061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立新竹教育大學", 系名 = "應用科學系奈米科學組", 代碼 = "037071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立新竹教育大學", 系名 = "應用數學系", 代碼 = "037081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立新竹教育大學", 系名 = "中國語文學系", 代碼 = "037091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺東大學", 系名 = "特殊教育學系", 代碼 = "038051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺東大學", 系名 = "應用科學系化學及奈米科學組", 代碼 = "038061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺東大學", 系名 = "應用科學系應用物理組", 代碼 = "038071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺東大學", 系名 = "資訊管理學系", 代碼 = "038091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺東大學", 系名 = "英美語文學系", 代碼 = "038101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺東大學", 系名 = "華語文學系", 代碼 = "038111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺東大學", 系名 = "生命科學系", 代碼 = "038121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺東大學", 系名 = "體育學系", 代碼 = "038151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺東大學", 系名 = "身心整合與運動休閒產業學系", 代碼 = "038161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立體育大學", 系名 = "休閒產業經營學系", 代碼 = "039011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立體育大學", 系名 = "運動保健學系", 代碼 = "039021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立體育大學", 系名 = "體育推廣學系", 代碼 = "039031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立體育大學", 系名 = "適應體育學系", 代碼 = "039041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立體育大學", 系名 = "陸上運動技術學系", 代碼 = "039051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立體育大學", 系名 = "技擊運動技術學系", 代碼 = "039061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "機械工程學系", 代碼 = "040011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "化學工程與材料科學學系", 代碼 = "040021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "工業工程與管理學系", 代碼 = "040031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "電機工程學系", 代碼 = "040041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "通訊工程學系", 代碼 = "040051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "光電工程學系", 代碼 = "040061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "資訊工程學系", 代碼 = "040071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "資訊管理學系", 代碼 = "040081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "資訊傳播學系網路傳播組", 代碼 = "040091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "資訊傳播學系數位媒體設計組", 代碼 = "040101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "資訊傳播學系互動育樂科技組", 代碼 = "040111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "管理學院（企業管理學士班）", 代碼 = "040121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "管理學院（財務金融學士班）", 代碼 = "040131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "管理學院（國際企業學士班）", 代碼 = "040141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "管理學院（會計學士班）", 代碼 = "040151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "管理學院（學士英語專班）", 代碼 = "040161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "應用外語學系", 代碼 = "040171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "中國語文學系", 代碼 = "040181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "社會暨政策科學學系", 代碼 = "040191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "元智大學", 系名 = "藝術與設計學系", 代碼 = "040201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中正大學", 系名 = "外國語文學系", 代碼 = "041021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中正大學", 系名 = "化學暨生物化學系", 代碼 = "041081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中正大學", 系名 = "社會福利學系", 代碼 = "041101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中正大學", 系名 = "心理學系", 代碼 = "041111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中正大學", 系名 = "勞工關係學系", 代碼 = "041121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中正大學", 系名 = "政治學系", 代碼 = "041131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中正大學", 系名 = "企業管理學系", 代碼 = "041201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中正大學", 系名 = "法律學系法學組", 代碼 = "041231", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立中正大學", 系名 = "法律學系法制組", 代碼 = "041241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "機械與自動化工程學系", 代碼 = "042011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "電機工程學系", 代碼 = "042021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "工業工程與科技管理學系", 代碼 = "042031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "環境工程學系", 代碼 = "042041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "資訊工程學系(自然組)", 代碼 = "042051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "資訊工程學系(社會組)", 代碼 = "042061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "材料科學與工程學系", 代碼 = "042071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "管理學院", 代碼 = "042081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "企業管理學系", 代碼 = "042091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "人力資源暨公共關係學系", 代碼 = "042101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "資訊管理學系", 代碼 = "042111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "會計資訊學系", 代碼 = "042121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "休閒事業管理學系", 代碼 = "042131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "國際企業管理學系", 代碼 = "042141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "財務金融學系", 代碼 = "042151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "運動事業管理學系", 代碼 = "042161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "英美語文學系", 代碼 = "042171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "應用日語學系", 代碼 = "042181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "歐洲語文學系", 代碼 = "042191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "生物產業科技學系(食品科技組)", 代碼 = "042201", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "生物產業科技學系(應用生物科技組)", 代碼 = "042211", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "分子生物科技學系", 代碼 = "042221", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "生物資源學系(生態旅遊與保育組)", 代碼 = "042231", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "生物資源學系(自然資源利用組)", 代碼 = "042241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "藥用植物與保健學系", 代碼 = "042251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "工業設計學系", 代碼 = "042261", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "造形藝術學系", 代碼 = "042271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "視覺傳達設計學系", 代碼 = "042281", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "大葉大學", 系名 = "空間設計學系", 代碼 = "042291", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "電機工程學系", 代碼 = "043011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "機械工程學系", 代碼 = "043021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "通訊工程學系", 代碼 = "043031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "微電子工程學系", 代碼 = "043041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "光機電與材料學士學位學程", 代碼 = "043051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "工業管理學系", 代碼 = "043061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "企業管理學系", 代碼 = "043071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "財務管理學系", 代碼 = "043081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "國際企業學系", 代碼 = "043091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "運輸科技與物流管理學系", 代碼 = "043101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "科技管理學系", 代碼 = "043111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "國際金融管理學士學位學程", 代碼 = "043121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "應用統計學系", 代碼 = "043131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "建築與都市計畫學系建築設計組", 代碼 = "043141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "建築與都市計畫學系環境規劃與經營管理組", 代碼 = "043151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "景觀建築學系", 代碼 = "043161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "土木工程學系", 代碼 = "043181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "創新設計與管理學士學位學程", 代碼 = "043191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "外國語文學系", 代碼 = "043201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "應用日語學系", 代碼 = "043211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "行政管理學系", 代碼 = "043221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "資訊工程學系資訊工程組", 代碼 = "043231", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "資訊工程學系軟體工程及設計組", 代碼 = "043241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "生物資訊學系", 代碼 = "043251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "資訊管理學系資訊系統設計組", 代碼 = "043261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "資訊管理學系資訊管理組", 代碼 = "043271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "資訊學士學位學程", 代碼 = "043281", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "中華大學", 系名 = "觀光學院學士班", 代碼 = "043291", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "華梵大學", 系名 = "工業工程與經營資訊學系", 代碼 = "044011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "華梵大學", 系名 = "機電工程學系", 代碼 = "044021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "華梵大學", 系名 = "電子工程學系", 代碼 = "044031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "華梵大學", 系名 = "建築學系", 代碼 = "044041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "華梵大學", 系名 = "工業設計學系", 代碼 = "044051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "華梵大學", 系名 = "中國文學系", 代碼 = "044061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "華梵大學", 系名 = "外國語文學系", 代碼 = "044071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "華梵大學", 系名 = "哲學系", 代碼 = "044081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "華梵大學", 系名 = "資訊管理學系", 代碼 = "044091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "華梵大學", 系名 = "環境與防災設計學系環境防災組", 代碼 = "044101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "華梵大學", 系名 = "環境與防災設計學系環境設計組", 代碼 = "044111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "華梵大學", 系名 = "美術學系", 代碼 = "044121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "電機工程學系", 代碼 = "045011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "電子工程學系", 代碼 = "045021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "資訊工程學系", 代碼 = "045031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "通訊工程學系", 代碼 = "045041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "機械與自動化工程學系", 代碼 = "045051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "化學工程學系", 代碼 = "045061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "土木與生態工程學系", 代碼 = "045071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "材料科學與工程學系", 代碼 = "045081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "應用數學系資訊科學組", 代碼 = "045091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "應用數學系財務分析組", 代碼 = "045101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "生物醫學工程學系", 代碼 = "045111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "工業工程與管理學系", 代碼 = "045121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "資訊管理學系", 代碼 = "045131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "企業管理學系", 代碼 = "045141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "財務金融學系", 代碼 = "045151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "會計學系", 代碼 = "045161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "國際商務學系", 代碼 = "045171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "公共政策與管理學系", 代碼 = "045181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "醫務管理學系", 代碼 = "045191", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "健康管理學系", 代碼 = "045201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "餐旅管理學系", 代碼 = "045211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "休閒事業管理學系", 代碼 = "045221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "觀光學系", 代碼 = "045231", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "國際企業經營學系(國際學院)", 代碼 = "045241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "國際財務金融學系(國際學院)", 代碼 = "045251", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "觀光餐旅學系(國際學院)", 代碼 = "045261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "應用英語學系", 代碼 = "045271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "大眾傳播學系", 代碼 = "045281", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "應用日語學系", 代碼 = "045291", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "生物科技學系", 代碼 = "045301", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "護理學系", 代碼 = "045311", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "醫學影像暨放射科學系", 代碼 = "045321", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "物理治療學系", 代碼 = "045331", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "職能治療學系", 代碼 = "045341", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "義守大學", 系名 = "醫學營養學系", 代碼 = "045351", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "傳播學院(台北校區)", 代碼 = "046011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "法律學院(台北校區)", 代碼 = "046021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "國際企業學系(台北校區)", 代碼 = "046031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "會計學系(台北校區)", 代碼 = "046041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "風險管理與保險學系(台北校區)", 代碼 = "046051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "企業管理學系(台北校區)", 代碼 = "046061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "財務金融學系(台北校區)", 代碼 = "046071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "應用統計資訊學系(桃園校區)", 代碼 = "046081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "經濟學系(桃園校區)", 代碼 = "046091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "應用中國文學系(桃園校區)", 代碼 = "046101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "應用英語學系(桃園校區)", 代碼 = "046111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "應用日語學系(桃園校區)", 代碼 = "046121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "都市規劃與防災學系(桃園校區)", 代碼 = "046131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "數位媒體設計學系(桃園校區)", 代碼 = "046141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "商品設計學系(桃園校區)", 代碼 = "046151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "建築學系(桃園校區)", 代碼 = "046161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "商業設計學系(桃園校區)", 代碼 = "046171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "資訊管理學系(桃園校區)", 代碼 = "046181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "資訊傳播工程學系(桃園校區)", 代碼 = "046191", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "資訊工程學系(桃園校區)", 代碼 = "046201", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "電子工程學系(桃園校區)", 代碼 = "046211", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "電腦與通訊工程學系(桃園校區)", 代碼 = "046221", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "觀光學院(桃園校區)", 代碼 = "046231", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "安全管理學系(桃園校區)", 代碼 = "046241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "公共事務學系(桃園校區)", 代碼 = "046251", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "諮商與工商心理學系(桃園校區)", 代碼 = "046261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "生物科技學系(桃園校區)", 代碼 = "046271", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "醫療資訊與管理學系(桃園校區)", 代碼 = "046281", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "生物醫學工程學系(桃園校區)", 代碼 = "046291", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "銘傳大學", 系名 = "華語文教學學系(桃園校區)", 代碼 = "046301", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "新聞學系", 代碼 = "047011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "廣播電視電影學系廣播組", 代碼 = "047021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "廣播電視電影學系電視組", 代碼 = "047031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "廣播電視電影學系電影組", 代碼 = "047041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "圖文傳播暨數位出版學系", 代碼 = "047051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "公共關係暨廣告學系", 代碼 = "047061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "口語傳播學系", 代碼 = "047071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "資訊傳播學系", 代碼 = "047081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "數位多媒體設計學系動畫設計組", 代碼 = "047091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "數位多媒體設計學系遊戲設計組", 代碼 = "047101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "傳播管理學系", 代碼 = "047111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "資訊管理學系資訊管理組", 代碼 = "047121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "資訊管理學系資訊科技組", 代碼 = "047131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "資訊管理學系網路科技組", 代碼 = "047141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "財務金融學系", 代碼 = "047151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "行政管理學系", 代碼 = "047161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "觀光學系餐旅事業管理組", 代碼 = "047171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "觀光學系旅遊暨遊憩規劃組", 代碼 = "047181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "經濟學系", 代碼 = "047191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "企業管理學系", 代碼 = "047201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "社會心理學系", 代碼 = "047211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "英語學系", 代碼 = "047221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "中國文學系", 代碼 = "047231", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "日本語文學系", 代碼 = "047241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "世新大學", 系名 = "法律學系", 代碼 = "047251", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "食品營養與保健生技學系(臺北校區)", 代碼 = "050011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "社會工作學系(臺北校區)", 代碼 = "050021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "家庭研究與兒童發展學系(臺北校區)", 代碼 = "050031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "餐飲管理學系(臺北校區)", 代碼 = "050041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "服裝設計學系(臺北校區)", 代碼 = "050051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "工業產品設計學系(臺北校區)", 代碼 = "050061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "媒體傳達設計學系數位3D動畫設計組(臺北校區)", 代碼 = "050071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "媒體傳達設計學系數位遊戲創意設計組(臺北校區)", 代碼 = "050081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "建築設計學系(臺北校區)", 代碼 = "050091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "會計學系(臺北校區)", 代碼 = "050101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "國際經營與貿易學系(臺北校區)", 代碼 = "050111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "企業管理學系(臺北校區)", 代碼 = "050121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "財務金融學系(臺北校區)", 代碼 = "050131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "風險管理與保險學系(臺北校區)", 代碼 = "050141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "資訊科技與管理學系(臺北校區)", 代碼 = "050151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "應用外語學系(臺北校區)", 代碼 = "050161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "國際貿易學系(高雄校區)", 代碼 = "050171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "會計資訊學系(高雄校區)", 代碼 = "050181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "資訊管理學系(高雄校區)", 代碼 = "050191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "金融管理學系(高雄校區)", 代碼 = "050201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "國際企業管理學系(高雄校區)", 代碼 = "050211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "行銷管理學系(高雄校區)", 代碼 = "050221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "資訊科技與通訊學系(高雄校區)", 代碼 = "050231", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "資訊模擬與設計學系(高雄校區)", 代碼 = "050241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "服飾設計與經營學系(高雄校區)", 代碼 = "050251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "應用英語學系(高雄校區)", 代碼 = "050261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "觀光管理學系(高雄校區)", 代碼 = "050271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "休閒產業管理學系(高雄校區)", 代碼 = "050281", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "時尚設計學系(高雄校區)", 代碼 = "050291", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "應用中文學系(高雄校區)", 代碼 = "050301", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "實踐大學", 系名 = "應用日文學系(高雄校區)", 代碼 = "050311", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "企業管理學系", 代碼 = "051011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "國際企業學系", 代碼 = "051021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "會計資訊學系", 代碼 = "051031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "航運管理學系", 代碼 = "051041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "土地管理與開發學系", 代碼 = "051051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "財務金融學系", 代碼 = "051061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "科技管理學位學程", 代碼 = "051071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "職業安全與衛生學系", 代碼 = "051091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "護理學系", 代碼 = "051101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "生物科技學系", 代碼 = "051111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "健康心理學系", 代碼 = "051121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "保健營養學系", 代碼 = "051131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "翻譯學系", 代碼 = "051151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "社會工作學系", 代碼 = "051161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "應用日語學系", 代碼 = "051171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "哲學與宗教學系", 代碼 = "051181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "資訊管理學系", 代碼 = "051191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "科技工程管理學系", 代碼 = "051201", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "長榮大學", 系名 = "資訊工程學系", 代碼 = "051211", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣藝術大學", 系名 = "電影學系", 代碼 = "056031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣藝術大學", 系名 = "戲劇學系", 代碼 = "056041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣藝術大學", 系名 = "美術學系", 代碼 = "056191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣藝術大學", 系名 = "書畫藝術學系", 代碼 = "056201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣藝術大學", 系名 = "雕塑學系", 代碼 = "056211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣藝術大學", 系名 = "視覺傳達設計學系", 代碼 = "056221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣藝術大學", 系名 = "工藝設計學系", 代碼 = "056231", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣藝術大學", 系名 = "多媒體動畫藝術學系", 代碼 = "056241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立暨南國際大學", 系名 = "中國語文學系", 代碼 = "058011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立暨南國際大學", 系名 = "外國語文學系", 代碼 = "058021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立暨南國際大學", 系名 = "公共行政與政策學系", 代碼 = "058041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立暨南國際大學", 系名 = "歷史學系", 代碼 = "058051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立暨南國際大學", 系名 = "國際企業學系", 代碼 = "058081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立暨南國際大學", 系名 = "經濟學系", 代碼 = "058091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立暨南國際大學", 系名 = "財務金融學系", 代碼 = "058111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立暨南國際大學", 系名 = "土木工程學系", 代碼 = "058141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立暨南國際大學", 系名 = "應用化學系", 代碼 = "058161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "企業管理系", 代碼 = "059011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "管理經濟學系", 代碼 = "059021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "旅遊事業管理學系", 代碼 = "059031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "會計資訊學系", 代碼 = "059041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "財務金融學系", 代碼 = "059051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "哲學系", 代碼 = "059061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "文學系", 代碼 = "059071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "生死學系", 代碼 = "059081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "外國語文學系", 代碼 = "059091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "幼兒教育學系", 代碼 = "059101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "傳播學系", 代碼 = "059111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "國際暨大陸事務學系", 代碼 = "059121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "應用社會學系", 代碼 = "059131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "資訊管理學系", 代碼 = "059141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "電子商務管理學系", 代碼 = "059151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "資訊工程學系", 代碼 = "059161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "自然生物科技學系", 代碼 = "059171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "建築與景觀學系", 代碼 = "059181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "民族音樂學系", 代碼 = "059191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "應用藝術與設計學系", 代碼 = "059201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "南華大學", 系名 = "視覺與媒體藝術學系", 代碼 = "059211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣體育學院", 系名 = "體育學系", 代碼 = "060011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣體育學院", 系名 = "運動管理學系", 代碼 = "060031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣體育學院", 系名 = "運動健康科學學系", 代碼 = "060041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣體育學院", 系名 = "運動資訊與傳播學系", 代碼 = "060051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣體育學院", 系名 = "休閒運動學系", 代碼 = "060061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣體育學院", 系名 = "競技運動學系", 代碼 = "060071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺灣體育學院", 系名 = "技擊運動學系", 代碼 = "060091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北市立體育學院", 系名 = "休閒運動管理學系(四年制)", 代碼 = "061011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北市立體育學院", 系名 = "體育與健康學系(四年制)", 代碼 = "061021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南藝術大學", 系名 = "藝術史學系", 代碼 = "063011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南藝術大學", 系名 = "應用音樂學系音樂行政組", 代碼 = "063031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南藝術大學", 系名 = "應用音樂學系音樂工程組", 代碼 = "063041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺南藝術大學", 系名 = "材質創作與設計系", 代碼 = "063051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "宗教學系", 代碼 = "065011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "中國語文學系", 代碼 = "065021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "應用外語學系", 代碼 = "065031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "大眾傳播學系", 代碼 = "065041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "新聞學系", 代碼 = "065051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "視覺傳達設計學系", 代碼 = "065061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "圖書資訊學系", 代碼 = "065071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "數位媒體設計學系", 代碼 = "065081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "藝術與創意設計學系", 代碼 = "065091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "法律學系", 代碼 = "065101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "應用心理學系", 代碼 = "065111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "社會福利學系", 代碼 = "065121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "成人教育與人力發展學系", 代碼 = "065131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "公共事務管理學系", 代碼 = "065141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "財務金融學系", 代碼 = "065151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "國際企業學系企業管理組", 代碼 = "065161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "國際企業學系行銷物流組", 代碼 = "065171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "玄奘大學", 系名 = "資訊管理學系", 代碼 = "065181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "人文與資訊學系(淡水校區)", 代碼 = "079011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "宗教文化與組織管理學系(淡水校區)", 代碼 = "079021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "英美語文學系(淡水校區)", 代碼 = "079031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "應用日語學系(淡水校區)", 代碼 = "079041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "台灣文學系(淡水校區)", 代碼 = "079051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "應用數學系(淡水校區)", 代碼 = "079061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "統計與精算學系(淡水校區)", 代碼 = "079071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "資訊工程學系(淡水校區)", 代碼 = "079081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "財經法律學系(淡水校區)", 代碼 = "079091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "會計資訊學系(淡水校區)", 代碼 = "079101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "財務金融學系(淡水校區)", 代碼 = "079111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "國際貿易學系(淡水校區)", 代碼 = "079121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "財政稅務學系(淡水校區)", 代碼 = "079131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "經濟學系(淡水校區)", 代碼 = "079141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "工業管理與經營資訊學系(淡水校區)", 代碼 = "079151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "企業管理學系(淡水校區)", 代碼 = "079161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "資訊管理學系(淡水校區)", 代碼 = "079171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "運動管理學系(淡水校區)", 代碼 = "079181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "運動資訊傳播學系(淡水校區)", 代碼 = "079191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "觀光事業學系(淡水校區)", 代碼 = "079201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "觀光數位知識學系(淡水校區)", 代碼 = "079211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "休閒遊憩事業學系(麻豆校區)", 代碼 = "079221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "餐旅管理學系(麻豆校區)", 代碼 = "079231", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "航空運輸管理學系(麻豆校區)", 代碼 = "079241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "自然資源應用學系(麻豆校區)", 代碼 = "079251", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "知識管理學系(麻豆校區)", 代碼 = "079261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "資訊應用學系(麻豆校區)", 代碼 = "079271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "工商管理學系(麻豆校區)", 代碼 = "079281", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "日本語文學系(麻豆校區)", 代碼 = "079291", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "應用英語學系(麻豆校區)", 代碼 = "079301", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "運動健康與休閒學系(麻豆校區)", 代碼 = "079311", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "真理大學", 系名 = "水域運動休閒學系(麻豆校區)", 代碼 = "079321", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "法律學系法學組", 代碼 = "099011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "法律學系司法組", 代碼 = "099021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "法律學系財經法組", 代碼 = "099031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "企業管理學系", 代碼 = "099041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "公共行政暨政策學系", 代碼 = "099061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "財政學系", 代碼 = "099071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "不動產與城鄉環境學系", 代碼 = "099081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "社會工作學系", 代碼 = "099091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "應用外語學系", 代碼 = "099101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "歷史學系", 代碼 = "099111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "資訊工程學系", 代碼 = "099121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "金融與合作經營學系", 代碼 = "099131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "統計學系", 代碼 = "099141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "經濟學系", 代碼 = "099151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立臺北大學", 系名 = "會計學系", 代碼 = "099161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "教育學系", 代碼 = "100011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "幼兒教育學系", 代碼 = "100021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "特殊教育學系", 代碼 = "100031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "輔導與諮商學系", 代碼 = "100041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "數位學習設計與管理學系", 代碼 = "100051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "中國文學系", 代碼 = "100061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "外國語言學系英語教學組", 代碼 = "100071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "外國語言學系應用外語組", 代碼 = "100081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "史地學系", 代碼 = "100091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "企業管理學系", 代碼 = "100101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "應用經濟學系", 代碼 = "100111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "生物事業管理學系", 代碼 = "100121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "資訊管理學系", 代碼 = "100131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "財務金融學系", 代碼 = "100141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "農藝學系", 代碼 = "100151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "園藝學系", 代碼 = "100161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "森林暨自然資源學系", 代碼 = "100171", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "林產科學暨家具工程學系", 代碼 = "100181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "動物科學系", 代碼 = "100191", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "生物農業科技學系", 代碼 = "100201", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "獸醫學系", 代碼 = "100211", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "景觀學系", 代碼 = "100221", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "應用數學系", 代碼 = "100231", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "電子物理學系", 代碼 = "100241", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "應用化學系", 代碼 = "100251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "生物機電工程學系", 代碼 = "100261", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "土木與水資源工程學系土木工程組", 代碼 = "100271", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "土木與水資源工程學系水利工程組", 代碼 = "100281", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "資訊工程學系", 代碼 = "100291", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "電機工程學系", 代碼 = "100301", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "食品科學系", 代碼 = "100311", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "生物資源學系", 代碼 = "100321", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "生化科技學系", 代碼 = "100331", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "微生物免疫與生物藥學系", 代碼 = "100341", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立嘉義大學", 系名 = "水生生物科學系", 代碼 = "100351", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄大學", 系名 = "政治法律學系", 代碼 = "101031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄大學", 系名 = "金融管理學系", 代碼 = "101061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄大學", 系名 = "應用物理學系", 代碼 = "101111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄大學", 系名 = "生命科學系", 代碼 = "101121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄大學", 系名 = "電機工程學系", 代碼 = "101131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄大學", 系名 = "土木與環境工程學系", 代碼 = "101141", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄大學", 系名 = "化學工程及材料工程學系", 代碼 = "101151", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄大學", 系名 = "資訊工程學系", 代碼 = "101161", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立高雄大學", 系名 = "傳統工藝與創意設計學系", 代碼 = "101171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "慈濟大學", 系名 = "醫學系", 代碼 = "108011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "慈濟大學", 系名 = "醫學檢驗生物技術學系", 代碼 = "108021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "慈濟大學", 系名 = "護理學系", 代碼 = "108041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "慈濟大學", 系名 = "物理治療學系", 代碼 = "108071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "慈濟大學", 系名 = "生命科學系", 代碼 = "108081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "慈濟大學", 系名 = "分子生物暨人類遺傳學系", 代碼 = "108091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "慈濟大學", 系名 = "兒童發展與家庭教育學系", 代碼 = "108111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "慈濟大學", 系名 = "社會工作學系", 代碼 = "108121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北醫學大學", 系名 = "醫學系", 代碼 = "109011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北醫學大學", 系名 = "牙醫學系", 代碼 = "109021", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北醫學大學", 系名 = "藥學系", 代碼 = "109031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北醫學大學", 系名 = "醫學檢驗暨生物技術學系", 代碼 = "109041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北醫學大學", 系名 = "護理學系", 代碼 = "109051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北醫學大學", 系名 = "保健營養學系", 代碼 = "109061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北醫學大學", 系名 = "公共衛生學系", 代碼 = "109071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北醫學大學", 系名 = "呼吸治療學系", 代碼 = "109091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北醫學大學", 系名 = "老人護理暨管理學系", 代碼 = "109101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "臺北醫學大學", 系名 = "牙體技術學系", 代碼 = "109111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "企業與創業管理學系企業管理組", 代碼 = "110011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "企業與創業管理學系創業管理組", 代碼 = "110021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "企業與創業管理學系科技管理組", 代碼 = "110031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "國際企業學系", 代碼 = "110041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "財務金融學系財務管理組", 代碼 = "110051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "財務金融學系金融組", 代碼 = "110061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "財務金融學系風險管理與保險組", 代碼 = "110071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "財務金融學系不動產管理組", 代碼 = "110081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "會計學系", 代碼 = "110091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "行銷學系", 代碼 = "110101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "資訊及電子商務學系", 代碼 = "110111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "資訊管理學系資訊管理組", 代碼 = "110121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "資訊管理學系資訊科技應用組", 代碼 = "110131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "資訊傳播學系", 代碼 = "110141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "創意產業與數位整合學士學位學程", 代碼 = "110151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "物流與航運管理學系", 代碼 = "110161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "觀光與餐飲管館學系", 代碼 = "110171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "空運管理學系", 代碼 = "110181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "運輸科技與管理學系", 代碼 = "110191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "休閒事業管理學系", 代碼 = "110201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "法律學系", 代碼 = "110211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "公共事務管理學系", 代碼 = "110221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "應用英語學系", 代碼 = "110231", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "應用日語學系", 代碼 = "110241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "保健營養學系", 代碼 = "110251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "養生與健康行銷學系養生療癒組", 代碼 = "110261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "養生與健康行銷學系健康行銷組", 代碼 = "110271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "開南大學", 系名 = "健康產業管理學系", 代碼 = "110281", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "幼兒教育學系(師資培育機構)", 代碼 = "111011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "應用外語學系英語組", 代碼 = "111021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "應用外語學系日語組", 代碼 = "111031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "企業管理學系", 代碼 = "111041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "休閒資訊管理學系", 代碼 = "111051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "商品開發與設計學系", 代碼 = "111061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "健康與美容事業管理學系", 代碼 = "111071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "餐旅管理學系", 代碼 = "111081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "觀光事業管理學系", 代碼 = "111091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "休閒設施規劃與管理學系", 代碼 = "111101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "資訊與多媒體設計學系", 代碼 = "111111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "數位娛樂與遊戲設計學系", 代碼 = "111121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "文化創意產業學位學程", 代碼 = "111131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "旅館管理學位學程", 代碼 = "111141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "致遠管理學院", 系名 = "休閒事業管理學系", 代碼 = "111151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "化粧品應用與管理學系", 代碼 = "112011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "生產事業管理學系", 代碼 = "112021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "健康產業管理學系健康照護組", 代碼 = "112031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "健康產業管理學系保健美容組", 代碼 = "112041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "時尚造型設計學系", 代碼 = "112051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "應用英語學系", 代碼 = "112061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "應用日語學系", 代碼 = "112071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "文化創意學系", 代碼 = "112081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "數位應用學系多媒體遊戲設計組", 代碼 = "112091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "數位應用學系網路組", 代碼 = "112101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "資訊傳播學系", 代碼 = "112111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "休閒管理學系觀光休閒組", 代碼 = "112121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "立德大學", 系名 = "餐飲管理學系", 代碼 = "112131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "興國管理學院", 系名 = "企業管理學系", 代碼 = "113011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "興國管理學院", 系名 = "行銷與物流管理學系", 代碼 = "113021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "興國管理學院", 系名 = "財務金融學系", 代碼 = "113031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "興國管理學院", 系名 = "財經法律學系", 代碼 = "113041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "興國管理學院", 系名 = "房地產經營學系", 代碼 = "113051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "興國管理學院", 系名 = "科技管理學系", 代碼 = "113061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "興國管理學院", 系名 = "網路多媒體設計學系", 代碼 = "113071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "興國管理學院", 系名 = "電子商務學系", 代碼 = "113081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "興國管理學院", 系名 = "資訊應用學系", 代碼 = "113091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "興國管理學院", 系名 = "珠寶設計與管理學系", 代碼 = "113101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "興國管理學院", 系名 = "應用日語學系", 代碼 = "113111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "興國管理學院", 系名 = "文化創意與觀光學系", 代碼 = "113121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "文學系", 代碼 = "130011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "歷史學系", 代碼 = "130031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "外國語文學系", 代碼 = "130041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "文化資產與創意學系", 代碼 = "130051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "未來學系", 代碼 = "130061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "經濟學系", 代碼 = "130081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "社會學系", 代碼 = "130091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "公共事務學系", 代碼 = "130101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "傳播學系", 代碼 = "130111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "管理學系經營管理組", 代碼 = "130121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "管理學系財務金融組", 代碼 = "130131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "學習與數位科技學系", 代碼 = "130171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "佛光大學", 系名 = "產品與媒體設計學系", 代碼 = "130181", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "動畫遊戲設計學系", 代碼 = "132011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "網路系統學系", 代碼 = "132021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "資訊管理學系", 代碼 = "132031", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "老人福祉學系", 代碼 = "132041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "餐旅管理學系", 代碼 = "132051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "諮商心理學系", 代碼 = "132061", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "營養科學學系", 代碼 = "132071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "幼兒教育學系(非師資培育系所)", 代碼 = "132081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "文學創作與傳播學系", 代碼 = "132091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "財經法律學系", 代碼 = "132101", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "運輸物流與行銷管理學系", 代碼 = "132111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "公共事務管理學系", 代碼 = "132121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "稻江科技暨管理學院", 系名 = "休閒遊憩與旅運管理學系", 代碼 = "132131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "產業創新與經營學系", 代碼 = "133011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "餐旅管理學系", 代碼 = "133021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "休閒保健學系", 代碼 = "133031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "國際行銷與運籌學系", 代碼 = "133041", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "財務金融學系", 代碼 = "133051", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "精緻農業學系", 代碼 = "133061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "資訊傳播學系", 代碼 = "133071", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "生物科技學系", 代碼 = "133081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "材料科學與工程學系", 代碼 = "133091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "光電暨能源工程學系", 代碼 = "133101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "綠環境設計學系", 代碼 = "133111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "數位設計學系", 代碼 = "133121", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "時尚造形學系", 代碼 = "133131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "景觀設計學系", 代碼 = "133141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "中國文學學系", 代碼 = "133151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "應用英語學系", 代碼 = "133161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "明道大學", 系名 = "應用日語學系", 代碼 = "133171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "健康產業管理學系健康產業管理組", 代碼 = "134011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "健康產業管理學系醫療機構管理組", 代碼 = "134021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "保健營養生技學系食品營養組", 代碼 = "134031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "保健營養生技學系化妝品組", 代碼 = "134041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "生物科技學系", 代碼 = "134051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "資訊工程學系資電應用組", 代碼 = "134061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "資訊工程學系數位內容組", 代碼 = "134071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "資訊多媒體應用學系多媒體應用組", 代碼 = "134081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "資訊多媒體應用學系多媒體管理組", 代碼 = "134091", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "光電與通訊學系", 代碼 = "134101", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "資訊傳播學系", 代碼 = "134111", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "生物與醫學資訊學系生物資訊組", 代碼 = "134121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "生物與醫學資訊學系醫學資訊組", 代碼 = "134131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "經營管理學系企業管理組", 代碼 = "134141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "經營管理學系行銷管理組", 代碼 = "134151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "國際企業學系國際行銷組", 代碼 = "134161", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "國際企業學系國際企業經營組", 代碼 = "134171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "休閒與遊憩管理學系", 代碼 = "134181", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "會計與資訊學系財稅應用組", 代碼 = "134191", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "會計與資訊學系管理應用組", 代碼 = "134201", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "財務金融學系投資管理組", 代碼 = "134211", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "財務金融學系金融機構管理組", 代碼 = "134221", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "財經法律學系科技法律組", 代碼 = "134231", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "財經法律學系財經法律組", 代碼 = "134241", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "心理學系", 代碼 = "134251", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "幼兒教育學系(師資培育學系)", 代碼 = "134261", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "社會工作學系", 代碼 = "134271", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "外國語文學系", 代碼 = "134281", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "數位媒體設計學系數位動畫設計組", 代碼 = "134291", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "數位媒體設計學系數位遊戲設計組", 代碼 = "134301", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "視覺傳達設計學系企業形象設計組", 代碼 = "134311", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "視覺傳達設計學系文化產業視覺設計組", 代碼 = "134321", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "創意商品設計學系流行精品設計組", 代碼 = "134331", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "創意商品設計學系文化創意商品設計組", 代碼 = "134341", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "亞洲大學", 系名 = "時尚設計學系", 代碼 = "134351", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立宜蘭大學", 系名 = "外國語文學系", 代碼 = "150011", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立宜蘭大學", 系名 = "應用經濟與管理學系", 代碼 = "150021", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立宜蘭大學", 系名 = "土木工程學系", 代碼 = "150031", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立宜蘭大學", 系名 = "機械與機電工程學系", 代碼 = "150041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立宜蘭大學", 系名 = "化學工程與材料工程學系", 代碼 = "150051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立宜蘭大學", 系名 = "環境工程學系", 代碼 = "150061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立宜蘭大學", 系名 = "生物機電工程學系", 代碼 = "150071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立宜蘭大學", 系名 = "食品科學系", 代碼 = "150081", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立宜蘭大學", 系名 = "動物科技學系", 代碼 = "150091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立宜蘭大學", 系名 = "電機工程學系", 代碼 = "150111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立宜蘭大學", 系名 = "電子工程學系", 代碼 = "150121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立宜蘭大學", 系名 = "電資學院學士班", 代碼 = "150131", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "機械工程學系", 代碼 = "151011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "化學工程學系", 代碼 = "151041", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "建築學系", 代碼 = "151051", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "土木與防災工程學系", 代碼 = "151061", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "工業設計學系", 代碼 = "151071", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "資訊管理學系", 代碼 = "151081", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "光電工程學系", 代碼 = "151091", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "資訊工程學系", 代碼 = "151111", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "能源與資源學系", 代碼 = "151121", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "台灣語文與傳播學系", 代碼 = "151131", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "華語文學系", 代碼 = "151141", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "經營管理學系", 代碼 = "151151", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "國立聯合大學", 系名 = "財務金融學系", 代碼 = "151171", 名額 = 2, 組別 = "社會組" });
            defaultList.Add(new 校系資料() { 校名 = "馬偕醫學院", 系名 = "醫學系", 代碼 = "152011", 名額 = 2, 組別 = "自然組" });
            defaultList.Add(new 校系資料() { 校名 = "馬偕醫學院", 系名 = "護理學系", 代碼 = "152021", 名額 = 2, 組別 = "自然組" });

            #endregion
            AccessHelper accessHelper = new AccessHelper();
            List<校系資料> list = accessHelper.Select<校系資料>();
            foreach (var item in list)
                item.Deleted = true;
            foreach (var item in defaultList)
            {
                bool found = false;
                foreach (var itemCurrent in list)
                {
                    if (item.代碼 == itemCurrent.代碼)
                    {
                        found = true;
                        itemCurrent.名額 = item.名額;
                        itemCurrent.校名 = item.校名;
                        itemCurrent.系名 = item.系名;
                        itemCurrent.組別 = item.組別;
                        break;
                    }
                }
                if (!found)
                    list.Add(item);
            }
            list.SaveAll();
        }
    }
}