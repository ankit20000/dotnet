using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class EncryptionDecryptionLibrary
    {
        public static string DecryptedString(string inputStr)
        {
            byte[] decodedByteArray =
              Convert.FromBase64CharArray(inputStr.ToCharArray(),
                                            0, inputStr.Length);
            return ASCIIZToString(decodedByteArray);            
        }
        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes= ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        static public string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes=Convert.FromBase64String(encodedData);
            string returnValue =ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }

        private static string ASCIIZToString(byte[] a)
        {
            string str = string.Empty;
            if (a.Length > 0)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > 0)
                    {
                        str = str + (char)a[i];
                    }
                    continue;
                }
            }
            return str;
        }
    }
}
