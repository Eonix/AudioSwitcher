using System;
using CoreAudio.Externals;

namespace AudioSwitcher.Wrappers
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