﻿using Drive.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Core.Interfaces.Service
{
    public interface IBaseService<Entity>
    {
        int InsertService(Entity entity);
        int UpdateService(Entity entity);
    }
}
