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
    public partial class MasterForm : Form
    {
        string FormID = string.Empty;
        public MasterForm()
        {
            InitializeComponent();
        }
        public MasterForm(string id)    // this constructor will be called from child page  
        {
            this.FormID = id;
            InitializeComponent();
        }
    }
}
