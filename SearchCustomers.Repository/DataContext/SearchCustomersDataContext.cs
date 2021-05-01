﻿using Microsoft.EntityFrameworkCore;
using SearchCustomers.Domain;
using SearchCustomers.Repository.Mappings;

namespace SearchCustomers.Repository.DataContext
{
    public class SearchCustomersDataContext : DbContext
    {
        public SearchCustomersDataContext(DbContextOptions<SearchCustomersDataContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserSys> UserSys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CityMap());
            modelBuilder.ApplyConfiguration(new ClassificationMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());            
            modelBuilder.ApplyConfiguration(new GenderMap());
            modelBuilder.ApplyConfiguration(new RegionMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new UserSysMap());
        }
    }
}
