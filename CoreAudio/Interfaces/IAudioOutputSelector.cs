using System;
using System.Runtime.InteropServices;

namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Provides access to a hardware demultiplexer control (output selector).
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd368236.aspx
    /// </remarks>
	public partial interface IAudioOutputSelector
    {
		/// <summary>
		/// Gets the local ID of the part that is connected to the selector output that is currently selected.
		/// </summary>
		/// <param name="partId">Receives the local ID of the part that has a direct link to the currently selected output.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetSelection(
			[Out] [MarshalAs(UnmanagedType.U4)] out UInt32 partId);

		/// <summary>
		/// Selects one of the outputs of the output selector.
		/// </summary>
		/// <param name="partId">The ID of the new selector output.</param>
		/// <param name="eventContext">A user context value that is passed to the notification callback.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int SetSelection(
			[In] [MarshalAs(UnmanagedType.U4)] UInt32 partId,
			[In, Optional] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);
    }
}
