﻿using Drive.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Drive.Core.Entities.File;

namespace Drive.Core.Interfaces.Service
{
    public interface IFileService:IBaseService<File>
    {
    }
}
