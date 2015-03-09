namespace AudioSwitcher.CoreAudioApi.Interfaces
{
    /// <summary>
	/// Provides access to a hardware midrange-level control.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd368232.aspx
    /// </remarks>
	public partial interface IAudioMidrange : AudioSwitcher.CoreAudioApi.Interfaces.IPerChannelDbLevel
    {
		// The IAudioMidrange interface inherits from IPerChannelDbLevel but does not define additional methods or properties.
		// Note: Although, derived classes normally do not work for COM interfaces, it does when no additional methods are defined in the subclass.
    }
}
