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
    public class Change_volume_implicit : TestBase<VolumeContext>
    {
        public override void DoTest() =>
            StartTest()
            .IsRunnable()
            .Include<Prepare_common_context>()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Display_bar_launcher())
            .DoAction(f => f.Write_query("vol "))
            .EndUsing()

            .UsingList<BarLauncher_results_fixture>()
            .With<BarLauncher_results_fixture.Result>(r => r.Title, r => r.SubTitle)
            .Check("set [VALUE]", "Set volume to VALUE (current volume: 73)")
            .Check("change [+/-]", "Increase/decrease volume with symboles + or - (current volume: 73)")
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Append__on_query("+"))
            .DoCheck(f => f.The_current_query_is(), "vol change +")
            .EndUsing()

            .UsingList<BarLauncher_results_fixture>()
            .With<BarLauncher_results_fixture.Result>(r => r.Title, r => r.SubTitle)
            .Check("change [+/-]", "Increase/decrease volume with symboles + or - (current volume: 74)")
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()

            .DoAction(f => f.Append__on_query("+"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 75)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 74)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 73)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 72)")

            .DoCheck(f => f.The_current_query_is(), "vol change ++---")

            .DoAction(f => f.Select_line(1))

            .DoCheck(f => f.The_current_query_is(), "vol change ")

            .EndUsing()

            .EndTest();
    }
}
