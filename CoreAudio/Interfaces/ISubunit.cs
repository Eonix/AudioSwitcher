namespace CoreAudio.Interfaces
{
    /// <summary>
	/// Represents a hardware subunit (for example, a volume control) that lies in the data path between a client and an audio endpoint device.
    /// </summary>
    /// <remarks>
	/// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd316540.aspx
    /// </remarks>
	public partial interface ISubunit
    {
		// The ISubunit interface inherits from the IUnknown interface but does not define additional methods or properties.
    }
}
