using ImagePick.DataAccess.Contracts;
using ImagePick.DataAccess.Contracts.Entities;
using ImagePick.DataAccess.EntityConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagePick.DataAccess
{
    public class ImagePickDbContext : DbContext, IImagePickDbContext
    {

        public ImagePickDbContext( DbContextOptions options ) : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
            modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });

            AlbumEntityConfig.SetEntityBuilder(modelBuilder.Entity<Album>());
            UserEntityConfig.SetEntityBuilder(modelBuilder.Entity<User>());
            ImageEntityConfig.SetEntityBuilder(modelBuilder.Entity<Image>());


            base.OnModelCreating(modelBuilder);

        }

    }
}
