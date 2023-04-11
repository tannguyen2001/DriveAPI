using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Drive.Core.Interfaces.Repository;

namespace Drive.Infrastructure.Repository
{
    public class BaseRepository<Entity>:IBaseRepository<Entity>
    {
        protected string ConnectionString;
        protected SqlConnection SqlConnection;
        string _className;
        public BaseRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("NVTAN");
            SqlConnection = new SqlConnection(ConnectionString);
            _className = typeof(Entity).Name;
        }
        public virtual IEnumerable<Entity> GetAll() => this.GetAll(null);

        public virtual IEnumerable<Entity> GetAll(string? storeName)
        {
            if (string.IsNullOrEmpty(storeName))
            {
                storeName = $"Proc_GetAll{_className}s";
            }
            var entities = SqlConnection.Query<Entity>(storeName, commandType: System.Data.CommandType.StoredProcedure);
            return entities;
        }
        /// <summary>
        /// Lấy đối tượng theo ID
        /// </summary>
        /// <param name="id">Giá trị của khoá chính</param>
        /// <returns></returns>
        public virtual Entity GetByID(int id)
        {
            var sql = $"select * from {_className} where {_className}Id = @{_className}Id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{_className}Id", id);
            var entity = SqlConnection.QueryFirstOrDefault<Entity>(sql, param: parameters);
            return entity;
        }

        public virtual int Insert(Entity entity)
        {
            var storeInsert = $"Proc_Insert{_className}";
            var rowEffects = SqlConnection.Execute(storeInsert, param: entity,commandType:System.Data.CommandType.StoredProcedure);
            return rowEffects;
        }

        public virtual int Update(Entity entity)
        {
            var storeInsert = $"Proc_Update{_className}";
            var rowEffects = SqlConnection.Execute(storeInsert, param: entity, commandType: System.Data.CommandType.StoredProcedure);
            return rowEffects;
        }

        public virtual int Delete(int id)
        {
            var sql = $"delete from {_className} where {_className}Id = @{_className}Id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{_className}Id", id);
            var rowEffects = SqlConnection.Execute(sql, param: parameters);
            return rowEffects;
        }
    }
}
