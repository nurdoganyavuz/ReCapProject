﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //bu metot ile; projeyi hangi veritabanı ile ilişkilendireceğimizi belirtiyoruz.
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;Database=RentACar;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Color> Colors { get; set; }

    }
}
//Context -- Db tabloları ile proje classlarını ilişkilendirme.
//Car, Brand, Color sınıflarının DB'de hangi tablolara karşılık geldiğini belirtme.