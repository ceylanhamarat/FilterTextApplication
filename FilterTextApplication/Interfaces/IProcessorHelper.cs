using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterTextApplication.Interfaces
{
    public interface IProcessorHelper
    {
        List<string> ProcessText(string filePath);
    }
}
