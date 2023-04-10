using Drive.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Core.Interfaces
{
    /// <summary>
    /// Nghiệp vụ, kiểm tra, validate ...
    /// </summary>
    public interface IUserSevice
    {
        int InsertService(User user);
        int UpdateService(User user);
    }
}
