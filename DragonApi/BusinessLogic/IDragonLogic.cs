using Contracts;

namespace BusinessLogic
{
    public interface IDragonLogic
    {
        void Insert(DragonCreationContract dragonContract);
        void Update(int id, DragonCreationContract dragonContract);
    }
}