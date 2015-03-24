using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using AudioSwitcher.Models;
using AudioSwitcher.Services;
using Hardcodet.Wpf.TaskbarNotification;

namespace AudioSwitcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public sealed partial class App : IDisposable
    {
        private readonly AudioDeviceManger deviceEnumerator;
        private const string AppName = "Audio Switcher";
        private TaskbarIcon taskbarIcon;

        public App()
        {
            deviceEnumerator = new AudioDeviceManger();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            taskbarIcon = new TaskbarIcon
            {
                Icon = AudioSwitcher.Properties.Resources.icon,
                ToolTipText = AppName,
                ContextMenu = new ContextMenu()
            };

            taskbarIcon.TrayMouseDoubleClick += IconOnDoubleClick;

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
            contextMenu.Items.Clear();

            var closeMenuItem = new MenuItem { Header = "Exit" };
            closeMenuItem.Click += (o, args) => Current.Shutdown();

            foreach (var device in GetAudioDevices())
            {
                contextMenu.Items.Add(device);
            }
            contextMenu.Items.Add(new Separator());
            contextMenu.Items.Add(closeMenuItem);
        }

        private IEnumerable<MenuItem> GetAudioDevices()
        {
            var devices = deviceEnumerator.AudioDevices.ToList();
            var deviceId = deviceEnumerator.DefaultDeviceId;

            var items = new MenuItem[devices.Count];
            for (int i = 0; i < devices.Count; i++)
            {
                var device = devices[i];

                var hbitmap = device.Icon.ToBitmap().GetHbitmap();
                var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());

                var item = new MenuItem
                {
                    IsChecked = device.Id == deviceId,
                    Header = device.Name,
                    Icon = new Image { Source = bitmapSource }
                };

                item.Click += (sender, args) => SetDefaultAudioDevice(device);
                items[i] = item;
            }

            return items;
        }

        private void SetDefaultAudioDevice(AudioDevice device)
        {
            deviceEnumerator.DefaultDeviceId = device.Id;
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
        }

        private void ShowToolTip(string deviceName)
        {
            taskbarIcon.ShowBalloonTip("Audio Device Switched", deviceName, BalloonIcon.Info);
        }

        public void Dispose()
        {
            taskbarIcon.Dispose();
        }
    }
}
