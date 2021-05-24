using System;
using System.Collections.Generic;

namespace ImagePick.Application.Contracts.Models
{
    public class AlbumApplication
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        public UserApplication User { get; set; }

        public virtual ICollection<ImageApplication> Images { get; set; }
    }
}
