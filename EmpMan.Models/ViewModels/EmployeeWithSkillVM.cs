using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpMan.Models.ViewModels
{
    public class EmployeeWithSkillVM
    {
        public EmployeeVM? EmployeeVMs{get; set;}

        public EmployeeSkillVM? EmployeeSkillVMs {get; set;}
    }
}