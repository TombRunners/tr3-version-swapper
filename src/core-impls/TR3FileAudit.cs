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
                // Root directory
                yield return "data.bin";
                yield return "DATA.TAG";
                yield return "DEC130.DLL";
                yield return "EDEC.DLL";
                yield return "lang.dat";
                yield return "layout.bin";
                yield return "os.dat";
                yield return "tomb3.exe";
                yield return "WINPLAY.DLL";
                yield return "WINSDEC.DLL";
                yield return "WINSTR.DLL";
                // Audio
                yield return "audio/cdaudio.wad";
                // Cutscenes
                yield return "cuts/CUT1.TR2";
                yield return "cuts/CUT2.TR2";
                yield return "cuts/CUT3.TR2";
                yield return "cuts/CUT4.TR2";
                yield return "cuts/CUT5.TR2";
                yield return "cuts/CUT6.TR2";
                yield return "cuts/CUT7.TR2";
                yield return "cuts/CUT8.TR2";
                yield return "cuts/CUT9.TR2";
                yield return "cuts/CUT11.TR2";
                yield return "cuts/CUT12.TR2";
                // Data
                yield return "data/ANTARC.TR2";
                yield return "data/AREA51.TR2";
                yield return "data/CHAMBER.TR2";
                yield return "data/CITY.TR2";
                yield return "data/COMPOUND.TR2";
                yield return "data/CRASH.TR2";
                yield return "data/HOUSE.TR2";
                yield return "data/JUNGLE.TR2";
                yield return "data/MAIN.SFX";
                yield return "data/MINES.TR2";
                yield return "data/NEVADA.TR2";
                yield return "data/OFFICE.TR2";
                yield return "data/QUADCHAS.TR2";
                yield return "data/RAPIDS.TR2";
                yield return "data/ROOFS.TR2";
                yield return "data/SEWER.TR2";
                yield return "data/SHORE.TR2";
                yield return "data/STPAUL.TR2";
                yield return "data/TEMPLE.TR2";
                yield return "data/TITLE.TR2";
                yield return "data/TOMBPC.DAT";
                yield return "data/TONYBOSS.TR2";
                yield return "data/TOWER.TR2";
                yield return "data/TRIBOSS.TR2";
                yield return "data/VICT.TR2";
                // FMV
                yield return "FMV/Endgame.rpl";
                yield return "FMV/logo.rpl";
            }
        }

        /// <summary>
        ///     Maps packaged version files to their MD5 hashes.
        /// </summary>
        internal static readonly Dictionary<string, string> VersionFilesAudit = new Dictionary<string, string>
        {
            {"International/DATA.TAG", "61f1377c2123f1c971cbfbf9c7ce8faf"},
            {"International/lang.dat", "90e64689804b4f4b0197c07290965a3c"},
            {"International/layout.bin", "d0f7f7eda9e692eac06b32813a86e0c3"},
            {"International/os.dat", "af1d8d9435cb10fe2f4b4215eaf6bec4"},
            {"International/tomb3.exe", "4044dc2c58f02bfea2572e80dd8f2abb"},
            {"International/WINPLAY.DLL", "4ee5d4026f15c967ed3ae599885018b0"},
            {"International/WINSTR.DLL", "bd9397ee53c1dbe34d1b4fc168d8025e"},
            {"International/audio/cdaudio.wad", "0e4643dc86f0228969c0e0c1b30c0711"},
            {"International/data/ANTARC.TR2", "80f7907ded8a372bb87b1bcea178f94e"},
            {"International/data/CRASH.TR2", "ab8b5f6f568432666aaf5c4d83b9f6f2"},
            {"International/data/JUNGLE.TR2", "9befdc5075fdb84450d2ed0533719b12"},
            {"International/data/MAIN.SFX", "508ba45acbe4317e23daaf54ba919d04"},
            {"International/data/OFFICE.TR2", "ba54a5782912a4ef83929f687009377e"},
            {"International/data/QUADCHAS.TR2", "ee80c9522dffc40aef5576de09ad5ded"},
            {"International/data/RAPIDS.TR2", "f080de24577654474fa1ebd6d07673e2"},
            {"International/data/ROOFS.TR2", "9b3f54902d526472008408949f23032b"},
            {"International/data/TEMPLE.TR2", "18af2d4384904bf48c6941fb51382672"},
            {"International/data/TOMBPC.DAT", "3ae21d4e98daf1692a1eaf0acd9d6958"},
            {"International/fmv/Crsh_Eng.rpl", "ee2d0aa76754fe0744c47f4ad9fcd607"},
            {"International/fmv/Intr_Eng.rpl", "3afa8b9903af0c8dabee5f6f1eb396d0"},
            {"International/fmv/Sail_Eng.rpl", "6947a8a13b70235f9fc1aa3ea4db1da9"},
            {"Japanese/DATA.TAG", "0fecd62136b09b4421442352ef557395"},
            {"Japanese/lang.dat", "cccaae5c8a23eae65df80531a235f6e8"},
            {"Japanese/layout.bin", "9163be32a20d0c8dab68ae8168bdd398"},
            {"Japanese/os.dat", "478f65a0b922b6ba0a6ce99e1d15c336"},
            {"Japanese/tomb3.exe", "66404f58bb5dbf30707abfd245692cd2"},
            {"Japanese/WINPLAY.DLL", "e1cd821e799f27721edea04bc246c762"},
            {"Japanese/WINSTR.DLL", "31269ef2475300687fd75c33e39c2062"},
            {"Japanese/AUDIO/cdaudio.wad", "4a9e43f013e8b8ccc971c05ce3648d93"},
            {"Japanese/DATA/ANTARC.TR2", "69de74c84ee731954d5c361d5f4e499a"},
            {"Japanese/DATA/CRASH.TR2", "7a1d32cdf7b16f04dad25b6801c2dc79"},
            {"Japanese/DATA/JUNGLE.TR2", "87afb1ac476fcd2e1f76c0001c72b999"},
            {"Japanese/DATA/MAIN.SFX", "e37fc4bb6bb7d99738cb1f539d657931"},
            {"Japanese/DATA/OFFICE.TR2", "66d4c033f2abe0ebd12c53c560a9e0de"},
            {"Japanese/DATA/QUADCHAS.TR2", "18c5c2a5ae795475dbc0cc540235f4c7"},
            {"Japanese/DATA/RAPIDS.TR2", "e6d73a2d4fec1a8fb7233320df1498ad"},
            {"Japanese/DATA/ROOFS.TR2", "39284a8eeee905e2aa83060d4eef6cc1"},
            {"Japanese/DATA/TEMPLE.TR2", "cf2250621717ca0c03342f8fd07bc6e5"},
            {"Japanese/DATA/TOMBPC.DAT", "8801ab5bc4a1730736c8d19954d10ab1"},
            {"Japanese/FMV/Crsh_Jap.rpl", "acc3d501e37718c6878f8e78d185d4c6"},
            {"Japanese/FMV/Intr_Jap.rpl", "2594a97c71477230bc4675385e7fc240"},
            {"Japanese/FMV/Sail_Jap.rpl", "879b72a646fe675fbc1172bcfb8dc596"}
        };
    }
}
