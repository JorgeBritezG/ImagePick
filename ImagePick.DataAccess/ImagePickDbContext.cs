using ImagePick.DataAccess.Contracts;
using ImagePick.DataAccess.Contracts.Entities;
using ImagePick.DataAccess.EntityConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagePick.DataAccess
{
    public class ImagePickDbContext : DbContext, IImagePickDbContext
    {

        public ImagePickDbContext( DbContextOptions<ImagePickDbContext> options ) : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
            modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles").HasNoKey(); });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims").HasNoKey(); });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins").HasNoKey(); });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens").HasNoKey(); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims").HasNoKey(); });

            AlbumEntityConfig.SetEntityBuilder(modelBuilder.Entity<Album>());
            UserEntityConfig.SetEntityBuilder(modelBuilder.Entity<User>());
            ImageEntityConfig.SetEntityBuilder(modelBuilder.Entity<Image>());


            base.OnModelCreating(modelBuilder);

        }

    }
}
