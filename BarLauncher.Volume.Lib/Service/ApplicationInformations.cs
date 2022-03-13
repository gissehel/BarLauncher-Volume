using BarLauncher.EasyHelper.Core.Service;
using BarLauncher.Volume.Lib.Core.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace BarLauncher.Volume.Lib.Service
{
    public class ApplicationInformations : IApplicationInformations
    {
        private ISystemService SystemService { get; set; }
        public ApplicationInformations(ISystemService systemService)
        {
            SystemService = systemService;
        }

        public string ApplicationName => SystemService.ApplicationName;

        public string Version => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;

        public string HomepageUrl => "https://github.com/gissehel/BarLauncher-Volume";
    }
}
