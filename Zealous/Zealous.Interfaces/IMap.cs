
namespace Zealous.Interfaces
{
    public interface IMap
    {
        IModel Map(IDBModel dbModel);
        IDBModel Map(IModel model);

        bool Applicable(IDBModel model);
        bool Applicable(IModel model);
    }
}
