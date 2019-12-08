using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSApplication
{
    public static class ErrorMessage
    {
        public static void DisplayMessage(string str)
        {
            MessageBox.Show(str, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }
        public static void InformationMessage(string str)
        {
            MessageBox.Show(str, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ConfirmationMessage(string str)
        {
            MessageBox.Show(str, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static void WarningMessage(string str)
        {
            MessageBox.Show(str, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
