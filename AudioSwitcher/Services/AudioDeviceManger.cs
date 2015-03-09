using System.Collections.Generic;
using System.Linq;
using AudioSwitcher.Models;
using AudioSwitcher.Services.Wrappers;

namespace AudioSwitcher.Services
{
    public class AudioDeviceManger
    {
        private readonly DeviceEnumerator deviceEnumerator;
        private readonly PolicyConfiguration policyConfiguration;

        public AudioDeviceManger()
        {
            deviceEnumerator = new DeviceEnumerator();
            policyConfiguration = new PolicyConfiguration();
        }

        public void SetDefaultDevice(string deviceId)
        {
            policyConfiguration.SetDefaultEndpoint(deviceId);
        }

        public string GetDefaultAudioDeviceId()
        {
            var defaultAudioEnpoint = deviceEnumerator.GetDefaultAudioEnpoint();
            return defaultAudioEnpoint.Id;
        }
        
        public IEnumerable<AudioDevice> GetAudioDevices()
        {
            var audioEndpoints = deviceEnumerator.EnumAudioEndpoints();
            return audioEndpoints.Select(audioEndpoint => new AudioDevice
            {
                Id = audioEndpoint.Id, 
                Name = audioEndpoint.Name, 
                Icon = audioEndpoint.Icon.ToBitmap()
            });
        }
    }
}