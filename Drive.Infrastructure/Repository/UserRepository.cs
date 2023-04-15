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

        public bool CheckUserExits(string username)
        {
            var sqlQuery = "SELECT * FROM Users WHERE username = @Username";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Username", username);
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
