﻿using CarBook.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DataAccessLayer.Concrete
{
    public class CarBookContext : IdentityDbContext<AppUser, AppRole, int>
    {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; initial catalog=CarBookDb; integrated Security=true");
		}
		public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarCategory> CarCategories  { get; set; }
        public DbSet<CarStatus> CarStatuses  { get; set; }
        public DbSet<Location> Locations  { get; set; }
        public DbSet<Price> Prices  { get; set; }
    }
}
