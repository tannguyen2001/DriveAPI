namespace Drive.Model
{
    public class Preview
    {
        public int ID { get; set; }
        public int FileID { get; set; }
        public Stream PreviewData { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
