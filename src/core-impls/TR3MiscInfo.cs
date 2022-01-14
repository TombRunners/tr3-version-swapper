using System.Collections.Generic;

using TRVS.Core;

namespace TR3_Version_Swapper
{
    /// <inheritdoc/>
    internal class TR3MiscInfo : MiscInfoBase
    {
        /// <inheritdoc/>
        public override IEnumerable<string> AsciiArt => new []
        {
            @"    _______ _____  _____                   ",
            @"   |__   __|  __ \|___  \              	 ",
            @"      | |  | |__) |  _| |               	 ",
            @"      | |  |  _  /  |_  |              	 ",
            @"      | |  | | \ \ ___| |            		 ",
            @"__    |_|_ |_|  \_\_____/                  ",
            @"\ \    / /          (_)                    ",
            @" \ \  / /__ _ __ ___ _  ___  _ __          ",
            @"  \ \/ / _ \ '__/ __| |/ _ \| '_ \         ",
            @"   \  /  __/ |  \__ \ | (_) | | | |        ",
            @"  __\/_\___|_|  |___/_|\___/|_| |_|        ",
            @" / ____|                                   ",
            @"| (_____      ____ _ _ __  _ __   ___ _ __ ",
            @" \___ \ \ /\ / / _` | '_ \| '_ \ / _ \ '__|",
            @" ____) \ V  V / (_| | |_) | |_) |  __/ |   ",
            @"|_____/ \_/\_/ \__,_| .__/| .__/ \___|_|   ",
            @"                    | |   | |              ",
            @"                    |_|   |_|              "
        };

        /// <inheritdoc/>
        public override string RepoLink => "https://github.com/TombRunners/tr3-version-swapper/";

        /// <inheritdoc/>
        public override string LatestReleaseLink => "https://github.com/TombRunners/tr3-version-swapper/releases/latest";
    }
}
