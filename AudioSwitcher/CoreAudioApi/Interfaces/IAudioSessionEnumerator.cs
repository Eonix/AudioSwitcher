using System;
using System.Runtime.InteropServices;

namespace AudioSwitcher.CoreAudioApi.Interfaces
{
    /// <summary>
	/// Enumerates audio sessions on an audio device.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd368281.aspx
    /// </remarks>
	public partial interface IAudioSessionEnumerator
    {
		/// <summary>
		/// Gets the total number of audio sessions that are open on the audio device.
		/// </summary>
		/// <param name="count">Receives the total number of audio sessions.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetCount(
			[Out] [MarshalAs(UnmanagedType.I4)] out Int32 count);

		/// <summary>
		/// Gets the audio session specified by an audio session number. 
		/// </summary>
		/// <param name="index">The zero-based index of the session.</param>
		/// <param name="session">Receives an <see cref="AudioSwitcher.CoreAudioApi.Interfaces.IAudioSessionControl"/> session object in the collection that is maintained by the session enumerator.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetSession(
			[In] [MarshalAs(UnmanagedType.I4)] Int32 index,
			[Out] [MarshalAs(UnmanagedType.Interface)] out AudioSwitcher.CoreAudioApi.Interfaces.IAudioSessionControl session);
    }
}
