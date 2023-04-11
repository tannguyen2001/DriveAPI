using Drive.Core.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using Drive.Core.Interfaces.Repository;

namespace Drive.Infrastructure.Repository
{
    public class UserRepository :BaseRepository<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration):base(configuration){}

        public bool CheckUserExits(string userName)
        {
            var sqlQuery = "select * from Account where user_name = @UserName";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserName", userName);
            var userExits = SqlConnection.QueryFirstOrDefault(sqlQuery, param: parameters);
            if(userExits != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
