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
    public partial class ButtonControl : UserControl
    {

       private string Pv_ButtonText = "";//"&Add;&Edit;&Delete;&View;&Close";
       private string Pv_OldButtonText  = "";
       public delegate void SubmitClickedHandler(string msg);
       
       [Category("Action")]
       [Description("Fires when the Submit button is clicked.")]
       public event SubmitClickedHandler SubmitClicked;

       public string ButtonText
       {
           get {
               return Pv_ButtonText;
           }
           set{Pv_ButtonText =value;
           if (!string.IsNullOrEmpty(Pv_ButtonText))
           {
               ComposeButtons();
           }

           }
       }


        public ButtonControl()
        {
            InitializeComponent();
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
     
        private void ComposeButtons() {
            if (!IsButtonTextChanged()) return; 

            this.Controls.Clear();  
            string[] Buttons = ButtonText.Replace("&", "").Split(';');
            int l = 0;
            Byte TabIndx = 0;


            Button[] Btns = new Button[Buttons.Length];
            int index = 0;
            int buttonsWidth = 0;
            foreach (string  btnTxt in Buttons)
            {

                Btns[index] = new Button();
                Btns[index].Width = 30;
                Btns[index].Height = this.Parent.Height;
                Btns[index].AutoSize = true;
                Btns[index].Text = btnTxt;
                Btns[index].BackColor = System.Drawing.Color.Transparent;
                Btns[index].Name = "btn" + btnTxt;
                Btns[index].Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Btns[index].ImageList = imageList1;
                //Btns[index].ImageIndex += 1;
                //Btns[index].ImageAlign = ContentAlignment.MiddleRight;
                Btns[index].TabIndex = TabIndx;
                Btns[index].Click += new System.EventHandler(this.btnSubmit_Click);
                TabIndx += 1;
                buttonsWidth += Btns[index].Width +10;
                index++;
             }
            l=(this.Parent.ClientSize.Width-buttonsWidth)/2;

                foreach (Button b in Btns)
                {
                    b.Left = l;
                    this.Controls.Add(b);
                    l += b.Width;
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

