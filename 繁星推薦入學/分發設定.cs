using System;
using System.Collections.Generic;
using System.Text;
using FISCA.UDT;

namespace 繁星推薦入學校內志願選填
{
    [TableName("繁星推薦入學校內志願選填.分發設定")]
    public class 分發設定 : ActiveRecord
    {
        [Field]
        public int 志願上限 { get; set; }
        [Field]
        public System.DateTime? 開放時間 { get; set; }
        [Field]
        public System.DateTime? 結束時間 { get; set; }
        [Field]
        public int? 開放梯次 { get; set; }
        [Field]
        public bool 允許跨組 { get; set; }
        [Field]
        public string 發佈訊息 { get; set; }
        [Field]
        public string 跳出訊息 { get; set; }
        [Field]
        public bool 禁止學生互查 { get; set; }
    }
}
