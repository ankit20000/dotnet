namespace POSApplication.Forms
{
    partial class FrmLCFlowMeter
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFuelBatchNo = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblRangeTemp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.txtFuellingEndTime = new System.Windows.Forms.TextBox();
            this.txtMeterEndReading = new System.Windows.Forms.TextBox();
            this.txtQtyDispensed = new System.Windows.Forms.TextBox();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblFuellingEndTime = new System.Windows.Forms.Label();
            this.lblMeterEndReading = new System.Windows.Forms.Label();
            this.lblQtyDispensed = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRangeDen = new System.Windows.Forms.Label();
            this.txtDensity = new System.Windows.Forms.TextBox();
            this.txtFuellingStartTime = new System.Windows.Forms.TextBox();
            this.txtMeterStartReading = new System.Windows.Forms.TextBox();
            this.txtEquipementNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFuellingStartTime = new System.Windows.Forms.Label();
            this.lblMeterStartReading = new System.Windows.Forms.Label();
            this.lblEquipementNo = new System.Windows.Forms.Label();
            this.txtCurrentTranNo = new System.Windows.Forms.TextBox();
            this.lblCirculationType = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFinalClearance = new System.Windows.Forms.Label();
            this.btnKeypad = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panel1.Location = new System.Drawing.Point(42, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 493);
            this.panel1.TabIndex = 2;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrentDate.Location = new System.Drawing.Point(688, 21);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(44, 21);
            this.lblCurrentDate.TabIndex = 12;
            this.lblCurrentDate.Text = "Date";
            // 
            // lblTodayDate
            // 
            this.lblTodayDate.AutoSize = true;
            this.lblTodayDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayDate.ForeColor = System.Drawing.Color.Navy;
            this.lblTodayDate.Location = new System.Drawing.Point(630, 21);
            this.lblTodayDate.Name = "lblTodayDate";
            this.lblTodayDate.Size = new System.Drawing.Size(53, 21);
            this.lblTodayDate.TabIndex = 11;
            this.lblTodayDate.Text = "Date :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbFuelBatchNo);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtCurrentTranNo);
            this.groupBox2.Controls.Add(this.lblCirculationType);
            this.groupBox2.Location = new System.Drawing.Point(7, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(881, 326);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fuel Batch No :";
            // 
            // cmbFuelBatchNo
            // 
            this.cmbFuelBatchNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFuelBatchNo.FormattingEnabled = true;
            this.cmbFuelBatchNo.Location = new System.Drawing.Point(214, 284);
            this.cmbFuelBatchNo.Name = "cmbFuelBatchNo";
            this.cmbFuelBatchNo.Size = new System.Drawing.Size(667, 31);
            this.cmbFuelBatchNo.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblRangeTemp);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtTemperature);
            this.groupBox4.Controls.Add(this.txtFuellingEndTime);
            this.groupBox4.Controls.Add(this.txtMeterEndReading);
            this.groupBox4.Controls.Add(this.txtQtyDispensed);
            this.groupBox4.Controls.Add(this.lblTemperature);
            this.groupBox4.Controls.Add(this.lblFuellingEndTime);
            this.groupBox4.Controls.Add(this.lblMeterEndReading);
            this.groupBox4.Controls.Add(this.lblQtyDispensed);
            this.groupBox4.Location = new System.Drawing.Point(464, 46);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(417, 232);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // lblRangeTemp
            // 
            this.lblRangeTemp.AutoSize = true;
            this.lblRangeTemp.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRangeTemp.ForeColor = System.Drawing.Color.Red;
            this.lblRangeTemp.Location = new System.Drawing.Point(10, 202);
            this.lblRangeTemp.Name = "lblRangeTemp";
            this.lblRangeTemp.Size = new System.Drawing.Size(147, 23);
            this.lblRangeTemp.TabIndex = 23;
            this.lblRangeTemp.Text = "(Less than 60 C)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ltrs";
            // 
            // txtTemperature
            // 
            this.txtTemperature.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemperature.Location = new System.Drawing.Point(186, 165);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(231, 32);
            this.txtTemperature.TabIndex = 21;
            // 
            // txtFuellingEndTime
            // 
            this.txtFuellingEndTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFuellingEndTime.Location = new System.Drawing.Point(186, 111);
            this.txtFuellingEndTime.Name = "txtFuellingEndTime";
            this.txtFuellingEndTime.Size = new System.Drawing.Size(231, 32);
            this.txtFuellingEndTime.TabIndex = 20;
            // 
            // txtMeterEndReading
            // 
            this.txtMeterEndReading.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeterEndReading.Location = new System.Drawing.Point(188, 59);
            this.txtMeterEndReading.Name = "txtMeterEndReading";
            this.txtMeterEndReading.Size = new System.Drawing.Size(229, 32);
            this.txtMeterEndReading.TabIndex = 19;
            // 
            // txtQtyDispensed
            // 
            this.txtQtyDispensed.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtyDispensed.Location = new System.Drawing.Point(188, 11);
            this.txtQtyDispensed.Name = "txtQtyDispensed";
            this.txtQtyDispensed.Size = new System.Drawing.Size(178, 32);
            this.txtQtyDispensed.TabIndex = 18;
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperature.Location = new System.Drawing.Point(6, 165);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(125, 23);
            this.lblTemperature.TabIndex = 13;
            this.lblTemperature.Text = "Temperature :";
            // 
            // lblFuellingEndTime
            // 
            this.lblFuellingEndTime.AutoSize = true;
            this.lblFuellingEndTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuellingEndTime.Location = new System.Drawing.Point(6, 120);
            this.lblFuellingEndTime.Name = "lblFuellingEndTime";
            this.lblFuellingEndTime.Size = new System.Drawing.Size(176, 23);
            this.lblFuellingEndTime.TabIndex = 12;
            this.lblFuellingEndTime.Text = "Fuelling End Time :";
            // 
            // lblMeterEndReading
            // 
            this.lblMeterEndReading.AutoSize = true;
            this.lblMeterEndReading.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeterEndReading.Location = new System.Drawing.Point(1, 67);
            this.lblMeterEndReading.Name = "lblMeterEndReading";
            this.lblMeterEndReading.Size = new System.Drawing.Size(181, 23);
            this.lblMeterEndReading.TabIndex = 11;
            this.lblMeterEndReading.Text = "Meter End Reading :";
            // 
            // lblQtyDispensed
            // 
            this.lblQtyDispensed.AutoSize = true;
            this.lblQtyDispensed.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyDispensed.Location = new System.Drawing.Point(6, 20);
            this.lblQtyDispensed.Name = "lblQtyDispensed";
            this.lblQtyDispensed.Size = new System.Drawing.Size(141, 23);
            this.lblQtyDispensed.TabIndex = 10;
            this.lblQtyDispensed.Text = "Qty Dispensed :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblRangeDen);
            this.groupBox3.Controls.Add(this.txtDensity);
            this.groupBox3.Controls.Add(this.txtFuellingStartTime);
            this.groupBox3.Controls.Add(this.txtMeterStartReading);
            this.groupBox3.Controls.Add(this.txtEquipementNo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblFuellingStartTime);
            this.groupBox3.Controls.Add(this.lblMeterStartReading);
            this.groupBox3.Controls.Add(this.lblEquipementNo);
            this.groupBox3.Location = new System.Drawing.Point(10, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(448, 235);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // lblRangeDen
            // 
            this.lblRangeDen.AutoSize = true;
            this.lblRangeDen.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRangeDen.ForeColor = System.Drawing.Color.Red;
            this.lblRangeDen.Location = new System.Drawing.Point(3, 192);
            this.lblRangeDen.Name = "lblRangeDen";
            this.lblRangeDen.Size = new System.Drawing.Size(174, 23);
            this.lblRangeDen.TabIndex = 18;
            this.lblRangeDen.Text = "(Between 750-850)";
            // 
            // txtDensity
            // 
            this.txtDensity.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDensity.Location = new System.Drawing.Point(204, 170);
            this.txtDensity.Name = "txtDensity";
            this.txtDensity.Size = new System.Drawing.Size(238, 32);
            this.txtDensity.TabIndex = 17;
            // 
            // txtFuellingStartTime
            // 
            this.txtFuellingStartTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFuellingStartTime.Location = new System.Drawing.Point(204, 119);
            this.txtFuellingStartTime.Name = "txtFuellingStartTime";
            this.txtFuellingStartTime.Size = new System.Drawing.Size(238, 32);
            this.txtFuellingStartTime.TabIndex = 16;
            // 
            // txtMeterStartReading
            // 
            this.txtMeterStartReading.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeterStartReading.Location = new System.Drawing.Point(204, 67);
            this.txtMeterStartReading.Name = "txtMeterStartReading";
            this.txtMeterStartReading.Size = new System.Drawing.Size(238, 32);
            this.txtMeterStartReading.TabIndex = 15;
            // 
            // txtEquipementNo
            // 
            this.txtEquipementNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipementNo.Location = new System.Drawing.Point(204, 14);
            this.txtEquipementNo.Name = "txtEquipementNo";
            this.txtEquipementNo.Size = new System.Drawing.Size(238, 32);
            this.txtEquipementNo.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Density (kg/m3) :";
            // 
            // lblFuellingStartTime
            // 
            this.lblFuellingStartTime.AutoSize = true;
            this.lblFuellingStartTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuellingStartTime.Location = new System.Drawing.Point(3, 123);
            this.lblFuellingStartTime.Name = "lblFuellingStartTime";
            this.lblFuellingStartTime.Size = new System.Drawing.Size(182, 23);
            this.lblFuellingStartTime.TabIndex = 12;
            this.lblFuellingStartTime.Text = "Fuelling Start Time :";
            // 
            // lblMeterStartReading
            // 
            this.lblMeterStartReading.AutoSize = true;
            this.lblMeterStartReading.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeterStartReading.Location = new System.Drawing.Point(3, 76);
            this.lblMeterStartReading.Name = "lblMeterStartReading";
            this.lblMeterStartReading.Size = new System.Drawing.Size(187, 23);
            this.lblMeterStartReading.TabIndex = 11;
            this.lblMeterStartReading.Text = "Meter Start Reading :";
            // 
            // lblEquipementNo
            // 
            this.lblEquipementNo.AutoSize = true;
            this.lblEquipementNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipementNo.Location = new System.Drawing.Point(3, 23);
            this.lblEquipementNo.Name = "lblEquipementNo";
            this.lblEquipementNo.Size = new System.Drawing.Size(152, 23);
            this.lblEquipementNo.TabIndex = 10;
            this.lblEquipementNo.Text = "Equipement No :";
            // 
            // txtCurrentTranNo
            // 
            this.txtCurrentTranNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentTranNo.Location = new System.Drawing.Point(236, 8);
            this.txtCurrentTranNo.Name = "txtCurrentTranNo";
            this.txtCurrentTranNo.Size = new System.Drawing.Size(648, 32);
            this.txtCurrentTranNo.TabIndex = 6;
            // 
            // lblCirculationType
            // 
            this.lblCirculationType.AutoSize = true;
            this.lblCirculationType.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCirculationType.Location = new System.Drawing.Point(13, 17);
            this.lblCirculationType.Name = "lblCirculationType";
            this.lblCirculationType.Size = new System.Drawing.Size(217, 23);
            this.lblCirculationType.TabIndex = 0;
            this.lblCirculationType.Text = "Current Transaction No :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(310, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(192, 33);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "LC Flow Meter";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFinalClearance);
            this.groupBox1.Controls.Add(this.btnKeypad);
            this.groupBox1.Controls.Add(this.btnYes);
            this.groupBox1.Controls.Add(this.lblPleaseWait);
            this.groupBox1.Location = new System.Drawing.Point(7, 405);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(881, 74);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lblFinalClearance
            // 
            this.lblFinalClearance.AutoSize = true;
            this.lblFinalClearance.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalClearance.ForeColor = System.Drawing.Color.Navy;
            this.lblFinalClearance.Location = new System.Drawing.Point(35, 31);
            this.lblFinalClearance.Name = "lblFinalClearance";
            this.lblFinalClearance.Size = new System.Drawing.Size(258, 25);
            this.lblFinalClearance.TabIndex = 13;
            this.lblFinalClearance.Text = "                  Final Clearance";
            // 
            // btnKeypad
            // 
            this.btnKeypad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnKeypad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKeypad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnKeypad.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeypad.ForeColor = System.Drawing.Color.White;
            this.btnKeypad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKeypad.Location = new System.Drawing.Point(604, 9);
            this.btnKeypad.Name = "btnKeypad";
            this.btnKeypad.Size = new System.Drawing.Size(102, 50);
            this.btnKeypad.TabIndex = 12;
            this.btnKeypad.Text = "Keypad";
            this.btnKeypad.UseVisualStyleBackColor = false;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnYes.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnYes.Location = new System.Drawing.Point(490, 9);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(83, 50);
            this.btnYes.TabIndex = 11;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPleaseWait.ForeColor = System.Drawing.Color.Navy;
            this.lblPleaseWait.Location = new System.Drawing.Point(35, 0);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(449, 25);
            this.lblPleaseWait.TabIndex = 0;
            this.lblPleaseWait.Text = "Processing Transaction ........... Please Wait ........";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fuel Batch No :";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmLCFlowMeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panel1);
            this.Name = "FrmLCFlowMeter";
            this.Text = "LC Flow Meter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLCFlowMeter_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLCFlowMeter_FormClosed);
            this.Load += new System.EventHandler(this.FrmLCFlowMeter_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCirculationType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCurrentTranNo;
        private System.Windows.Forms.ComboBox cmbFuelBatchNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblRangeTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.TextBox txtFuellingEndTime;
        private System.Windows.Forms.TextBox txtMeterEndReading;
        private System.Windows.Forms.TextBox txtQtyDispensed;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblFuellingEndTime;
        private System.Windows.Forms.Label lblMeterEndReading;
        private System.Windows.Forms.Label lblQtyDispensed;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblRangeDen;
        private System.Windows.Forms.TextBox txtDensity;
        private System.Windows.Forms.TextBox txtFuellingStartTime;
        private System.Windows.Forms.TextBox txtMeterStartReading;
        private System.Windows.Forms.TextBox txtEquipementNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFuellingStartTime;
        private System.Windows.Forms.Label lblMeterStartReading;
        private System.Windows.Forms.Label lblEquipementNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label lblPleaseWait;
        private System.Windows.Forms.Button btnKeypad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblFinalClearance;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label lblTodayDate;
    }
}