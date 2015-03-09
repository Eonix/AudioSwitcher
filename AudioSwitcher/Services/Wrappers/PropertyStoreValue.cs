using AudioSwitcher.CoreAudioApi.Externals;

namespace AudioSwitcher.Services.Wrappers
{
    internal class PropertyStoreValue
    {
        private readonly PROPVARIANT propvariant;

        public PropertyStoreValue(PROPVARIANT propvariant)
        {
            this.propvariant = propvariant;
        }

        public PropertyStoreValueData Data
        {
            get { return new PropertyStoreValueData(propvariant.Data); }
        }
    }
}