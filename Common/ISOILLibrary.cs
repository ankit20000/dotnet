using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ISOILLibrary
    {
        [DllImport("vegaisoil.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long switching(int j);
        [DllImport("vegaisoil.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long FillArr([MarshalAs(UnmanagedType.LPArray)] long[] inArr,long ArrSize);
        [DllImport("vegaisoil.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long checkStatus(int j);
        [DllImport("vegaisoil.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long printing(string word);
    }
}
