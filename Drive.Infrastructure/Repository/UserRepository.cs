using Drive.Core.Entities;
using Drive.Core.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace Drive.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        string _connectionString;
        SqlConnection _sqlConnection;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("NVTAN");
            _sqlConnection = new SqlConnection(_connectionString);
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            var users = _sqlConnection.Query<User>("select id as 'ID',username as 'UserName',password as 'Password',full_name as 'FullName' from Account");
            return users;
        }

        public User GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(User user)
        {
            var sqlCommand = "Proc_InsertUser";
            var res = _sqlConnection.Execute(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
            return res;
        }

        public int Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
