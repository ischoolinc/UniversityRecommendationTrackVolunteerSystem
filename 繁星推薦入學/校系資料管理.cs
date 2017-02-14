using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 繁星推薦入學校內志願選填
{
    public partial class 校系資料管理 : FISCA.Presentation.Controls.BaseForm
    {
        BackgroundWorker _BKW = new BackgroundWorker();
        public 校系資料管理()
        {
            InitializeComponent();
            this.pictureBox1.BackColor = Color.White;
            _BKW.DoWork += delegate
            {
                校系資料庫.Sync();
            };
            _BKW.RunWorkerCompleted += delegate
            {
                dataGridViewX1.Rows.Clear();
                List<DataGridViewRow> newRows = new List<DataGridViewRow>();
                foreach (var item in 校系資料庫.Items.Values)
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGridViewX1, item.RecordStatus, item.UID, item.校名, item.系名, item.代碼, item.組別, item.名額, item.網路資訊);
                    newRow.Tag = item;
                    newRows.Add(newRow);
                }
                dataGridViewX1.Rows.AddRange(newRows.ToArray());
                foreach (Control item in this.Controls)
                {
                    item.Enabled = true;
                }
                this.pictureBox1.Visible = this.pictureBox1.Enabled = false;
            };
            btnReflash_Click(null, null);
        }

        private void btnReflash_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                item.Enabled = false;
            }
            this.pictureBox1.Visible = this.pictureBox1.Enabled = true;
            if (!_BKW.IsBusy)
            {
                _BKW.RunWorkerAsync();
            }
        }
        #region 處裡編輯儲存格跟結束編輯的切換

        private void dataGridViewX1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewX1.EndEdit();
        }

        private void dataGridViewX1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 2 && e.RowIndex >= 0)
                dataGridViewX1.BeginEdit(true);
        }

        private void dataGridViewX1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 2 && e.RowIndex >= 0)
                dataGridViewX1.BeginEdit(true);
        }

        private void dataGridViewX1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewX1.EndEdit();
        }
        #endregion

        private void dataGridViewX1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridViewRow targetRow = dataGridViewX1.CurrentCell.OwningRow;
            dataGridViewX1.EndEdit();
            校系資料 target = (校系資料)targetRow.Tag;
            target.校名 = "" + targetRow.Cells[2].Value;
            target.系名 = "" + targetRow.Cells[3].Value;
            target.代碼 = "" + targetRow.Cells[4].Value;
            target.組別 = "" + targetRow.Cells[5].Value;
            target.網路資訊 = "" + targetRow.Cells[7].Value;
            int limit = 0;
            if (int.TryParse("" + targetRow.Cells[6].Value, out limit) && limit >= 0)
            {
                target.名額 = limit;
                if (!String.IsNullOrEmpty(targetRow.Cells[6].ErrorText))
                {
                    targetRow.Cells[6].ErrorText = "";
                    dataGridViewX1.UpdateCellErrorText(6, targetRow.Index);
                }
            }
            else
            {
                if (targetRow.Cells[6].ErrorText != "請輸入0或正整數")
                {
                    targetRow.Cells[6].ErrorText = "請輸入0或正整數";
                    dataGridViewX1.UpdateCellErrorText(6, targetRow.Index);
                }
            }
            targetRow.Cells[0].Value = target.RecordStatus;
            dataGridViewX1.BeginEdit(false);
        }

        private void dataGridViewX1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            校系資料 newITem = new 校系資料();
            e.Row.Tag = newITem;
            e.Row.SetValues(newITem.RecordStatus, newITem.UID, newITem.校名, newITem.系名, newITem.代碼, newITem.組別, newITem.名額, newITem.網路資訊);
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            List<校系資料> list = new List<校系資料>();
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.IsNewRow) continue;
                list.Add((校系資料)row.Tag);
            }
            list.SaveAll();
            btnReflash_Click(null, null);
        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                List<DataGridViewRow> removeRows = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                {
                    if (row.IsNewRow) continue;
                    校系資料 target = (校系資料)row.Tag;
                    if (target.RecordStatus == FISCA.UDT.RecordStatus.Insert)
                        removeRows.Add(row);
                    else
                    {
                        target.Deleted = true;
                        row.Cells[0].Value = target.RecordStatus;
                    }
                }
                foreach (var item in removeRows)
                {
                    dataGridViewX1.Rows.Remove(item);
                }
            }
        }

        private bool _ReplaceAll = false;
        List<校系資料> _DeletedItems = new List<校系資料>();
        private void buttonX1_Click(object sender, EventArgs e)
        {
            ImportLibrary.PowerfulImportWizard wizard = new ImportLibrary.PowerfulImportWizard("匯入校系資料", null);
            ImportLibrary.IPowerfulImportWizard iWizard = wizard;
            ImportLibrary.VirtualCheckBox chkReplaceAll = new 繁星推薦入學校內志願選填.ImportLibrary.VirtualCheckBox("刪除不在匯入表中的所有資料", false);
            chkReplaceAll.Description = "請小心使用";
            chkReplaceAll.CheckedChanged += new EventHandler(chkReplaceAll_CheckedChanged);
            iWizard.Options.Add(chkReplaceAll);
            iWizard.RequiredFields.Add("代碼");
            iWizard.ImportableFields.AddRange("校名", "系名", "組別", "名額", "網路資訊");
            iWizard.IdentifyRow += new EventHandler<繁星推薦入學校內志願選填.ImportLibrary.IdentifyRowEventArgs>(iWizard_IdentifyRow);
            iWizard.ValidateRow += new EventHandler<繁星推薦入學校內志願選填.ImportLibrary.ValidateRowEventArgs>(iWizard_ValidateRow);
            iWizard.ImportStart += new EventHandler(iWizard_ImportStart);
            iWizard.ImportPackage += new EventHandler<繁星推薦入學校內志願選填.ImportLibrary.ImportPackageEventArgs>(iWizard_ImportPackage);
            iWizard.ImportComplete += new EventHandler(iWizard_ImportComplete);
            this.Close();
            Application.DoEvents();
            wizard.Owner = FISCA.Presentation.MotherForm.Form;
            wizard.ShowDialog();
        }

        void chkReplaceAll_CheckedChanged(object sender, EventArgs e)
        {
            _ReplaceAll = ((ImportLibrary.VirtualCheckBox)sender).Checked;
        }

        void iWizard_IdentifyRow(object sender, 繁星推薦入學校內志願選填.ImportLibrary.IdentifyRowEventArgs e)
        {
            if (校系資料庫.Items.ContainsKey(e.RowData["代碼"]))
                e.RowData.ID = 校系資料庫.Items[e.RowData["代碼"]].UID;
        }

        void iWizard_ValidateRow(object sender, 繁星推薦入學校內志願選填.ImportLibrary.ValidateRowEventArgs e)
        {
            foreach (var field in e.SelectFields)
            {
                string value = e.Data[field];
                switch (field)
                {
                    default:
                    case "校名":
                    case "系名":
                    case "組別":
                        break;
                    case "名額":
                        int i = 0;
                        if (!int.TryParse(value, out i) || i < 0)
                            e.ErrorFields.Add("名額", "請輸入大於0之整數數字");
                        break;
                }
            }
        }

        void iWizard_ImportStart(object sender, EventArgs e)
        {
            if (_ReplaceAll)
            {
                foreach (var item in 校系資料庫.Items.Values)
                {
                    _DeletedItems.Add(item);
                }
            }
        }

        void iWizard_ImportPackage(object sender, 繁星推薦入學校內志願選填.ImportLibrary.ImportPackageEventArgs e)
        {
            List<校系資料> importItems = new List<校系資料>();
            foreach (var row in e.Items)
            {
                校系資料 importData = (row.ID != "") ?
                    校系資料庫.Items[row["代碼"]] :
                    new 校系資料() { 代碼 = row["代碼"] };
                if (_DeletedItems.Contains(importData))
                    _DeletedItems.Remove(importData);
                foreach (var field in e.ImportFields)
                {
                    string value = row[field];
                    switch (field)
                    {
                        default:
                            break;
                        case "校名":
                            importData.校名 = value;
                            break;
                        case "系名":
                            importData.系名 = value;
                            break;
                        case "組別":
                            importData.組別 = value;
                            break;
                        case "名額":
                            importData.名額 = int.Parse(value);
                            break;
                        case "網路資訊":
                            importData.網路資訊 = value;
                            break;
                    }
                }
                importItems.Add(importData);
            }
            importItems.SaveAll();
        }


        void iWizard_ImportComplete(object sender, EventArgs e)
        {
            if (_ReplaceAll)
            {
                foreach (var item in _DeletedItems)
                {
                    item.Deleted = true;
                }
                _DeletedItems.SaveAll();
            }
            校系資料庫.Sync();
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "另存新檔";
            saveFileDialog1.FileName = "分發校系資料.xls";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls|所有檔案 (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
                int colIndex = 0, rowIndex = 0;
                wb.Worksheets[0].Cells[rowIndex, colIndex++].PutValue("代碼");
                wb.Worksheets[0].Cells[rowIndex, colIndex++].PutValue("校名");
                wb.Worksheets[0].Cells[rowIndex, colIndex++].PutValue("系名");
                wb.Worksheets[0].Cells[rowIndex, colIndex++].PutValue("組別");
                wb.Worksheets[0].Cells[rowIndex, colIndex++].PutValue("名額");
                wb.Worksheets[0].Cells[rowIndex, colIndex++].PutValue("網路資訊");
                foreach (var item in 校系資料庫.Items.Values)
                {
                    rowIndex++;
                    colIndex = 0;
                    wb.Worksheets[0].Cells[rowIndex, colIndex++].PutValue(item.代碼);
                    wb.Worksheets[0].Cells[rowIndex, colIndex++].PutValue(item.校名);
                    wb.Worksheets[0].Cells[rowIndex, colIndex++].PutValue(item.系名);
                    wb.Worksheets[0].Cells[rowIndex, colIndex++].PutValue(item.組別);
                    wb.Worksheets[0].Cells[rowIndex, colIndex++].PutValue(item.名額);
                    wb.Worksheets[0].Cells[rowIndex, colIndex++].PutValue(item.網路資訊);
                }
                for (int k = 0; k < colIndex; k++)
                {
                    wb.Worksheets[0].AutoFitColumn(k, 0, 150);
                }
                wb.Worksheets[0].FreezePanes(1, 0, 1, colIndex);
                wb.Save(saveFileDialog1.FileName);
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
            }
        }
    }
}
