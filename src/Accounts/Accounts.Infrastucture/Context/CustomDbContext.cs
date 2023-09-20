using Accounts.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Infrastucture.Context
{
    public class CustomDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public CustomDbContext()
        {
        }

        public CustomDbContext(DbContextOptions<CustomDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Age).HasColumnName("age");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");
            });

            modelBuilder.Entity<PaymentMethod>(entity => {
                entity.ToTable("PaymentMethod");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.PaymentType).HasColumnName("paymentType");
                entity.Property(e => e.AccountNumber).HasColumnName("accountNumber");
                entity.Property(e => e.CreditCardNumber).HasColumnName("creditCardNumber");
                entity.Property(e => e.CurrencyCode).HasColumnName("currencyCode");
                entity.Property(e => e.Cvv).HasColumnName("cvv");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.City).HasColumnName("city");
                entity.Property(e => e.Zip).HasColumnName("ip");
                entity.Property(e => e.RoutingNumber).HasColumnName("routingNumber");
            });

            modelBuilder.Entity<Account>(entity => {
                entity.ToTable("Account");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.AccountType).HasColumnName("accountType");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.City).HasColumnName("city");
                entity.Property(e => e.City).HasColumnName("Region");
                entity.Property(e => e.City).HasColumnName("PostalCode");
                entity.HasMany(e => e.PaymentMethods).WithMany();
                entity.HasMany(e => e.People).WithMany();
            });
        }
    }
}
