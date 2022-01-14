using System;
using System.Collections.Generic;

using TRVS.Core;

namespace TR3_Version_Swapper
{
    /// <inheritdoc cref="IFileAudit"/>
    internal class TR3FileAudit : IFileAudit
    {
        /// <inheritdoc/>
        public IEnumerable<string> GameFiles
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
