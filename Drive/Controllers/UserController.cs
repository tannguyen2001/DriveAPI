using Dapper;
using Drive.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Drive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            string connectionString = "Data Source=DESKTOP-FFQCPU7\\TAN;Initial Catalog=Drive;Integrated Security=True";
            var sqlConnection = new SqlConnection(connectionString);
            var Users = sqlConnection.Query<User>("select id as 'ID', username as 'UserName', password as 'Password' , full_name as 'FullName'  from Account;").ToList();
            return Ok(Users);
        }
    }
}
