using System;
using AudioSwitcher.CoreAudioApi.Externals;

namespace AudioSwitcher.Services.Wrappers
{
    internal class PropertyStoreKey
    {
        private readonly PROPERTYKEY propertykey;

        public PropertyStoreKey(PROPERTYKEY propertykey)
        {
            this.propertykey = propertykey;
        }

        public Guid FmtId
        {
            get { return propertykey.fmtid; }
        }
    }
}