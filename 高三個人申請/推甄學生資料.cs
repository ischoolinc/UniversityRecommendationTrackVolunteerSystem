using System;
using System.Collections.Generic;
using System.Text;
using FISCA.UDT;
using System.Collections.ObjectModel;
using 個人申請入學志願選填;

namespace 個人申請入學志願選填
{
    [TableName("個人申請.推甄學生資料")]
    public class 推甄學生資料 : ActiveRecord
    {
        public 推甄學生資料()
        {
            成績內容 = "";
            分發校系代碼 = "";
            組別 = "";
            志願組 = new ReadOnlyCollection<志願>(new List<志願>());
        }
        [Field]
        private string RefStudentID { get; set; }
        [Field]
        public int 排名 { get; set; }
        [Field]
        public decimal? 總分 { get; set; }
        [Field]
        public string 成績內容 { get; set; }
        [Field]
        public bool 確定分發結果 { get; set; }
        [Field]
        private string 分發校系代碼 { get; set; }
        [Field]
        public string 組別 { get; set; }
        [Field]
        public int? 梯次 { get; set; }
        [Field]
        public string 備註 { get; set; }

        public K12.Data.StudentRecord StudentRecord
        {
            get { return K12.Data.Student.SelectByID(RefStudentID); }
            set { RefStudentID = value.ID; }
        }
        public 校系資料 分發結果
        {
            get { return 校系資料庫.Items.ContainsKey(分發校系代碼) ? 校系資料庫.Items[分發校系代碼] : null; }
            set { 分發校系代碼 = (value == null ? "" : value.代碼); }
        }
        public ReadOnlyCollection<志願> 志願組 { get; private set; }
        internal void 填入志願組(ReadOnlyCollection<志願> newList)
        {
            志願組 = newList;
        }
    }
}
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public static class ㄗㄟ洗擠雷究理孩究理孩ㄟ可辣史
{
    public static void 取得志願組(this 推甄學生資料 item)
    {
        List<志願> list = new List<志願>();
        list.AddRange(new AccessHelper().Select<志願>("RefStudentID = '" + item.UID + "'"));
        list.Sort(delegate(志願 o1, 志願 o2)
        {
            return o1.志願排序.CompareTo(o2.志願排序);
        });
        item.填入志願組(list.AsReadOnly());
    }
    public static void 取得志願組(this IEnumerable<推甄學生資料> items)
    {
        FISCA.UDT.Condition.InCondition RefStudentIDCondition = new FISCA.UDT.Condition.InCondition() { Field = "RefStudentID" };
        Dictionary<推甄學生資料, List<志願>> dicNewList = new Dictionary<推甄學生資料, List<志願>>();
        foreach (var item in items)
        {
            RefStudentIDCondition.Values.Add(item.StudentRecord.ID);
            if (!dicNewList.ContainsKey(item))
                dicNewList.Add(item, new List<志願>());
        }
        if (RefStudentIDCondition.Values.Count != 0)
        {
            foreach (var wish in new AccessHelper().Select<志願>(RefStudentIDCondition))
            {
                foreach (var item in items)
                {
                    if (item.StudentRecord.ID == wish.StudentRecord.ID)
                    {
                        dicNewList[item].Add(wish);
                        break;
                    }
                }
            }
        }
        foreach (var item in items)
        {
            dicNewList[item].Sort(delegate(志願 o1, 志願 o2)
            {
                return o1.志願排序.CompareTo(o2.志願排序);
            });
            item.填入志願組(dicNewList[item].AsReadOnly());
        }
    }
}
