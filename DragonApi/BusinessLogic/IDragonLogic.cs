using Contracts;
using Repository.Model;

namespace BusinessLogic
{
    public interface IDragonLogic
    {
        void Insert(DragonCreationContract dragonContract);
        IList<Dragon> Read(int skip, int take);
        Dragon Read(int id);
        void Update(int id, DragonCreationContract dragonContract);
    }
}