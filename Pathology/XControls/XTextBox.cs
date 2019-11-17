using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//Original
namespace Pathology
{
    class XTextBox : TextBox
    {
        
        public XTextBox()
        {
            _BackColor = this.BackColor;
            MoveOnEnter = true;
        }
        
        #region Declarations
        private Color _BackColor;
        private Color _gotFocusColor = Color.Yellow;
        private Color _ForeColorDisabled = System.Drawing.SystemColors.WindowText;
        System.Windows.Forms.ToolTip myToolTip = new System.Windows.Forms.ToolTip();
        #endregion

        #region Properties
        public bool MoveOnEnter { get; set; }
        public Label Caption { get; set; }
        public bool IsValid { get; set; }
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

        #region Events
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter & MoveOnEnter)
                SendKeys.Send("{Tab}");
        }
        protected override void OnEnter(EventArgs e)
        {
            //base.OnEnter(e);

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
            if (!this.DesignMode)
            {
                this.BackColor = _BackColor;
                if (this.Caption != null)
                    Caption.Font = new Font(Caption.Font.Name, Caption.Font.Size, FontStyle.Regular);
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

            if (TextBrush != null)
                TextBrush.Dispose();
        }
        private void this_LangChange(KeyEventArgs e)
        {
            int i = (int)e.KeyCode;
            if (e.Shift == true)
            {
                switch (i)
                {
                    case 65://a
                        this.SelectedText = "ा";
                        e.SuppressKeyPress = true;
                        break;
                    case 66://b
                        this.SelectedText = "भ";
                        e.SuppressKeyPress = true;
                        break;
                    case 67: //c
                        this.SelectedText = "छ";
                        e.SuppressKeyPress = true;
                        break;
                    case 68://d
                        this.SelectedText = "ड";
                        e.SuppressKeyPress = true;
                        break;
                    case 69://e
                        this.SelectedText = "े";
                        e.SuppressKeyPress = true;
                        break;
                    case 72://h
                        this.SelectedText = "ः";
                        e.SuppressKeyPress = true;
                        break;
                    case 73://i
                        this.SelectedText = "ि";
                        e.SuppressKeyPress = true;
                        break;
                    case 75://k
                        this.SelectedText = "ख";
                        e.SuppressKeyPress = true;
                        break;
                    case 76://l
                        this.SelectedText = "ळ";
                        e.SuppressKeyPress = true;
                        break;
                    case 77://m
                        this.SelectedText = "ं";
                        e.SuppressKeyPress = true;
                        break;
                    case 78://n
                        this.SelectedText = "ण";
                        e.SuppressKeyPress = true;
                        break;
                    case 79://o
                        this.SelectedText = "ै";
                        e.SuppressKeyPress = true;
                        break;
                    case 82://r
                        this.SelectedText = "ृ";
                        e.SuppressKeyPress = true;
                        break;
                    case 83://s
                        this.SelectedText = "श";
                        e.SuppressKeyPress = true;
                        break;
                    case 84: //t
                        this.SelectedText = "ट";
                        e.SuppressKeyPress = true;
                        break;
                    case 85: //u
                        this.SelectedText = "ु";
                        e.SuppressKeyPress = true;
                        break;
                    case 88: //x
                        this.SelectedText = "ज्ञ";
                        e.SuppressKeyPress = true;
                        break;
                    case 90://z
                        this.SelectedText = "ञ";
                        e.SuppressKeyPress = true;
                        break;

                }
                return;
            }

            if (e.Alt == true)
            {
                switch (i)
                {
                    case 65://a
                        this.SelectedText = "आ";
                        e.SuppressKeyPress = true;
                        break;
                    case 69://e
                        this.SelectedText = "ो";
                        e.SuppressKeyPress = true;
                        break;
                    case 68://d
                        this.SelectedText = "ध";
                        e.SuppressKeyPress = true;
                        break;
                    case 71://g
                        this.SelectedText = "घ";
                        e.SuppressKeyPress = true;
                        break;
                    case 73://i
                        this.SelectedText = "ी";
                        e.SuppressKeyPress = true;
                        break;
                    case 77://m
                        this.SelectedText = "ॐ";
                        e.SuppressKeyPress = true;
                        break;
                    case 79://o
                        this.SelectedText = "ौ";
                        e.SuppressKeyPress = true;
                        break;
                    case 83://s
                        this.SelectedText = "ष";
                        e.SuppressKeyPress = true;
                        break;
                    case 84://t
                        this.SelectedText = "ठ";
                        e.SuppressKeyPress = true;
                        break;
                    case 85://u
                        this.SelectedText = "ू";
                        e.SuppressKeyPress = true;
                        break;
                }
                return;
            }

            if (e.Control)
            {
                switch (i)
                {
                    case 68://d
                        this.SelectedText = "ढ";
                        e.SuppressKeyPress = true;
                        break;
                    case 84://t
                        this.SelectedText = "थ";
                        e.SuppressKeyPress = true;
                        break;
                }
                return;
            }

            switch (i)
            {
                case 65://a
                    this.SelectedText = "अ";
                    e.SuppressKeyPress = true;
                    break;
                case 66://b
                    this.SelectedText = "ब";
                    e.SuppressKeyPress = true;
                    break;
                case 67://c
                    this.SelectedText = "च";
                    e.SuppressKeyPress = true;
                    break;
                case 68://d
                    this.SelectedText = "द";
                    e.SuppressKeyPress = true;
                    break;
                case 69://e
                    this.SelectedText = "ए";
                    e.SuppressKeyPress = true;
                    break;
                case 70://f
                    this.SelectedText = "फ";
                    e.SuppressKeyPress = true;
                    break;
                case 71://g
                    this.SelectedText = "ग";
                    e.SuppressKeyPress = true;
                    break;
                case 72://h
                    this.SelectedText = "ह";
                    e.SuppressKeyPress = true;
                    break;
                case 73://i
                    this.SelectedText = "इ";
                    e.SuppressKeyPress = true;
                    break;
                case 74://j
                    this.SelectedText = "ज";
                    e.SuppressKeyPress = true;
                    break;
                case 75://k
                    this.SelectedText = "क";
                    e.SuppressKeyPress = true;
                    break;
                case 76://l
                    this.SelectedText = "ल";
                    e.SuppressKeyPress = true;
                    break;
                case 77://m
                    this.SelectedText = "म";
                    e.SuppressKeyPress = true;
                    break;
                case 78://n
                    this.SelectedText = "न";
                    e.SuppressKeyPress = true;
                    break;
                case 79://o
                    this.SelectedText = "ओ";
                    e.SuppressKeyPress = true;
                    break;
                case 80://p
                    this.SelectedText = "प";
                    e.SuppressKeyPress = true;
                    break;
                case 81://q
                    this.SelectedText = "";
                    e.SuppressKeyPress = true;
                    break;
                case 82://r
                    this.SelectedText = "र";
                    e.SuppressKeyPress = true;
                    break;
                case 83://s
                    this.SelectedText = "स";
                    e.SuppressKeyPress = true;
                    break;
                case 84://t
                    this.SelectedText = "त";
                    e.SuppressKeyPress = true;
                    break;
                case 85://u
                    this.SelectedText = "उ";
                    e.SuppressKeyPress = true;
                    break;
                case 86://v
                    this.SelectedText = "व";
                    e.SuppressKeyPress = true;
                    break;
                case 87://w
                    this.SelectedText = "ॅ";
                    e.SuppressKeyPress = true;
                    break;
                case 88://x
                    this.SelectedText = "क्ष";
                    e.SuppressKeyPress = true;
                    break;
                case 89://y
                    this.SelectedText = "य";
                    e.SuppressKeyPress = true;
                    break;
                case 90://z
                    this.SelectedText = "झ";
                    e.SuppressKeyPress = true;
                    break;
                case 192://`
                    this.SelectedText = "्";
                    e.SuppressKeyPress = true;
                    break;
            }
        }
        #endregion

        #region Methods
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
