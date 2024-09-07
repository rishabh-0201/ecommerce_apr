﻿// <auto-generated />
using System;
using EcommerceRPA.DataConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcommerceRPA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcommerceAPR.model.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColorId"));

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColorId");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("EcommerceAPR.model.Feature", b =>
                {
                    b.Property<int>("FeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeatureId"));

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("ProcessorId")
                        .HasColumnType("int");

                    b.Property<int>("RamId")
                        .HasColumnType("int");

                    b.Property<int>("RomId")
                        .HasColumnType("int");

                    b.HasKey("FeatureId");

                    b.HasIndex("ColorId");

                    b.HasIndex("ProcessorId");

                    b.HasIndex("RamId");

                    b.HasIndex("RomId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("EcommerceAPR.model.Processor", b =>
                {
                    b.Property<int>("ProcessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProcessorId"));

                    b.Property<string>("ProcessorValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProcessorId");

                    b.ToTable("Processors");
                });

            modelBuilder.Entity("EcommerceAPR.model.RAM", b =>
                {
                    b.Property<int>("RamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RamId"));

                    b.Property<string>("RamValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RamId");

                    b.ToTable("RAMs");
                });

            modelBuilder.Entity("EcommerceAPR.model.ROM", b =>
                {
                    b.Property<int>("RomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RomId"));

                    b.Property<string>("RomValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RomId");

                    b.ToTable("ROMs");
                });

            modelBuilder.Entity("EcommerceRPA.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EcommerceRPA.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("EcommerceRPA.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("HighMarkup")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LowMarkup")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EcommerceRPA.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FeatureId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EcommerceRPA.Models.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"));

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StateId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("EcommerceRPA.Models.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("VendorId");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("EcommerceAPR.model.Feature", b =>
                {
                    b.HasOne("EcommerceAPR.model.Color", "Color")
                        .WithMany("Features")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceAPR.model.Processor", "processor")
                        .WithMany("Features")
                        .HasForeignKey("ProcessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceAPR.model.RAM", "Ram")
                        .WithMany("Features")
                        .HasForeignKey("RamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceAPR.model.ROM", "Rom")
                        .WithMany("Features")
                        .HasForeignKey("RomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Ram");

                    b.Navigation("Rom");

                    b.Navigation("processor");
                });

            modelBuilder.Entity("EcommerceRPA.Models.City", b =>
                {
                    b.HasOne("EcommerceRPA.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("EcommerceRPA.Models.Product", b =>
                {
                    b.HasOne("EcommerceRPA.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

<<<<<<< HEAD
                    b.HasOne("EcommerceAPR.model.Feature", "Feature")
=======
                    b.HasOne("EcommerceAPR.model.Feature", null)
>>>>>>> 55f65d89ae4640258abf662e1d4e805f2c12e0b9
                        .WithMany("Products")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
<<<<<<< HEAD

                    b.Navigation("Feature");
=======
>>>>>>> 55f65d89ae4640258abf662e1d4e805f2c12e0b9
                });

            modelBuilder.Entity("EcommerceRPA.Models.Vendor", b =>
                {
                    b.HasOne("EcommerceRPA.Models.City", "City")
                        .WithMany("Vendors")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceRPA.Models.Company", "Company")
                        .WithMany("Vendors")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("EcommerceAPR.model.Color", b =>
                {
                    b.Navigation("Features");
                });

            modelBuilder.Entity("EcommerceAPR.model.Feature", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EcommerceAPR.model.Processor", b =>
                {
                    b.Navigation("Features");
                });

            modelBuilder.Entity("EcommerceAPR.model.RAM", b =>
                {
                    b.Navigation("Features");
                });

            modelBuilder.Entity("EcommerceAPR.model.ROM", b =>
                {
                    b.Navigation("Features");
                });

            modelBuilder.Entity("EcommerceRPA.Models.City", b =>
                {
                    b.Navigation("Vendors");
                });

            modelBuilder.Entity("EcommerceRPA.Models.Company", b =>
                {
                    b.Navigation("Vendors");
                });

            modelBuilder.Entity("EcommerceRPA.Models.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
