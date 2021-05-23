using ImagePick.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ImagePick.DataAccess.Contracts
{
    public interface IImagePickDbContext
    {

        DbSet<User> Users { get; set; }

        DbSet<Album> Albums { get; set; }

        DbSet<Image> Images { get; set; }

        Task<int> SaveChangesAsync( CancellationToken cancellationToken = default );
        
        int SaveChanges();    


    }
}
