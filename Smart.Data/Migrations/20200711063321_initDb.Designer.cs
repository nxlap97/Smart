﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smart.Data;

namespace Smart.Data.Migrations
{
    [DbContext(typeof(SmartDbContext))]
    [Migration("20200711063321_initDb")]
    partial class initDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Smart.Core.Domain.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("Smart.Core.Domain.AttachFile", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("DocId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ObjectId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("AttachFiles");
                });

            modelBuilder.Entity("Smart.Core.Domain.Blog", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("ShortDescription");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Smart.Core.Domain.BlogCategory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("BlogId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("BlogCategories");
                });

            modelBuilder.Entity("Smart.Core.Domain.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Smart.Core.Domain.Customer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("HashPassword");

                    b.Property<string>("IPAddress");

                    b.Property<string>("Key");

                    b.Property<string>("Password");

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.Property<DateTime?>("TExpired");

                    b.Property<string>("Token")
                        .HasMaxLength(128);

                    b.Property<int>("Type");

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Smart.Core.Domain.CustomerRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("CustomerRoles");
                });

            modelBuilder.Entity("Smart.Core.Domain.Document", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("FileName");

                    b.Property<string>("FileUrl");

                    b.Property<long>("Size");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Smart.Core.Domain.Employer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .HasMaxLength(100);

                    b.Property<string>("IdentityCard")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("Smart.Core.Domain.Info", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("ObjectId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<bool>("Published");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Infos");
                });

            modelBuilder.Entity("Smart.Core.Domain.Lesson", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("ShortDescription");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Smart.Core.Domain.Logging", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("Entity")
                        .HasMaxLength(128);

                    b.Property<string>("Error");

                    b.HasKey("Id");

                    b.ToTable("Loggings");
                });

            modelBuilder.Entity("Smart.Core.Domain.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("ShortDescription");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Smart.Core.Domain.ProductCategory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Smart.Core.Domain.Setting", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime?>("Expired");

                    b.Property<string>("ObjectId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("PageType");

                    b.Property<int>("Type");

                    b.Property<int>("UI");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Smart.Core.Domain.Subject", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
