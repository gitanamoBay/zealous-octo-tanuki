using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zealous.Interfaces
{
    public interface IMap<T,T2>
    {
        IModel Map(IDBModel dbModel);
        IDBModel Map(IModel model);

        bool Applicable(IDBModel model);
        bool Applicable(IModel model);
    }
}
