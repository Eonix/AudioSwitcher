using System;
using System.Runtime.InteropServices;

namespace CoreAudio.Interfaces
{
    /// <summary>
    /// Provides notifications when the volume level or muting state of an audio endpoint device changes.
    /// </summary>
    /// <remarks>
    /// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd370894.aspx
    /// </remarks>
    public partial interface IAudioEndpointVolumeCallback
    {
        /// <summary>
        /// Notifies the client that the volume level or muting state of the audio endpoint device has changed.
        /// </summary>
        /// <param name="notificationData">The volume-notification data.</param>
        /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
        [PreserveSig]
        int OnNotify(
            [In] IntPtr notificationData);
    }
}
