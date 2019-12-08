using BusinessEntityLayer;
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
using Unity;

namespace POSApplication.Forms
{
    public delegate void SendTransactionInfo(Transactions transactions);
    public partial class FrmStart : MasterForm
    {
        private FrmLCFlowMeter frmLCFlowMeter;
        byte result = 0;
        public FrmStart() : base("FrmStart")
        {
            InitializeComponent();
        }
        public Transactions transactions { get; set; }
        private void FrmStart_Load(object sender, EventArgs e)
        {
            if (GlobalVariable.fuel_trans_type == "FT")
                lblTransactionType.Text = "Fuelling ?";
            else if (GlobalVariable.fuel_trans_type == "DF")
                lblTransactionType.Text = "Defuelling ?";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Close();
            var container = DependencyInjector.Register();
            frmLCFlowMeter = container.Resolve<FrmLCFlowMeter>();

            if (transactions != null)
            {
                SendTransactionInfo del = new SendTransactionInfo(frmLCFlowMeter.AssignTransactionInfo);
                del(transactions);
            }
            frmLCFlowMeter.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            result = LCMeterLibrary.LCP02Close();
            this.Close();
        }
    }
}
