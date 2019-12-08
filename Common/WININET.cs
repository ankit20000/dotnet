using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class WININET
    {
        #region [Library Functions]

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern UInt32 GetProcessHeaps(UInt32 NumberOfHeaps, IntPtr[] ProcessHeaps);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr HeapAlloc(IntPtr hHeap, uint dwFlags, UIntPtr dwBytes);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool HeapFree(IntPtr hHeap, uint dwFlags, IntPtr lpMem);
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory1(IntPtr dest, long src, long count);
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory2(long dest, IntPtr src, long count);


        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InternetFindNextFile(IntPtr hFind, out WIN32_FIND_DATA findFileData);
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FtpFindFirstFile(IntPtr hConnect, string searchFile, out WIN32_FIND_DATA findFileData, int flags, IntPtr context);
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FtpGetFile(IntPtr hConnect, string remoteFile, string newFile, [MarshalAs(UnmanagedType.Bool)] bool failIfExists, int flagsAndAttributes, int flags, IntPtr context);
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FtpPutFile(IntPtr hConnect, string lpszLocalFile, string lpszNewRemoteFile, int dwFlags, IntPtr dwContext);
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool FtpSetCurrentDirectory(IntPtr hFtpConnection, string lpszDirectory);
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr InternetOpen(string lpszAgent, int dwAccessType, string lpszProxyName, string lpszProxyBypass, int dwFlags);
        [DllImport("wininet.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool FtpCommandA(IntPtr hFtpSession, [MarshalAs(UnmanagedType.Bool)] bool fExpectResponse, int dwFlags, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszCommand, IntPtr dwContext, IntPtr phFtpCommand);


        // Opens a HTTP session for a given site.
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr InternetConnect(IntPtr hInternet, string lpszServerName, short nServerPort, string lpszUsername, string lpszPassword, int dwService, int dwFlags, IntPtr dwContext);
        [DllImport("wininet.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InternetGetLastResponseInfo(out int errorCode, StringBuilder buffer, ref int bufferLength);

        // Opens an HTTP request handle.
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern IntPtr HttpOpenRequest(IntPtr hConnect, string lpszVerb, string lpszObjectName, string lpszVersion,
        string lpszReferer, string[] lplpszAcceptTypes, int dwFlags, IntPtr dwContext);

        // Sends the specified request to the HTTP server.
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool HttpSendRequest([In] IntPtr hRequest, [In] string lpszHeaders, [In] uint dwHeadersLength,
        [In] IntPtr lpOptional, [In] uint dwOptionalLength);

        // Queries for information about an HTTP request.
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool HttpQueryInfo(IntPtr hInternet, int dwInfoLevel, ref long lpBuffer, ref long lpdwBufferLength, ref long lpdwIndex);

        // Reads data from a handle opened by the HttpOpenRequest function.
        //        Public Declare Function InternetReadFile Lib "wininet.dll" _
        //(ByVal hFile As Long, ByVal sBuffer As String, ByVal lNumBytesToRead As Long, _
        //lNumberOfBytesRead As Long) As Integer

        //Public Declare Function InternetWriteFile Lib "wininet.dll" _
        //        (ByVal hFile As Long, ByVal sBuffer As String, _
        //        ByVal lNumberOfBytesToRead As Long, _
        //        lNumberOfBytesRead As Long) As Integer

        [DllImport("wininet.dll", EntryPoint = "FtpOpenFile", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern uint FtpOpenFile(IntPtr hFtpConn, string strFileName, uint nAccess, uint nFlags, uint nContext);
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FtpDeleteFile(IntPtr hConnect, string fileName);
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetSetOptionStr(IntPtr hInternet, int dwOption, string lpBuffer, int lpdwBufferLength);

        // Closes a single Internet handle or a subtree of Internet handles.
        [DllImport("wininet.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InternetCloseHandle(IntPtr hInternet);

        // Queries an Internet option on the specified handle
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetQueryOption(IntPtr hInternet, uint dwOption, char[] lpBuffer, ref int lpdwBufferLength);

        // Adds one or more HTTP request headers to the HTTP request handle.
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern int HttpAddRequestHeaders(long hHttpRequest,string sHeaders,long lHeadersLength,long lModifiers);

        #endregion [Library Functions]

        #region [Constants]

        public const byte HEAP_ZERO_MEMORY = 0x8;
        public const byte HEAP_GENERATE_EXCEPTIONS = 0x4;
        public const int MAX_PATH = 260;
        public const byte NO_ERROR = 0;
        public const byte FILE_ATTRIBUTE_READONLY = 0x1;
        public const byte FILE_ATTRIBUTE_HIDDEN = 0x2;
        public const byte FILE_ATTRIBUTE_SYSTEM = 0x4;
        public const byte FILE_ATTRIBUTE_DIRECTORY = 0x10;
        public const byte FILE_ATTRIBUTE_ARCHIVE = 0x20;
        public const long FILE_ATTRIBUTE_NORMAL = 0x80;
        public const long FILE_ATTRIBUTE_TEMPORARY = 0x100;
        public const long FILE_ATTRIBUTE_COMPRESSED = 0x800;
        public const long FILE_ATTRIBUTE_OFFLINE = 0x1000;

        public const byte ERROR_NO_MORE_FILES = 18;

        public const string scUserAgent = "vb wininet";        //User agent constant.

        // Use registry access settings.
        public const byte INTERNET_OPEN_TYPE_PRECONFIG = 0;
        public const byte INTERNET_OPEN_TYPE_DIRECT = 1;
        public const byte INTERNET_OPEN_TYPE_PROXY = 3;
        public const byte INTERNET_INVALID_PORT_NUMBER = 0;

        public const byte FTP_TRANSFER_TYPE_BINARY = 0x2;
        public const byte FTP_TRANSFER_TYPE_ASCII = 0x1;
        public const long INTERNET_FLAG_PASSIVE = 0x8000000;

        public const long ERROR_INTERNET_EXTENDED_ERROR = 12003;

        // Number of the TCP/IP port on the server to connect to.
        public const byte INTERNET_DEFAULT_FTP_PORT = 21;
        public const byte INTERNET_DEFAULT_GOPHER_PORT = 70;
        public const byte INTERNET_DEFAULT_HTTP_PORT = 80;
        public const int INTERNET_DEFAULT_HTTPS_PORT = 443;
        public const int INTERNET_DEFAULT_SOCKS_PORT = 1080;

        public const byte INTERNET_OPTION_CONNECT_TIMEOUT = 2;
        public const byte INTERNET_OPTION_RECEIVE_TIMEOUT = 6;
        public const byte INTERNET_OPTION_SEND_TIMEOUT = 5;

        public const byte INTERNET_OPTION_USERNAME = 28;
        public const byte INTERNET_OPTION_PASSWORD = 29;
        public const byte INTERNET_OPTION_PROXY_USERNAME = 43;
        public const byte INTERNET_OPTION_PROXY_PASSWORD = 44;

        // Type of service to access.
        public const byte INTERNET_SERVICE_FTP = 1;
        public const byte INTERNET_SERVICE_GOPHER = 2;
        public const byte INTERNET_SERVICE_HTTP = 3;

        // Brings the data across the wire even if it locally cached.

        public const long INTERNET_FLAG_RELOAD = 0x80000000;
        public const long INTERNET_FLAG_KEEP_CONNECTION = 0x400000;
        public const long INTERNET_FLAG_MULTIPART = 0x200000;
        public const long GENERIC_READ = 0x80000000;
        public const long GENERIC_WRITE = 0x40000000;

        // The possible values for the lInfoLevel parameter include:
        public const byte HTTP_QUERY_CONTENT_TYPE = 1;
        public const byte HTTP_QUERY_CONTENT_LENGTH = 5;
        public const byte HTTP_QUERY_EXPIRES = 10;
        public const byte HTTP_QUERY_LAST_MODIFIED = 11;
        public const byte HTTP_QUERY_PRAGMA = 17;
        public const byte HTTP_QUERY_VERSION = 18;
        public const byte HTTP_QUERY_STATUS_CODE = 19;
        public const byte HTTP_QUERY_STATUS_TEXT = 20;
        public const byte HTTP_QUERY_RAW_HEADERS = 21;
        public const byte HTTP_QUERY_RAW_HEADERS_CRLF = 22;
        public const byte HTTP_QUERY_FORWARDED = 30;
        public const byte HTTP_QUERY_SERVER = 37;
        public const byte HTTP_QUERY_USER_AGENT = 39;
        public const byte HTTP_QUERY_SET_COOKIE = 43;
        public const byte HTTP_QUERY_REQUEST_METHOD = 45;
        public const int HTTP_STATUS_DENIED = 401;
        public const int HTTP_STATUS_PROXY_AUTH_REQ = 407;

        // Add this flag to the about flags to get request header.
        public const long HTTP_QUERY_FLAG_REQUEST_HEADERS = 0x80000000;
        public const long HTTP_QUERY_FLAG_NUMBER = 0x20000000;

        // Returns the version number of Wininet.dll.
        public const byte INTERNET_OPTION_VERSION = 40;

        // Flags to modify the semantics of this function. Can be a combination of these values:
        // Adds the header only if it does not already exist; otherwise, an error is returned.
        public const long HTTP_ADDREQ_FLAG_ADD_IF_NEW = 0x10000000;

        // Adds the header if it does not exist. Used with REPLACE.
        public const long HTTP_ADDREQ_FLAG_ADD = 0x20000000;

        // Replaces or removes a header. If the header value is empty and the header is found,
        // it is removed. If not empty, the header value is replaced
        public const long HTTP_ADDREQ_FLAG_REPLACE = 0x80000000;

        #endregion [Constants]
    }

    #region [Structure definitions]

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FILETIME
    {
        public long dwLowDateTime;
        public long dwHighDateTime;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WIN32_FIND_DATA
    {
        long dwFileAttributes;
        FILETIME ftCreationTime;
        FILETIME ftLastAccessTime;
        FILETIME ftLastWriteTime;
        long nFileSizeHigh;
        long nFileSizeLow;
        byte dwReserved0;
        byte dwReserved1;
        // string cFileName* MAX_PATH;
        // string cAlternate * 14;
    }

    // Contains the version number of the DLL that contains the Windows Internet functions (Wininet.dll).
    // This structure is used when passing the INTERNET_OPTION_VERSION flag to the InternetQueryOption function.
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct tWinInetDLLVersion
    {
        long lMajorVersion;
        long lMinorVersion;
    }

    #endregion [Structure definitions]
}
