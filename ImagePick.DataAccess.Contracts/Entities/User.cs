using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ImagePick.DataAccess.Contracts.Entities
{
    public class User : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
