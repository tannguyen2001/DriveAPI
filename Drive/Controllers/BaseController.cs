using Drive.Core.Interfaces.Repository;
using Drive.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Drive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity> : ControllerBase
    {
        IBaseRepository<Entity> _repository;
        IBaseService<Entity> _service;
        public BaseController(IBaseRepository<Entity> repository, IBaseService<Entity> service)
        {
            _repository = repository;
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            return Ok(_repository.GetByID(id));
        }
        [HttpPost]
        public IActionResult Insert(Entity entity)
        {
            return Ok(_service.InsertService(entity));
        }
    }
}
