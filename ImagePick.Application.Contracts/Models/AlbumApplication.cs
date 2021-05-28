using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImagePick.Application.Contracts.Models
{
    public class AlbumApplication
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string UserId { get; set; }

        public UserApplication User { get; set; }

        public virtual ICollection<ImageApplication> Images { get; set; }
    }
}
