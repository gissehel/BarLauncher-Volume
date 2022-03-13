using AllGreen.Lib;
using BarLauncher.Volume.Test.AllGreen.Helper;
using BarLauncher.Volume.Test.AllGreen.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarLauncher.Volume.Test.AllGreen.Test
{
    public class Set_volume_explicit : TestBase<VolumeContext>
    {
        public override void DoTest() =>
            StartTest()
            .IsRunnable()

            .Include<Prepare_common_context>()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Display_bar_launcher())
            .DoCheck(f => f.The_current_query_is(), "")
            .EndUsing()

            .UsingList<BarLauncher_results_fixture>()
            .With<BarLauncher_results_fixture.Result>(r => r.Title, r => r.SubTitle)
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Write_query("vol"))
            .EndUsing()

            .UsingList<BarLauncher_results_fixture>()
            .With<BarLauncher_results_fixture.Result>(r => r.Title, r => r.SubTitle)
            .Check("set [VALUE]", "Set volume to VALUE (current volume: 73)")
            .Check("change [+/-]", "Increase/decrease volume with symboles + or - (current volume: 73)")
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Append__on_query(" se"))
            .EndUsing()

            .UsingList<BarLauncher_results_fixture>()
            .With<BarLauncher_results_fixture.Result>(r => r.Title, r => r.SubTitle)
            .Check("set [VALUE]", "Set volume to VALUE (current volume: 73)")
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Append__on_query("t"))
            .EndUsing()

            .UsingList<BarLauncher_results_fixture>()
            .With<BarLauncher_results_fixture.Result>(r => r.Title, r => r.SubTitle)
            .Check("set [VALUE]", "Set volume to VALUE (current volume: 73)")
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Append__on_query(" "))
            .EndUsing()

            .UsingList<BarLauncher_results_fixture>()
            .With<BarLauncher_results_fixture.Result>(r => r.Title, r => r.SubTitle)
            .Check("set [VALUE]", "Set volume to VALUE (current volume: 73)")
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Append__on_query("4"))
            .EndUsing()

            .UsingList<BarLauncher_results_fixture>()
            .With<BarLauncher_results_fixture.Result>(r => r.Title, r => r.SubTitle)
            .Check("set 4", "Set volume to 4 (current volume: 73)")
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Append__on_query("1"))
            .EndUsing()

            .UsingList<BarLauncher_results_fixture>()
            .With<BarLauncher_results_fixture.Result>(r => r.Title, r => r.SubTitle)
            .Check("set 41", "Set volume to 41 (current volume: 73)")
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Select_line(1))
            .DoReject(f => f.Bar_launcher_is_displayed())
            .EndUsing()

            .Using<Volume_fixture>()
            .DoCheck(f => f.The_system_volum_is(), "41")
            .EndUsing()

            .Using<BarLauncher_bar_fixture>()
            .DoAction(f => f.Display_bar_launcher())
            .DoAction(f => f.Write_query("vol"))
            .DoCheck(f => f.The_number_of_results_is(), "2")
            .DoCheck(f => f.The_title_of_result__is(1), "set [VALUE]")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Set volume to VALUE (current volume: 41)")

            .DoAction(f => f.Write_query("vol set error"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_title_of_result__is(1), "set error")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Error: Don't understand [error]")

            .DoCheck(f => f.The_current_query_is(), "vol set error")
            .DoAction(f => f.Select_line(1))
            .DoAccept(f => f.Bar_launcher_is_displayed())
            .DoCheck(f => f.The_current_query_is(), "vol set ")

            .EndUsing()

            .EndTest();
    }
}