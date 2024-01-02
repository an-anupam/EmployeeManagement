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
         //   _db.Employees.Update(obj);
          var objFromDb = _db.Employees.FirstOrDefault(u => u.Id == obj.Id);
        if (objFromDb != null)
            {
                objFromDb.FirstName = obj.FirstName;
                objFromDb.LastName = obj.LastName;
                objFromDb.DOJ = obj.DOJ;
                objFromDb.Designation = obj.Designation;
                objFromDb.Email = obj.Email;
                objFromDb.DepartmentId = obj.DepartmentId;
               //  objFromDb.Description = obj.Description;
               //  objFromDb.CategoryId = obj.CategoryId;
               //  objFromDb.Author = obj.Author;
               //  // objFromDb.ProductImages = obj.ProductImages;
               //  if (obj.ImageUrl != null)
               //  {
               //     objFromDb.ImageUrl = obj.ImageUrl;
               //  }
            }
        }
    }
}