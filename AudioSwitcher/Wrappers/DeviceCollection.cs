using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CoreAudio.Interfaces;

namespace AudioSwitcher.Wrappers
{
    class DeviceCollection : IEnumerable<Device>
    {
        private readonly IMMDeviceCollection deviceCollection;

        public DeviceCollection(IMMDeviceCollection deviceCollection)
        {
            this.deviceCollection = deviceCollection;
        }

        public int Count
        {
            get
            {
                uint count;
                Marshal.ThrowExceptionForHR(deviceCollection.GetCount(out count));
                return (int)count;
            }
        }

        public Device this[int key]
        {
            get
            {
                IMMDevice device;
                Marshal.ThrowExceptionForHR(deviceCollection.Item((uint)key, out device));
                return new Device(device);
            }
        }

        public IEnumerator<Device> GetEnumerator()
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