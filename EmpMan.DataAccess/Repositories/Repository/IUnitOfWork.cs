using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.Models;

namespace EmpMan.DataAccess.Repositories.Repository
{
    public interface IUnitOfWork
    {
         IEmployeeRepository Employee{ get; }
         ISkillRepository Skill{get; }

         IDepartmentRepository Department{get; }

         IEmployeeSkillRepository EmployeeSkill{get;}

        void Save();
    }
}