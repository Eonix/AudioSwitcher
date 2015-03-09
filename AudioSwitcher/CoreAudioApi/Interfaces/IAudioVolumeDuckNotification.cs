using System;
using System.Runtime.InteropServices;

namespace AudioSwitcher.CoreAudioApi.Interfaces
{
    /// <summary>
	/// Used to by the system to send notifications about stream attenuation changes.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371006.aspx
    /// </remarks>
	public partial interface IAudioVolumeDuckNotification
    {
		/// <summary>
		/// Sends a notification about a pending system ducking event.
		/// </summary>
		/// <param name="sessionId">A string containing the session instance identifier of the communications session that raises the the auto-ducking event.</param>
		/// <param name="activeSessionCount">The number of active communications sessions.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int OnVolumeDuckNotification(
			[In] [MarshalAs(UnmanagedType.LPWStr)] string sessionId,
			[In] UInt32 activeSessionCount);

		/// <summary>
		/// Sends a notification about a pending system unducking event.
		/// </summary>
		/// <param name="sessionId">A string containing the session instance identifier of the terminating communications session that intiated the ducking.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int OnVolumeUnduckNotification(
			[In] [MarshalAs(UnmanagedType.LPWStr)] string sessionId);
    }
}
