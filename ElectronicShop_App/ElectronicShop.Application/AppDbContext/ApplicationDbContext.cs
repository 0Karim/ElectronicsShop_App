using ElectronicShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShop.Application.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        #region Tables

        public DbSet<Product> Products { get; set; }

        public DbSet<Offers> Offers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData
                (
                new Category() { Id = 1, NameEn = "TVs" , NameAr = "شاشات تلفاز", IsActive = true },
                new Category() { Id = 2, NameEn = "Laptops", NameAr = "لاب توب", IsActive = true },
                new Category() { Id = 3, NameEn = "Sound Systems",  NameAr = "أجهزة صوت", IsActive = true }
                );

            modelBuilder.Entity<Role>().HasData
                (
                new Role() { Id = 1, RoleName = "Admin", IsActive = true },
                new Role() { Id = 2, RoleName = "Customer", IsActive = true }
                );

            modelBuilder.Entity<User>().HasData
                (
                new User() { Id = 1, NameEn = "admin", NameAr = "مدير النظام", FullAddress="admin" , Email="admin@admin.com" , UserName="admin" , Password= "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", PhoneNumber="01154465989" , 
                    BirthDate = DateTime.Now ,RoleId = 1  ,  IsActive = true }
                );

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = "Server=localhost;Database=ElectronicShopDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
