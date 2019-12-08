namespace POSApplication.Forms
{
    partial class FrmFuelTransaction
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnKeypad = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStartFuelling = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtProceedingTo = new System.Windows.Forms.TextBox();
            this.txtArrivingFrom = new System.Windows.Forms.TextBox();
            this.lblArrivingFrom = new System.Windows.Forms.Label();
            this.lblProceedingTo = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdoBelow40T = new System.Windows.Forms.RadioButton();
            this.chkTurboProp = new System.Windows.Forms.CheckBox();
            this.rdoAbove40T = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.cmbSupplierCode = new System.Windows.Forms.ComboBox();
            this.txtHydrantPitNo = new System.Windows.Forms.TextBox();
            this.lblHydrantPitNo = new System.Windows.Forms.Label();
            this.lblActivity1 = new System.Windows.Forms.Label();
            this.cmbActivity = new System.Windows.Forms.ComboBox();
            this.txtBayNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAircraftType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRegistrationNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoDutyPaid = new System.Windows.Forms.RadioButton();
            this.rdoBonded = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoInternational = new System.Windows.Forms.RadioButton();
            this.rdoDomestic = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtShipTo = new System.Windows.Forms.TextBox();
            this.lblShipTo = new System.Windows.Forms.Label();
            this.txtBillTo = new System.Windows.Forms.TextBox();
            this.lblBillTo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFlightNo = new System.Windows.Forms.ComboBox();
            this.cmbAirlineCode = new System.Windows.Forms.ComboBox();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.lblFlightNo = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 555);
            this.panel1.TabIndex = 0;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrentDate.Location = new System.Drawing.Point(730, 13);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(44, 21);
            this.lblCurrentDate.TabIndex = 15;
            this.lblCurrentDate.Text = "Date";
            // 
            // lblTodayDate
            // 
            this.lblTodayDate.AutoSize = true;
            this.lblTodayDate.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayDate.ForeColor = System.Drawing.Color.Navy;
            this.lblTodayDate.Location = new System.Drawing.Point(672, 13);
            this.lblTodayDate.Name = "lblTodayDate";
            this.lblTodayDate.Size = new System.Drawing.Size(53, 21);
            this.lblTodayDate.TabIndex = 14;
            this.lblTodayDate.Text = "Date :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(295, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(257, 33);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Fuelling Transactions";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnKeypad);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnStartFuelling);
            this.panel2.Location = new System.Drawing.Point(9, 490);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 60);
            this.panel2.TabIndex = 12;
            // 
            // btnKeypad
            // 
            this.btnKeypad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnKeypad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKeypad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnKeypad.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeypad.ForeColor = System.Drawing.Color.White;
            this.btnKeypad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKeypad.Location = new System.Drawing.Point(351, 5);
            this.btnKeypad.Name = "btnKeypad";
            this.btnKeypad.Size = new System.Drawing.Size(120, 50);
            this.btnKeypad.TabIndex = 23;
            this.btnKeypad.Text = "Keypad";
            this.btnKeypad.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(147)))));
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(518, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 50);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStartFuelling
            // 
            this.btnStartFuelling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnStartFuelling.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartFuelling.ForeColor = System.Drawing.Color.White;
            this.btnStartFuelling.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartFuelling.Location = new System.Drawing.Point(140, 5);
            this.btnStartFuelling.Name = "btnStartFuelling";
            this.btnStartFuelling.Size = new System.Drawing.Size(163, 50);
            this.btnStartFuelling.TabIndex = 22;
            this.btnStartFuelling.Text = "Start Fuelling";
            this.btnStartFuelling.UseVisualStyleBackColor = false;
            this.btnStartFuelling.Click += new System.EventHandler(this.btnStartFuelling_Click_1);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtProceedingTo);
            this.groupBox7.Controls.Add(this.txtArrivingFrom);
            this.groupBox7.Controls.Add(this.lblArrivingFrom);
            this.groupBox7.Controls.Add(this.lblProceedingTo);
            this.groupBox7.Location = new System.Drawing.Point(512, 315);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(443, 103);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            // 
            // txtProceedingTo
            // 
            this.txtProceedingTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProceedingTo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProceedingTo.Location = new System.Drawing.Point(151, 61);
            this.txtProceedingTo.MaxLength = 25;
            this.txtProceedingTo.Name = "txtProceedingTo";
            this.txtProceedingTo.Size = new System.Drawing.Size(292, 32);
            this.txtProceedingTo.TabIndex = 20;
            // 
            // txtArrivingFrom
            // 
            this.txtArrivingFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArrivingFrom.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArrivingFrom.Location = new System.Drawing.Point(151, 12);
            this.txtArrivingFrom.MaxLength = 25;
            this.txtArrivingFrom.Name = "txtArrivingFrom";
            this.txtArrivingFrom.Size = new System.Drawing.Size(292, 32);
            this.txtArrivingFrom.TabIndex = 18;
            // 
            // lblArrivingFrom
            // 
            this.lblArrivingFrom.AutoSize = true;
            this.lblArrivingFrom.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivingFrom.Location = new System.Drawing.Point(0, 17);
            this.lblArrivingFrom.Name = "lblArrivingFrom";
            this.lblArrivingFrom.Size = new System.Drawing.Size(149, 25);
            this.lblArrivingFrom.TabIndex = 12;
            this.lblArrivingFrom.Text = "Arriving From :";
            // 
            // lblProceedingTo
            // 
            this.lblProceedingTo.AutoSize = true;
            this.lblProceedingTo.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProceedingTo.Location = new System.Drawing.Point(1, 66);
            this.lblProceedingTo.Name = "lblProceedingTo";
            this.lblProceedingTo.Size = new System.Drawing.Size(150, 25);
            this.lblProceedingTo.TabIndex = 13;
            this.lblProceedingTo.Text = "Proceeding To :";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdoBelow40T);
            this.groupBox6.Controls.Add(this.chkTurboProp);
            this.groupBox6.Controls.Add(this.rdoAbove40T);
            this.groupBox6.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.Blue;
            this.groupBox6.Location = new System.Drawing.Point(512, 232);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(443, 68);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Aircraft Turbo Prop Indicator And Weight";
            // 
            // rdoBelow40T
            // 
            this.rdoBelow40T.AutoSize = true;
            this.rdoBelow40T.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBelow40T.ForeColor = System.Drawing.Color.Black;
            this.rdoBelow40T.Location = new System.Drawing.Point(294, 33);
            this.rdoBelow40T.Name = "rdoBelow40T";
            this.rdoBelow40T.Size = new System.Drawing.Size(134, 29);
            this.rdoBelow40T.TabIndex = 15;
            this.rdoBelow40T.TabStop = true;
            this.rdoBelow40T.Text = "Below 40 T";
            this.rdoBelow40T.UseVisualStyleBackColor = true;
            // 
            // chkTurboProp
            // 
            this.chkTurboProp.AutoSize = true;
            this.chkTurboProp.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTurboProp.ForeColor = System.Drawing.Color.Black;
            this.chkTurboProp.Location = new System.Drawing.Point(9, 35);
            this.chkTurboProp.Name = "chkTurboProp";
            this.chkTurboProp.Size = new System.Drawing.Size(131, 29);
            this.chkTurboProp.TabIndex = 13;
            this.chkTurboProp.Text = "Turbo Prop";
            this.chkTurboProp.UseVisualStyleBackColor = true;
            // 
            // rdoAbove40T
            // 
            this.rdoAbove40T.AutoSize = true;
            this.rdoAbove40T.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAbove40T.ForeColor = System.Drawing.Color.Black;
            this.rdoAbove40T.Location = new System.Drawing.Point(151, 35);
            this.rdoAbove40T.Name = "rdoAbove40T";
            this.rdoAbove40T.Size = new System.Drawing.Size(137, 29);
            this.rdoAbove40T.TabIndex = 14;
            this.rdoAbove40T.TabStop = true;
            this.rdoAbove40T.Text = "Above 40 T";
            this.rdoAbove40T.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblSupplierCode);
            this.groupBox5.Controls.Add(this.cmbSupplierCode);
            this.groupBox5.Controls.Add(this.txtHydrantPitNo);
            this.groupBox5.Controls.Add(this.lblHydrantPitNo);
            this.groupBox5.Controls.Add(this.lblActivity1);
            this.groupBox5.Controls.Add(this.cmbActivity);
            this.groupBox5.Controls.Add(this.txtBayNo);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtAircraftType);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtRegistrationNo);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.btnRegistration);
            this.groupBox5.Location = new System.Drawing.Point(9, 217);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(497, 267);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierCode.Location = new System.Drawing.Point(6, 8);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(140, 23);
            this.lblSupplierCode.TabIndex = 20;
            this.lblSupplierCode.Text = "Supplier Code :";
            // 
            // cmbSupplierCode
            // 
            this.cmbSupplierCode.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplierCode.FormattingEnabled = true;
            this.cmbSupplierCode.Location = new System.Drawing.Point(157, 5);
            this.cmbSupplierCode.MaxLength = 50;
            this.cmbSupplierCode.Name = "cmbSupplierCode";
            this.cmbSupplierCode.Size = new System.Drawing.Size(340, 31);
            this.cmbSupplierCode.TabIndex = 10;
            // 
            // txtHydrantPitNo
            // 
            this.txtHydrantPitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHydrantPitNo.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHydrantPitNo.Location = new System.Drawing.Point(153, 189);
            this.txtHydrantPitNo.MaxLength = 25;
            this.txtHydrantPitNo.Name = "txtHydrantPitNo";
            this.txtHydrantPitNo.Size = new System.Drawing.Size(344, 32);
            this.txtHydrantPitNo.TabIndex = 19;
            // 
            // lblHydrantPitNo
            // 
            this.lblHydrantPitNo.AutoSize = true;
            this.lblHydrantPitNo.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHydrantPitNo.Location = new System.Drawing.Point(2, 191);
            this.lblHydrantPitNo.Name = "lblHydrantPitNo";
            this.lblHydrantPitNo.Size = new System.Drawing.Size(157, 25);
            this.lblHydrantPitNo.TabIndex = 17;
            this.lblHydrantPitNo.Text = "Hydrant Pit No :";
            // 
            // lblActivity1
            // 
            this.lblActivity1.AutoSize = true;
            this.lblActivity1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivity1.Location = new System.Drawing.Point(2, 236);
            this.lblActivity1.Name = "lblActivity1";
            this.lblActivity1.Size = new System.Drawing.Size(96, 25);
            this.lblActivity1.TabIndex = 16;
            this.lblActivity1.Text = "Activity :";
            // 
            // cmbActivity
            // 
            this.cmbActivity.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbActivity.FormattingEnabled = true;
            this.cmbActivity.Location = new System.Drawing.Point(153, 233);
            this.cmbActivity.MaxLength = 50;
            this.cmbActivity.Name = "cmbActivity";
            this.cmbActivity.Size = new System.Drawing.Size(344, 31);
            this.cmbActivity.TabIndex = 21;
            this.cmbActivity.SelectedIndexChanged += new System.EventHandler(this.cmbActivity_SelectedIndexChanged);
            // 
            // txtBayNo
            // 
            this.txtBayNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBayNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBayNo.Location = new System.Drawing.Point(153, 140);
            this.txtBayNo.MaxLength = 25;
            this.txtBayNo.Name = "txtBayNo";
            this.txtBayNo.Size = new System.Drawing.Size(344, 32);
            this.txtBayNo.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Bay No. :";
            // 
            // txtAircraftType
            // 
            this.txtAircraftType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAircraftType.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAircraftType.Location = new System.Drawing.Point(154, 98);
            this.txtAircraftType.MaxLength = 20;
            this.txtAircraftType.Name = "txtAircraftType";
            this.txtAircraftType.Size = new System.Drawing.Size(344, 32);
            this.txtAircraftType.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Aircraft Type :";
            // 
            // txtRegistrationNo
            // 
            this.txtRegistrationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegistrationNo.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistrationNo.Location = new System.Drawing.Point(170, 51);
            this.txtRegistrationNo.MaxLength = 10;
            this.txtRegistrationNo.Name = "txtRegistrationNo";
            this.txtRegistrationNo.Size = new System.Drawing.Size(153, 32);
            this.txtRegistrationNo.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Registration No:";
            // 
            // btnRegistration
            // 
            this.btnRegistration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnRegistration.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistration.ForeColor = System.Drawing.Color.White;
            this.btnRegistration.Location = new System.Drawing.Point(330, 48);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(168, 40);
            this.btnRegistration.TabIndex = 12;
            this.btnRegistration.Text = "Select Reg. No";
            this.btnRegistration.UseVisualStyleBackColor = false;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoDutyPaid);
            this.groupBox4.Controls.Add(this.rdoBonded);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(512, 156);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(443, 57);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Product Type";
            // 
            // rdoDutyPaid
            // 
            this.rdoDutyPaid.AutoSize = true;
            this.rdoDutyPaid.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDutyPaid.ForeColor = System.Drawing.Color.Black;
            this.rdoDutyPaid.Location = new System.Drawing.Point(236, 25);
            this.rdoDutyPaid.Name = "rdoDutyPaid";
            this.rdoDutyPaid.Size = new System.Drawing.Size(119, 29);
            this.rdoDutyPaid.TabIndex = 9;
            this.rdoDutyPaid.TabStop = true;
            this.rdoDutyPaid.Text = "Duty Paid";
            this.rdoDutyPaid.UseVisualStyleBackColor = true;
            this.rdoDutyPaid.CheckedChanged += new System.EventHandler(this.rdoDutyPaid_CheckedChanged);
            // 
            // rdoBonded
            // 
            this.rdoBonded.AutoSize = true;
            this.rdoBonded.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBonded.ForeColor = System.Drawing.Color.Black;
            this.rdoBonded.Location = new System.Drawing.Point(74, 25);
            this.rdoBonded.Name = "rdoBonded";
            this.rdoBonded.Size = new System.Drawing.Size(97, 29);
            this.rdoBonded.TabIndex = 8;
            this.rdoBonded.TabStop = true;
            this.rdoBonded.Text = "Bonded";
            this.rdoBonded.UseVisualStyleBackColor = true;
            this.rdoBonded.CheckedChanged += new System.EventHandler(this.rdoBonded_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoInternational);
            this.groupBox3.Controls.Add(this.rdoDomestic);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(9, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(497, 68);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Flight Type";
            // 
            // rdoInternational
            // 
            this.rdoInternational.AutoSize = true;
            this.rdoInternational.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoInternational.ForeColor = System.Drawing.Color.Black;
            this.rdoInternational.Location = new System.Drawing.Point(247, 31);
            this.rdoInternational.Name = "rdoInternational";
            this.rdoInternational.Size = new System.Drawing.Size(138, 29);
            this.rdoInternational.TabIndex = 7;
            this.rdoInternational.TabStop = true;
            this.rdoInternational.Text = "International";
            this.rdoInternational.UseVisualStyleBackColor = true;
            // 
            // rdoDomestic
            // 
            this.rdoDomestic.AutoSize = true;
            this.rdoDomestic.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDomestic.ForeColor = System.Drawing.Color.Black;
            this.rdoDomestic.Location = new System.Drawing.Point(98, 33);
            this.rdoDomestic.Name = "rdoDomestic";
            this.rdoDomestic.Size = new System.Drawing.Size(114, 29);
            this.rdoDomestic.TabIndex = 6;
            this.rdoDomestic.TabStop = true;
            this.rdoDomestic.Text = "Domestic";
            this.rdoDomestic.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtShipTo);
            this.groupBox2.Controls.Add(this.lblShipTo);
            this.groupBox2.Controls.Add(this.txtBillTo);
            this.groupBox2.Controls.Add(this.lblBillTo);
            this.groupBox2.Location = new System.Drawing.Point(512, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 101);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // txtShipTo
            // 
            this.txtShipTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShipTo.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipTo.Location = new System.Drawing.Point(115, 54);
            this.txtShipTo.MaxLength = 50;
            this.txtShipTo.Name = "txtShipTo";
            this.txtShipTo.Size = new System.Drawing.Size(328, 32);
            this.txtShipTo.TabIndex = 5;
            // 
            // lblShipTo
            // 
            this.lblShipTo.AutoSize = true;
            this.lblShipTo.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipTo.Location = new System.Drawing.Point(2, 55);
            this.lblShipTo.Name = "lblShipTo";
            this.lblShipTo.Size = new System.Drawing.Size(92, 25);
            this.lblShipTo.TabIndex = 4;
            this.lblShipTo.Text = "Ship To :";
            // 
            // txtBillTo
            // 
            this.txtBillTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBillTo.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillTo.Location = new System.Drawing.Point(114, 6);
            this.txtBillTo.MaxLength = 50;
            this.txtBillTo.Name = "txtBillTo";
            this.txtBillTo.Size = new System.Drawing.Size(329, 32);
            this.txtBillTo.TabIndex = 4;
            // 
            // lblBillTo
            // 
            this.lblBillTo.AutoSize = true;
            this.lblBillTo.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillTo.Location = new System.Drawing.Point(1, 7);
            this.lblBillTo.Name = "lblBillTo";
            this.lblBillTo.Size = new System.Drawing.Size(85, 25);
            this.lblBillTo.TabIndex = 3;
            this.lblBillTo.Text = "Bill To :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFlightNo);
            this.groupBox1.Controls.Add(this.cmbAirlineCode);
            this.groupBox1.Controls.Add(this.cmbCustomerName);
            this.groupBox1.Controls.Add(this.lblFlightNo);
            this.groupBox1.Controls.Add(this.lblCustomerName);
            this.groupBox1.Location = new System.Drawing.Point(9, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 86);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cmbFlightNo
            // 
            this.cmbFlightNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFlightNo.FormattingEnabled = true;
            this.cmbFlightNo.Location = new System.Drawing.Point(292, 53);
            this.cmbFlightNo.MaxLength = 10;
            this.cmbFlightNo.Name = "cmbFlightNo";
            this.cmbFlightNo.Size = new System.Drawing.Size(205, 31);
            this.cmbFlightNo.TabIndex = 2;
            this.cmbFlightNo.SelectedIndexChanged += new System.EventHandler(this.cmbFlightNo_SelectedIndexChanged);
            // 
            // cmbAirlineCode
            // 
            this.cmbAirlineCode.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAirlineCode.FormattingEnabled = true;
            this.cmbAirlineCode.Location = new System.Drawing.Point(156, 52);
            this.cmbAirlineCode.MaxLength = 4;
            this.cmbAirlineCode.Name = "cmbAirlineCode";
            this.cmbAirlineCode.Size = new System.Drawing.Size(119, 31);
            this.cmbAirlineCode.TabIndex = 1;
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(157, 8);
            this.cmbCustomerName.MaxLength = 50;
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(340, 31);
            this.cmbCustomerName.TabIndex = 0;
            this.cmbCustomerName.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerName_SelectedIndexChanged);
            // 
            // lblFlightNo
            // 
            this.lblFlightNo.AutoSize = true;
            this.lblFlightNo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightNo.Location = new System.Drawing.Point(5, 53);
            this.lblFlightNo.Name = "lblFlightNo";
            this.lblFlightNo.Size = new System.Drawing.Size(107, 23);
            this.lblFlightNo.TabIndex = 1;
            this.lblFlightNo.Text = "Flight No. :";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(3, 11);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(157, 23);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier Code :";
            // 
            // FrmFuelTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panel1);
            this.Name = "FrmFuelTransaction";
            this.Text = "Fuel Transaction";
            this.Load += new System.EventHandler(this.FrmFuelTransaction_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblShipTo;
        private System.Windows.Forms.Label lblBillTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtShipTo;
        private System.Windows.Forms.TextBox txtBillTo;
        private System.Windows.Forms.Label lblFlightNo;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.ComboBox cmbFlightNo;
        private System.Windows.Forms.ComboBox cmbAirlineCode;
        public System.Windows.Forms.ComboBox cmbCustomerName;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdoBelow40T;
        private System.Windows.Forms.RadioButton rdoAbove40T;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtBayNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAircraftType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRegistrationNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoDutyPaid;
        private System.Windows.Forms.RadioButton rdoBonded;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoInternational;
        private System.Windows.Forms.RadioButton rdoDomestic;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtProceedingTo;
        private System.Windows.Forms.TextBox txtArrivingFrom;
        private System.Windows.Forms.Label lblProceedingTo;
        private System.Windows.Forms.Label lblArrivingFrom;
        private System.Windows.Forms.Label lblActivity1;
        private System.Windows.Forms.ComboBox cmbActivity;
        private System.Windows.Forms.TextBox txtHydrantPitNo;
        private System.Windows.Forms.Label lblHydrantPitNo;
        private System.Windows.Forms.ComboBox cmbSupplierCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStartFuelling;
        private System.Windows.Forms.Button btnKeypad;
        private System.Windows.Forms.CheckBox chkTurboProp;
        private System.Windows.Forms.Label lblSupplierCode;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label lblTodayDate;
    }
}