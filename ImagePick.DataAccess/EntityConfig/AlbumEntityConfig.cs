using ImagePick.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImagePick.DataAccess.EntityConfig
{
    public static class AlbumEntityConfig
    {
        public static void SetEntityBuilder( EntityTypeBuilder<Album> modelBuilder )
        {

            modelBuilder.HasKey(x => x.Id);
            modelBuilder.Property(x => x.Id).IsRequired();

            modelBuilder.Property(x => x.Name).IsRequired();
            modelBuilder.Property(x => x.Name).HasMaxLength(50);

            modelBuilder.HasOne(x => x.User)
                        .WithMany(x => x.Albums)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.HasMany(x => x.Images)
                        .WithOne(x => x.Album)
                        .HasForeignKey(x => x.AlbumId);

        }
    }
}
