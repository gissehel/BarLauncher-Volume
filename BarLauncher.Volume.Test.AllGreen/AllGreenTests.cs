using AllGreen.Lib;
using AllGreen.Lib.Core.Engine.Service;
using AllGreen.Lib.Engine.Service;
using BarLauncher.EasyHelper;
using BarLauncher.Volume.Test.AllGreen.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace BarLauncher.Volume.Test.AllGreen
{
    public class AllGreenTests
    {
        private static readonly ITestRunnerService _testRunnerService = new TestRunnerService();

        private static readonly TestFinder<VolumeContext> _testFinder = new TestFinder<VolumeContext>()
        {
            Assembly = Assembly.GetExecutingAssembly(),
        };

        public static IEnumerable<object[]> GetTestScriptNames() => _testFinder.GetNames().Select(name => new object[] { name });

        [Theory]
        [MemberData(nameof(GetTestScriptNames))]
        public void Run(string name)
        {
            var testScript = _testFinder.GetTestScript(name);
            if (testScript != null)
            {
                var result = _testRunnerService.RunTest(testScript);

                Assert.NotNull(result);
                Assert.True(result.Success, result.PipedName);
            }
            else
            {
                Assert.True(false, "Don't know [{0}] as a test name !".FormatWith(name));
            }
        }
    }
}
