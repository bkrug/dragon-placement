using Repository.Model;

namespace Repository
{
    public class DragonGetter : IDragonGetter
    {
        private readonly DragonContext _dragonContext;

        public DragonGetter(DragonContext dragonContext) {
            _dragonContext = dragonContext;
        }

        public Dragon GetDragon(int id)
        {
            return _dragonContext.Dragons.FirstOrDefault(d => d.Id == id);
        }

        public IList<Dragon> GetDragons(int skip, int take)
        {
            return _dragonContext.Dragons
                .OrderBy(d => d.Name)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }
}
