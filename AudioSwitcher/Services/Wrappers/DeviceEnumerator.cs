using System.Runtime.InteropServices;
using AudioSwitcher.CoreAudioApi;
using AudioSwitcher.CoreAudioApi.Constants;
using AudioSwitcher.CoreAudioApi.Enumerations;
using AudioSwitcher.CoreAudioApi.Interfaces;

namespace AudioSwitcher.Services.Wrappers
{
    internal class DeviceEnumerator
    {
        private readonly IMMDeviceEnumerator enumerator;

        public DeviceEnumerator()
        {
            enumerator = new MMDeviceEnumerator() as IMMDeviceEnumerator;
        }

        public Device GetDefaultAudioEnpoint()
        {
            IMMDevice device;
            Marshal.ThrowExceptionForHR(enumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out device));
            return new Device(device);
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