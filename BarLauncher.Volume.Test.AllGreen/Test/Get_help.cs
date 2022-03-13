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
    public class Get_help : TestBase<VolumeContext>
    {
        public override void DoTest() =>
            StartTest()

            .IsRunnable()

            .Include<Prepare_common_context>()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Display_bar_launcher())
            .DoAction(f => f.Write_query("vol"))
            .EndUsing()

            .UsingList<BarLauncher_results_fixture>()
            .With<BarLauncher_results_fixture.Result>(r => r.Title, r=>r.SubTitle)
            .Check("set [VALUE]", "Set volume to VALUE (current volume: 73)")
            .Check("change [+/-]", "Increase/decrease volume with symboles + or - (current volume: 73)")
            .Check("help", "BarLauncher_Volume version 0.0.0 - (Go to BarLauncher_Volume main web site)")
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Append__on_query(" hel"))
            .EndUsing()

            .UsingList<BarLauncher_results_fixture>()
            .With<BarLauncher_results_fixture.Result>(r => r.Title, r => r.SubTitle)
            .Check("help", "BarLauncher_Volume version 0.0.0 - (Go to BarLauncher_Volume main web site)")
            .EndUsing()

            .UsingList<Url_opened_fixture>()
            .With<Url_opened_fixture.Result>(r => r.Url)
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Select_line(1))
            .EndUsing()

            .UsingList<Url_opened_fixture>()
            .With<Url_opened_fixture.Result>(r => r.Url)
            .Check("https://example.com/BarLauncher_Volume")
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoReject(f => f.Bar_launcher_is_displayed())
            .EndUsing()

            .EndTest();
    }
}
