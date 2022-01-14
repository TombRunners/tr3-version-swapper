using TRVS.Core;

namespace TR3_Version_Swapper
{
    internal class TR3Program 
        : ProgramBase<TR3Directories, TR3FileAudit, TR3InstallationManager, TR3VersionSwapper>
    {
        protected override TR3Directories Directories => new TR3Directories();
        protected override TR3FileAudit FileAudit => new TR3FileAudit();

        protected override TRVSProgramData ProgramData => new TRVSProgramData
        {
            GameAbbreviation = "TR3",
            GameExe = "tomb3",
            NLogger = NLog.LogManager.GetCurrentClassLogger(),
            MiscInfo = new TR3MiscInfo(),
            Settings = new TRVSUserSettings(),
            Version = typeof(Program).Assembly.GetName().Version
        };
    }
}
