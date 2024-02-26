using Contracts;
using Repository.Model;

namespace BusinessLogic
{
    public interface IDragonLogic
    {
        void Insert(DragonCreationContract dragonContract);
        RowsWithRowCount<Dragon> Read(int skip, int take);
        Dragon Read(int id);
        void Update(int id, DragonCreationContract dragonContract);
    }
}