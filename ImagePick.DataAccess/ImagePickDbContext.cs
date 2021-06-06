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
    public class ImagePickDbContext : IdentityDbContext<User>, IImagePickDbContext
    {

        public ImagePickDbContext( DbContextOptions<ImagePickDbContext> options ) : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Image> Images { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity => { entity.ToTable(name: "Users"); });
            modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
            modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });

            UserEntityConfig.SetEntityBuilder(modelBuilder.Entity<User>());
            AlbumEntityConfig.SetEntityBuilder(modelBuilder.Entity<Album>());
            ImageEntityConfig.SetEntityBuilder(modelBuilder.Entity<Image>());


            base.OnModelCreating(modelBuilder);

        }

    }
}
