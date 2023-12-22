﻿// <auto-generated />
using System;
using EmpMan.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmpMan.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231221182449_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("EmpMan.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DOJ")
                        .HasColumnType("TEXT");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DOJ = new DateOnly(2022, 11, 3),
                            Designation = "Developer",
                            Email = "a@gmail.com",
                            FirstName = "Anupam",
                            LastName = "Mohanty"
                        },
                        new
                        {
                            Id = 2,
                            DOJ = new DateOnly(2022, 11, 3),
                            Designation = "Developer",
                            Email = "avi@gmail.com",
                            FirstName = "Avinash",
                            LastName = "Kumar"
                        },
                        new
                        {
                            Id = 3,
                            DOJ = new DateOnly(2022, 10, 3),
                            Designation = "Tester",
                            Email = "aditya@gmail.com",
                            FirstName = "Aditya",
                            LastName = "Khadanga"
                        },
                        new
                        {
                            Id = 4,
                            DOJ = new DateOnly(2021, 10, 3),
                            Designation = "Architecture",
                            Email = "anubh@gmail.com",
                            FirstName = "Anubhab",
                            LastName = "Mohanty"
                        },
                        new
                        {
                            Id = 5,
                            DOJ = new DateOnly(2020, 10, 4),
                            Designation = "Sr. Developer",
                            Email = "kurnal@gmail.com",
                            FirstName = "Kurnal",
                            LastName = "Das"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
