using System.Runtime.InteropServices;
using CoreAudio.Externals;

namespace AudioSwitcher.Wrappers
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