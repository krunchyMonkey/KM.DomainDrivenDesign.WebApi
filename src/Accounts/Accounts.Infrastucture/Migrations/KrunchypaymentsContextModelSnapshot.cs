﻿// <auto-generated />
using System;
using Accounts.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Accounts.Infrastucture.Migrations
{
    [DbContext(typeof(KrunchypaymentsContext))]
    partial class KrunchypaymentsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccountPaymentMethod", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PaymentMethodsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccountId", "PaymentMethodsId");

                    b.HasIndex("PaymentMethodsId");

                    b.ToTable("AccountPaymentMethod");
                });

            modelBuilder.Entity("AccountPerson", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PeopleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccountId", "PeopleId");

                    b.HasIndex("PeopleId");

                    b.ToTable("AccountPerson");
                });

            modelBuilder.Entity("Accounts.Domain.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("accountType");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PostalCode");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Account", null, t =>
                        {
                            t.Property("PostalCode")
                                .HasColumnName("PostalCode1");
                        });
                });

            modelBuilder.Entity("Accounts.Domain.Models.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("accountNumber");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.Property<string>("CreditCardNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("creditCardNumber");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("currencyCode");

                    b.Property<string>("Cvv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cvv");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("paymentType");

                    b.Property<string>("RoutingNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("routingNumber");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ip");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethod", (string)null);
                });

            modelBuilder.Entity("Accounts.Domain.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("lastName");

                    b.HasKey("Id");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("AccountPaymentMethod", b =>
                {
                    b.HasOne("Accounts.Domain.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Domain.Models.PaymentMethod", null)
                        .WithMany()
                        .HasForeignKey("PaymentMethodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccountPerson", b =>
                {
                    b.HasOne("Accounts.Domain.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Domain.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
