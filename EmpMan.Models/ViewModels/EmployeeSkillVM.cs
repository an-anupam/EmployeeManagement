using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpMan.Models.ViewModels
{
    public class EmployeeSkillVM
    {
        public Employee? Employee;

        public EmployeeSkill? EmployeeSkill;

        public IEnumerable<SelectListItem>? SkillList;
    }
}