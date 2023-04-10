using Drive.Core.Interfaces;
using Drive.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var users = _repository.GetAll();
                return Ok(users);
            }
            catch(Exception ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi sảy ra, xin vui lòng thử lại"
                };
                return StatusCode(500, res);
            }
        }
    }
}
