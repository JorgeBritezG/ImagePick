using System;
using System.Collections.Generic;

namespace ImagePick.DataAccess.Contracts.Entities
{
    public class Album
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
