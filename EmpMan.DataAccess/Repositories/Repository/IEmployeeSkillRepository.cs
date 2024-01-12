using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.Models;

namespace EmpMan.DataAccess.Repositories.Repository
{
    public interface IEmployeeSkillRepository : IRepository<EmployeeSkill>
    {
        void Update(EmployeeSkill obj);


        IEnumerable<EmployeeSkill> GetByEmployeeId(int id, string? includeProperties = null);
    }
}