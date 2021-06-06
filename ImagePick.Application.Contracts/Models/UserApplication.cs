using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImagePick.Application.Contracts.Models
{
    public class UserApplication : IdentityUser
    {
                
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }


        [MaxLength(100)]
        public string LastName { get; set; }

        public virtual ICollection<AlbumApplication> Albums { get; set; }

    }
}
