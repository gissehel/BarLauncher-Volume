using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarLauncher.EasyHelper.Core.Service;
using BarLauncher.EasyHelper.Wox;
using BarLauncher.Volume.Core.Service;
using BarLauncher.Volume.Lib.Service;
using BarLauncher.Volume.Win.Service;

namespace BarLauncher.Volume.Wox
{
    public class VolumePlugin : WoxPlugin
    {
        public override IBarLauncherResultFinder PrepareContext()
        {
            IVolumeService volumeService = new VolumeService();
            IBarLauncherResultFinder volumeResultFinder = new VolumeResultFinder(BarLauncherContextService, volumeService);

            return volumeResultFinder;
        }
    }
}
