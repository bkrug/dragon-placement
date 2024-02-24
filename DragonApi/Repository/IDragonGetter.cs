using Repository.Model;

namespace Repository
{
    public interface IDragonGetter
    {
        Dragon GetDragon(int id);
        IList<Dragon> GetDragons(int skip, int take);
    }
}