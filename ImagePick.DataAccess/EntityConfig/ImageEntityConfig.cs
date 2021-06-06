using ImagePick.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImagePick.DataAccess.EntityConfig
{
    public static class ImageEntityConfig
    {
        public static void SetEntityBuilder( EntityTypeBuilder<Image> modelBuilder )
        {

            modelBuilder.HasKey(x => x.Id);
            modelBuilder.Property(x => x.Id).IsRequired();

            modelBuilder.Property(x => x.UserName).IsRequired();
            modelBuilder.Property(x => x.UserName).HasMaxLength(100);

            modelBuilder.Property(x => x.AlbumId).IsRequired();

            modelBuilder.HasOne(x => x.Album)
                        .WithMany(x => x.Images)
                        .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
