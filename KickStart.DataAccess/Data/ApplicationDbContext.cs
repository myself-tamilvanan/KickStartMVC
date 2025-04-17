﻿using KickStart.Models;
using Microsoft.EntityFrameworkCore;

namespace KickStart.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
             
        }

        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id=1, Name="Action", DisplaOrder=1 },
                new CategoryModel { Id=2, Name="SciFi", DisplaOrder=1 },
                new CategoryModel { Id=3, Name="History", DisplaOrder=1 }
                );
        }
    }
}
