using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImagePick.Application.Contracts.Models
{
    public class UserApplication
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }


        [MaxLength(100)]
        public string LastName { get; set; }

        public virtual ICollection<AlbumApplication> Albums { get; set; }

    }
}
