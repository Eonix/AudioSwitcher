using System.Runtime.InteropServices;
using AudioSwitcher.CoreAudioApi.Enumerations;

namespace AudioSwitcher.CoreAudioApi.Interfaces
{
    /// <summary>
    /// Represents an audio endpoint device.
    /// </summary>
    public partial interface IMMEndpoint
    {
        /// <summary>
        /// Indicates whether the endpoint is associated with a rendering device or a capture device.
        /// </summary>
        /// <param name="dataFlow">The data-flow direction of the endpoint device.</param>
        /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
        [PreserveSig]
        int GetDataFlow(
			[Out] [MarshalAs(UnmanagedType.I4)] out EDataFlow dataFlow);
    }
}
