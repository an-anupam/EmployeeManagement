using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpMan.Models.ViewModels
{
    public class EmployeeSkillVM
    {
        public Employee? Employee { get; set; }

        [ValidateNever]
        public EmployeeSkill? EmployeeSkill { get; set; }

        [ValidateNever]
        public IEnumerable<EmployeeSkill>? EmployeeSkills { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem>? SkillList { get; set; }
    }
}