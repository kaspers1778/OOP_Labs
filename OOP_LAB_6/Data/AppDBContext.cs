using Microsoft.EntityFrameworkCore;
using OOP_LAB_6.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace OOP_LAB_6.Data
{
    class AppDBContext:DbContext
    {
        public DbSet<Brocker> Brocers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Agency> Agencys { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RieltorsAgencyDB;Integrated Security = True;");
        }
    }
}
