using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsRouteLocator.Interfaces
{
    public interface ISearchHistoryWriter
    {
        void Write(IEnumerable<string> list);
    }
}
