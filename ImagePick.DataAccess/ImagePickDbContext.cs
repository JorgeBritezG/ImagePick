using ImagePick.DataAccess.Contracts;
using ImagePick.DataAccess.Contracts.Entities;
using ImagePick.DataAccess.EntityConfig;
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
            
            AlbumEntityConfig.SetEntityBuilder(modelBuilder.Entity<Album>());



            base.OnModelCreating(modelBuilder);

        }

    }
}
