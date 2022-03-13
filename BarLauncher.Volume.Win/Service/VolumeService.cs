using AudioSwitcher.AudioApi.CoreAudio;
using BarLauncher.Volume.Core.Service;
using System;

namespace BarLauncher.Volume.Win.Service
{
    public class VolumeService : IVolumeService
    {
        private CoreAudioDevice DefaultPlaybackDevice { get; set; }

        public int Volume
        {
            get => DefaultPlaybackDevice == null ? 0 : Convert.ToInt32(DefaultPlaybackDevice.Volume);
            set
            {
                if (DefaultPlaybackDevice != null)
                {
                    DefaultPlaybackDevice.Volume = value;
                }

            }
        }

        public VolumeService()
        {
        }

        public void Init()
        {
            DefaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
        }

        public void Dispose()
        {
            DefaultPlaybackDevice.Dispose();
        }
    }
}
