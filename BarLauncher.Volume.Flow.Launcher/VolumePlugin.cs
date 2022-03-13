using BarLauncher.EasyHelper.Core.Service;
using BarLauncher.EasyHelper.Flow.Launcher;
using BarLauncher.EasyHelper.Service;
using BarLauncher.Volume.Core.Service;
using BarLauncher.Volume.Lib.Core.Service;
using BarLauncher.Volume.Lib.Service;
using BarLauncher.Volume.Win.Service;

namespace BarLauncher.Volume.Flow.Launcher
{
    public class VolumePlugin : FlowLauncherPlugin
    {
        public override IBarLauncherResultFinder PrepareContext()
        {
            IVolumeService volumeService = new VolumeService();
            ISystemService systemService = new SystemService("BarLauncher_Volume");
            IApplicationInformations applicationInformations = new ApplicationInformations(systemService);
            IBarLauncherResultFinder volumeResultFinder = new VolumeResultFinder(BarLauncherContextService, volumeService, applicationInformations, systemService);

            return volumeResultFinder;
        }
    }
}
