using Drive.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Core.Interfaces.Repository
{
    public interface IBaseRepository<Entity>
    {
        IEnumerable<Entity> GetAll();
        Entity GetByID(int id);
        int Insert(Entity user);
        int Update(Entity user);
        int Delete(int id); 
    }
}
