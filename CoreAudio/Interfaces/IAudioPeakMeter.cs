using System;
using System.Runtime.InteropServices;

namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Provides access to a hardware peak-meter control.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd368239.aspx
    /// </remarks>
	public partial interface IAudioPeakMeter
    {
		/// <summary>
		/// Gets the number of channels in the audio stream.
		/// </summary>
		/// <param name="count">Receives the channel count.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetChannelCount(
			[Out] [MarshalAs(UnmanagedType.U4)] out UInt32 count);

		/// <summary>
		/// Gets the peak level that the peak meter recorded for the specified channel since the peak level for that channel was previously read.
		/// </summary>
		/// <param name="index">The zero-based channel index.</param>
		/// <param name="level">Receives the peak meter level in decibels.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetLevel(
			[In] [MarshalAs(UnmanagedType.U4)] UInt32 index,
			[Out] [MarshalAs(UnmanagedType.R4)] out float level);
    }
}
