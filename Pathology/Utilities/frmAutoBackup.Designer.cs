namespace Pathology
{
    partial class frmAutoBackup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoBackup));
            this.lblBackupPath = new System.Windows.Forms.Label();
            this.txtBackupPath = new Pathology.XTextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblBackupFrequency = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.xNumTextBox1 = new Pathology.XNumTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnBackupNow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.AutoSize = true;
            this.lblBackupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupPath.Location = new System.Drawing.Point(16, 57);
            this.lblBackupPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(84, 16);
            this.lblBackupPath.TabIndex = 0;
            this.lblBackupPath.Text = "Backup Path";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.BackColorDisabled = System.Drawing.SystemColors.Window;
            this.txtBackupPath.Caption = this.lblBackupPath;
            this.txtBackupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupPath.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.txtBackupPath.gotFocusColor = System.Drawing.Color.Yellow;
            this.txtBackupPath.Location = new System.Drawing.Point(139, 54);
            this.txtBackupPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtBackupPath.MoveOnEnter = true;
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(337, 22);
            this.txtBackupPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(484, 54);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(27, 22);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblBackupFrequency
            // 
            this.lblBackupFrequency.AutoSize = true;
            this.lblBackupFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupFrequency.Location = new System.Drawing.Point(16, 105);
            this.lblBackupFrequency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackupFrequency.Name = "lblBackupFrequency";
            this.lblBackupFrequency.Size = new System.Drawing.Size(121, 16);
            this.lblBackupFrequency.TabIndex = 3;
            this.lblBackupFrequency.Text = "Backup Frequency";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Days";
            // 
            // xNumTextBox1
            // 
            this.xNumTextBox1.BackColorDisabled = System.Drawing.SystemColors.Window;
            this.xNumTextBox1.Caption = this.lblBackupFrequency;
            this.xNumTextBox1.DataType = Pathology.XNumTextBox.Data.Text;
            this.xNumTextBox1.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.xNumTextBox1.Format = "###0";
            this.xNumTextBox1.gotFocusColor = System.Drawing.Color.Yellow;
            this.xNumTextBox1.Location = new System.Drawing.Point(139, 102);
            this.xNumTextBox1.MoveOnEnter = true;
            this.xNumTextBox1.Name = "xNumTextBox1";
            this.xNumTextBox1.NumValue = "###0";
            this.xNumTextBox1.Size = new System.Drawing.Size(39, 22);
            this.xNumTextBox1.TabIndex = 9;
            this.xNumTextBox1.Text = "0";
            this.xNumTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(379, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(322, 162);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(51, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnBackupNow
            // 
            this.btnBackupNow.Image = ((System.Drawing.Image)(resources.GetObject("btnBackupNow.Image")));
            this.btnBackupNow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackupNow.Location = new System.Drawing.Point(209, 162);
            this.btnBackupNow.Name = "btnBackupNow";
            this.btnBackupNow.Size = new System.Drawing.Size(107, 23);
            this.btnBackupNow.TabIndex = 6;
            this.btnBackupNow.Text = "Backup Now";
            this.btnBackupNow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackupNow.UseVisualStyleBackColor = true;
            this.btnBackupNow.Click += new System.EventHandler(this.btnBackupNow_Click);
            // 
            // frmAutoBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 201);
            this.Controls.Add(this.xNumTextBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBackupNow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBackupFrequency);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtBackupPath);
            this.Controls.Add(this.lblBackupPath);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAutoBackup";
            this.Text = "Auto Backup";
            this.Load += new System.EventHandler(this.frmAutoBackup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAutoBackup_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBackupPath;
        private XTextBox txtBackupPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblBackupFrequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBackupNow;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private XNumTextBox xNumTextBox1;
    }
}