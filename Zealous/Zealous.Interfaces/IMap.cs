using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zealous.Interfaces
{
    public interface IMap
    {
        IModel Map(IDBModel dbModel);
        IDBModel Map(IModel model);
    }
}
