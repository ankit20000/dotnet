using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MeterFunctions
    {
        byte result, devStatus = 0;        
        byte[] fieldData = new byte[50];
        long Data = 0, GrossTotal=0;
        int i;
        string d, s1, s2;
        string MeterNo="",EquipementNo="",QtyDispensed,MeterEndReading,MeterStartReading;

        /// <summary>
        /// This method is used to return updated value of quantity dispensed for LC flow meter.
        /// </summary>
        /// <returns>returns updated quantity dispensed</returns>
        public string QtyDispensedRefreshLC()              //for Timer Event
        {
            try
            {
                result = LCMeterLibrary.LCP02GetField(Constants.device, LCMeterLibrary.LCRF_GrossQty_NE, ref Data, ref devStatus, LCMeterLibrary.LCRM_WAIT);
                d = Data.ToString();
                i = CountNumberOfDigits(Data);
                s1 = d.Substring(1, i - 1);
                s2 = d.Substring(i - 1, 1);
                d = s1 + "." + s2;
                QtyDispensed = Data.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return QtyDispensed;
        }

        /// <summary>
        /// This Function is used count number of digits in a number.
        /// </summary>
        /// <param name="Data">Parameter of long datatype</param>
        /// <returns></returns>
        public int CountNumberOfDigits(long Data)
        {
            int count = 0;
            while (Data != 0)
            {
                count++;
                Data = Data / 10;
            }
            return count;
        }

        /// <summary>
        /// This method is used to return equipement or meter number.
        /// </summary>  
        /// <returns>Equipement Meter No</returns>
        public string GetEquipementNumber()
        {
            try
            {
                result = LCMeterLibrary.LCP02MustGetField(Constants.device, LCMeterLibrary.LCRF_MeterID_WM, fieldData, ref devStatus, Constants.delaypointer, Constants.delaypointer);
                if (result==0)
                {
                    LCString.ASCIIZToString(ref fieldData, ref MeterNo);
                    EquipementNo = MeterNo;
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return EquipementNo;
        }

        /// <summary>
        /// This method is used to return Meter Start Reading for LC meter.
        /// </summary>
        /// <returns>Meter Start Reading</returns>
        public string GetMeterStartReading()
        {
            try
            {
                result = LCMeterLibrary.LCP02GetField(Constants.device, LCMeterLibrary.LCRF_GrossTotal_WM, ref GrossTotal, ref devStatus, LCMeterLibrary.LCRM_WAIT);
                MeterStartReading = GrossTotal.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return MeterStartReading;
        }

        /// <summary>
        /// This method is used to return Meter End Reading for LC meter.
        /// </summary>
        /// <returns>Meter End Reading</returns>
        public string GetMeterEndReading()
        {
            try
            {
                result = LCMeterLibrary.LCP02GetField(Constants.device, LCMeterLibrary.LCRF_GrossTotal_WM, ref Data, ref devStatus, LCMeterLibrary.LCRM_WAIT);
                d = Data.ToString();
                i = CountNumberOfDigits(Data);
                s1 = d.Substring(0, i - 1);
                s2 = d.Substring(i - 1, 1);
                d = s1 + "." + s2;
                MeterEndReading = Data.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return MeterEndReading;
        }

        /// <summary>
        /// This method is used to return Meter start reading for ISOIL Meter.
        /// </summary>
        /// <returns>Meter start long value</returns>
        public long getMeterStart()
        {
            long[] MyArr = new long[2];
            int ArrSize = 2;
            long lval = 0;
            lval = ISOILLibrary.FillArr(MyArr, ArrSize);
            if (lval != 0)
                GlobalVariable.MeterStart = MyArr[1];
            return lval;
        }       
    }
}
