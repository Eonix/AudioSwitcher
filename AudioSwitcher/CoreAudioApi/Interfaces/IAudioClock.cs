using System;
using System.Runtime.InteropServices;

namespace AudioSwitcher.CoreAudioApi.Interfaces
{
    /// <summary>
	/// Enables a client to monitor a stream's data rate and the current position in the stream.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd370881.aspx
    /// </remarks>
	public partial interface IAudioClock
    {
		/// <summary>
		/// Gets the device frequency.
		/// </summary>
		/// <param name="frequency">Receives the device frequency.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetFrequency(
			[Out] [MarshalAs(UnmanagedType.U8)] out UInt64 frequency);

		/// <summary>
		/// Gets the current position in the stream.
		/// </summary>
		/// <param name="devicePosition">Receives the device position.</param>
		/// <param name="counterPosition">Receives the value of the performance counter at the time that the device read the position.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetPosition(
			[Out] [MarshalAs(UnmanagedType.U8)] out UInt64 devicePosition,
			[Out, Optional] [MarshalAs(UnmanagedType.U8)] out UInt64 counterPosition);

		/// <summary>
		/// Reserved for future use.
		/// </summary>
		/// <param name="characteristics">Receives a value that indicates the characteristics of the audio clock.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetCharacteristics(
			[Out] [MarshalAs(UnmanagedType.U4)] out UInt32 characteristics);
    }
}
