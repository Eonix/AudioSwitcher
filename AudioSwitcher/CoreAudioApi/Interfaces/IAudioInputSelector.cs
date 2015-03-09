using System;
using System.Runtime.InteropServices;

namespace AudioSwitcher.CoreAudioApi.Interfaces
{
    /// <summary>
	/// Provides access to a hardware multiplexer control (input selector).
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd368220.aspx
    /// </remarks>
	public partial interface IAudioInputSelector
    {
		/// <summary>
		/// Gets the local ID of the part that is connected to the selector input that is currently selected.
		/// </summary>
		/// <param name="partId">Receives the local ID of the part that directly links to the currently selected selector input.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetSelection(
			[Out] [MarshalAs(UnmanagedType.U4)] out UInt32 partId);

		/// <summary>
		/// Selects one of the inputs of the input selector.
		/// </summary>
		/// <param name="partId">The ID of the new selector input.</param>
		/// <param name="eventContext">A user context value that is passed to the notification callback.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int SetSelection(
			[In] [MarshalAs(UnmanagedType.U4)] UInt32 partId,
			[In, Optional] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);
    }
}
