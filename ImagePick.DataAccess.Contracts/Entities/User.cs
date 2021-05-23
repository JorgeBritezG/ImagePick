using System.Collections.Generic;

namespace ImagePick.DataAccess.Contracts.Entities
{
    public class User
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
