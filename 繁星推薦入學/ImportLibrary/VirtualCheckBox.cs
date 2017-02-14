using System;
using System.Collections.Generic;
using System.Text;

namespace 繁星推薦入學校內志願選填.ImportLibrary
{
    public class VirtualCheckBox : VirtualCheckItem
    {
        public VirtualCheckBox() { }
        public VirtualCheckBox(string text)
        {
            this.Text = text;
        }
        public VirtualCheckBox(string text, bool check)
            : this(text)
        {
            this.Checked = check;
        }
    }
}
