using System;
using System.Runtime.InteropServices;

namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Represents a control interface on a part (connector or subunit) in a device topology.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371098.aspx
    /// </remarks>
	public partial interface IControlInterface
    {
		/// <summary>
		/// Gets the friendly name for the audio function that the control interface encapsulates.
		/// </summary>
		/// <param name="name">Receives a string that contains the friendly name.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetName(
			[Out] [MarshalAs(UnmanagedType.LPWStr)] out string name);

        /// <summary>
        /// Gets the interface ID of the function-specific control interface of the part.
        /// </summary>
        /// <param name="interfaceId">Receives the interface ID of the function-specific control interface of the part.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetIID(
            [Out] out Guid interfaceId);
    }
}
