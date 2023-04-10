namespace Drive.Core.Entities
{
    public class Trash
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public int UserID { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
