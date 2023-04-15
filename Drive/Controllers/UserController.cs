using Drive.Core.Entities;
using Drive.Core.Exceptions;
using Drive.Core.Interfaces.Repository;
using Drive.Core.Interfaces.Service;
using Drive.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        IUserRepository _repository;
        IUserSevice _sevice;
        public UserController(IUserRepository repository, IUserSevice sevice):base(repository,sevice)
        {
            _repository = repository;
            _sevice = sevice;
        }


        
    }
}
