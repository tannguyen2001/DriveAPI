using Drive.Core.Exceptions;
using Drive.Core.Interfaces.Repository;
using Drive.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Core.Services
{
    public class BaseService<Entity>:IBaseService<Entity>
    {
        protected IBaseRepository<Entity> Repository;
        protected List<string> ErrorValidateMsgs;
        public BaseService(IBaseRepository<Entity> repository)
        {
            Repository = repository;
            ErrorValidateMsgs = new List<string>();
        }

        public int InsertService(Entity entity)
        {
            // thực hiện validate dữ liệu
            var isValidate = Validate(entity);
            if (isValidate)
            {
                // thực hiện thêm mới vào database
                var res = Repository.Insert(entity);
                return res;
            }
            else
            {
                throw new ExceptionValidate("Dữ liệu đầu vào không hợp lệ!",ErrorValidateMsgs);
            }
            
        }

        public int UpdateService(Entity entity)
        {
            throw new NotImplementedException();
        }

        protected virtual bool Validate(Entity entity)
        {
            return true;
        }
    }
}
