
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using SpeechAndTTS;

namespace SDKTemplate
{
    public partial class MainPage : Page
    {
        public const string FEATURE_NAME = "Cyborg";

        List<Scenario> scenarios = new List<Scenario>
        {
            new Scenario() { Title="Cyborg", ClassType=typeof(PredefinedDictationGrammarScenario)},
            new Scenario() { Title="About Us", ClassType=typeof(PredefinedDictationGrammarScenario)},
            new Scenario() { Title="Help", ClassType=typeof(PredefinedDictationGrammarScenario)},
            new Scenario() { Title="Developers", ClassType=typeof(PredefinedDictationGrammarScenario)},
          };
    }

    public class Scenario
    {
        public string Title { get; set; }
        public Type ClassType { get; set; }
    }
}
