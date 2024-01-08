using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.DataAccess.Data;
using EmpMan.DataAccess.Repositories.Repository;
using EmpMan.Models;

namespace EmpMan.DataAccess.Repositories
{
    public class EmployeeSkillRepository : Repository<EmployeeSkill>, IEmployeeSkillRepository
    {
       private ApplicationDbContext _db;
       
       public EmployeeSkillRepository(ApplicationDbContext db) : base(db){
          _db = db;
       }

       public void Update(EmployeeSkill obj){
          _db.EmployeeSkills.Update(obj);
       }

    }
}