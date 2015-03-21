using System.Runtime.InteropServices;
using CoreAudio.Enumerations;
using CoreAudio.Policy;

namespace AudioSwitcher.Wrappers
{
    internal class PolicyConfiguration
    {
        [ComImport, Guid("870AF99C-171D-4F9E-AF0D-E63DF40C2BC9")]
        private class PolicyConfig { }

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