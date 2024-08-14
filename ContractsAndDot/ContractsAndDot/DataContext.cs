using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractsAndDot
{
    internal class DataContext : DbContext
    {
        /*public DataContext(DbContextOptions<DataContext> options) : base(options) { 
            Database.EnsureCreated();
        }*/
        public DataContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<LegalPerson> LegalPersons { get; set; }
        public DbSet<PrivatePerson> PrivatePersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-PQ2DSNS\\SQLENGINE;Initial Catalog=contracts_and_dot;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contract>()
                .HasOne(contract => contract.Counterparty)
                .WithMany(counterparty => counterparty.Contracts)
                .HasForeignKey(contract => contract.CounterpartyId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Contract>()
                .HasOne(contract => contract.Designee)
                .WithMany(designee => designee.Contracts)
                .HasForeignKey(contract => contract.DesigneeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<City>()
                .HasOne(city => city.Country)
                .WithMany(country => country.Cities)
                .HasForeignKey(city => city.CountryId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<LegalPerson>()
                .HasOne(lp => lp.City)
                .WithMany(city => city.LegalPersons)
                .HasForeignKey(lp => lp.CityId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<PrivatePerson>()
                .HasOne(pp => pp.City)
                .WithMany(city => city.PrivatePersons)
                .HasForeignKey(pp => pp.CityId);

            modelBuilder.Entity<LegalPerson>()
                .HasOne(lp => lp.Country)
                .WithMany(country => country.LegalPersons)
                .HasForeignKey(lp => lp.CountryId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<PrivatePerson>()
                .HasOne(pp => pp.Country)
                .WithMany(country => country.PrivatePersons)
                .HasForeignKey(pp => pp.CountryId)
                .OnDelete(DeleteBehavior.ClientCascade);

        }
    }
}
