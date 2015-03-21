using System;
using System.Runtime.InteropServices;

namespace CoreAudio.Interfaces
{
    /// <summary>
    /// Represents a collection of audio devices.
    /// </summary>
    /// <remarks>
    /// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371396.aspx
    /// </remarks>
    public partial interface IMMDeviceCollection
    {
        /// <summary>
        /// Retrieves a count of the devices in the device collection.
        /// </summary>
        /// <param name="count">The number of devices in the device collection.</param>
        /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
        [PreserveSig]
        int GetCount(
            [Out] [MarshalAs(UnmanagedType.U4)] out UInt32 count);

        /// <summary>
        /// Retrieves a pointer to the specified item in the device collection.
        /// </summary>
        /// <param name="index">The zero based device index.</param>
        /// <param name="device">The <see cref="IMMDevice"/> interface of the specified item in the device collection.</param>
        /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
        [PreserveSig]
        int Item(
			[In] [MarshalAs(UnmanagedType.U4)] UInt32 index,
            [Out] [MarshalAs(UnmanagedType.Interface)] out IMMDevice device);
    }
}
