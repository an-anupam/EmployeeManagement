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

        public DbSet<EmployeeSkill> EmployeeSkills{get; set;}

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
               },
               new Employee
               {
                   Id = 6,
                   FirstName = "Some",
                   LastName = "Guy",
                   DOJ = DateOnly.FromDateTime(new DateTime(2021, 12, 4)),
                   Designation = "Frotend Developer",
                   Email = "SomeGuy@gmail.com",
                   DepartmentId = 4
               }
               );

            modelBuilder.Entity<Skill>().HasData(
            new Skill
            {
                Id = 1,
                allSkills = "JavaScript"
                
            },
            new Skill
            {
                Id = 2,
                allSkills = "Java"
                
            },
            new Skill
            {
                Id = 3,
                allSkills = "Python"
                
            },
            new Skill
            {
                Id = 4,
                allSkills = ".Net Frameworks"
                
            },
             new Skill
             {
                 Id = 5,
                 allSkills = "C++"
                
             },
             new Skill
             {
                 Id = 6,
                 allSkills = "C"
                 
             },
             new Skill
             {
                 Id = 7,
                 allSkills = "AWS Cloud"
                
             },
             new Skill
             {
                 Id = 8,
                 allSkills = "Azure Cloud"
                
             },
             new Skill
             {
                 Id = 9,
                 allSkills = "Azure Cloud"
                 
             },
             new Skill
             {
                 Id = 10,
                 allSkills = "Azure Cloud"
                
             }
            );

        modelBuilder.Entity<EmployeeSkill>().HasData(
            new EmployeeSkill
            {
                Id = 1,
                EmployeeId = 1,
                SkillId = 1,
                ratingsInSkill=1,
                experienceInSkill=1
            },

             new EmployeeSkill
            {
                Id = 2,
                EmployeeId = 3,
                SkillId = 2,
                ratingsInSkill=4,
                experienceInSkill=3
            },

             new EmployeeSkill
            {
                Id = 3,
                EmployeeId = 4,
                SkillId = 4,
                ratingsInSkill=4,
                experienceInSkill=4
            },

             new EmployeeSkill
            {
                Id = 4,
                EmployeeId = 2,
                SkillId = 6,
                ratingsInSkill=8,
                experienceInSkill=5
            },

             new EmployeeSkill
            {
                Id = 5,
                EmployeeId = 5,
                SkillId = 8,
                ratingsInSkill=1,
                experienceInSkill=1
            },

             new EmployeeSkill
            {
                Id = 6,
                EmployeeId = 6,
                SkillId = 9,
                ratingsInSkill=8,
                experienceInSkill=7
            }

        );   
        

        }

    }

}

