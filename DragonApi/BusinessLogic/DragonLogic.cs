using Contracts;
using Repository;
using Repository.Model;

namespace BusinessLogic
{
    public class DragonLogic : IDragonLogic
    {
        private readonly IDragonRepository _dragonRepository;

        public DragonLogic(IDragonRepository dragonRepository)
        {
            _dragonRepository = dragonRepository;
        }

        public void CreateDragon(DragonCreationContract dragonContract)
        {
            //TODO: This is an actually good use for automapper. Install it.
            var dragonRecord = new Dragon
            {
                Name = dragonContract.Name,
                Title = dragonContract.Title,
                HasFire = dragonContract.HasFire,
                HasFlight = dragonContract.HasFlight,
            };
            _dragonRepository.Create(dragonRecord);
        }
    }
}
