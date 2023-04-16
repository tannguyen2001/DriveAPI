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

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm]FileUsing file)
        {
            var uploadsDir = Path.Combine(_env.ContentRootPath, "uploads");
            var filePath = Path.Combine(uploadsDir, file.FileProperty.FileName);
            var destFilePath = Path.Combine(uploadsDir, file.FileProperty.FileName + file.FileProperty.UserID + file.FileProperty.CreatedAt);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
               System.IO.File.Copy(filePath, destFilePath);
            }
            return this.Insert(file.FileProperty);
        }

        [HttpGet("getfile/{id}")]
        public IActionResult GetFile(int id)
        {
            return Ok();
        }


    }
}
