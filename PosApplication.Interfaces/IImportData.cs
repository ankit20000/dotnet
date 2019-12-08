using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApplication.Interfaces
{
    public interface IImportData
    {
        DataTable GetMasterTables();
        string ImportMasterTables(List<string> lstTableNames);
    }
}
