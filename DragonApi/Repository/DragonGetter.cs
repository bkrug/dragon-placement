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
            var someDragon = _dragonContext.Dragons.FirstOrDefault(d => d.Id == id);

            return someDragon;
        }
    }
}
