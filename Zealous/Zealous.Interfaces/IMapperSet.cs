using System.Collections.Generic;

namespace Zealous.Interfaces
{
    public interface IMapperSet
    {
        IList<IMap> Maps { get; set; }
    }
}