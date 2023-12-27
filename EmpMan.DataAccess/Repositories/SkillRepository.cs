using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.DataAccess.Repositories.Repository;
using EmpMan.Models;
using EmpMan.DataAccess.Data;

namespace EmpMan.DataAccess.Repositories
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        private ApplicationDbContext _db;

        public SkillRepository(ApplicationDbContext db) : base(db){
           _db = db;
        }

        public void Update(Skill obj)
        {
            _db.Skills.Update(obj);
        }

    }
}
