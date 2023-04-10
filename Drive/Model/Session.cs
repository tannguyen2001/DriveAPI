namespace Drive.Model
{
    public class Session
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string SessionKey { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
