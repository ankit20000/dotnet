using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSApplication.Forms
{
    public partial class FrmStockTransfer : MasterForm
    {
        private FrmRefuellerToRefueller frmRefuellerToRefueller;
        private FrmRefuellerToTank frmRefuellerToTank;
        public FrmStockTransfer()
        {
            InitializeComponent();
        }
        private void FrmStockTransfer_Load(object sender, EventArgs e)
        {

        }
        private void btnRefuellerToRefueller_Click(object sender, EventArgs e)
        {
            GlobalVariable.StockTransferType = Constants.RefuellerToRefueller;
            frmRefuellerToRefueller = new FrmRefuellerToRefueller();
            frmRefuellerToRefueller.Show();
        }

        private void btnRefuellerToTank_Click(object sender, EventArgs e)
        {
            GlobalVariable.StockTransferType = Constants.RefuellerToTank;
            frmRefuellerToTank = new FrmRefuellerToTank();
            frmRefuellerToTank.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
