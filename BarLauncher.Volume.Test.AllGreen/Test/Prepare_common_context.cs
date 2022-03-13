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

            .Using<Volume_fixture>()
            .DoAction(f => f.Change_the_system_volume_to(73))
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Start_the_bar())
            .EndUsing()

            .EndTest();
    }
}
