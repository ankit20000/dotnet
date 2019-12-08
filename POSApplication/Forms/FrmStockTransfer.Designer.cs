namespace POSApplication.Forms
{
    partial class FrmStockTransfer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefuellerToRefueller = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefuellerToTank = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(224, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 355);
            this.panel1.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(183, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(179, 33);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Stock Transfer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefuellerToRefueller);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnRefuellerToTank);
            this.groupBox1.Location = new System.Drawing.Point(3, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 263);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnRefuellerToRefueller
            // 
            this.btnRefuellerToRefueller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnRefuellerToRefueller.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefuellerToRefueller.ForeColor = System.Drawing.Color.White;
            this.btnRefuellerToRefueller.Location = new System.Drawing.Point(98, 19);
            this.btnRefuellerToRefueller.Name = "btnRefuellerToRefueller";
            this.btnRefuellerToRefueller.Size = new System.Drawing.Size(365, 50);
            this.btnRefuellerToRefueller.TabIndex = 3;
            this.btnRefuellerToRefueller.Text = "Refueller To Refueller ";
            this.btnRefuellerToRefueller.UseVisualStyleBackColor = false;
            this.btnRefuellerToRefueller.Click += new System.EventHandler(this.btnRefuellerToRefueller_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(147)))));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(98, 190);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(364, 50);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefuellerToTank
            // 
            this.btnRefuellerToTank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnRefuellerToTank.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefuellerToTank.ForeColor = System.Drawing.Color.White;
            this.btnRefuellerToTank.Location = new System.Drawing.Point(97, 107);
            this.btnRefuellerToTank.Name = "btnRefuellerToTank";
            this.btnRefuellerToTank.Size = new System.Drawing.Size(365, 50);
            this.btnRefuellerToTank.TabIndex = 5;
            this.btnRefuellerToTank.Text = "Refueller To Tank";
            this.btnRefuellerToTank.UseVisualStyleBackColor = false;
            this.btnRefuellerToTank.Click += new System.EventHandler(this.btnRefuellerToTank_Click);
            // 
            // FrmStockTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panel1);
            this.Name = "FrmStockTransfer";
            this.Text = "Stock Transfer";
            this.Load += new System.EventHandler(this.FrmStockTransfer_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefuellerToRefueller;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefuellerToTank;
        private System.Windows.Forms.Label lblTitle;
    }
}