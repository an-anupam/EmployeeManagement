using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.DataAccess.Data;
using EmpMan.DataAccess.Repositories.Repository;
using EmpMan.Models;

namespace EmpMan.DataAccess.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private ApplicationDbContext _db;

        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Department obj){
             _db.Departments.Update(obj);
        }
    }
}