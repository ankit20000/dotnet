namespace POSApplication.Forms
{
    partial class FrmDailyAvailableFlights 
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.lblTodayDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNewFlight = new System.Windows.Forms.Button();
            this.btnOtherSchedules = new System.Windows.Forms.Button();
            this.btnOperatorSchedules = new System.Windows.Forms.Button();
            this.btnProcessFuelling = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
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
            this.panel1.Controls.Add(this.dataGrid);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(49, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 496);
            this.panel1.TabIndex = 0;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrentDate.Location = new System.Drawing.Point(693, 18);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(49, 23);
            this.lblCurrentDate.TabIndex = 4;
            this.lblCurrentDate.Text = "Date";
            // 
            // lblTodayDate
            // 
            this.lblTodayDate.AutoSize = true;
            this.lblTodayDate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayDate.ForeColor = System.Drawing.Color.Navy;
            this.lblTodayDate.Location = new System.Drawing.Point(635, 18);
            this.lblTodayDate.Name = "lblTodayDate";
            this.lblTodayDate.Size = new System.Drawing.Size(60, 23);
            this.lblTodayDate.TabIndex = 3;
            this.lblTodayDate.Text = "Date :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(257, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 33);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Scheduled Flights Today ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnNewFlight);
            this.panel2.Controls.Add(this.btnOtherSchedules);
            this.panel2.Controls.Add(this.btnOperatorSchedules);
            this.panel2.Controls.Add(this.btnProcessFuelling);
            this.panel2.Location = new System.Drawing.Point(3, 419);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(886, 72);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(147)))));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(773, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 50);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNewFlight
            // 
            this.btnNewFlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnNewFlight.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewFlight.ForeColor = System.Drawing.Color.White;
            this.btnNewFlight.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewFlight.Location = new System.Drawing.Point(614, 7);
            this.btnNewFlight.Name = "btnNewFlight";
            this.btnNewFlight.Size = new System.Drawing.Size(137, 50);
            this.btnNewFlight.TabIndex = 4;
            this.btnNewFlight.Text = "New Flight";
            this.btnNewFlight.UseVisualStyleBackColor = false;
            this.btnNewFlight.Click += new System.EventHandler(this.btnNewFlight_Click_1);
            // 
            // btnOtherSchedules
            // 
            this.btnOtherSchedules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnOtherSchedules.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtherSchedules.ForeColor = System.Drawing.Color.White;
            this.btnOtherSchedules.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOtherSchedules.Location = new System.Drawing.Point(419, 7);
            this.btnOtherSchedules.Name = "btnOtherSchedules";
            this.btnOtherSchedules.Size = new System.Drawing.Size(179, 50);
            this.btnOtherSchedules.TabIndex = 3;
            this.btnOtherSchedules.Text = "Other\'s Schedules";
            this.btnOtherSchedules.UseVisualStyleBackColor = false;
            this.btnOtherSchedules.Click += new System.EventHandler(this.btnOtherSchedules_Click);
            // 
            // btnOperatorSchedules
            // 
            this.btnOperatorSchedules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnOperatorSchedules.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperatorSchedules.ForeColor = System.Drawing.Color.White;
            this.btnOperatorSchedules.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOperatorSchedules.Location = new System.Drawing.Point(199, 7);
            this.btnOperatorSchedules.Name = "btnOperatorSchedules";
            this.btnOperatorSchedules.Size = new System.Drawing.Size(205, 50);
            this.btnOperatorSchedules.TabIndex = 2;
            this.btnOperatorSchedules.Text = "Operator Schedules";
            this.btnOperatorSchedules.UseVisualStyleBackColor = false;
            this.btnOperatorSchedules.Click += new System.EventHandler(this.btnOperatorSchedules_Click_1);
            // 
            // btnProcessFuelling
            // 
            this.btnProcessFuelling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnProcessFuelling.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessFuelling.ForeColor = System.Drawing.Color.White;
            this.btnProcessFuelling.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcessFuelling.Location = new System.Drawing.Point(3, 7);
            this.btnProcessFuelling.Name = "btnProcessFuelling";
            this.btnProcessFuelling.Size = new System.Drawing.Size(177, 50);
            this.btnProcessFuelling.TabIndex = 1;
            this.btnProcessFuelling.Text = "Process Fuelling";
            this.btnProcessFuelling.UseVisualStyleBackColor = false;
            this.btnProcessFuelling.Click += new System.EventHandler(this.btnProcessFuelling_Click_1);
            // 
            // dataGrid
            // 
            this.dataGrid.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(4, 53);
            this.dataGrid.Name = "dataGrid";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.Size = new System.Drawing.Size(886, 360);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick_1);
            this.dataGrid.Click += new System.EventHandler(this.dataGrid_Click_1);
            // 
            // FrmDailyAvailableFlights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDailyAvailableFlights";
            this.Text = "Scheduled Flights Today ";
            this.Load += new System.EventHandler(this.FrmDailyAvailableFlights_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNewFlight;
        private System.Windows.Forms.Button btnOtherSchedules;
        private System.Windows.Forms.Button btnOperatorSchedules;
        private System.Windows.Forms.Button btnProcessFuelling;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label lblTodayDate;
    }
}