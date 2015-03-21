using System;
using System.Runtime.InteropServices;
using CoreAudio.Structures;

namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Provides information about the jacks or internal connectors that provide a physical connection between a device and an endpoint.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371388.aspx
    /// </remarks>
	public partial interface IKsJackDescription2
    {
		/// <summary>
		/// Gets the number of jacks on the connector, which are required to connect to an endpoint device.
		/// </summary>
		/// <param name="count">Receives the number of audio jacks associated with the connector.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetJackCount(
			[Out] [MarshalAs(UnmanagedType.U4)] out UInt32 count);

		/// <summary>
		/// Gets the description of a specified audio jack.
		/// </summary>
		/// <param name="index">The zero-based index of the jack.</param>
		/// <param name="descriptor">Receives a structure of type <see cref="KSJACK_DESCRIPTION2"/> that contains information about the jack.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetJackDescription(
			[In] [MarshalAs(UnmanagedType.U4)] UInt32 index,
			[Out] out KSJACK_DESCRIPTION2 descriptor);
    }
}
