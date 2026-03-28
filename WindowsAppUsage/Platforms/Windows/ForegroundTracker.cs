using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAppUsage.Platforms.Windows
{
    public class ForegroundTracker
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        public static string GetActiveApp()
        {
            IntPtr hwnd = GetForegroundWindow();
            if (hwnd == IntPtr.Zero) return "Unknown";

            GetWindowThreadProcessId(hwnd, out uint pid);
            var process = Process.GetProcessById((int)pid);
            return process.ProcessName;
        }
    }
}
