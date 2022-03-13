using AllGreen.Lib.Core;
using AllGreen.Lib.Core.DomainModel.Script;
using AllGreen.Lib.Core.DomainModel.ScriptResult;
using AllGreen.Lib.DomainModel.ScriptResult;
using AllGreen.Lib.Engine.Service;

namespace BarLauncher.Volume.Test.AllGreen.Helper
{
    public class VolumeContext : IContext<VolumeContext>
    {
        public ITestScript<VolumeContext> TestScript { get; set; }
        public ITestScriptResult<VolumeContext> TestScriptResult { get; set; }

        public ApplicationStarter ApplicationStarter { get; set; }

        public void OnTestStart()
        {
            ApplicationStarter = new ApplicationStarter();
            ApplicationStarter.Init(TestScript.Name);
        }

        public void OnTestStop()
        {
            var testScriptResult = TestScriptResult as TestScriptResult<VolumeContext>;
            (new JsonOutputService()).Output(testScriptResult, ApplicationStarter.TestPath, testScriptResult.TestScript.Name);
            (new TextOutputService()).Output(testScriptResult, ApplicationStarter.TestPath, testScriptResult.TestScript.Name);
        }
    }
}
