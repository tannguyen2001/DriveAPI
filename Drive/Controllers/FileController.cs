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

        public override IActionResult GetByID(int id)
        {
            var file = _repository.GetByID(id);
            if (!System.IO.File.Exists(file.FilePath))
            {
                return NotFound();
            }
            // Lấy tên file và đọc nội dung tệp tin
            var fileBytes = System.IO.File.ReadAllBytes(file.FilePath);
            var fileName = Path.GetFileName(file.FilePath);

            // Trả về nội dung tệp tin dưới dạng FileContentResult
            return File(fileBytes, "application/vnd.ms-excel", fileName);

        }

        [HttpDelete]
        public IActionResult DeleteFileByID([FromQuery] int id)
        {
            return Ok(_repository.DeleteFileByID(id));
        }

        public override IActionResult Insert(File entity)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory; // Lấy đường dẫn đến thư mục chứa file thực thi ứng dụng
            string filesUploadedPath = Path.Combine(path, "FilesUploaded"); // Kết hợp đường dẫn với tên thư mục "FilesUploaded"
            System.IO.File.Copy(entity.FilePath,filesUploadedPath + "/"+ entity.FileName );
            return base.Insert(entity);
        }

    }
}
