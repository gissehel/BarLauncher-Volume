using AllGreen.Lib;
using BarLauncher.Volume.Test.AllGreen.Fixture;
using BarLauncher.Volume.Test.AllGreen.Helper;

namespace BarLauncher.Volume.Test.AllGreen.Test
{
    public class Change_volume_adaptative : TestBase<VolumeContext>
    {
        public override void DoTest() => 
            StartTest()

            .IsRunnable()
            .Include<Prepare_common_context>()

            .Using<BarLauncher_bar_fixture>()

            .DoAction(f => f.Display_bar_launcher())

            .DoAction(f => f.Write_query("vol change "))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 73)")

            .DoAction(f => f.Append__on_query("+"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 74)")

            .DoAction(f => f.Append__on_query("+"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 75)")

            .DoAction(f => f.Append__on_query("+"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 76)")

            .DoAction(f => f.Append__on_query("+"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 77)")

            .DoAction(f => f.Append__on_query("+"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 79)")

            .DoAction(f => f.Append__on_query("+"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 82)")

            .DoAction(f => f.Append__on_query("+"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 86)")

            .DoAction(f => f.Append__on_query("+"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 91)")

            .DoAction(f => f.Append__on_query("+"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 96)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 95)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 94)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 93)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 92)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 90)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 87)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 83)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 78)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 73)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 68)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 63)")

            .DoAction(f => f.Append__on_query("-"))
            .DoCheck(f => f.The_number_of_results_is(), "1")
            .DoCheck(f => f.The_subtitle_of_result__is(1), "Increase/decrease volume with symboles + or - (current volume: 58)")

            .EndUsing()

            .EndTest();
    }
}
