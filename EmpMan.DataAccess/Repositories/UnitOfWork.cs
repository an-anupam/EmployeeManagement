using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.DataAccess.Repositories.Repository;
using EmpMan.Models;
using EmpMan.DataAccess.Data;



namespace EmpMan.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IEmployeeRepository Employee{ get; private set; }

        public ISkillRepository Skill {get; private set;}

        public IDepartmentRepository Department {get; private set;}

        public IEmployeeSkillRepository EmployeeSkill {get; set;}

        public UnitOfWork(ApplicationDbContext db){
            _db = db;
            Employee = new EmployeeRepository(_db);
            Skill  =  new SkillRepository(_db);
            Department = new DepartmentRepository(_db);
            EmployeeSkill = new EmployeeSkillRepository(_db);
           
        }
       
    
       public void Save(){
         _db.SaveChanges();
       }
    }
}