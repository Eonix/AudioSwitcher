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
                ContextMenu = new ContextMenu()
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
            var contextMenu = taskbarIcon.ContextMenu;
            contextMenu.MenuItems.Clear();

            var closeMenuItem = new MenuItem { Text = "Exit" };
            closeMenuItem.Click += (o, args) => Current.Shutdown();

            contextMenu.MenuItems.AddRange(GetAudioDevices());
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add(closeMenuItem);
        }

        private MenuItem[] GetAudioDevices()
        {
            var devices = deviceEnumerator.AudioDevices.ToList();
            var deviceId = deviceEnumerator.DefaultDeviceId;

            var items = new MenuItem[devices.Count];
            for (var i = 0; i < devices.Count; i++)
            {
                var device = devices[i];

                var item = new MenuItem
                {
                    Text = device.Name,
                    Checked = device.Id == deviceId
                };

                item.Click += (sender, args) => SetDefaultAudioDevice(device);
                items[i] = item;
            }

            return items;
        }

        private void SetDefaultAudioDevice(AudioDevice device)
        {
            if (deviceEnumerator.DefaultDeviceId == device.Id)
                return;

            deviceEnumerator.DefaultDeviceId = device.Id;
            ShowToolTip(device, "Audio Device Switched");
            SetAudioDeviceMenuItems();
        }

        private void IconOnDoubleClick(object sender, EventArgs eventArgs)
        {
            var devices = deviceEnumerator.AudioDevices.ToList();
            var currentDefaultDeviceId = deviceEnumerator.DefaultDeviceId;
            
            var indexOfCurrentDevice = devices.FindIndex(device => device.Id == currentDefaultDeviceId);
            var indexOfNextDevice = indexOfCurrentDevice == devices.Count - 1 ? 0 : indexOfCurrentDevice + 1;
            var nextAudioDevice = devices[indexOfNextDevice];

            if (nextAudioDevice.Id != currentDefaultDeviceId)
                SetDefaultAudioDevice(nextAudioDevice);
        }

        private void ShowToolTip(AudioDevice device, string message)
        {
            taskbarIcon.BalloonTipTitle = message;
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
