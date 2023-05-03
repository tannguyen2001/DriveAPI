using Dapper;
using Drive.Core.Entities;
using Drive.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using File = Drive.Core.Entities.File;

namespace Drive.Infrastructure.Repository
{
    public class FileRepository:BaseRepository<File>,IFileRepository
    {
        public FileRepository(IConfiguration configuration) : base(configuration) { }

        public IEnumerable<File> GetBySearch(string key)
        {
            if (key==null)
            {
                key = "";
            }
            var storeSearch = $"Proc_GetFilesBySeach";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@KEY", key);

            var files = SqlConnection.Query<File>(storeSearch, param: dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
            return files;
        }

        public int DeleteFileByID(int ID)
        {
            var store = $"Proc_DeleteFileByID";
            DynamicParameters dynParameters = new DynamicParameters();
            dynParameters.Add("@ID", ID);
            int res = SqlConnection.Execute(store,param:dynParameters,commandType:System.Data.CommandType.StoredProcedure);
            return res;
        }
        public override int Insert(File entity)
        {
            return base.Insert(entity);
        }

    }
}
