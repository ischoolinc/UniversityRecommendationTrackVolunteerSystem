using System;
using System.Collections.Generic;
using System.Text;

namespace 繁星推薦入學校內志願選填.ImportLibrary
{
    /// <summary>
    /// 要匯入的一筆資料
    /// </summary>
    public class RowData : SortedList<string, string>
    {
        private string _ID = "";

        /// <summary>
        /// 編號
        /// </summary>
        public string ID { get { return _ID; } set { _ID = value; } }
    }
}
