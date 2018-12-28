using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynManager
{
    internal class CloudStorage
    {
        public static bool ProcessIsRunnig(string _process)
        {
            if (System.Diagnostics.Process.GetProcessesByName(_process).Any())
                return true;
            return false;
        }
    }
}
