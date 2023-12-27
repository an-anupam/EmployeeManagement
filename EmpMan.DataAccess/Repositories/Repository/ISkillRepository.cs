using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.Models;

namespace EmpMan.DataAccess.Repositories.Repository
{
    public interface ISkillRepository : IRepository<Skill> 
    {
        void Update(Skill obj);
    }
}