using BarLauncher.Volume.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarLauncher.Volume.Test.Mock.Service
{
    public class VolumeServiceMock : IVolumeService
    {
        private int _volume;
        public int Volume
        {
            get => _volume;
            set
            {
                if (value < 0)
                {
                    _volume = 0;
                }
                else if (value > 100)
                {
                    _volume = 100;
                }
                else
                {
                    _volume = value;
                }
            }
        }

        public void Init()
        {
        }

        public void Dispose()
        {
        }

    }
}
