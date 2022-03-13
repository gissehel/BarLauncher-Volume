using AllGreen.Lib;
using BarLauncher.Volume.Test.AllGreen.Helper;

namespace BarLauncher.Volume.Test.AllGreen.Fixture
{
    public class Volume_fixture : FixtureBase<VolumeContext>
    {
        public void Change_the_system_volume_to(int volume)
        {
            Context.ApplicationStarter.VolumeService.Volume = volume;
        }
        public string The_system_volum_is()
        {
            return Context.ApplicationStarter.VolumeService.Volume.ToString();
        }
    }
}
