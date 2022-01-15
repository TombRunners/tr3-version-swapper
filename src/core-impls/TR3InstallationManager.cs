using TRVS.Core;

namespace TR3_Version_Swapper
{
    internal class TR3InstallationManager : InstallationManagerBase<TR3Directories, TR3FileAudit>
    {
        protected override TRVSProgramData ProgramData { get; }
        protected override TRVSProgramManager ProgramManager { get; }
        protected override TR3FileAudit FileAudit { get; }
        protected override TR3Directories Directories { get; }

        public TR3InstallationManager(TRVSProgramData programData, TRVSProgramManager programManager, TR3FileAudit fileAudit, TR3Directories directories)
        {
            ProgramData = programData;
            ProgramManager = programManager;
            FileAudit = fileAudit;
            Directories = directories;
        }

        protected override void ValidatePackagedFiles()
        {
            // Check that each version's game files are present and unmodified.
            ValidateMd5Hashes(TR3FileAudit.VersionFilesAudit, Directories.Versions);
        }
    }
}
