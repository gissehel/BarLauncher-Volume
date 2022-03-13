using AllGreen.Lib;
using BarLauncher.Volume.Test.AllGreen.Fixture;
using BarLauncher.Volume.Test.AllGreen.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarLauncher.Volume.Test.AllGreen.Test
{
    public class Prepare_common_context : TestBase<VolumeContext>
    {
        public override void DoTest() =>
            StartTest()

            .Using<Application_information_fixture>()
            .DoAction(f => f.Application_name_is("BarLauncher_Volume"))
            .DoAction(f => f.Application_verison_is("0.0.0"))
            .DoAction(f => f.Application_url_is("https://example.com/BarLauncher_Volume"))
            .EndUsing()

            .Using<Volume_fixture>()
            .DoAction(f => f.Change_the_system_volume_to(73))
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Start_the_bar())
            .EndUsing()

            .EndTest();
    }
}
