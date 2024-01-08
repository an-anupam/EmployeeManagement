﻿// <auto-generated />
using System;
using EmpMan.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmpMan.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        },
                        new
                        {
                            Id = 6,
                            DOJ = new DateOnly(2021, 12, 4),
                            DepartmentId = 4,
                            Designation = "Frotend Developer",
                            Email = "SomeGuy@gmail.com",
                            FirstName = "Some",
                            LastName = "Guy"
                        });
                });

            modelBuilder.Entity("EmpMan.Models.EmployeeSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("experienceInSkill")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ratingsInSkill")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SkillId");

                    b.ToTable("EmployeeSkills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1,
                            SkillId = 1,
                            experienceInSkill = 1,
                            ratingsInSkill = 1
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 3,
                            SkillId = 2,
                            experienceInSkill = 3,
                            ratingsInSkill = 4
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 4,
                            SkillId = 4,
                            experienceInSkill = 4,
                            ratingsInSkill = 4
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 2,
                            SkillId = 6,
                            experienceInSkill = 5,
                            ratingsInSkill = 8
                        },
                        new
                        {
                            Id = 5,
                            EmployeeId = 5,
                            SkillId = 8,
                            experienceInSkill = 1,
                            ratingsInSkill = 1
                        },
                        new
                        {
                            Id = 6,
                            EmployeeId = 6,
                            SkillId = 9,
                            experienceInSkill = 7,
                            ratingsInSkill = 8
                        });
                });

            modelBuilder.Entity("EmpMan.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("allSkills")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            allSkills = "JavaScript"
                        },
                        new
                        {
                            Id = 2,
                            allSkills = "Java"
                        },
                        new
                        {
                            Id = 3,
                            allSkills = "Python"
                        },
                        new
                        {
                            Id = 4,
                            allSkills = ".Net Frameworks"
                        },
                        new
                        {
                            Id = 5,
                            allSkills = "C++"
                        },
                        new
                        {
                            Id = 6,
                            allSkills = "C"
                        },
                        new
                        {
                            Id = 7,
                            allSkills = "AWS Cloud"
                        },
                        new
                        {
                            Id = 8,
                            allSkills = "Azure Cloud"
                        },
                        new
                        {
                            Id = 9,
                            allSkills = "Azure Cloud"
                        },
                        new
                        {
                            Id = 10,
                            allSkills = "Azure Cloud"
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

            modelBuilder.Entity("EmpMan.Models.EmployeeSkill", b =>
                {
                    b.HasOne("EmpMan.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmpMan.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Skill");
                });
#pragma warning restore 612, 618
        }
    }
}
