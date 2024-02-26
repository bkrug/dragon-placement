using Contracts;
using Repository;
using Repository.Model;

namespace BusinessLogic
{
    public class DragonLogic : IDragonLogic
    {
        private readonly IGenericRepository<Dragon> _dragonRepository;

        public DragonLogic(IGenericRepository<Dragon> dragonRepository)
        {
            _dragonRepository = dragonRepository;
        }

        public void Insert(DragonCreationContract dragonContract)
        {
            //TODO: This is an actually good use for automapper. Install it.
            var dragonRecord = new Dragon
            {
                Name = dragonContract.Name,
                Title = dragonContract.Title,
                HasFire = dragonContract.HasFire,
                HasFlight = dragonContract.HasFlight,
            };
            _dragonRepository.Insert(dragonRecord);
            _dragonRepository.SaveChanges();
        }

        public void Update(int id, DragonCreationContract dragonContract)
        {
            //TODO: This is an actually good use for automapper. Install it.
            var dragonRecord = new Dragon
            {
                Id = id,
                Name = dragonContract.Name,
                Title = dragonContract.Title,
                HasFire = dragonContract.HasFire,
                HasFlight = dragonContract.HasFlight,
            };
            _dragonRepository.Update(dragonRecord);
            _dragonRepository.SaveChanges();
        }

        public RowsWithRowCount<Dragon> Read(int skip, int take)
        {
            return new RowsWithRowCount<Dragon>
            {
                RowCount = _dragonRepository.Get(orderBy: q => q.OrderBy(dr => dr.Name)).Count(),
                Items = _dragonRepository.Get(orderBy: q => q.OrderBy(dr => dr.Name))
                    .Skip(skip)
                    .Take(take)
                    .ToList()
            };
        }

        public Dragon Read(int id)
        {
            return _dragonRepository.GetById(id);
        }
    }
}
