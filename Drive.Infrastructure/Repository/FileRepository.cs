using Drive.Core.Entities;
using Drive.Core.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Drive.Core.Entities.File;

namespace Drive.Infrastructure.Repository
{
    public class FileRepository:BaseRepository<File>,IFileRepository
    {
        public FileRepository(IConfiguration configuration) : base(configuration) { }

        public override int Insert(File entity)
        {
            return base.Insert(entity);
        }

    }
}
