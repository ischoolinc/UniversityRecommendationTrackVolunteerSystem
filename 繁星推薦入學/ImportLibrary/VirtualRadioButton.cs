using System;
using System.Collections.Generic;
using System.Text;

namespace 繁星推薦入學校內志願選填.ImportLibrary
{
    public class VirtualRadioButton : VirtualCheckItem
    {
        public VirtualRadioButton() { }
        public VirtualRadioButton(string text)
        {
            this.Text = text;
        }
        public VirtualRadioButton(string text, bool check)
            : this(text)
        {
            this.Checked = check;
        }
    }
}
