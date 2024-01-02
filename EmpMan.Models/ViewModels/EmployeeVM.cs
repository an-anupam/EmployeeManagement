using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EmpMan.Models.ViewModels
{
    public class EmployeeVM
    {
        public Employee? Employee{get; set;}
        
        [ValidateNever]
        public IEnumerable<SelectListItem>? DepartmentList {get; set;}
        
        
    }
}