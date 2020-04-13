﻿// <auto-generated />
using System;
using ApplicationApi.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PolestarApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200405173317_CreatePolesterDb")]
    partial class CreatePolesterDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PolestarApi.DataBase.Models.BookingDetails", b =>
                {
                    b.Property<int>("BookingDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("BookingDetailId");

                    b.ToTable("BookingDetail");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.BookingStatus", b =>
                {
                    b.Property<int>("BookingStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingStatusId");

                    b.ToTable("BookingStatus");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.Bookings", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BookingStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<int>("UsersCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("UsersVendorId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.CampaignType", b =>
                {
                    b.Property<int>("CampaignTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("CampaignTypeId");

                    b.ToTable("CampaignTypes");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.DiscountCode", b =>
                {
                    b.Property<int>("DiscountCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("UsersCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("UsersVendorId")
                        .HasColumnType("int");

                    b.HasKey("DiscountCodeId");

                    b.ToTable("DiscountCodes");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.MarketingCampaign", b =>
                {
                    b.Property<int>("MarketingCampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CampaignTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<bool>("Stauts")
                        .HasColumnType("bit");

                    b.Property<int>("UserVendorId")
                        .HasColumnType("int");

                    b.HasKey("MarketingCampaignId");

                    b.ToTable("MarketingCampaigns");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.Policy", b =>
                {
                    b.Property<int>("PolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PolicyTypeId")
                        .HasColumnType("int");

                    b.HasKey("PolicyId");

                    b.ToTable("Polices");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.PolicyType", b =>
                {
                    b.Property<int>("PolicyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PolicyTypeId");

                    b.ToTable("PolicyTypes");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.Reviews", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsersVendorId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.Roles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.Services", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.ServicesImage", b =>
                {
                    b.Property<int>("ServiceImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceImageId");

                    b.ToTable("ServiceImages");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubscriptionPackageId")
                        .HasColumnType("int");

                    b.Property<bool>("SubscriptionStatus")
                        .HasColumnType("bit");

                    b.Property<int>("UserVendorId")
                        .HasColumnType("int");

                    b.HasKey("SubscriptionId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.SubscriptionPackage", b =>
                {
                    b.Property<int>("SubscriptionPackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubscriptionPackageId");

                    b.ToTable("SubscriptionPackages");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.UserAccounts", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VendorAvailabilityStatusId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("UserAccount");
                });

            modelBuilder.Entity("PolestarApi.DataBase.Models.VendorAvailabilityStatus", b =>
                {
                    b.Property<int>("VendorAvailabilityStatusIdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorAvailabilityStatusIdId");

                    b.ToTable("VendorAvailabilityStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
