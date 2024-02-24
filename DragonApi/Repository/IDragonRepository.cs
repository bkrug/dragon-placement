using Repository.Model;

namespace Repository
{
    public interface IDragonRepository
    {
        void Create(Dragon dragon);
        Dragon GetDragon(int id);
        IList<Dragon> GetDragons(int skip, int take);
    }
}