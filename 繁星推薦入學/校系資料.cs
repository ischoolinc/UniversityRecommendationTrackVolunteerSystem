using System;
using System.Collections.Generic;
using System.Text;
using FISCA.UDT;

namespace 繁星推薦入學校內志願選填
{
    [TableName("繁星推薦入學校內志願選填.校系資料")]
    public class 校系資料 : ActiveRecord
    {
        [Field]
        public string 校名 { get; set; }
        [Field]
        public string 系名 { get; set; }
        [Field]
        public string 代碼 { get; set; }
        [Field]
        public string 組別 { get; set; }
        [Field]
        public int 名額 { get; set; }
        [Field]
        public string 網路資訊 { get; set; }

        public override string ToString()
        {
            return 校名 + " " + 系名;
        }
    }
}
