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
    [Migration("20220424152158_event")]
    partial class @event
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
                    b.Property<int>("CompaniesCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyActivitiesActivityId")
                        .HasColumnType("int");

                    b.HasKey("CompaniesCompanyId", "CompanyActivitiesActivityId");

                    b.HasIndex("CompanyActivitiesActivityId");

                    b.ToTable("ActivityCompany");
                });

            modelBuilder.Entity("ActivityUser", b =>
                {
                    b.Property<int>("ActivitiesActivityId")
                        .HasColumnType("int");

                    b.Property<int>("ActivitiesUsersUserId")
                        .HasColumnType("int");

                    b.HasKey("ActivitiesActivityId", "ActivitiesUsersUserId");

                    b.HasIndex("ActivitiesUsersUserId");

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

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Limit")
                        .HasColumnType("int");

                    b.Property<bool>("NeedTicket")
                        .HasColumnType("bit");

                    b.Property<int?>("TicketPrice")
                        .HasColumnType("int");

                    b.HasKey("ActivityId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
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

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RePassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ActivityCompany", b =>
                {
                    b.HasOne("task2_FiratKahreman.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task2_FiratKahreman.Models.Activity", null)
                        .WithMany()
                        .HasForeignKey("CompanyActivitiesActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ActivityUser", b =>
                {
                    b.HasOne("task2_FiratKahreman.Models.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task2_FiratKahreman.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesUsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.Activity", b =>
                {
                    b.HasOne("task2_FiratKahreman.Models.Category", "Category")
                        .WithMany("ActivitiesCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task2_FiratKahreman.Models.City", "City")
                        .WithMany("ActivitiesCities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("City");
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.Category", b =>
                {
                    b.Navigation("ActivitiesCategories");
                });

            modelBuilder.Entity("task2_FiratKahreman.Models.City", b =>
                {
                    b.Navigation("ActivitiesCities");
                });
#pragma warning restore 612, 618
        }
    }
}
