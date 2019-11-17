

using System;
using System.Windows.Forms;
namespace Pathology
{
    class XGroupBox : System.Windows.Forms.GroupBox
    {
        private bool _ReadOnly;
        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }
            set
            {
                _ReadOnly = value;
                foreach (Control c in this.Controls)
                {
                    Type t = c.GetType();
                    if (t == typeof(CheckBox))
                    {
                        ((CheckBox)c).AutoCheck = !value;
                    }
                    else if (t == typeof(XTextBox))
                    {
                        ((XTextBox)c).Enabled = !value;
                    }
                    else if (t == typeof(RadioButton))
                    {
                        ((RadioButton)c).AutoCheck = !value;
                    }
                }
            }
        }
    }
}
