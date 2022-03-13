using BarLauncher.Volume.Lib.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarLauncher.Volume.Test.Mock.Service
{
    public class ApplicationInformationsMock : IApplicationInformations
    {
        public string ApplicationName { get; set; }

        public string Version { get; set; }

        public string HomepageUrl { get; set; }
    }
}
