namespace POSApplication.Forms
{
    partial class FrmRefuellerToTank
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
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.lblTodayDate = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CmbFuelBatchNo = new System.Windows.Forms.ComboBox();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDensity = new System.Windows.Forms.TextBox();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.lblDensity = new System.Windows.Forms.Label();
            this.lblFuelBatchNo = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKeypad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCurrentDate);
            this.panel1.Controls.Add(this.lblTodayDate);
            this.panel1.Controls.Add(this.lblLogin);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(81, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 364);
            this.panel1.TabIndex = 2;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrentDate.Location = new System.Drawing.Point(641, 30);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(44, 21);
            this.lblCurrentDate.TabIndex = 10;
            this.lblCurrentDate.Text = "Date";
            // 
            // lblTodayDate
            // 
            this.lblTodayDate.AutoSize = true;
            this.lblTodayDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayDate.ForeColor = System.Drawing.Color.Navy;
            this.lblTodayDate.Location = new System.Drawing.Point(583, 30);
            this.lblTodayDate.Name = "lblTodayDate";
            this.lblTodayDate.Size = new System.Drawing.Size(53, 21);
            this.lblTodayDate.TabIndex = 9;
            this.lblTodayDate.Text = "Date :";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblLogin.Location = new System.Drawing.Point(132, 17);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(406, 33);
            this.lblLogin.TabIndex = 8;
            this.lblLogin.Text = "Stock Transfer - Refueller To Tank";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CmbFuelBatchNo);
            this.groupBox2.Controls.Add(this.cmbDestination);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDensity);
            this.groupBox2.Controls.Add(this.txtTemperature);
            this.groupBox2.Controls.Add(this.lblDensity);
            this.groupBox2.Controls.Add(this.lblFuelBatchNo);
            this.groupBox2.Controls.Add(this.lblTemperature);
            this.groupBox2.Location = new System.Drawing.Point(14, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(823, 206);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // CmbFuelBatchNo
            // 
            this.CmbFuelBatchNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFuelBatchNo.FormattingEnabled = true;
            this.CmbFuelBatchNo.Location = new System.Drawing.Point(186, 170);
            this.CmbFuelBatchNo.Name = "CmbFuelBatchNo";
            this.CmbFuelBatchNo.Size = new System.Drawing.Size(635, 31);
            this.CmbFuelBatchNo.TabIndex = 10;
            // 
            // cmbDestination
            // 
            this.cmbDestination.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(255, 7);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(219, 31);
            this.cmbDestination.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Destination :";
            // 
            // txtDensity
            // 
            this.txtDensity.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDensity.Location = new System.Drawing.Point(255, 61);
            this.txtDensity.Name = "txtDensity";
            this.txtDensity.Size = new System.Drawing.Size(219, 32);
            this.txtDensity.TabIndex = 1;
            // 
            // txtTemperature
            // 
            this.txtTemperature.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemperature.Location = new System.Drawing.Point(255, 115);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(219, 32);
            this.txtTemperature.TabIndex = 5;
            // 
            // lblDensity
            // 
            this.lblDensity.AutoSize = true;
            this.lblDensity.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDensity.Location = new System.Drawing.Point(2, 70);
            this.lblDensity.Name = "lblDensity";
            this.lblDensity.Size = new System.Drawing.Size(239, 23);
            this.lblDensity.TabIndex = 0;
            this.lblDensity.Text = "Observed Density (kg/m3) :";
            // 
            // lblFuelBatchNo
            // 
            this.lblFuelBatchNo.AutoSize = true;
            this.lblFuelBatchNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuelBatchNo.Location = new System.Drawing.Point(4, 172);
            this.lblFuelBatchNo.Name = "lblFuelBatchNo";
            this.lblFuelBatchNo.Size = new System.Drawing.Size(148, 23);
            this.lblFuelBatchNo.TabIndex = 4;
            this.lblFuelBatchNo.Text = "Fuel Batch No. :";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperature.Location = new System.Drawing.Point(2, 119);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(247, 23);
            this.lblTemperature.TabIndex = 2;
            this.lblTemperature.Text = "Observed Temperature (0c) :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKeypad);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Location = new System.Drawing.Point(14, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnKeypad
            // 
            this.btnKeypad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnKeypad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKeypad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnKeypad.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeypad.ForeColor = System.Drawing.Color.White;
            this.btnKeypad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKeypad.Location = new System.Drawing.Point(318, 8);
            this.btnKeypad.Name = "btnKeypad";
            this.btnKeypad.Size = new System.Drawing.Size(114, 50);
            this.btnKeypad.TabIndex = 15;
            this.btnKeypad.Text = "Keypad";
            this.btnKeypad.UseVisualStyleBackColor = false;
            this.btnKeypad.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(93, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(202, 50);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Start Stock Transfer";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(147)))));
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(453, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 50);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmRefuellerToTank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(984, 528);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRefuellerToTank";
            this.Text = "Stock Transfer - Refueller To Tank";
            this.Load += new System.EventHandler(this.FrmRefuellerToTank_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDensity;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.Label lblDensity;
        private System.Windows.Forms.Label lblFuelBatchNo;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnKeypad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label lblTodayDate;
        private System.Windows.Forms.ComboBox CmbFuelBatchNo;
    }
}