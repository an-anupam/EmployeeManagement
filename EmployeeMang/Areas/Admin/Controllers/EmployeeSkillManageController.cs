using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.DataAccess.Repositories.Repository;
using EmpMan.Models;
using EmpMan.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace EmployeeMang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeSkillManageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeSkillManageController (IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        } 

        public IActionResult Index()
        {
            List<EmployeeSkill> ObjEmployeeSkill = _unitOfWork.EmployeeSkill.GetAll(includeProperties: "Skill, Employee").ToList();
            return View(ObjEmployeeSkill);
        }
        
         public IActionResult Assign(int? id)
        {
            EmployeeSkillVM employeeSkillVM = new()
            {
                SkillList = _unitOfWork.Skill.GetAll().Select(u => new SelectListItem
                {
                    Text = u.allSkills,
                    Value = u.Id.ToString()
                }),
                Employee = new Employee(),
                EmployeeSkill = new EmployeeSkill(),
            };
            if(id == null || id == 0)
            {
                //create
                return View(employeeSkillVM);
            }
            else
            {
                //update
                employeeSkillVM.Employee = _unitOfWork.Employee.Get(u=>u.Id == id);
                return View(employeeSkillVM);
            }
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }

        #region API CALLS
         
        [HttpGet]
            public IActionResult GetAll()
        {
            List<EmployeeSkill> ObjEmployeeSkill = _unitOfWork.EmployeeSkill.GetAll(includeProperties: "Skill, Employee").ToList();
            return Json(new{ data = ObjEmployeeSkill});
        }

        #endregion
    }
}