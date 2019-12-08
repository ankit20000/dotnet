using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class LCString
    {      
        /// <summary>
        /// This method is used to convert ASCII character array to string.
        /// </summary>
        /// <param name="a">Array of type byte</param>
        /// <param name="Data">Converted string</param>       
        public static void ASCIIZToString(ref byte[] a, ref string Data)
        {
            Data = string.Empty;
            if (a.Length > 0)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != 0)
                        Data = Data + (char)a[i];                   
                    else                   
                    break;
                }
            }
            //Data = ASCIIEncoding.ASCII.GetString(a);  OR
        }

        /// <summary>
        /// This method is used to convert string into byte array.
        /// </summary>
        /// <param name="s">String for conversion</param>
        /// <param name="a">Converted byte array</param>
        public static void StringToASCIIZ(string s,byte[] a)
        {
            a=ASCIIEncoding.ASCII.GetBytes(s);                       
        }        

        /// <summary>
        /// This method is used to convert currenttime(HH:mm:ss) into HHmmss format
        /// </summary>
        /// <param name="timestring">Time string for conversion</param>
        /// <returns>converted time string</returns>
        public static string TimeFormatConversion(string timestring)
        {
            StringBuilder sb = new StringBuilder();
            string[] timearray = timestring.Split(':');
            foreach (string item in timearray)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }        
    }
}
