using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


///Cosoha
namespace Pathology
{
    class XDateTimePicker : DateTimePicker, IDisposable
    {
        private Color _BackColor;
        public XDateTimePicker()
        {
            _BackColor = base.BackColor;
            MoveOnEnter = true;
        }
        public Label Caption { get; set; }
        public bool MoveOnEnter { get; set; }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter & MoveOnEnter)
                SendKeys.Send("{Tab}");

            //if (e.KeyCode == Keys.Escape)
            //{
            //    if (Caption == null)
            //    {
            //        Control parent = this.Parent;
            //        parent.Focus();
            //    }
            //    else
            //    {
            //        Caption.Focus();
            //    }
            //}

        }
        private Color _gotFocusColor = Color.Yellow;
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
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (!this.DesignMode)
            {
                _BackColor = this.BackColor;
                this.BackColor = _gotFocusColor;
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
        //protected override void OnEnabledChanged(System.EventArgs e)
        //{
        //    base.OnEnabledChanged(e);
        //    if (!this.Enabled)
        //    {
        //        this.SetStyle(ControlStyles.UserPaint, true);
        //    }
        //    else
        //    {
        //        this.SetStyle(ControlStyles.UserPaint, false);
        //    }

        //    this.Invalidate();
        //}
        //protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    SolidBrush TextBrush = default(SolidBrush);
        //    StringFormat sf = new StringFormat();
        //    RectangleF rDraw = new RectangleF(this.ClientRectangle.Location, this.ClientRectangle.Size);
        //    rDraw.Inflate(0, 0);
        //    if (this.Enabled)
        //    {
        //        //TextBrush = new SolidBrush(this.ForeColor);
        //        //SolidBrush BackBrush = new SolidBrush(this._BackColor);
        //        //e.Graphics.FillRectangle(BackBrush, 0f, 0f, this.Width, this.Height);
        //    }
        //    else
        //    {
        //        TextBrush = new SolidBrush(this._ForeColorDisabled);
        //        SolidBrush BackBrush = new SolidBrush(this._BackColorDisabled);
        //        e.Graphics.FillRectangle(BackBrush, 0f, 0f, this.Width, this.Height);
        //    }
        //    e.Graphics.DrawString(this.Text, this.Font, TextBrush, rDraw, sf);

        //    if (TextBrush != null)
        //        TextBrush.Dispose();
            
        //}
        private Color _ForeColorDisabled = System.Drawing.SystemColors.WindowText;

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
        //this.xTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        #region Methods
        public void ShowBalloon(string Msg)
        {
            System.Windows.Forms.ToolTip myToolTip = new System.Windows.Forms.ToolTip();
            myToolTip.IsBalloon = true;
            myToolTip.Show(string.Empty, this, 0);
            myToolTip.Show(Msg, this, this.Width / 2, this.Height, 3000);
            this.Focus();
        }
        #endregion
    }
}
