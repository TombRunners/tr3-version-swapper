using System.IO;

using TRVS.Core;

namespace TR3_Version_Swapper
{
    /// <inheritdoc cref="IDirectories"/>
    internal class TR3Directories : IDirectories
    {
        /// <inheritdoc/>
        public string Game { get; }

        public TR3Directories()
        {
            string root = Path.GetFullPath(Directory.GetCurrentDirectory());
            Game = Directory.GetParent(root).FullName;
        }
    }
}
