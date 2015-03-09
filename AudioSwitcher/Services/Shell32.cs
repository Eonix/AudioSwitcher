using System;
using System.Runtime.InteropServices;

namespace AudioSwitcher.Services
{
    internal static class Shell32
    {
        [DllImport("shell32.dll")]
        public static extern int ExtractIconEx(string libName, int iconIndex, IntPtr[] largeIcon, IntPtr[] smallIcon, int nIcons); 
    }
}