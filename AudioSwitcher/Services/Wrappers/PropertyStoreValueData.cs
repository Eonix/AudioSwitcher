using System.Runtime.InteropServices;
using AudioSwitcher.CoreAudioApi.Externals;

namespace AudioSwitcher.Services.Wrappers
{
    internal class PropertyStoreValueData
    {
        private readonly VariantData data;

        public PropertyStoreValueData(VariantData data)
        {
            this.data = data;
        }

        public string AsString()
        {
            return Marshal.PtrToStringUni(data.AsStringPtr);
        }
    }
}