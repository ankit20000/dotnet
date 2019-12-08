namespace POSApplication.Forms
{
    partial class FrmTransactions
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
            this.btnFuelParameter = new System.Windows.Forms.Button();
            this.btnFuellingTransactions = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnCirculationTest = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btnStockTransfer = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
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
            this.panel1.Location = new System.Drawing.Point(192, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 554);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(199, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(157, 33);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Transactions";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFuelParameter);
            this.groupBox1.Controls.Add(this.btnFuellingTransactions);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.btnCirculationTest);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.btnStockTransfer);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Location = new System.Drawing.Point(7, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 500);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnFuelParameter
            // 
            this.btnFuelParameter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnFuelParameter.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuelParameter.ForeColor = System.Drawing.Color.White;
            this.btnFuelParameter.Location = new System.Drawing.Point(75, 220);
            this.btnFuelParameter.Name = "btnFuelParameter";
            this.btnFuelParameter.Size = new System.Drawing.Size(447, 50);
            this.btnFuelParameter.TabIndex = 6;
            this.btnFuelParameter.Text = "Fuel Parameter Entry";
            this.btnFuelParameter.UseVisualStyleBackColor = false;
            this.btnFuelParameter.Click += new System.EventHandler(this.btnFuelParameter_Click);
            // 
            // btnFuellingTransactions
            // 
            this.btnFuellingTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnFuellingTransactions.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuellingTransactions.ForeColor = System.Drawing.Color.White;
            this.btnFuellingTransactions.Location = new System.Drawing.Point(74, 0);
            this.btnFuellingTransactions.Name = "btnFuellingTransactions";
            this.btnFuellingTransactions.Size = new System.Drawing.Size(446, 50);
            this.btnFuellingTransactions.TabIndex = 3;
            this.btnFuellingTransactions.Text = "Fuelling Transactions";
            this.btnFuellingTransactions.UseVisualStyleBackColor = false;
            this.btnFuellingTransactions.Click += new System.EventHandler(this.btnFuellingTransactions_Click_1);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(147)))));
            this.button10.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(74, 433);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(449, 50);
            this.button10.TabIndex = 10;
            this.button10.Text = "Logout";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // btnCirculationTest
            // 
            this.btnCirculationTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnCirculationTest.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCirculationTest.ForeColor = System.Drawing.Color.White;
            this.btnCirculationTest.Location = new System.Drawing.Point(73, 143);
            this.btnCirculationTest.Name = "btnCirculationTest";
            this.btnCirculationTest.Size = new System.Drawing.Size(447, 50);
            this.btnCirculationTest.TabIndex = 5;
            this.btnCirculationTest.Text = "Circulation Test";
            this.btnCirculationTest.UseVisualStyleBackColor = false;
            this.btnCirculationTest.Click += new System.EventHandler(this.btnCirculationTest_Click_1);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.button9.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(75, 361);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(448, 50);
            this.button9.TabIndex = 9;
            this.button9.Text = "Re-Printing ADR";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnStockTransfer
            // 
            this.btnStockTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnStockTransfer.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockTransfer.ForeColor = System.Drawing.Color.White;
            this.btnStockTransfer.Location = new System.Drawing.Point(74, 73);
            this.btnStockTransfer.Name = "btnStockTransfer";
            this.btnStockTransfer.Size = new System.Drawing.Size(448, 50);
            this.btnStockTransfer.TabIndex = 4;
            this.btnStockTransfer.Text = "Stock Transfer";
            this.btnStockTransfer.UseVisualStyleBackColor = false;
            this.btnStockTransfer.Click += new System.EventHandler(this.btnStockTransfer_Click_1);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnExport.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(75, 291);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(224, 50);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export Data";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(88)))), ((int)(((byte)(159)))));
            this.btnImport.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(296, 291);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(227, 50);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import Data";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FrmTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTransactions";
            this.Text = "Transactions";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFuelParameter;
        private System.Windows.Forms.Button btnFuellingTransactions;
        private System.Windows.Forms.Button btnCirculationTest;
        private System.Windows.Forms.Button btnStockTransfer;
        private System.Windows.Forms.Label lblTitle;
    }
}