using System;
using System.Runtime.InteropServices;

namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Used to get the current device position.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd370882.aspx
    /// </remarks>
	public partial interface IAudioClock2
    {
		/// <summary>
		/// Gets the current device position, in frames, directly from the hardware.
		/// </summary>
		/// <param name="devicePosition">Receives the device position, in frames.</param>
		/// <param name="counterPosition">Receives the value of the performance counter at the time that the device read the position.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetDevicePosition(
			[Out] [MarshalAs(UnmanagedType.U8)] out UInt64 devicePosition,
			[Out, Optional] [MarshalAs(UnmanagedType.U8)] out UInt64 counterPosition);
    }
}
