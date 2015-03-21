using System.Runtime.InteropServices;

namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Used to adjust the sample rate of a stream.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd370884.aspx
    /// </remarks>
	public partial interface IAudioClockAdjustment
    {
		/// <summary>
		/// Sets the sample rate of a stream.
		/// </summary>
		/// <param name="sampleRate">The new sample rate in frames per second.</param>
		/// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
		[PreserveSig]
		int SetSampleRate(
			[In] [MarshalAs(UnmanagedType.R4)] float sampleRate);
    }
}
