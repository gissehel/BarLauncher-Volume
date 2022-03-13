using BarLauncher.EasyHelper.Test.Mock.Service;
using BarLauncher.Volume.Lib.Service;
using BarLauncher.Volume.Test.Mock.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BarLauncher.Volume.Test.AllGreen.Helper
{
    public class ApplicationStarter
    {
        public string TestName { get; set; }
        public string TestPath { get; set; }

        public ApplicationInformationsMock ApplicationInformations { get; set; }

        public BarLauncherContextServiceMock BarLauncherContextService { get; set; }

        public QueryServiceMock QueryService { get; set; }
        
        public VolumeResultFinder VolumeResultFinder { get; set; }

        public VolumeServiceMock VolumeService { get; set; }

        public SystemServiceMock SystemService { get; set; }

        public ApplicationStarter()
        {
        }

        public void Init(string testName)
        {
            TestName = testName;
            TestPath = GetApplicationDataPath(testName);

            ApplicationInformations = new ApplicationInformationsMock();
            SystemService = new SystemServiceMock();
            QueryService = new QueryServiceMock();
            BarLauncherContextService = new BarLauncherContextServiceMock(QueryService);
            VolumeService = new VolumeServiceMock();
            VolumeResultFinder = new VolumeResultFinder(BarLauncherContextService, VolumeService, ApplicationInformations, SystemService);

            BarLauncherContextService.AddQueryFetcher("vol", VolumeResultFinder);
        }

        public void Start()
        {
            VolumeResultFinder.Init();
        }

        private static string GetThisAssemblyDirectory()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var thisAssemblyCodeBase = assembly.Location;
            var thisAssemblyDirectory = Path.GetDirectoryName(new Uri(thisAssemblyCodeBase).LocalPath);

            return thisAssemblyDirectory;
        }

        private string GetApplicationDataPath(string testName)
        {
            var thisAssemblyDirectory = GetThisAssemblyDirectory();
            var path = Path.Combine(Path.Combine(thisAssemblyDirectory, "AllGreen"), string.Format("AG_{0:yyyyMMdd-HHmmss-fff}_{1}", DateTime.Now, testName));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }
}
