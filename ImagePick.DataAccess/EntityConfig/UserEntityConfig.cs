using ImagePick.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImagePick.DataAccess.EntityConfig
{
    public static class UserEntityConfig
    {
        public static void SetEntityBuilder( EntityTypeBuilder<User> modelBuilder )
        {

            modelBuilder.HasKey(x => x.Id);
            modelBuilder.Property(x => x.Id).IsRequired();

            modelBuilder.Property(x => x.Email).IsRequired();
            modelBuilder.Property(x => x.Email).HasMaxLength(256);

            modelBuilder.Property(x => x.FirstName).IsRequired();
            modelBuilder.Property(x => x.FirstName).HasMaxLength(100);

            modelBuilder.Property(x => x.LastName).HasMaxLength(100);


            modelBuilder.HasMany(x => x.Albums)
                        .WithOne(x => x.User)
                        .HasForeignKey(x => x.UserId);

        }
    }
}
