namespace Zealous.Interfaces
{
    public interface IMap
    {
        IDal Dal { get; set; }
        IModel Map(IDBModel dbModel);
        IDBModel Map(IModel model);
        bool Applicable(IDBModel model);
        bool Applicable(IModel model);
    }
}