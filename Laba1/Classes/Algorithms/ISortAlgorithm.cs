using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Classes.Algorithms
{
    public interface ISortAlgorithm
    {
        string Name { get; }
        int Sort(int[] array);
    }
}


