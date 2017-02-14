using System;
using System.Collections.Generic;
using System.Text;
using FISCA.UDT;

namespace 繁星推薦入學校內志願選填
{
    [TableName("繁星推薦入學校內志願選填.志願")]
    public class 志願 : ActiveRecord
    {
        [Field]
        private string RefStudentID { get; set; }
        [Field]
        private string 校系資料代碼 { get; set; }
        [Field]
        public int 志願排序 { get; set; }
        [Field]
        public bool 忽略 { get; set; }
        [Field]
        public string 忽略原因 { get; set; }

        public K12.Data.StudentRecord StudentRecord
        {
            get { return K12.Data.Student.SelectByID(RefStudentID); }
            set { RefStudentID = value.ID; }
        }

        public 校系資料 校系資料
        {
            get { return 校系資料庫.Items.ContainsKey(校系資料代碼) ? 校系資料庫.Items[校系資料代碼] : null; }
            set { 校系資料代碼 = (value == null ? "" : value.代碼); }
        }
    }
}
