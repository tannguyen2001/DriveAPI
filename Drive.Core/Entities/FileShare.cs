﻿namespace Drive.Core.Entities
{
    public class FileShare
    {
        public int ID { get; set; }
        public int FileID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
