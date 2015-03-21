using System;
using System.Runtime.InteropServices;

namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Provides access to a loudness compensation control.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd368224.aspx
    /// </remarks>
	public partial interface IAudioLoudness
    {
		/// <summary>
		/// Gets the current state (enabled or disabled) of the loudness control.
		/// </summary>
		/// <param name="isEnabled">Receives the current loudness state.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetEnabled(
			[Out] [MarshalAs(UnmanagedType.Bool)] out bool isEnabled);

		/// <summary>
		/// Enables or disables the loudness control.
		/// </summary>
		/// <param name="isEnabled">Sets the new loudness state.</param>
		/// <param name="eventContext">A user context value that is passed to the notification callback.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int SetEnabled(
			[In] [MarshalAs(UnmanagedType.Bool)] bool isEnabled,
			[In, Optional] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);
    }
}
