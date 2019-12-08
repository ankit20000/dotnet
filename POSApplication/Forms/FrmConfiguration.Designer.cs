namespace POSApplication.Forms
{
    partial class FrmConfiguration
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnKeypad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnImportData = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtADRTransaction = new System.Windows.Forms.TextBox();
            this.lblIATACode = new System.Windows.Forms.Label();
            this.txtOtherTransaction = new System.Windows.Forms.TextBox();
            this.lblDGCANumber = new System.Windows.Forms.Label();
            this.txtDGCANumber = new System.Windows.Forms.TextBox();
            this.lblADRTransaction = new System.Windows.Forms.Label();
            this.txtIATACode = new System.Windows.Forms.TextBox();
            this.lblOtherTransaction = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBOIPAddress = new System.Windows.Forms.Label();
            this.lblFlowMeter = new System.Windows.Forms.Label();
            this.cmbFlowMeter = new System.Windows.Forms.ComboBox();
            this.cmbRefuller = new System.Windows.Forms.ComboBox();
            this.lblRefullerID = new System.Windows.Forms.Label();
            this.txtBOIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(25, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 377);
            this.panel1.TabIndex = 0;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrentDate.Location = new System.Drawing.Point(716, 21);
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
            this.lblTodayDate.Location = new System.Drawing.Point(658, 21);
            this.lblTodayDate.Name = "lblTodayDate";
            this.lblTodayDate.Size = new System.Drawing.Size(53, 21);
            this.lblTodayDate.TabIndex = 9;
            this.lblTodayDate.Text = "Date :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(311, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 36);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Configuration";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnKeypad);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnImportData);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 299);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(899, 65);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(147)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(601, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 50);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnKeypad
            // 
            this.btnKeypad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnKeypad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKeypad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnKeypad.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeypad.ForeColor = System.Drawing.Color.White;
            this.btnKeypad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKeypad.Location = new System.Drawing.Point(114, 4);
            this.btnKeypad.Name = "btnKeypad";
            this.btnKeypad.Size = new System.Drawing.Size(135, 50);
            this.btnKeypad.TabIndex = 7;
            this.btnKeypad.Text = "Keypad";
            this.btnKeypad.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(450, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 50);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImportData
            // 
            this.btnImportData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnImportData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnImportData.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportData.ForeColor = System.Drawing.Color.White;
            this.btnImportData.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportData.Location = new System.Drawing.Point(284, 3);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(139, 50);
            this.btnImportData.TabIndex = 8;
            this.btnImportData.Text = "Import Data";
            this.btnImportData.UseVisualStyleBackColor = false;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtADRTransaction);
            this.groupBox2.Controls.Add(this.lblIATACode);
            this.groupBox2.Controls.Add(this.txtOtherTransaction);
            this.groupBox2.Controls.Add(this.lblDGCANumber);
            this.groupBox2.Controls.Add(this.txtDGCANumber);
            this.groupBox2.Controls.Add(this.lblADRTransaction);
            this.groupBox2.Controls.Add(this.txtIATACode);
            this.groupBox2.Controls.Add(this.lblOtherTransaction);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(408, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 213);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Site Configuration";
            // 
            // txtADRTransaction
            // 
            this.txtADRTransaction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtADRTransaction.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtADRTransaction.Location = new System.Drawing.Point(245, 128);
            this.txtADRTransaction.MaxLength = 10;
            this.txtADRTransaction.Name = "txtADRTransaction";
            this.txtADRTransaction.Size = new System.Drawing.Size(274, 32);
            this.txtADRTransaction.TabIndex = 5;
            // 
            // lblIATACode
            // 
            this.lblIATACode.AutoSize = true;
            this.lblIATACode.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIATACode.ForeColor = System.Drawing.Color.Black;
            this.lblIATACode.Location = new System.Drawing.Point(6, 43);
            this.lblIATACode.Name = "lblIATACode";
            this.lblIATACode.Size = new System.Drawing.Size(117, 23);
            this.lblIATACode.TabIndex = 4;
            this.lblIATACode.Text = "IA TA Code :";
            // 
            // txtOtherTransaction
            // 
            this.txtOtherTransaction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOtherTransaction.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherTransaction.Location = new System.Drawing.Point(245, 170);
            this.txtOtherTransaction.Name = "txtOtherTransaction";
            this.txtOtherTransaction.Size = new System.Drawing.Size(275, 32);
            this.txtOtherTransaction.TabIndex = 6;
            // 
            // lblDGCANumber
            // 
            this.lblDGCANumber.AutoSize = true;
            this.lblDGCANumber.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDGCANumber.ForeColor = System.Drawing.Color.Black;
            this.lblDGCANumber.Location = new System.Drawing.Point(6, 86);
            this.lblDGCANumber.Name = "lblDGCANumber";
            this.lblDGCANumber.Size = new System.Drawing.Size(152, 23);
            this.lblDGCANumber.TabIndex = 5;
            this.lblDGCANumber.Text = "DGCA Appr. No.";
            // 
            // txtDGCANumber
            // 
            this.txtDGCANumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDGCANumber.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDGCANumber.Location = new System.Drawing.Point(245, 85);
            this.txtDGCANumber.MaxLength = 50;
            this.txtDGCANumber.Name = "txtDGCANumber";
            this.txtDGCANumber.Size = new System.Drawing.Size(274, 32);
            this.txtDGCANumber.TabIndex = 4;
            // 
            // lblADRTransaction
            // 
            this.lblADRTransaction.AutoSize = true;
            this.lblADRTransaction.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblADRTransaction.ForeColor = System.Drawing.Color.Black;
            this.lblADRTransaction.Location = new System.Drawing.Point(6, 127);
            this.lblADRTransaction.Name = "lblADRTransaction";
            this.lblADRTransaction.Size = new System.Drawing.Size(220, 23);
            this.lblADRTransaction.TabIndex = 6;
            this.lblADRTransaction.Text = "ADR Transaction Series :";
            // 
            // txtIATACode
            // 
            this.txtIATACode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIATACode.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIATACode.Location = new System.Drawing.Point(245, 40);
            this.txtIATACode.MaxLength = 50;
            this.txtIATACode.Name = "txtIATACode";
            this.txtIATACode.Size = new System.Drawing.Size(274, 32);
            this.txtIATACode.TabIndex = 3;
            // 
            // lblOtherTransaction
            // 
            this.lblOtherTransaction.AutoSize = true;
            this.lblOtherTransaction.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherTransaction.ForeColor = System.Drawing.Color.Black;
            this.lblOtherTransaction.Location = new System.Drawing.Point(6, 169);
            this.lblOtherTransaction.Name = "lblOtherTransaction";
            this.lblOtherTransaction.Size = new System.Drawing.Size(224, 23);
            this.lblOtherTransaction.TabIndex = 7;
            this.lblOtherTransaction.Text = "Other Transaction Series :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBOIPAddress);
            this.groupBox1.Controls.Add(this.lblFlowMeter);
            this.groupBox1.Controls.Add(this.cmbFlowMeter);
            this.groupBox1.Controls.Add(this.cmbRefuller);
            this.groupBox1.Controls.Add(this.lblRefullerID);
            this.groupBox1.Controls.Add(this.txtBOIPAddress);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(16, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 213);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Configuration";
            // 
            // lblBOIPAddress
            // 
            this.lblBOIPAddress.AutoSize = true;
            this.lblBOIPAddress.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOIPAddress.ForeColor = System.Drawing.Color.Black;
            this.lblBOIPAddress.Location = new System.Drawing.Point(7, 52);
            this.lblBOIPAddress.Name = "lblBOIPAddress";
            this.lblBOIPAddress.Size = new System.Drawing.Size(142, 23);
            this.lblBOIPAddress.TabIndex = 1;
            this.lblBOIPAddress.Text = "BO IP Address :";
            // 
            // lblFlowMeter
            // 
            this.lblFlowMeter.AutoSize = true;
            this.lblFlowMeter.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlowMeter.ForeColor = System.Drawing.Color.Black;
            this.lblFlowMeter.Location = new System.Drawing.Point(6, 161);
            this.lblFlowMeter.Name = "lblFlowMeter";
            this.lblFlowMeter.Size = new System.Drawing.Size(119, 23);
            this.lblFlowMeter.TabIndex = 3;
            this.lblFlowMeter.Text = "Flow Meter :";
            // 
            // cmbFlowMeter
            // 
            this.cmbFlowMeter.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFlowMeter.ForeColor = System.Drawing.Color.Black;
            this.cmbFlowMeter.FormattingEnabled = true;
            this.cmbFlowMeter.Location = new System.Drawing.Point(162, 160);
            this.cmbFlowMeter.MaxLength = 50;
            this.cmbFlowMeter.Name = "cmbFlowMeter";
            this.cmbFlowMeter.Size = new System.Drawing.Size(218, 29);
            this.cmbFlowMeter.TabIndex = 2;
            this.cmbFlowMeter.Text = "Please Select";
            // 
            // cmbRefuller
            // 
            this.cmbRefuller.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRefuller.ForeColor = System.Drawing.Color.Black;
            this.cmbRefuller.FormattingEnabled = true;
            this.cmbRefuller.Location = new System.Drawing.Point(162, 109);
            this.cmbRefuller.MaxLength = 4;
            this.cmbRefuller.Name = "cmbRefuller";
            this.cmbRefuller.Size = new System.Drawing.Size(218, 29);
            this.cmbRefuller.TabIndex = 1;
            this.cmbRefuller.Text = "Please Select";
            // 
            // lblRefullerID
            // 
            this.lblRefullerID.AutoSize = true;
            this.lblRefullerID.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefullerID.ForeColor = System.Drawing.Color.Black;
            this.lblRefullerID.Location = new System.Drawing.Point(7, 110);
            this.lblRefullerID.Name = "lblRefullerID";
            this.lblRefullerID.Size = new System.Drawing.Size(116, 23);
            this.lblRefullerID.TabIndex = 2;
            this.lblRefullerID.Text = "Refuller ID :";
            // 
            // txtBOIPAddress
            // 
            this.txtBOIPAddress.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBOIPAddress.ForeColor = System.Drawing.Color.Black;
            this.txtBOIPAddress.Location = new System.Drawing.Point(162, 51);
            this.txtBOIPAddress.MaxLength = 25;
            this.txtBOIPAddress.Name = "txtBOIPAddress";
            this.txtBOIPAddress.Size = new System.Drawing.Size(218, 29);
            this.txtBOIPAddress.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Magenta;
            this.label1.Location = new System.Drawing.Point(311, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuration";
            // 
            // FrmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panel1);
            this.Name = "FrmConfiguration";
            this.Text = "Configuration Settings";
            this.Load += new System.EventHandler(this.FrmConfiguration_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.Button btnKeypad;
        private System.Windows.Forms.TextBox txtOtherTransaction;
        private System.Windows.Forms.TextBox txtADRTransaction;
        private System.Windows.Forms.TextBox txtDGCANumber;
        private System.Windows.Forms.TextBox txtIATACode;
        private System.Windows.Forms.Label lblOtherTransaction;
        private System.Windows.Forms.Label lblADRTransaction;
        private System.Windows.Forms.Label lblDGCANumber;
        private System.Windows.Forms.Label lblIATACode;
        private System.Windows.Forms.ComboBox cmbFlowMeter;
        private System.Windows.Forms.TextBox txtBOIPAddress;
        private System.Windows.Forms.Label lblFlowMeter;
        private System.Windows.Forms.Label lblRefullerID;
        private System.Windows.Forms.Label lblBOIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRefuller;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label lblTodayDate;
    }
}