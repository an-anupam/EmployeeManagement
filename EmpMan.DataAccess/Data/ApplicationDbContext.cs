using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmpMan.Models;



namespace EmpMan.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>().HasData(
              new Department
              {
                  Id = 1,
                  Name = "PSS"
              },
              new Department
              {
                  Id = 2,
                  Name = "CSP"
              },
              new Department
              {
                  Id = 3,
                  Name = "TSP"
              },
              new Department
              {
                  Id = 4,
                  Name = "Rail"
              }

          );


            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   FirstName = "Anupam",
                   LastName = "Mohanty",
                   DOJ = DateOnly.FromDateTime(new DateTime(2022, 11, 3)),
                   Designation = "Developer",
                   Email = "a@gmail.com",
                   DepartmentId = 1
               },
               new Employee
               {
                   Id = 2,
                   FirstName = "Avinash",
                   LastName = "Kumar",
                   DOJ = DateOnly.FromDateTime(new DateTime(2022, 11, 3)),
                   Designation = "Developer",
                   Email = "avi@gmail.com",
                   DepartmentId = 2

               },
               new Employee
               {
                   Id = 3,
                   FirstName = "Aditya",
                   LastName = "Khadanga",
                   DOJ = DateOnly.FromDateTime(new DateTime(2022, 10, 3)),
                   Designation = "Tester",
                   Email = "aditya@gmail.com",
                   DepartmentId = 2

               },
               new Employee
               {
                   Id = 4,
                   FirstName = "Anubhab",
                   LastName = "Mohanty",
                   DOJ = DateOnly.FromDateTime(new DateTime(2021, 10, 3)),
                   Designation = "Architecture",
                   Email = "anubh@gmail.com",
                   DepartmentId = 3

               },
               new Employee
               {
                   Id = 5,
                   FirstName = "Kurnal",
                   LastName = "Das",
                   DOJ = DateOnly.FromDateTime(new DateTime(2020, 10, 4)),
                   Designation = "Sr. Developer",
                   Email = "kurnal@gmail.com",
                   DepartmentId = 1
               }
               );

            modelBuilder.Entity<Skill>().HasData(
            new Skill
            {
                Id = 1,
                PrimarySkill = "Java",
                SecondarySkill = "JavaScript",
                ratingsInSkill = 7,
                experienceInSkill = 3
            },
            new Skill
            {
                Id = 2,
                PrimarySkill = "C++",
                SecondarySkill = "Swift",
                ratingsInSkill = 6,
                experienceInSkill = 2
            },
            new Skill
            {
                Id = 3,
                PrimarySkill = "C#",
                SecondarySkill = "JavaScript",
                ratingsInSkill = 8,
                experienceInSkill = 1
            },
            new Skill
            {
                Id = 4,
                PrimarySkill = "Python",
                SecondarySkill = "Java",
                ratingsInSkill = 7,
                experienceInSkill = 2
            }

          );
        }

    }

}

