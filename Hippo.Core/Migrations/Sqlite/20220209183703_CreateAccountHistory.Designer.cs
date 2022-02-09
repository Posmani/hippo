﻿// <auto-generated />
using System;
using Hippo.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hippo.Core.Migrations.Sqlite
{
    [DbContext(typeof(AppDbContextSqlite))]
    [Migration("20220209183703_CreateAccountHistory")]
    partial class CreateAccountHistory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("Hippo.Core.Domain.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CanSponsor")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SponsorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SshKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("SponsorId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Hippo.Core.Domain.AccountHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ActorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ActorId");

                    b.ToTable("AccountHistories");
                });

            modelBuilder.Entity("Hippo.Core.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Iam")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Kerberos")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hippo.Core.Domain.Account", b =>
                {
                    b.HasOne("Hippo.Core.Domain.User", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hippo.Core.Domain.Account", "Sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId");

                    b.Navigation("Owner");

                    b.Navigation("Sponsor");
                });

            modelBuilder.Entity("Hippo.Core.Domain.AccountHistory", b =>
                {
                    b.HasOne("Hippo.Core.Domain.Account", "Account")
                        .WithMany("Histories")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hippo.Core.Domain.User", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId");

                    b.Navigation("Account");

                    b.Navigation("Actor");
                });

            modelBuilder.Entity("Hippo.Core.Domain.Account", b =>
                {
                    b.Navigation("Histories");
                });

            modelBuilder.Entity("Hippo.Core.Domain.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
