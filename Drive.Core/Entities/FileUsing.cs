using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Core.Entities
{
    public class FileUsing
    {
        public IFormFile File { get;set;}
        public File FileProperty { get;set;}
    }
}
