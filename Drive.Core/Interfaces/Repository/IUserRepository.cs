﻿using Drive.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Core.Interfaces.Repository
{
    public interface IUserRepository:IBaseRepository<User>
    {
        bool CheckUserExits(string userName);
    }
}
