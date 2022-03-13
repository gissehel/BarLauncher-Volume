using System;
using System.Collections.Generic;
using System.Text;

namespace BarLauncher.Volume.Core.Service
{
    public interface IVolumeService : IDisposable
    {
        int Volume { get; set; }

        void Init();
    }
}