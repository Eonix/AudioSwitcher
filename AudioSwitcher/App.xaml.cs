using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using AudioSwitcher.Models;
using AudioSwitcher.Services;

namespace AudioSwitcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public sealed partial class App : IDisposable
    {
        private NotifyIcon icon;
        private ContextMenuStrip contextMenuStrip;
        private readonly AudioDeviceManger deviceEnumerator;
        private const string AppName = "Audio Switcher";
        private readonly Icon appIcon = AudioSwitcher.Properties.Resources.icon;

        public App()
        {
            deviceEnumerator = new AudioDeviceManger();
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            contextMenuStrip = new ContextMenuStrip();
            SetAudioDeviceMenuItems();

            icon = new NotifyIcon
            {
                Visible = true,
                Icon = appIcon,
                Text = AppName,
                ContextMenuStrip = contextMenuStrip
            };

            icon.DoubleClick += IconOnDoubleClick;

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Dispose();
            base.OnExit(e);
        }

        private void SetAudioDeviceMenuItems()
        {
            contextMenuStrip.Items.Clear();

            var closeMenuItem = new ToolStripMenuItem("Exit");
            closeMenuItem.Click += (o, args) => Current.Shutdown();

            contextMenuStrip.Items.AddRange(GetAudioDevices());
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                new ToolStripSeparator(),
                closeMenuItem,
            });
        }

        private ToolStripItem[] GetAudioDevices()
        {
            var devices = deviceEnumerator.AudioDevices.ToList();
            var deviceId = deviceEnumerator.DefaultDeviceId;

            var items = new ToolStripItem[devices.Count];
            for (int i = 0; i < devices.Count; i++)
            {
                var device = devices[i];
                var item = new ToolStripMenuItem
                {
                    Checked = device.Id == deviceId,
                    Text = device.Name,
                    Image = device.Icon
                };
                item.Click += (sender, args) => SetDefaultAudioDevice(device);
                items[i] = item;
            }

            return items;
        }

        private void SetDefaultAudioDevice(AudioDevice device)
        {
            deviceEnumerator.DefaultDeviceId= device.Id;
            ShowToolTip(device.Name);
            SetAudioDeviceMenuItems();
        }

        private void IconOnDoubleClick(object sender, EventArgs eventArgs)
        {
            var devices = deviceEnumerator.AudioDevices.ToList();
            var deviceId = deviceEnumerator.DefaultDeviceId;

            var index = 0;
            for (var i = 0; i < devices.Count; i++)
            {
                if (devices[i].Id == deviceId)
                    index = i + 1;
            }

            if (index == devices.Count)
                index = 0;

            SetDefaultAudioDevice(devices[index]);
            ShowToolTip(devices[index].Name);
        }

        private void ShowToolTip(string deviceName)
        {
            icon.ShowBalloonTip(5000, "Audio Device Switched", deviceName, ToolTipIcon.Info);
        }

        public void Dispose()
        {
            icon.Dispose();
            contextMenuStrip.Dispose();
            appIcon.Dispose();
        }
    }
}
