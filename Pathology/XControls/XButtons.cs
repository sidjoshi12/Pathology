using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows;
namespace Pathology
{
    public partial class XButtons : UserControl
    {

        private string Pv_ButtonText = "";//"&Add;&Edit;&Delete;&View;&Close";
        private string Pv_OldButtonText = "";
        public delegate void SubmitClickedHandler(string msg);
        ImageList imageList2 = new ImageList();

        [Category("Action")]
        [Description("Fires when the Submit button is clicked.")]
        public event SubmitClickedHandler SubmitClicked;

        public string ButtonText
        {
            get
            {
                return Pv_ButtonText;
            }
            set
            {
                Pv_ButtonText = value;
                if (!string.IsNullOrEmpty(Pv_ButtonText))
                {
                    ComposeButtons();
                }

            }
        }


        public XButtons()
        {
            Bitmap bmp = new Bitmap(16, 16);
            imageList2.Images.Add(bmp);
            InitializeComponent();
       imageList2.Images.Add(Properties.Resources.first);
       imageList2.Images.Add(Properties.Resources.next);
       imageList2.Images.Add(Properties.Resources.back);
       imageList2.Images.Add(Properties.Resources.last);
       imageList2.Images.Add(Properties.Resources.edit);
       imageList2.Images.Add(Properties.Resources.save);
       imageList2.Images.Add(Properties.Resources.delete);
       imageList2.Images.Add(Properties.Resources.exit);
       imageList2.Images.Add(Properties.Resources.add);
       imageList2.Images.Add(Properties.Resources.search);
       imageList2.Images.Add(Properties.Resources.cancel);
       imageList2.Images.Add(Properties.Resources.view);   
        }


        private Boolean IsButtonTextChanged()
        {
            if (Pv_ButtonText != Pv_OldButtonText)
            {
                Pv_OldButtonText = Pv_ButtonText;
                return true;
            }

            else
                return false;
        }

        private void ComposeButtons()
        {
            if (!IsButtonTextChanged()) return;

            this.Controls.Clear();
            string[] Buttons = ButtonText.Replace("&", "").Split(';');
            int l = 0;
            Byte TabIndx = 0;


            Button[] Btns = new Button[Buttons.Length];
            int index = 0;
            int buttonsWidth = 0;
            foreach (string btnTxt in Buttons)
            {
                Btns[index] = new Button();
                Btns[index].Width = 30;
                Btns[index].Height = this.Parent.Height;
                Btns[index].AutoSize = true;
                Btns[index].Text = btnTxt;
                Btns[index].BackColor = System.Drawing.Color.Transparent;
                Btns[index].Name = "btn" + btnTxt;
                Btns[index].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Btns[index].ImageIndex = getImageIndex(btnTxt);
                Btns[index].ImageList = imageList2;
                Btns[index].ImageAlign = ContentAlignment.MiddleLeft;
                Btns[index].TextAlign = ContentAlignment.MiddleRight;
                Btns[index].Width += 25;
                Btns[index].TabIndex = TabIndx;
                Btns[index].Click += new System.EventHandler(this.btnSubmit_Click);
                TabIndx += 1;
                buttonsWidth += Btns[index].Width;// +10;
                index++;
            }
            l = (this.Parent.ClientSize.Width - buttonsWidth) / 2;

            foreach (Button b in Btns)
            {
                b.Left = l;
                this.Controls.Add(b);
                l += b.Width;
            }


        }
        private int getImageIndex(string btnCaption)
        {
            switch (btnCaption)
            {
                case "First": return 1; 
                case "Next": return 2; 
                case "Back": return 3; 
                case "Last": return 4; 
                case "Edit": return 5; 
                case "Save": return 6; 
                case "Delete": return 7; 
                case "Exit": return 8; 
                case "Add": return 9; 
                case "Search": return 10; 
                case "Cancel": return 11; 
                case "View": return 12; 
                default:return 0;
            }
        }

        // Add a protected method called OnSubmitClicked(). 
        // You may use this in child classes instead of adding
        // event handlers.
        protected virtual void OnSubmitClicked(string msg)
        {
            // If an event has no subscribers registerd, it will 
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (SubmitClicked != null)
            {
                SubmitClicked(msg);  // Notify Subscribers
            }
        }

        // Handler for Submit Button. Do some validation before
        // calling the event.
        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            OnSubmitClicked(((Button)sender).Text);
        }

    }
}

