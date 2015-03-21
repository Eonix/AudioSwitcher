using System.Runtime.InteropServices;
using CoreAudio.Structures;

namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Provides access to jack sink information if the jack is supported by the hardware.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371393.aspx
    /// </remarks>
	public partial interface IKsJackSinkInformation
    {
		/// <summary>
		/// Retrieves the sink information for the specified jack. 
		/// </summary>
		/// <param name="information">Receives a structure of type <see cref="KSJACK_SINK_INFORMATION"/> that contains the jack sink information.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetJackSinkInformation(
			[Out] out KSJACK_SINK_INFORMATION information); // TODO: This will have to be changed to an IntPtr. See KSJACK_SINK_INFORMATION.cs for details.
    }
}
