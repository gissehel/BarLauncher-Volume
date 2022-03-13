using BarLauncher.EasyHelper.Core.Service;
using BarLauncher.EasyHelper.Flow.Launcher;
using BarLauncher.Volume.Core.Service;
using BarLauncher.Volume.Lib.Service;
using BarLauncher.Volume.Win.Service;

namespace BarLauncher.Volume.Flow.Launcher
{
    public class VolumePlugin : FlowLauncherPlugin
    {
        public override IBarLauncherResultFinder PrepareContext()
        {
            IVolumeService volumeService = new VolumeService();
            IBarLauncherResultFinder volumeResultFinder = new VolumeResultFinder(BarLauncherContextService, volumeService);

            return volumeResultFinder;
        }
    }
}
