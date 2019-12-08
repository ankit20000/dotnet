namespace POSApplication.Forms
{
    partial class FrmCirculationTestFlowMeter
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.lblTodayDate = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFuellingEndTime = new System.Windows.Forms.TextBox();
            this.txtMeterEndReading = new System.Windows.Forms.TextBox();
            this.txtQtyCirculated = new System.Windows.Forms.TextBox();
            this.lblFuellingEndTime = new System.Windows.Forms.Label();
            this.lblMeterEndReading = new System.Windows.Forms.Label();
            this.lblQtyCirculated = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFuellingStartTime = new System.Windows.Forms.TextBox();
            this.txtMeterStartReading = new System.Windows.Forms.TextBox();
            this.txtEquipementNo = new System.Windows.Forms.TextBox();
            this.lblMeterStartReading = new System.Windows.Forms.Label();
            this.lblFuellingStartTime = new System.Windows.Forms.Label();
            this.lblEquipementNo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFinalClearance = new System.Windows.Forms.Label();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCurrentDate);
            this.panel1.Controls.Add(this.lblTodayDate);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(53, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 344);
            this.panel1.TabIndex = 13;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrentDate.Location = new System.Drawing.Point(645, 21);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(44, 21);
            this.lblCurrentDate.TabIndex = 7;
            this.lblCurrentDate.Text = "Date";
            // 
            // lblTodayDate
            // 
            this.lblTodayDate.AutoSize = true;
            this.lblTodayDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayDate.ForeColor = System.Drawing.Color.Navy;
            this.lblTodayDate.Location = new System.Drawing.Point(587, 21);
            this.lblTodayDate.Name = "lblTodayDate";
            this.lblTodayDate.Size = new System.Drawing.Size(53, 21);
            this.lblTodayDate.TabIndex = 6;
            this.lblTodayDate.Text = "Date :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(837, 195);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtFuellingEndTime);
            this.groupBox4.Controls.Add(this.txtMeterEndReading);
            this.groupBox4.Controls.Add(this.txtQtyCirculated);
            this.groupBox4.Controls.Add(this.lblFuellingEndTime);
            this.groupBox4.Controls.Add(this.lblMeterEndReading);
            this.groupBox4.Controls.Add(this.lblQtyCirculated);
            this.groupBox4.Location = new System.Drawing.Point(430, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(405, 173);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(356, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ltrs";
            // 
            // txtFuellingEndTime
            // 
            this.txtFuellingEndTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFuellingEndTime.Location = new System.Drawing.Point(183, 122);
            this.txtFuellingEndTime.MaxLength = 30;
            this.txtFuellingEndTime.Name = "txtFuellingEndTime";
            this.txtFuellingEndTime.Size = new System.Drawing.Size(216, 32);
            this.txtFuellingEndTime.TabIndex = 5;
            // 
            // txtMeterEndReading
            // 
            this.txtMeterEndReading.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeterEndReading.Location = new System.Drawing.Point(183, 59);
            this.txtMeterEndReading.MaxLength = 20;
            this.txtMeterEndReading.Name = "txtMeterEndReading";
            this.txtMeterEndReading.Size = new System.Drawing.Size(216, 32);
            this.txtMeterEndReading.TabIndex = 3;
            // 
            // txtQtyCirculated
            // 
            this.txtQtyCirculated.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtyCirculated.Location = new System.Drawing.Point(183, 5);
            this.txtQtyCirculated.MaxLength = 20;
            this.txtQtyCirculated.Name = "txtQtyCirculated";
            this.txtQtyCirculated.Size = new System.Drawing.Size(167, 32);
            this.txtQtyCirculated.TabIndex = 1;
            // 
            // lblFuellingEndTime
            // 
            this.lblFuellingEndTime.AutoSize = true;
            this.lblFuellingEndTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuellingEndTime.Location = new System.Drawing.Point(1, 125);
            this.lblFuellingEndTime.Name = "lblFuellingEndTime";
            this.lblFuellingEndTime.Size = new System.Drawing.Size(176, 23);
            this.lblFuellingEndTime.TabIndex = 12;
            this.lblFuellingEndTime.Text = "Fuelling End Time :";
            // 
            // lblMeterEndReading
            // 
            this.lblMeterEndReading.AutoSize = true;
            this.lblMeterEndReading.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeterEndReading.Location = new System.Drawing.Point(1, 68);
            this.lblMeterEndReading.Name = "lblMeterEndReading";
            this.lblMeterEndReading.Size = new System.Drawing.Size(181, 23);
            this.lblMeterEndReading.TabIndex = 11;
            this.lblMeterEndReading.Text = "Meter End Reading :";
            // 
            // lblQtyCirculated
            // 
            this.lblQtyCirculated.AutoSize = true;
            this.lblQtyCirculated.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyCirculated.Location = new System.Drawing.Point(6, 12);
            this.lblQtyCirculated.Name = "lblQtyCirculated";
            this.lblQtyCirculated.Size = new System.Drawing.Size(143, 23);
            this.lblQtyCirculated.TabIndex = 10;
            this.lblQtyCirculated.Text = "Qty Circulated :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFuellingStartTime);
            this.groupBox3.Controls.Add(this.txtMeterStartReading);
            this.groupBox3.Controls.Add(this.txtEquipementNo);
            this.groupBox3.Controls.Add(this.lblMeterStartReading);
            this.groupBox3.Controls.Add(this.lblFuellingStartTime);
            this.groupBox3.Controls.Add(this.lblEquipementNo);
            this.groupBox3.Location = new System.Drawing.Point(0, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(413, 173);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // txtFuellingStartTime
            // 
            this.txtFuellingStartTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFuellingStartTime.Location = new System.Drawing.Point(186, 122);
            this.txtFuellingStartTime.MaxLength = 30;
            this.txtFuellingStartTime.Name = "txtFuellingStartTime";
            this.txtFuellingStartTime.Size = new System.Drawing.Size(221, 32);
            this.txtFuellingStartTime.TabIndex = 4;
            // 
            // txtMeterStartReading
            // 
            this.txtMeterStartReading.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeterStartReading.Location = new System.Drawing.Point(186, 63);
            this.txtMeterStartReading.MaxLength = 20;
            this.txtMeterStartReading.Name = "txtMeterStartReading";
            this.txtMeterStartReading.Size = new System.Drawing.Size(221, 32);
            this.txtMeterStartReading.TabIndex = 2;
            // 
            // txtEquipementNo
            // 
            this.txtEquipementNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipementNo.Location = new System.Drawing.Point(186, 9);
            this.txtEquipementNo.MaxLength = 10;
            this.txtEquipementNo.Name = "txtEquipementNo";
            this.txtEquipementNo.Size = new System.Drawing.Size(221, 32);
            this.txtEquipementNo.TabIndex = 0;
            // 
            // lblMeterStartReading
            // 
            this.lblMeterStartReading.AutoSize = true;
            this.lblMeterStartReading.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeterStartReading.Location = new System.Drawing.Point(-2, 66);
            this.lblMeterStartReading.Name = "lblMeterStartReading";
            this.lblMeterStartReading.Size = new System.Drawing.Size(187, 23);
            this.lblMeterStartReading.TabIndex = 11;
            this.lblMeterStartReading.Text = "Meter Start Reading :";
            // 
            // lblFuellingStartTime
            // 
            this.lblFuellingStartTime.AutoSize = true;
            this.lblFuellingStartTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuellingStartTime.Location = new System.Drawing.Point(-2, 125);
            this.lblFuellingStartTime.Name = "lblFuellingStartTime";
            this.lblFuellingStartTime.Size = new System.Drawing.Size(182, 23);
            this.lblFuellingStartTime.TabIndex = 12;
            this.lblFuellingStartTime.Text = "Fuelling Start Time :";
            // 
            // lblEquipementNo
            // 
            this.lblEquipementNo.AutoSize = true;
            this.lblEquipementNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipementNo.Location = new System.Drawing.Point(-4, 12);
            this.lblEquipementNo.Name = "lblEquipementNo";
            this.lblEquipementNo.Size = new System.Drawing.Size(152, 23);
            this.lblEquipementNo.TabIndex = 10;
            this.lblEquipementNo.Text = "Equipement No :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(285, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(195, 33);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Circulation Test";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFinalClearance);
            this.groupBox1.Controls.Add(this.lblPleaseWait);
            this.groupBox1.Controls.Add(this.btnYes);
            this.groupBox1.Location = new System.Drawing.Point(14, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 75);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lblFinalClearance
            // 
            this.lblFinalClearance.AutoSize = true;
            this.lblFinalClearance.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalClearance.ForeColor = System.Drawing.Color.Navy;
            this.lblFinalClearance.Location = new System.Drawing.Point(164, 47);
            this.lblFinalClearance.Name = "lblFinalClearance";
            this.lblFinalClearance.Size = new System.Drawing.Size(258, 25);
            this.lblFinalClearance.TabIndex = 14;
            this.lblFinalClearance.Text = "                  Final Clearance";
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPleaseWait.ForeColor = System.Drawing.Color.Navy;
            this.lblPleaseWait.Location = new System.Drawing.Point(75, 6);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(449, 25);
            this.lblPleaseWait.TabIndex = 0;
            this.lblPleaseWait.Text = "Processing Transaction ........... Please Wait ........";
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnYes.Location = new System.Drawing.Point(530, 19);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(74, 50);
            this.btnYes.TabIndex = 6;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmCirculationTestFlowMeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 546);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCirculationTestFlowMeter";
            this.Text = "Circulation Test FlowMeter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCirculationTestFlowMeter_FormClosing);
            this.Load += new System.EventHandler(this.FrmCirculationTestFlowMeter_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFuellingEndTime;
        private System.Windows.Forms.TextBox txtMeterEndReading;
        private System.Windows.Forms.TextBox txtQtyCirculated;
        private System.Windows.Forms.Label lblFuellingEndTime;
        private System.Windows.Forms.Label lblMeterEndReading;
        private System.Windows.Forms.Label lblQtyCirculated;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtFuellingStartTime;
        private System.Windows.Forms.TextBox txtMeterStartReading;
        private System.Windows.Forms.TextBox txtEquipementNo;
        private System.Windows.Forms.Label lblFuellingStartTime;
        private System.Windows.Forms.Label lblMeterStartReading;
        private System.Windows.Forms.Label lblEquipementNo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label lblPleaseWait;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblFinalClearance;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label lblTodayDate;
    }
}