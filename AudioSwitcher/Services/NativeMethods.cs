using System;
using System.Runtime.InteropServices;

namespace AudioSwitcher.Services
{
    internal static class NativeMethods
    {
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
        public static extern int ExtractIconEx(string libName, int iconIndex, IntPtr[] largeIcon, IntPtr[] smallIcon, int nIcons); 
    }
}