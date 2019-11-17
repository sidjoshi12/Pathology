using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pathology
{
    class XNumTextBox : TextBox
    {
        private Color _BackColor;
        public XNumTextBox()
        {
            _BackColor = this.BackColor;
            MoveOnEnter = true;
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            if (this.Text == "")
                this.Text = String.Format("{0:" + _Format + "}", 0);
        }
        #region Declarations
        private Color _gotFocusColor = Color.Yellow;
        private Color _ForeColorDisabled = System.Drawing.SystemColors.WindowText;
        private Color _BackColorDisabled = System.Drawing.SystemColors.Window;
        private string _Format = "###0";
        public enum Data
        {
            Text,
            Integer,
            AlphaNumeric,
            Double
        }
        System.Windows.Forms.ToolTip myToolTip = new System.Windows.Forms.ToolTip();
        #endregion

        #region Properties
        public Label Caption { get; set; }
        public bool MoveOnEnter { get; set; }
        public Data DataType { get; set; }
        public string NumValue
        {
            get
            {
                return String.Format(_Format, this.Text.toDouble()); ;
            }
            set
            {
                this.Text = String.Format("{0:" + _Format + "}", value.toDouble());
            }
        }

        public Color gotFocusColor
        {
            get
            {
                return _gotFocusColor;
            }
            set
            {
                _gotFocusColor = value;
            }
        }


        /// <summary>
        /// Set or Get Disabled Fore Color
        /// </summary>
        [Category("Custom Category")]
        [Description("Set or Get Disabled Fore Color")]
        public Color ForeColorDisabled
        {
            get
            {
                return _ForeColorDisabled;
            }
            set
            {
                _ForeColorDisabled = value;
            }
        }


        /// <summary>
        /// Set or Get Disabled Back Color
        /// </summary>
        [Category("Custom Category")]
        [Description("Set or Get Disabled Back Color")]
        public Color BackColorDisabled
        {
            get
            {
                return _BackColorDisabled;
            }
            set
            {
                _BackColorDisabled = value;

            }
        }
        /////////////////////////////////////////////////

        public string Format
        {
            get
            {
                return _Format;
            }
            set
            {
                _Format = value;
            }
        }
        #endregion

        #region Events
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter & MoveOnEnter)
                SendKeys.Send("{Tab}");
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (!this.DesignMode)
            {
                _BackColor = base.BackColor;
                this.BackColor = _gotFocusColor;
                if (this.Caption != null)
                    Caption.Font = new Font(Caption.Font.Name, Caption.Font.Size, FontStyle.Bold);
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            //if (this.Text == "")
            //    this.Text = "0";

            this.BackColor = _BackColor;
            if (this.Caption != null)
                Caption.Font = new Font(Caption.Font.Name, Caption.Font.Size, FontStyle.Regular);
            if (this.DataType == Data.Double)
            {
                string op = "";
                foreach (char c in Text)
                {
                    if (c == '.' && !op.Contains('.'))
                    {
                        op += c.ToString();
                    }
                    else if (c != '.')
                        op += c.ToString();
                }
                this.NumValue = op;
                //this.Text = op;
                //this.Text = String.Format("{0:" + _Format + "}", Convert.ToDouble(op));
            }
        }
        protected override void OnEnabledChanged(System.EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (!this.Enabled)
            {
                this.SetStyle(ControlStyles.UserPaint, true);
            }
            else
            {
                this.SetStyle(ControlStyles.UserPaint, false);
            }

            this.Invalidate();
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            SolidBrush TextBrush = default(SolidBrush);
            StringFormat sf = new StringFormat();
            switch (this.TextAlign)
            {
                case HorizontalAlignment.Center:
                    sf.Alignment = StringAlignment.Center;
                    break;
                case HorizontalAlignment.Left:
                    sf.Alignment = StringAlignment.Near;
                    break;
                case HorizontalAlignment.Right:
                    sf.Alignment = StringAlignment.Far;
                    break;
            }
            RectangleF rDraw = new RectangleF(this.ClientRectangle.Location, this.ClientRectangle.Size);
            rDraw.Inflate(0, 0);
            if (this.Enabled)
            {
                TextBrush = new SolidBrush(this.ForeColor);
                //SolidBrush BackBrush = new SolidBrush(this.BackColor);
                //e.Graphics.FillRectangle(BackBrush, 0f, 0f, this.Width, this.Height);
            }
            else
            {
                TextBrush = new SolidBrush(this._ForeColorDisabled);
                SolidBrush BackBrush = new SolidBrush(this._BackColorDisabled);
                e.Graphics.FillRectangle(BackBrush, 0f, 0f, this.Width, this.Height);
            }
            e.Graphics.DrawString(this.Text, this.Font, TextBrush, rDraw, sf);
            //this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            if (TextBrush != null)
                TextBrush.Dispose();
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //base.OnKeyPress(e);
            char ch = e.KeyChar;
            decimal x;
            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) && ch != '.' || !Decimal.TryParse(this.Text + ch, out x))
            {
                e.Handled = true;
            }
            //if ((!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)) || Text.Contains('.'))
            //    e.Handled = true;
        }
        #endregion

        #region Mathods
        public void ShowBalloon(string Msg)
        {
            myToolTip.IsBalloon = true;
            myToolTip.Show(string.Empty, this, 0);
            myToolTip.Show(Msg, this, this.Width / 2, this.Height, 3000);
            this.Focus();
        }
        #endregion
    }
}
