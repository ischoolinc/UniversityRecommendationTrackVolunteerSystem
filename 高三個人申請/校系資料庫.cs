using System;
using System.Collections.Generic;
using System.Text;
using FISCA.UDT;

namespace 個人申請入學志願選填
{
    static class 校系資料庫
    {
        private static Dictionary<string, 校系資料> _Items = null;
        public static Dictionary<string, 校系資料> Items { get { if (_Items == null)Sync(); return _Items; } }
        public static void Sync()
        {
            Dictionary<string, 校系資料> items = new Dictionary<string, 校系資料>();
            var list = new AccessHelper().Select<校系資料>();
            //new AccessHelper().DeletedValues(list as IEnumerable<ActiveRecord>);
            //list = null;
            list.Sort(delegate(校系資料 o1, 校系資料 o2)
            {
                return (o1.代碼.CompareTo(o2.代碼)) == 0 ? o1.UID.CompareTo(o2.UID) : (o1.代碼.CompareTo(o2.代碼));
            });
            foreach (var item in list)
            {
                items.Add(item.代碼, item);
            }
            _Items = items;
        }
    }
}
