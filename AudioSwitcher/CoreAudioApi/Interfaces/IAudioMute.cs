using System;
using System.Runtime.InteropServices;

namespace AudioSwitcher.CoreAudioApi.Interfaces
{
    /// <summary>
	/// Provides access to a hardware mute control.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd368233.aspx
    /// </remarks>
	public partial interface IAudioMute
    {
        /// <summary>
        /// Enables or disables the mute control.
        /// </summary>
        /// <param name="isMuted">The new state of the mute control.</param>
        /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int SetMute(
            [In] [MarshalAs(UnmanagedType.Bool)] bool isMuted,
            [In, Optional] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

		/// <summary>
		/// Gets the current state (enabled or disabled) of the mute control.
		/// </summary>
		/// <param name="isMuted">Receives the current state of the mute control.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetMute(
			[Out] [MarshalAs(UnmanagedType.Bool)] out bool isMuted);
    }
}
