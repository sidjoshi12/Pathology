namespace Pathology
{
    partial class frmBackupLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTop = new Pathology.XNumTextBox();
            this.lblTop = new System.Windows.Forms.Label();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.radFailed = new System.Windows.Forms.RadioButton();
            this.radSuccess = new System.Windows.Forms.RadioButton();
            this.btnShow = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 313);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(544, 244);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTop);
            this.panel1.Controls.Add(this.radAll);
            this.panel1.Controls.Add(this.radFailed);
            this.panel1.Controls.Add(this.radSuccess);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.lblTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 57);
            this.panel1.TabIndex = 0;
            // 
            // txtTop
            // 
            this.txtTop.BackColorDisabled = System.Drawing.SystemColors.Window;
            this.txtTop.Caption = this.lblTop;
            this.txtTop.DataType = Pathology.XNumTextBox.Data.Text;
            this.txtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTop.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.txtTop.Format = "###0";
            this.txtTop.gotFocusColor = System.Drawing.Color.Yellow;
            this.txtTop.Location = new System.Drawing.Point(284, 17);
            this.txtTop.MoveOnEnter = true;
            this.txtTop.Name = "txtTop";
            this.txtTop.NumValue = "###0";
            this.txtTop.Size = new System.Drawing.Size(45, 22);
            this.txtTop.TabIndex = 7;
            this.txtTop.Text = "50";
            this.txtTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTop.Location = new System.Drawing.Point(245, 20);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(33, 16);
            this.lblTop.TabIndex = 1;
            this.lblTop.Text = "Top";
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(198, 18);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(41, 20);
            this.radAll.TabIndex = 6;
            this.radAll.TabStop = true;
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // radFailed
            // 
            this.radFailed.AutoSize = true;
            this.radFailed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFailed.Location = new System.Drawing.Point(107, 18);
            this.radFailed.Name = "radFailed";
            this.radFailed.Size = new System.Drawing.Size(64, 20);
            this.radFailed.TabIndex = 5;
            this.radFailed.Text = "Failed";
            this.radFailed.UseVisualStyleBackColor = true;
            // 
            // radSuccess
            // 
            this.radSuccess.AutoSize = true;
            this.radSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSuccess.Location = new System.Drawing.Point(16, 18);
            this.radSuccess.Name = "radSuccess";
            this.radSuccess.Size = new System.Drawing.Size(78, 20);
            this.radSuccess.TabIndex = 4;
            this.radSuccess.Text = "Success";
            this.radSuccess.UseVisualStyleBackColor = true;
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(357, 17);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // frmBackupLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 313);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmBackupLog";
            this.Text = "Backup Log";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private XNumTextBox txtTop;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.RadioButton radFailed;
        private System.Windows.Forms.RadioButton radSuccess;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblTop;
    }
}