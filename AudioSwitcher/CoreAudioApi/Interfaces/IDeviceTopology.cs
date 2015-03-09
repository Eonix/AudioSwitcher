using System;
using System.Runtime.InteropServices;

namespace AudioSwitcher.CoreAudioApi.Interfaces
{
    /// <summary>
	/// Provides access to the topology of an audio device.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371376.aspx
    /// </remarks>
	public partial interface IDeviceTopology
    {
        /// <summary>
        /// Gets the number of connectors in the device-topology object.
        /// </summary>
		/// <param name="count">Receives the connector count.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetConnectorCount(
            [Out] [MarshalAs(UnmanagedType.U4)] out UInt32 count);

		/// <summary>
		/// Gets the connector that is specified by a connector number.
		/// </summary>
		/// <param name="index">The zero-based index of the connector.</param>
		/// <param name="connector">Receives the <see cref="AudioSwitcher.CoreAudioApi.Interfaces.IConnector"/> interface of the connector object.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetConnector(
			[In] [MarshalAs(UnmanagedType.U4)] UInt32 index,
			[Out] [MarshalAs(UnmanagedType.Interface)] out AudioSwitcher.CoreAudioApi.Interfaces.IConnector connector);

        /// <summary>
        /// Gets the number of subunits in the device topology.
        /// </summary>
        /// <param name="subunitCount">Receives the subunit count.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetSubunitCount(
			[Out] [MarshalAs(UnmanagedType.U4)] out UInt32 subunitCount);

        /// <summary>
        /// Gets the subunit that is specified by a subunit number.
        /// </summary>
        /// <param name="subunitIndex">The zero-based index of the subunit.</param>
        /// <param name="subunit">Receives the <see cref="AudioSwitcher.CoreAudioApi.Interfaces.ISubunit"/> interface of the object.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetSubunit(
			[In] [MarshalAs(UnmanagedType.U4)] UInt32 subunitIndex,
			[Out] [MarshalAs(UnmanagedType.Interface)] out AudioSwitcher.CoreAudioApi.Interfaces.ISubunit subunit);

        /// <summary>
        /// Gets a part that is identified by its local ID.
        /// </summary>
        /// <param name="partId">The ID of the part to get.</param>
        /// <param name="part">Receives the <see cref="AudioSwitcher.CoreAudioApi.Interfaces.IPart"/> interface of the part object.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetPartById(
			[In] [MarshalAs(UnmanagedType.U4)] UInt32 partId,
			[Out] [MarshalAs(UnmanagedType.Interface)] out AudioSwitcher.CoreAudioApi.Interfaces.IPart part);

		/// <summary>
		/// Gets the device identifier of the device that is represented by the device-topology object.
		/// </summary>
		/// <param name="deviceId">Receives a string containing the device ID.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetDeviceId(
			[Out] [MarshalAs(UnmanagedType.LPWStr)] out string deviceId);

		/// <summary>
		/// Gets a list of parts in the signal path that links two parts, if the path exists.
		/// </summary>
		/// <param name="partFrom">The part at the beginning of the signal path.</param>
		/// <param name="partTo">The part at the end of the signal path.</param>
		/// <param name="rejectMixedPaths">Specifies whether to reject paths that contain mixed data.</param>
		/// <param name="partList">Receives an <see cref="AudioSwitcher.CoreAudioApi.Interfaces.IPartsList"/> interface instance.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetSignalPath(
			[In] [MarshalAs(UnmanagedType.Interface)] AudioSwitcher.CoreAudioApi.Interfaces.IPart partFrom,
			[In] [MarshalAs(UnmanagedType.Interface)] AudioSwitcher.CoreAudioApi.Interfaces.IPart partTo,
			[In] [MarshalAs(UnmanagedType.Bool)] bool rejectMixedPaths,
			[Out] [MarshalAs(UnmanagedType.Interface)] out AudioSwitcher.CoreAudioApi.Interfaces.IPartsList partList);
    }
}
