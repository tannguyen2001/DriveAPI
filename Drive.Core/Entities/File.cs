namespace Drive.Core.Entities
{
    public class File
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int UserID { get; set; }
        public int FolderID { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
