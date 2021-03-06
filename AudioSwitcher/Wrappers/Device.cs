﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using AudioSwitcher.Services;
using CoreAudio.Constants;
using CoreAudio.Externals;
using CoreAudio.Interfaces;

namespace AudioSwitcher.Wrappers
{
    internal class Device
    {
        private readonly IMMDevice device;

        public Device(IMMDevice device)
        {
            this.device = device;
        }

        public string Id
        {
            get
            {
                string id;
                Marshal.ThrowExceptionForHR(device.GetId(out id));
                return id;
            }
        }

        public PropertyStore PropertyStore
        {
            get
            {
                IPropertyStore store;
                Marshal.ThrowExceptionForHR(device.OpenPropertyStore(STGM.STGM_READ, out store));
                return new PropertyStore(store);
            }
        }

        public string Name
        {
            get
            {
                var valuePair = PropertyStore.FirstOrDefault(pair => pair.Key.FmtId == PropertyKeys.PKEY_DeviceInterface_FriendlyName);
                return !valuePair.Equals(default(KeyValuePair<PropertyStoreKey, PropertyStoreValue>))
                    ? valuePair.Value.Data.AsString()
                    : "Unknown";
            }
        }

        public Icon Icon
        {
            get
            {
                var valuePair = PropertyStore.FirstOrDefault(pair => pair.Key.FmtId == PropertyKeys.PKEY_DeviceClass_IconPath);
                var iconPath = !valuePair.Equals(default(KeyValuePair<PropertyStoreKey, PropertyStoreValue>))
                    ? valuePair.Value.Data.AsString()
                    : null;

                var path = Environment.ExpandEnvironmentVariables(iconPath ?? string.Empty);
                var paths = path.Split(',');
                if (paths.Length <= 1)
                    return new Icon(paths[0], 16, 16);

                var hIconEx = new IntPtr[1];
                Marshal.ThrowExceptionForHR(NativeMethods.ExtractIconEx(paths[0], int.Parse(paths[1], CultureInfo.InvariantCulture), hIconEx, null, 1));
                return Icon.FromHandle(hIconEx[0]);
            }
        }
    }
}