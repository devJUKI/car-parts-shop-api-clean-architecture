﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CarPartsShopDbContext))]
    [Migration("20231108215317_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AdsWebsiteAPI.Data.Entities.BodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BodyTypes");
                });

            modelBuilder.Entity("AdsWebsiteAPI.Data.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BodyId")
                        .HasColumnType("int");

                    b.Property<float>("Engine")
                        .HasColumnType("float");

                    b.Property<DateTime>("FirstRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("FuelId")
                        .HasColumnType("int");

                    b.Property<int?>("GearboxId")
                        .HasColumnType("int");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.HasIndex("FuelId");

                    b.HasIndex("GearboxId");

                    b.HasIndex("ModelId");

                    b.HasIndex("ShopId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AdsWebsiteAPI.Data.Entities.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("AdsWebsiteAPI.Data.Entities.GearboxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("GearboxTypes");
                });

            modelBuilder.Entity("AdsWebsiteAPI.Data.Entities.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("AdsWebsiteAPI.Data.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("AdsWebsiteAPI.Data.Entities.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("Core.Entities.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .HasColumnType("longtext");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AdsWebsiteAPI.Data.Entities.Car", b =>
                {
                    b.HasOne("AdsWebsiteAPI.Data.Entities.BodyType", "Body")
                        .WithMany()
                        .HasForeignKey("BodyId");

                    b.HasOne("AdsWebsiteAPI.Data.Entities.FuelType", "Fuel")
                        .WithMany()
                        .HasForeignKey("FuelId");

                    b.HasOne("AdsWebsiteAPI.Data.Entities.GearboxType", "Gearbox")
                        .WithMany()
                        .HasForeignKey("GearboxId");

                    b.HasOne("AdsWebsiteAPI.Data.Entities.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId");

                    b.HasOne("Core.Entities.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Body");

                    b.Navigation("Fuel");

                    b.Navigation("Gearbox");

                    b.Navigation("Model");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("AdsWebsiteAPI.Data.Entities.Model", b =>
                {
                    b.HasOne("AdsWebsiteAPI.Data.Entities.Make", "Make")
                        .WithMany()
                        .HasForeignKey("MakeId");

                    b.Navigation("Make");
                });

            modelBuilder.Entity("AdsWebsiteAPI.Data.Entities.Part", b =>
                {
                    b.HasOne("AdsWebsiteAPI.Data.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Core.Entities.Shop", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
