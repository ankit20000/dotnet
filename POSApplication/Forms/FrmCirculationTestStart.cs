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
    public partial class FrmCirculationTestStart : MasterForm
    {
        private FrmCirculationTestFlowMeter frmCirculationTestFlowMeter;
        public FrmCirculationTestStart() : base("FrmCirculationTestStart")
        {
            InitializeComponent();
        }

        private void FrmCirculationTestStart_Load(object sender, EventArgs e)
        {

        }

        private void btnCirculationTest_Click(object sender, EventArgs e)
        {
            var container = DependencyInjector.Register();
            frmCirculationTestFlowMeter = container.Resolve<FrmCirculationTestFlowMeter>();            
            frmCirculationTestFlowMeter.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
