using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapDB:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCapDB;Trusted_Connection=true");


        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Carss { get; set; }
        public DbSet<Color> Colors { get; set; }
        
    }
}
