using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zealous.Interfaces
{
    public interface IMapperSet
    {
         IList<IMap<object,object>> Maps { get; set; }
    }
}
