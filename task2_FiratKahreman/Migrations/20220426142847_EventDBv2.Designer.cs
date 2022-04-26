﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman.Migrations
{
    [DbContext(typeof(EventContext))]
    [Migration("20220426142847_EventDBv2")]
    partial class EventDBv2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActivityCompany", b =>
                {
                    b.Property<int>("CompanyActivitiesActivityId")
                        .HasColumnType("int");

                    b.Property<int>("SellerCompaniesCompanyId")
                        .HasColumnType("int");

                    b.HasKey("CompanyActivitiesActivityId", "SellerCompaniesCompanyId");

                    b.HasIndex("SellerCompaniesCompanyId");

                    b.ToTable("ActivityCompany");
                });

            modelBuilder.Entity("ActivityUser", b =>
                {
                    b.Property<int>("AttendedActivitiesActivityId")
                        .HasColumnType("int");

                    b.Property<int>("AttendedUsersUserId")
                        .HasColumnType("int");

                    b.HasKey("AttendedActivitiesActivityId", "AttendedUsersUserId");

                    b.HasIndex("AttendedUsersUserId");

                    b.ToTable("ActivityUser");
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActivityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActivityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Limit")
                        .HasColumnType("int");

                    b.Property<bool>("NeedTicket")
                        .HasColumnType("bit");

                    b.Property<int?>("TicketPrice")
                        .HasColumnType("int");

                    b.HasKey("ActivityId");

                    b.HasIndex("CategoryName");

                    b.HasIndex("CityName");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.Category", b =>
                {
                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoryName");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.City", b =>
                {
                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CityName");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyRePassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyWeb")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsOrganizer")
                        .HasColumnType("bit");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RePassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ActivityCompany", b =>
                {
                    b.HasOne("task2_FiratKahreman.Models.Activity", null)
                        .WithMany()
                        .HasForeignKey("CompanyActivitiesActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task2_FiratKahreman.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("SellerCompaniesCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ActivityUser", b =>
                {
                    b.HasOne("task2_FiratKahreman.Models.Activity", null)
                        .WithMany()
                        .HasForeignKey("AttendedActivitiesActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task2_FiratKahreman.Models.User", null)
                        .WithMany()
                        .HasForeignKey("AttendedUsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.Activity", b =>
                {
                    b.HasOne("task2_FiratKahreman.Models.Category", "Category")
                        .WithMany("CategoryActivities")
                        .HasForeignKey("CategoryName");

                    b.HasOne("task2_FiratKahreman.Models.City", "City")
                        .WithMany("CityActivities")
                        .HasForeignKey("CityName");

                    b.Navigation("Category");

                    b.Navigation("City");
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.Category", b =>
                {
                    b.Navigation("CategoryActivities");
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.City", b =>
                {
                    b.Navigation("CityActivities");
                });
#pragma warning restore 612, 618
        }
    }
}
