using System.Runtime.InteropServices;
using AudioSwitcher.CoreAudioApi.Enumerations;
using AudioSwitcher.Policy;

namespace AudioSwitcher.Services.Wrappers
{
    internal class PolicyConfiguration
    {
        private readonly IPolicyConfig policyConfig;

        public PolicyConfiguration()
        {
            policyConfig = new PolicyConfig() as IPolicyConfig;
        }

        public void SetDefaultEndpoint(string deviceId)
        {
            Marshal.ThrowExceptionForHR(policyConfig.SetDefaultEndpoint(deviceId, ERole.eMultimedia));
        }
    }
}