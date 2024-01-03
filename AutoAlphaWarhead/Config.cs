using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAlphaWarhead
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("Time when Warhead will be activating")]
        public int WarheadTime { get; set; } = 1200;
        [Description("Text which will be showing when auto warhead activated")]
        public string Text { get; set; } = "<color=red>Auto Warhead was activating</color>";
    }
}
