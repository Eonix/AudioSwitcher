using System;
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
        private readonly AudioDeviceManger deviceEnumerator;
        private readonly NotifyIcon taskbarIcon;
        private const string AppName = "Audio Switcher";

        public App()
        {
            deviceEnumerator = new AudioDeviceManger();
            taskbarIcon = new NotifyIcon
            {
                Icon = AudioSwitcher.Properties.Resources.icon,
                Text = AppName,
                ContextMenuStrip = new ContextMenuStrip()
            };

            taskbarIcon.DoubleClick += IconOnDoubleClick;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            taskbarIcon.Visible = true;
            SetAudioDeviceMenuItems();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Dispose();
            base.OnExit(e);
        }

        private void SetAudioDeviceMenuItems()
        {
            var contextMenu = taskbarIcon.ContextMenuStrip;
            contextMenu.Items.Clear();

            var closeMenuItem = new ToolStripMenuItem { Text = "Exit" };
            closeMenuItem.Click += (o, args) => Current.Shutdown();

            contextMenu.Items.AddRange(GetAudioDevices());
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(closeMenuItem);
        }

        private ToolStripItem[] GetAudioDevices()
        {
            var devices = deviceEnumerator.AudioDevices.ToList();
            var deviceId = deviceEnumerator.DefaultDeviceId;

            var items = new ToolStripItem[devices.Count];
            for (var i = 0; i < devices.Count; i++)
            {
                var device = devices[i];

                var item = new ToolStripMenuItem
                {
                    Text = device.Name,
                    Image = device.Icon.ToBitmap(),
                    Checked = device.Id == deviceId
                };

                item.Click += (sender, args) => SetDefaultAudioDevice(device);
                items[i] = item;
            }

            return items;
        }

        private void SetDefaultAudioDevice(AudioDevice device)
        {
            deviceEnumerator.DefaultDeviceId = device.Id;
            ShowToolTip(device);
            SetAudioDeviceMenuItems();
        }

        private void IconOnDoubleClick(object sender, EventArgs eventArgs)
        {
            var devices = deviceEnumerator.AudioDevices.ToList();
            var currentDefaultDeviceId = deviceEnumerator.DefaultDeviceId;
            
            var indexOfCurrentDevice = devices.FindIndex(device => device.Id == currentDefaultDeviceId);
            var indexOfNextDevice = indexOfCurrentDevice == devices.Count - 1 ? 0 : indexOfCurrentDevice + 1;
            SetDefaultAudioDevice(devices[indexOfNextDevice]);
        }

        private void ShowToolTip(AudioDevice device)
        {
            taskbarIcon.BalloonTipTitle = "Audio Device Switched";
            taskbarIcon.BalloonTipText = device.Name;
            taskbarIcon.BalloonTipIcon = ToolTipIcon.Info;
            taskbarIcon.ShowBalloonTip(1000);
        }

        public void Dispose()
        {
            taskbarIcon.Dispose();
        }
    }
}
