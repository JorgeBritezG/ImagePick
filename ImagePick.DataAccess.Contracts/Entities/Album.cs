using System;

namespace ImagePick.DataAccess.Contracts.Entities
{
    public class Album
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
