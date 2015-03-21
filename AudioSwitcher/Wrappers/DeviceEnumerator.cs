using System.Runtime.InteropServices;
using CoreAudio.Constants;
using CoreAudio.Enumerations;
using CoreAudio.Interfaces;

namespace AudioSwitcher.Wrappers
{
    internal class DeviceEnumerator
    {
        [ComImport, Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
        private class MmDeviceEnumerator { }

        private readonly IMMDeviceEnumerator enumerator;

        public DeviceEnumerator()
        {
            enumerator = new MmDeviceEnumerator() as IMMDeviceEnumerator;
        }

        public Device DefaultAudioEndpoint
        {
            get
            {
                IMMDevice device;
                Marshal.ThrowExceptionForHR(enumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out device));
                return new Device(device);
            }
        }

        public DeviceCollection EnumAudioEndpoints()
        {
            IMMDeviceCollection deviceCollection;
            Marshal.ThrowExceptionForHR(enumerator.EnumAudioEndpoints(EDataFlow.eRender,
                DEVICE_STATE_XXX.DEVICE_STATE_ACTIVE, out deviceCollection));
            return new DeviceCollection(deviceCollection);
        }
    }
}