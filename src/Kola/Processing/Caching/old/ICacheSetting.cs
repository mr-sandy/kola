using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kola.Processing.Caching
{
    public interface ICacheSetting
    {
        ICacheSetting Merge(ICacheSetting other);
    }
}
