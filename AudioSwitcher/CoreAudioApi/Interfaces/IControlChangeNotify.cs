using System;
using System.Runtime.InteropServices;

namespace AudioSwitcher.CoreAudioApi.Interfaces
{
    /// <summary>
	/// Provides notifications when the status of a part (connector or subunit) changes.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371088.aspx
    /// </remarks>
	public partial interface IControlChangeNotify
    {
		/// <summary>
		/// Notifies the client when the status of a part (connector or subunit) changes.
		/// </summary>
		/// <param name="processId">The process ID of the client that changed the state of the control.</param>
		/// <param name="eventContext">A user context value that is passed to the notification callback.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int OnNotify(
			[In] [MarshalAs(UnmanagedType.U4)] UInt32 processId,
			[In, Optional] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);
    }
}
