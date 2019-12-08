using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Constants
    {
        #region Consatnts

        public static string ErrorMessage = "Error while processing your request!";

        // Meter Types
        public const string LCMeterType = "LIQUID CONTROL";
        public const string ISOILMeterType = "ISOIL";

        // Ciculation Types
        public const string CirculationType = "CIRCULATION";
        public const string NozzelType = "NOZZLE CALIBRATION";

        // Flow Meter Constants
        public const byte minDevice = 1;
        public const byte maxDevice = 1;
        public const byte device = 1;
        public const byte delaypointer = 0;

        // Stock Transfer Type
        public const string RefuellerToRefueller = "RR";
        public const string RefuellerToTank = "RT";
        #endregion

        #region AlertMessages

        public const string SqlNoDataFound = "{0}: No Data found to import \n";
        public const string ImportSuccessful = "{0}: Data imported successfully \n";

        #endregion
    }
}
