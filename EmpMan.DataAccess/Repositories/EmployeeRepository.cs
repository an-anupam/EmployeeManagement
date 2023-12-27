using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.DataAccess.Data;
using EmpMan.DataAccess.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using EmpMan.Models;

namespace EmpMan.DataAccess.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
         private ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db){
           _db = db;
        }
        
         public void Update(Employee obj)
        {
           _db.Employees.Update(obj);
        }
    }
}