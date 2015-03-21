using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CoreAudio.Externals;

namespace AudioSwitcher.Wrappers
{
    internal class PropertyStore : IEnumerable<KeyValuePair<PropertyStoreKey, PropertyStoreValue>>
    {
        private readonly IPropertyStore propertyStore;

        public PropertyStore(IPropertyStore propertyStore)
        {
            this.propertyStore = propertyStore;
        }

        public int Count
        {
            get
            {
                uint propertyCount;
                Marshal.ThrowExceptionForHR(propertyStore.GetCount(out propertyCount));
                return (int)propertyCount;
            }
        }

        public KeyValuePair<PropertyStoreKey, PropertyStoreValue> this[int key]
        {
            get
            {
                PROPERTYKEY propertykey;
                Marshal.ThrowExceptionForHR(propertyStore.GetAt((uint)key, out propertykey));

                PROPVARIANT propvariant;
                Marshal.ThrowExceptionForHR(propertyStore.GetValue(ref propertykey, out propvariant));

                return new KeyValuePair<PropertyStoreKey, PropertyStoreValue>(new PropertyStoreKey(propertykey), new PropertyStoreValue(propvariant));
            }
        }

        public IEnumerator<KeyValuePair<PropertyStoreKey, PropertyStoreValue>> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}