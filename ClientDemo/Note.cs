using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClientDemo
{
    class Note
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref CopyData lParam);
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        //定义消息常数 
        public const int WM_COPYDATA = 0x004A;
        public struct CopyData
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        public static IntPtr GetMainIntPtr()
        {
            var hwnd = FindWindow(null, "frmMain");
            return hwnd;
        }
        public static bool SendMsg(string MSG)
        {
            var hwnd = FindWindow(null, "frmMain");
            if (hwnd == IntPtr.Zero)
            {
                return false;
            }
            CopyData data;
            data.dwData = IntPtr.Zero;
            data.lpData = MSG;
            data.cbData = Encoding.Default.GetBytes(data.lpData).Length + 1;
            SendMessage(hwnd, WM_COPYDATA, 0, ref data);
            return true;
        }
        public static bool SendMsg(IntPtr hwnd, string MSG)
        {
            //var hwnd = FindWindowEx(hwndParent, IntPtr.Zero, null, "Form1");
            CopyData data;
            data.dwData = IntPtr.Zero;
            data.lpData = MSG;
            data.cbData = Encoding.Default.GetBytes(data.lpData).Length + 1;
            SendMessage(hwnd, WM_COPYDATA, 0, ref data);
            return true;
        }
    }
}
