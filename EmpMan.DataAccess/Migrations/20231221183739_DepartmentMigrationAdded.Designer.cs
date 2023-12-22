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
    [Migration("20231221183739_DepartmentMigrationAdded")]
    partial class DepartmentMigrationAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("EmpMan.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "PSS"
                        },
                        new
                        {
                            Id = 2,
                            Name = "CSP"
                        },
                        new
                        {
                            Id = 3,
                            Name = "TSP"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Rail"
                        });
                });

            modelBuilder.Entity("EmpMan.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DOJ")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

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

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DOJ = new DateOnly(2022, 11, 3),
                            DepartmentId = 1,
                            Designation = "Developer",
                            Email = "a@gmail.com",
                            FirstName = "Anupam",
                            LastName = "Mohanty"
                        },
                        new
                        {
                            Id = 2,
                            DOJ = new DateOnly(2022, 11, 3),
                            DepartmentId = 2,
                            Designation = "Developer",
                            Email = "avi@gmail.com",
                            FirstName = "Avinash",
                            LastName = "Kumar"
                        },
                        new
                        {
                            Id = 3,
                            DOJ = new DateOnly(2022, 10, 3),
                            DepartmentId = 2,
                            Designation = "Tester",
                            Email = "aditya@gmail.com",
                            FirstName = "Aditya",
                            LastName = "Khadanga"
                        },
                        new
                        {
                            Id = 4,
                            DOJ = new DateOnly(2021, 10, 3),
                            DepartmentId = 3,
                            Designation = "Architecture",
                            Email = "anubh@gmail.com",
                            FirstName = "Anubhab",
                            LastName = "Mohanty"
                        },
                        new
                        {
                            Id = 5,
                            DOJ = new DateOnly(2020, 10, 4),
                            DepartmentId = 1,
                            Designation = "Sr. Developer",
                            Email = "kurnal@gmail.com",
                            FirstName = "Kurnal",
                            LastName = "Das"
                        });
                });

            modelBuilder.Entity("EmpMan.Models.Employee", b =>
                {
                    b.HasOne("EmpMan.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
