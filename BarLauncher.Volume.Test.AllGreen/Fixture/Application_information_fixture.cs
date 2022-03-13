using AllGreen.Lib;
using BarLauncher.Volume.Test.AllGreen.Helper;

namespace BarLauncher.Volume.Test.AllGreen.Fixture
{
    public class Application_information_fixture : FixtureBase<VolumeContext>
    {
        public void Application_name_is(string name)
        {
            Context.ApplicationStarter.ApplicationInformations.ApplicationName = name;
        }

        public void Application_verison_is(string version)
        {
            Context.ApplicationStarter.ApplicationInformations.Version = version;
        }

        public void Application_url_is(string url)
        {
            Context.ApplicationStarter.ApplicationInformations.HomepageUrl = url;
        }
    }
}
