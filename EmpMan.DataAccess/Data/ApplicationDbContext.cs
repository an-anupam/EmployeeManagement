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
                allSkills = "JavaScript",
                ratingsInSkill = 1,
                experienceInSkill = 1
            },
            new Skill
            {
                Id = 2,
                allSkills = "Java",
                ratingsInSkill = 2,
                experienceInSkill = 2
            },
            new Skill
            {
                Id = 3,
                allSkills = "Python",
                ratingsInSkill = 3,
                experienceInSkill = 3
            },
            new Skill
            {
                Id = 4,
                allSkills = ".Net Frameworks",
                ratingsInSkill = 4,
                experienceInSkill = 4
            },
             new Skill
             {
                 Id = 5,
                 allSkills = "C++",
                 ratingsInSkill = 5,
                 experienceInSkill = 5
             },
             new Skill
             {
                 Id = 6,
                 allSkills = "C",
                 ratingsInSkill = 6,
                 experienceInSkill = 6
             },
             new Skill
             {
                 Id = 7,
                 allSkills = "AWS Cloud",
                 ratingsInSkill = 7,
                 experienceInSkill = 7
             },
             new Skill
             {
                 Id = 8,
                 allSkills = "Azure Cloud",
                 ratingsInSkill = 8,
                 experienceInSkill = 8
             },
             new Skill
             {
                 Id = 9,
                 allSkills = "Azure Cloud",
                 ratingsInSkill = 9,
                 experienceInSkill = 9
             },
             new Skill
             {
                 Id = 10,
                 allSkills = "Azure Cloud",
                 ratingsInSkill = 10,
                 experienceInSkill = 10
             }
            );
        }

    }

}

