using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pathology
{
    class XMaskedTextBox : MaskedTextBox
    {
        
        public XMaskedTextBox()
        {
            this._BackColor = base.BackColor;
            this.Mask = "00/00/0000";
            this.InputFormat = "dd-MM-yyyy";
            this.MoveOnEnter = true;
            this.ErrorMsg = "Invalid Date";
            this.gotFocusColor = Color.Yellow;
        }
        #region Declarations
        private Color _BackColor;
        System.Windows.Forms.ToolTip myToolTip = new System.Windows.Forms.ToolTip();
        #endregion

        #region Properties
        public string ErrorMsg { get; set; }
        public string InputFormat { get; set; }
        public Label Caption { get; set; }
        public bool MoveOnEnter { get; set; }
        public Color gotFocusColor { get; set; }

        private Color _ForeColorDisabled = System.Drawing.SystemColors.Window;
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
        private Color _BackColorDisabled = System.Drawing.SystemColors.Window;
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
        #endregion
        #region Methods
        public DateTime getDate()
        {
            DateTime result;
            var valid = DateTime.TryParse(this.Text, out result);
            return result;
        }
        public void setDate(DateTime value)
        {
            this.Text = string.Format("{0:" + InputFormat + "}", value);
        }

        public bool isDate()
        {
            DateTime result;
            var valid = DateTime.TryParse(this.Text, out result);
            return valid;
        }
        public bool isEmpty()
        {
            if (this.Text == "  -  -")
                return true;
            else
                return
                    false;
        }
        public void ShowBalloon(string Msg)
        {
            myToolTip.IsBalloon = true;
            myToolTip.Show(string.Empty, this, 0);
            myToolTip.Show(Msg, this, this.Width / 2, this.Height, 3000);
            this.Focus();
        }
        #endregion

        #region Events
        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            if (this.Text != "  -  -")
            {
                DateTime myDate = DateTime.Now;
                try
                {
                    myDate = DateTime.ParseExact(this.Text, InputFormat,
                                   System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    myToolTip.IsBalloon = true;
                    myToolTip.Show(string.Empty, this, 0);
                    myToolTip.Show(ErrorMsg, this, this.Width / 2, this.Height, 3000);
                    this.Focus();
                }
            }
        }
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
                _BackColor = this.BackColor;
                this.BackColor = gotFocusColor;
                if (Caption != null)
                    Caption.Font = new Font(Caption.Font, FontStyle.Bold);
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (!this.DesignMode)
            {
                this.BackColor = _BackColor;
                if (Caption != null)
                    Caption.Font = new Font(Caption.Font, FontStyle.Regular);
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
            //RectangleF rDraw = new RectangleF(this.ClientRectangle.Location, this.ClientRectangle.Size);
            //rDraw.Inflate(0, 0);
            if (this.Enabled)
            {
                //TextBrush = new SolidBrush(this.ForeColor);
                //SolidBrush BackBrush = new SolidBrush(this._BackColor);
                //e.Graphics.FillRectangle(BackBrush, 0f, 0f, this.Width, this.Height);
            }
            else
            {
                TextBrush = new SolidBrush(this._ForeColorDisabled);
                SolidBrush BackBrush = new SolidBrush(this._BackColorDisabled);
                e.Graphics.FillRectangle(BackBrush, 0f, 0f, this.Width, this.Height);
            }
            //e.Graphics.DrawString(this.Text, this.Font, TextBrush, rDraw, sf);
            this.Text = Text;
            this.Mask = Mask;
            if (TextBrush != null)
                TextBrush.Dispose();
        }
        #endregion


    }
}
