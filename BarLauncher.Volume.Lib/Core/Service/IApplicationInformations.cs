using System;
using System.Collections.Generic;
using System.Text;

namespace BarLauncher.Volume.Lib.Core.Service
{
    public interface IApplicationInformations
    {
        string ApplicationName { get; }

        string Version { get; }

        string HomepageUrl { get; }
    }
}
