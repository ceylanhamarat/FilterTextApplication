using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterText.Interfaces
{
    public interface IFilter
    {
        string[] Filter(string[] words);
    }
}
