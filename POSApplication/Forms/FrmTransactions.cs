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
    public partial class FrmTransactions : MasterForm
    {
        FrmDailyAvailableFlights frmDailyAvailableFlights;
        FrmStockTransfer frmStockTransfer;
        FrmCirculationTest frmCirculationTest;
        FrmFuelEntryParameter frmFuelEntryParameter;
        FrmExportData frmExportData;
        FrmImportData frmImportData;
        FrmADRPrint frmADRPrint;
        public FrmTransactions()
        {
            InitializeComponent();
        }
        private void btnFuellingTransactions_Click_1(object sender, EventArgs e)
        {
            var container = DependencyInjector.Register();
            frmDailyAvailableFlights = container.Resolve<FrmDailyAvailableFlights>();
            frmDailyAvailableFlights.Show();
        }
        private void btnStockTransfer_Click_1(object sender, EventArgs e)
        {
            frmStockTransfer = new FrmStockTransfer();
            frmStockTransfer.ShowDialog();
        }
        private void btnFuelParameter_Click(object sender, EventArgs e)
        {
            var container = DependencyInjector.Register();
            frmFuelEntryParameter = container.Resolve<FrmFuelEntryParameter>();
            frmFuelEntryParameter.Show();
        }
        private void btnCirculationTest_Click_1(object sender, EventArgs e)
        {
            var container = DependencyInjector.Register();
            frmCirculationTest = container.Resolve<FrmCirculationTest>();
            frmCirculationTest.Show();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            var container = DependencyInjector.Register();
            frmExportData = container.Resolve<FrmExportData>();
            frmExportData.Show();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            var container = DependencyInjector.Register();
            frmImportData = container.Resolve<FrmImportData>();
            frmImportData.Show();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            var container = DependencyInjector.Register();
            frmADRPrint = container.Resolve<FrmADRPrint>();
            frmADRPrint.Show();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
                f.Close();
        }       
    }
}
