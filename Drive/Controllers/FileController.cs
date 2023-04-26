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
        private readonly IWebHostEnvironment _env;
        public FileController(IFileRepository repository, IFileService service,IWebHostEnvironment env):base(repository,service)
        {
            _repository = repository;
            _service = service;
            _env = env;
        }
        [HttpGet]
        public override IActionResult GetAll()
        {
            // Code xử lý tùy ý
            return Ok(_repository.GetAll());
        }

        [HttpGet("search")]
        public IActionResult GetBySearch(string? key="")
        {
            return Ok(_repository.GetBySearch(key));
        }



    }
}
