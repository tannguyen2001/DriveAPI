using Drive.Core.Entities;
using Drive.Core.Interfaces.Repository;
using Drive.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Drive.Core.Entities.File;

namespace Drive.Core.Services
{
    public class FileService:BaseService<File>,IFileService
    {
        IFileRepository _fileRepository;
        public FileService(IFileRepository fileRepository) : base(fileRepository)
        {
            _fileRepository = fileRepository;
        }

        protected override bool Validate(File entity)
        {
            return base.Validate(entity);
        }

    }
}
