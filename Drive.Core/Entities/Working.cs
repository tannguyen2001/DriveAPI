namespace Drive.Core.Entities
{
    public class Working
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
