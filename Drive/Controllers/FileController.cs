using Drive.Core.Entities;
using Drive.Core.Interfaces.Repository;
using Drive.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using File = Drive.Core.Entities.File;

namespace Drive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseController<File>
    {
        IFileRepository _repository;
        IFileService _service;
        public FileController(IFileRepository repository, IFileService service):base(repository,service)
        {
            _repository = repository;
            _service = service;
        }
        [HttpGet]
        public override IActionResult GetAll()
        {
            // Code xử lý tùy ý
            return Ok(_repository.GetAll());
        }
    }
}
