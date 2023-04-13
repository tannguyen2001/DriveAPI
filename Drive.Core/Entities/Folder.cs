using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Core.Entities
{
    public class Folder
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public int ParentFolderID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
