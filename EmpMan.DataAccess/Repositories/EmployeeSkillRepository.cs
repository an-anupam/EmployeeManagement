using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.DataAccess.Data;
using EmpMan.DataAccess.Repositories.Repository;
using EmpMan.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpMan.DataAccess.Repositories
{
    public class EmployeeSkillRepository : Repository<EmployeeSkill>, IEmployeeSkillRepository
    {
        private ApplicationDbContext _db;

        public EmployeeSkillRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EmployeeSkill obj)
        {
            _db.EmployeeSkills.Update(obj);
        }

        public IEnumerable<EmployeeSkill> GetByEmployeeId(int id, string? includeProperties = null)
        {
            IQueryable<EmployeeSkill> query = dbSet;

            query = query.Where(u => u.EmployeeId == id);

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

    }
}