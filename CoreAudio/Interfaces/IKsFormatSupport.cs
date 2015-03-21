using System;
using System.Runtime.InteropServices;

namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Provides information about the audio data formats that are supported by a software-configured I/O connection.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371384.aspx
    /// </remarks>
	public partial interface IKsFormatSupport
    {
        /// <summary>
        /// Indicates whether the audio adapter device supports the specified audio stream format.
        /// </summary>
        /// <param name="format">An audio-stream format specifier.</param>
        /// <param name="size">The size in bytes of the buffer that contains the format specifier.</param>
        /// <param name="isSupported">Receives a value to indicate whether the format is supported.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int IsFormatSupported(
            [In] [MarshalAs(UnmanagedType.SysInt)] IntPtr format,
            [In] [MarshalAs(UnmanagedType.U4)] UInt32 size,
            [Out] [MarshalAs(UnmanagedType.Bool)] out bool isSupported);

		/// <summary>
		/// Gets the preferred audio stream format for the connection.
		/// </summary>
		/// <param name="format">Receives the format specifier for the preferred format.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetDevicePreferredFormat(
            [Out] [MarshalAs(UnmanagedType.SysInt)] out IntPtr format);
    }
}
