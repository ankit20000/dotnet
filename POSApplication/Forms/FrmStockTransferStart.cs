using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntityLayer;
using Common;
using Unity;

namespace POSApplication.Forms
{
    public delegate void PassStockTransfer(StockTransfer stockTransfer);
    public partial class FrmStockTransferStart : MasterForm
    {
        private FrmStockTransferLCMeter frmStockTransferLCMeter;
        public FrmStockTransferStart() :base("FrmStockTransferStart")
        {
            InitializeComponent();
        }
        public StockTransfer stockTransfer { get; set; }
        private void FrmStockTransferStart_Load(object sender, EventArgs e)
        {
                     
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Close();
            var container = DependencyInjector.Register();
            frmStockTransferLCMeter = container.Resolve<FrmStockTransferLCMeter>();
            if (stockTransfer != null)
            {
                PassStockTransfer del = new PassStockTransfer(frmStockTransferLCMeter.AssignStockTransfer);
                del(stockTransfer);
            }
            frmStockTransferLCMeter.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            LCMeterLibrary.LCP02Close();
            this.Close();
        }
    }
}
