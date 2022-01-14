using System.Diagnostics.CodeAnalysis;

using TRVS.Core;

namespace TR3_Version_Swapper
{
    /// <inheritdoc/>
    // ReSharper doesn't detect the Activator.CreateInstance{T} usage
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class TR3VersionSwapper : VersionSwapperBase<TR3Directories>
    {
        protected override TRVSProgramData ProgramData { get; }
        protected override TRVSProgramManager ProgramManager { get; }
        protected override TR3Directories Directories { get; }

        public TR3VersionSwapper(TRVSProgramData programData, TRVSProgramManager programManager, TR3Directories directories)
        {
            ProgramData = programData;
            ProgramManager = programManager;
            Directories = directories;
        }

        /// <inheritdoc/>
        public override void SwapVersions()
        {
            throw new System.NotImplementedException();
        }
    }
}
