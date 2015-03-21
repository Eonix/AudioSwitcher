using System;
using System.Runtime.InteropServices;

namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Represents a list of parts, each of which is an object with an <see cref="IPart"/> interface that represents a connector or subunit.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371430.aspx
    /// </remarks>
	public partial interface IPartsList
    {
		/// <summary>
		/// Gets the number of parts in the parts list.
		/// </summary>
		/// <param name="count">Receives the number of parts in the parts list.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetCount(
			[Out] [MarshalAs(UnmanagedType.U4)] out UInt32 count);

		/// <summary>
		/// Gets a part from the parts list.
		/// </summary>
		/// <param name="index">The zero-based index of the part.</param>
		/// <param name="part">Receives the <see cref="IPart"/> interface of the specified part object.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int GetPart(
            [In]  [MarshalAs(UnmanagedType.U4)] UInt32 index,
            [Out] [MarshalAs(UnmanagedType.Interface)] out IPart part);
    }
}
