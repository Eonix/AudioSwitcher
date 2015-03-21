using System.Runtime.InteropServices;
using CoreAudio.Structures;

namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Provides information about the jacks or internal connectors that provide a physical connection between a device and an endpoint.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371387.aspx
    /// </remarks>
	public partial interface IKsJackDescription
    {
		/// <summary>
		/// Gets the number of jacks required to connect to an endpoint device.
		/// </summary>
		/// <param name="count">Receives the number of jacks associated with the connector.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetJackCount(
			[Out] out uint count);

		/// <summary>
		/// Gets a description of an audio jack.
		/// </summary>
		/// <param name="index">The zero-based index of the jack.</param>
		/// <param name="descriptor">Receives a structure of type <see cref="KSJACK_DESCRIPTION"/> that contains information about the jack.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetJackDescription(
			[In] uint index,
			[Out] out KSJACK_DESCRIPTION descriptor);
    }
}
