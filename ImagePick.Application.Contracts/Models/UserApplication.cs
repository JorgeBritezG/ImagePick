using System.Collections.Generic;

namespace ImagePick.Application.Contracts.Models
{
    public class UserApplication
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<AlbumApplication> Albums { get; set; }

    }
}
