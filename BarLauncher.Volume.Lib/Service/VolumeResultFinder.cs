using BarLauncher.EasyHelper;
using BarLauncher.EasyHelper.Core.Service;
using BarLauncher.Volume.Core.Service;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BarLauncher.Volume.Lib.Service
{
    public class VolumeResultFinder : BarLauncherResultFinder
    {
        private IVolumeService VolumeService { get; set; }

        public VolumeResultFinder(IBarLauncherContextService barLauncherContextService, IVolumeService volumeService) : base(barLauncherContextService)
        {
            VolumeService = volumeService;
        }

        public override void Init()
        {
            VolumeService.Init();
            InitCommands();
        }

        public void InitCommands()
        {
            AddCommand("set", () => "set [VALUE]", () => "Set volume to VALUE (current volume: {0})".FormatWith(VolumeService.Volume), VolumeCommand);
            AddCommand("change", () => "change [+/-]", () => "Increase/decrease volume with symboles + or - (current volume: {0})".FormatWith(VolumeService.Volume), ChangeCommand);

            AddDefaultCommand(VolumeCommand);
        }

        public IEnumerable<BarLauncherResult> VolumeCommand(BarLauncherQuery query, int position)
        {
            var terms = query.GetSearchTermsStarting(position);
            BarLauncherResult result = null;
            if (terms.Count() > 1)
            {
                result = GetCompletionResult("set [VALUE]", "Error: Only one value can be entered", () => "set");
            }
            else if (terms.Count() == 1)
            {
                var newVolumeString = terms.ElementAt(0);
                if (newVolumeString.EndsWith("+") || newVolumeString.EndsWith("-"))
                {
                    LastChangeQuery = newVolumeString.Substring(0, newVolumeString.Length - 1);
                    foreach (var r in ChangeCommand(query, position))
                    {
                        yield return r;
                    }
                }
                else
                {
                    try
                    {
                        var newVolume = Convert.ToInt32(newVolumeString);
                        result = GetActionResult
                            (
                                "set {0}".FormatWith(newVolume),
                                "Set volume to {0} (current volume: {1})".FormatWith(newVolume, VolumeService.Volume),
                                () =>
                                {
                                    VolumeService.Volume = newVolume;
                                    BarLauncherContextService.ChangeQuery(query.Command);
                                }
                            );
                    }
                    catch
                    {
                        result = GetCompletionResult
                            (
                                "set {0}".FormatWith(newVolumeString),
                                "Error: Don't understand [{0}]".FormatWith(newVolumeString),
                                () => "set"
                            );
                    }
                }
            }
            else if (terms.Count() == 0)
            {
                result = GetEmptyCommandResult("set", CommandInfos);
            }

            if (result != null)
            {
                yield return result;
            }
        }

        private string LastChangeQuery { get; set; } = null;

        private char LastSens { get; set; } = ' ';
        private int AdaptativeIncrement { get; set; } = 1;
        private int AdaptativeIncrementRounds { get; set; } = 0;

        private void ChangeSound(char c)
        {
            if (LastSens == c)
            {
                if (AdaptativeIncrementRounds >= 3)
                {
                    if (AdaptativeIncrement < 5)
                    {
                        AdaptativeIncrement += 1;
                    }
                }
                AdaptativeIncrementRounds++;
            }
            else
            {
                LastSens = c;
                AdaptativeIncrement = 1;
                AdaptativeIncrementRounds = 0;
            }
            if (c == '+')
            {
                if (VolumeService.Volume < 100)
                {
                    VolumeService.Volume += AdaptativeIncrement;
                }
            }
            if (c == '-')
            {
                if (VolumeService.Volume > 0)
                {
                    VolumeService.Volume -= AdaptativeIncrement;
                }
            }
        }

        public IEnumerable<BarLauncherResult> ChangeCommand(BarLauncherQuery query, int position)
        {
            var terms = query.GetAllSearchTermsStarting(position);

            if (terms == null)
            {
                terms = "";
            }

            bool sequence = false;

            if ((LastChangeQuery != null) && (terms != null))
            {
                if (terms.StartsWith(LastChangeQuery))
                {
                    sequence = true;
                    var newChars = terms.Substring(LastChangeQuery.Length, terms.Length - LastChangeQuery.Length);
                    foreach (var c in newChars)
                    {
                        ChangeSound(c);
                    }
                }
            }

            if (!sequence)
            {
                LastSens = ' ';
                AdaptativeIncrement = 1;
                AdaptativeIncrementRounds = 0;
            }
            LastChangeQuery = terms;

            var expectedQuery = BarLauncherContextService.ActionKeyword + BarLauncherContextService.Seperater + "change" + BarLauncherContextService.Seperater + terms;
            if (query.RawQuery.Trim(' ') != expectedQuery.Trim(' '))
            {
                BarLauncherContextService.ChangeQuery(expectedQuery);
            }

            yield return GetEmptyCommandResult("change", CommandInfos); ;
        }

        public override void Dispose()
        {
            base.Dispose();
            VolumeService.Dispose();
        }

    }
}