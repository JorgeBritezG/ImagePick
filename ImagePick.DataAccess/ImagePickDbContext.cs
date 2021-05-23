using ImagePick.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagePick.DataAccess
{
    public class ImagePickDbContext : DbContext
    {

        public ImagePickDbContext( DbContextOptions options ) : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            base.OnModelCreating(modelBuilder);

        }

    }
}
