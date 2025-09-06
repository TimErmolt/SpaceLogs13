using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLogs13.Classes.Logs
{
    internal interface ILogMethods
    {
        string[] Lines();

        string[] Search(string keyword, bool case_sensitive = false);

        int CountLines(string keyword);
    }
}
