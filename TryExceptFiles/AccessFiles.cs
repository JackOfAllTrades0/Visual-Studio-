using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryExceptFiles
{
    internal class AccessFiles
    {
        private string FilePath;
        private string FileName;
        private string[] Contents;
        private AccessFiles(string Afilename, string Afilepath, string[]Acontents)
        {
            FileName = Afilename;
            FilePath = Afilepath;
            Contents = Acontents;
        }


    }
}
