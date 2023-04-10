using Drive.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Core.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByID(int id);
        int Insert(User user);
        int Update(User user);
        int Delete(int id);
    }
}
