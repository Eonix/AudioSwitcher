namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Provides access to a hardware treble-level control.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371001.aspx
    /// </remarks>
	public partial interface IAudioTreble : IPerChannelDbLevel
    {
		// The IAudioTreble interface inherits from IPerChannelDbLevel but does not define additional methods or properties.
		// Note: Although, derived classes normally do not work for COM interfaces, it does when no additional methods are defined in the subclass.
    }
}
