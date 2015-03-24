using System.Collections.Generic;
using System.Linq;
using AudioSwitcher.Models;
using AudioSwitcher.Wrappers;

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

        public string DefaultDeviceId
        {
            get { return deviceEnumerator.DefaultAudioEndpoint.Id; }
            set { policyConfiguration.SetDefaultEndpoint(value); }
        }

        public IEnumerable<AudioDevice> AudioDevices
        {
            get
            {
                return deviceEnumerator.EnumAudioEndpoints().Select(audioEndpoint => new AudioDevice
                {
                    Id = audioEndpoint.Id,
                    Name = audioEndpoint.Name,
                    Icon = audioEndpoint.Icon
                }); 
            }
        }
    }
}