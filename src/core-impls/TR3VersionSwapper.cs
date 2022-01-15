using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using TRVS.Core;

namespace TR3_Version_Swapper
{
    /// <inheritdoc/>
    // ReSharper doesn't detect the Activator.CreateInstance{T} usage
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class TR3VersionSwapper : VersionSwapperBase<TR3Directories>
    {
        /// <summary>
        ///     The user's <see cref="VersionPrompt"/> options.
        /// </summary>
        private enum Version
        {
            International = 1,
            Japanese = 2
        }
        
        /// <summary>
        ///     Mapping of <see cref="Version"/>s to directory <see langword="string"/>s.
        /// </summary>
        private static readonly Dictionary<Version, string> SelectionDictionary = new Dictionary<Version, string>
        {
            {Version.International, "International"},
            {Version.Japanese, "Japanese"},
        };

        private static readonly Dictionary<Version, List<string>> ExcessVersionFiles = new Dictionary<Version, List<string>>();
        private static readonly Dictionary<Version, List<string>> ExcessVersionDirectories = new Dictionary<Version, List<string>>();

        protected override TRVSProgramData ProgramData { get; }
        protected override TRVSProgramManager ProgramManager { get; }
        protected override TR3Directories Directories { get; }

        public TR3VersionSwapper(TRVSProgramData programData, TRVSProgramManager programManager, TR3Directories directories)
        {
            ProgramData = programData;
            ProgramManager = programManager;
            Directories = directories;

            ExcessVersionFiles.Add(
                Version.International,
                new List<string> { 
                    Path.Combine(Directories.Game, "fmv", "Crsh_Jap.rpl"),
                    Path.Combine(Directories.Game, "fmv", "Intr_Jap.rpl"),
                    Path.Combine(Directories.Game, "fmv", "Sail_Jap.rpl"),
                    Path.Combine(Directories.Game, "support", "info", "Readme_uk.txt"),
                    Path.Combine(Directories.Game, "support", "info", "Support_uk.htm")
                }
            );
            ExcessVersionFiles.Add(
                Version.Japanese,
                new List<string> { 
                    Path.Combine(Directories.Game, "installscript.vdf"),
                    Path.Combine(Directories.Game, "fmv", "Crsh_Eng.rpl"),
                    Path.Combine(Directories.Game, "fmv", "Intr_Eng.rpl"),
                    Path.Combine(Directories.Game, "fmv", "Sail_Eng.rpl")
                }
            );
            ExcessVersionDirectories.Add(
                Version.International,
                new List<string> { 
                    Path.Combine(Directories.Game, "support", "drivers")
                }
            );
        }

        /// <inheritdoc/>
        public override void SwapVersions()
        {
            HandleVersions();
        }

        /// <summary>
        ///     Prompts, then returns the directory of the user's chosen version.
        /// </summary>
        /// <returns>
        ///     The folder name of the chosen version
        /// </returns>
        private Version VersionPrompt()
        {
            PrintVersionList();
            string choice = string.Empty;
            int selectionNumber = 0;
            while (selectionNumber < 1 || selectionNumber > 2)
            {
                Console.Write("Enter your desired version number, or enter nothing for the default [2]: ");
                choice = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(choice))
                    selectionNumber = 2;
                else
                    int.TryParse(choice, out selectionNumber);
            }

            var selectedVersion = (Version)selectionNumber;
            ProgramData.NLogger.Debug($"User input `{choice}`, interpreting as {selectedVersion}");
            return selectedVersion;
        }

        /// <summary>
        ///     Asks the user which version they want, then acts appropriately.
        /// </summary>
        private void HandleVersions()
        {
            Version selectedVersion = VersionPrompt();
            string selectedVersionText = SelectionDictionary[selectedVersion];

            // Copy files from selected version into installation folder.
            string versionDir = Path.Combine(Directories.Versions, selectedVersionText);
            TryCopyingDirectory(versionDir, Directories.Game);
            ProgramData.NLogger.Info($"Installed {selectedVersionText} successfully.");
            
            // Cleanup possibly remaining files that are not part of the selected version.
            DeleteExcessFiles(selectedVersion);
            DeleteExcessDirectories(selectedVersion);

            // Success!
            ConsoleIO.PrintHeader($"{selectedVersionText} successfully installed!", foregroundColor: ConsoleColor.Green);
            Console.WriteLine();
        }
        
        /// <summary>
        ///     Pretty-prints a numbered list of versions the user can choose.
        /// </summary>
        private static void PrintVersionList()
        {
            Console.WriteLine("Version List:");
            for (int i = 1; i <= SelectionDictionary.Values.Count; ++i)
            {
                string name = SelectionDictionary[(Version) i];
                Console.WriteLine($"\t{i}: {name}");
            }
        }

        /// <summary>
        ///     If applicable, deletes excess files that are not part of the version just installed.
        /// </summary>
        /// <param name="newlyInstalledVersion">The newly-installed <see cref="Version"/></param>
        private void DeleteExcessFiles(Version newlyInstalledVersion)
        {
            if (ExcessVersionFiles.TryGetValue(newlyInstalledVersion, out List<string> excessFilesToDeleteForThisVersion))
            {
                if (!TryDeletingFiles(excessFilesToDeleteForThisVersion))
                {
                    Console.WriteLine("Failed to delete excess files from old installation.");
                    Console.WriteLine("This does not affect your version's behavior or leaderboard compatibility.");
                }
                ProgramData.NLogger.Info($"Deleted excess files successfully.");
            }
            else
            {
                ProgramData.NLogger.Info($"No excess files to delete.");
            }
        }

        /// <summary>
        ///     If applicable, deletes excess directories that are not part of the version just installed.
        /// </summary>
        /// <param name="newlyInstalledVersion">The newly-installed <see cref="Version"/></param>
        private void DeleteExcessDirectories(Version newlyInstalledVersion)
        {
            if (ExcessVersionDirectories.TryGetValue(newlyInstalledVersion, out List<string> excessDirsToDelete))
            {
                if (!TryDeletingDirectories(excessDirsToDelete, recursive: true))
                {
                    Console.WriteLine("Failed to delete excess directories from old installation.");
                    Console.WriteLine("This does not affect your version's behavior or leaderboard compatibility.");
                }
                ProgramData.NLogger.Info($"Deleted excess directories successfully.");
            }
            else
            {
                ProgramData.NLogger.Info($"No excess directories to delete.");
            }
        }
    }
}
