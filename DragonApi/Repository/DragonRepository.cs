using Repository.Model;

namespace Repository
{
    [Obsolete]
    public class DragonRepository : IDragonRepository
    {
        private readonly DragonContext _dragonContext;

        public DragonRepository(DragonContext dragonContext) {
            _dragonContext = dragonContext;
        }

        public void Create(Dragon dragon)
        {
            _dragonContext.Add(dragon);
            _dragonContext.SaveChanges();
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
