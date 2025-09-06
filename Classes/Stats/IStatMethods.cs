using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLogs13.Classes.Stats;

internal interface IStatMethods
{
    string[] GetRaw();
    string GetFormatted();
}
