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

        public EmployeeSkillManageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Employee> ObjEmployeeSkill = _unitOfWork.Employee.GetAll().ToList();

            var employeeSkillVMs = ObjEmployeeSkill.Select(e => new EmployeeSkillVM
            {
                Employee = new Employee
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DOJ = e.DOJ,
                    Designation = e.Designation,
                    Email = e.Email,
                    DepartmentId = e.DepartmentId,
                    Department = e.Department
                },
                EmployeeSkills = _unitOfWork.EmployeeSkill.GetByEmployeeId(e.Id, includeProperties: "Skill")
            }).ToList();
            return View(employeeSkillVMs);
            // List<EmployeeSkill> ObjEmployeeSkill = _unitOfWork.EmployeeSkill.GetAll(includeProperties: "Skill, Employee").ToList();
            // return View(ObjEmployeeSkill);
        }

        public IActionResult Assign(int id)
        {
            EmployeeSkillVM employeeSkillVM = new()
            {
                EmployeeSkills = _unitOfWork.EmployeeSkill.GetByEmployeeId(id, includeProperties: "Skill").ToList(),
                SkillList = _unitOfWork.Skill.GetAll().Select(i => new SelectListItem
                {
                    Text = i.allSkills,
                    Value = i.Id.ToString()
                })

            };

            if (id == null || id == 0)
            {

                return NotFound();
            }
            else
            {
                //update
                employeeSkillVM.Employee = _unitOfWork.Employee.Get(u => u.Id == id);
                return View(employeeSkillVM);
            }
        }


        public IActionResult UpdateSkill(int id)
        {
            EmployeeSkillVM employeeSkillVM = new()
            {
                SkillList = _unitOfWork.Skill.GetAll().Select(i => new SelectListItem
                {
                    Text = i.allSkills,
                    Value = i.Id.ToString()
                }),
                EmployeeSkill = new EmployeeSkill()
            };

             if (id == null || id == 0)
            {
               return NoContent();
               
            }
            else
            {
                //update
                employeeSkillVM.EmployeeSkill = _unitOfWork.EmployeeSkill.Get(u => u.EmployeeId == id);
                employeeSkillVM.Employee = _unitOfWork.Employee.Get(u=> u.Id == id);
                return View(employeeSkillVM);
            }
        }


         [HttpPost]
        public IActionResult UpdateSKill(EmployeeSkillVM employeeSkillVM)
        {

            if(employeeSkillVM.EmployeeSkill.Id == 0)
            {
                _unitOfWork.EmployeeSkill.Add(employeeSkillVM.EmployeeSkill);
                _unitOfWork.Save();
                TempData["success"] = "Employee Created Successfully";
                return RedirectToAction("Index", "EmployeeSkillManage");
            }
            if (ModelState.IsValid)
            {
              Console.WriteLine("Entered into If");

                 if(employeeSkillVM.EmployeeSkill.Id != null){
                     _unitOfWork.EmployeeSkill.Update(employeeSkillVM.EmployeeSkill);
                    
                 }
                 else{
                   _unitOfWork.EmployeeSkill.Add(employeeSkillVM.EmployeeSkill);
                 }
                
                            
                _unitOfWork.Save();
                TempData["success"] = "Employee Created Successfully";
                return RedirectToAction("Index", "EmployeeSkillManage");
            }
            else
            {
                Console.WriteLine("Entered into else");
                employeeSkillVM.SkillList = _unitOfWork.Skill.GetAll().Select(u => new SelectListItem
                {
                    Text = u.allSkills,
                    Value = u.Id.ToString()
                });
                return View("UpdateSkill", employeeSkillVM);
            }
        }


        // [HttpPost]
        // public IActionResult Assign(EmployeeSkillVM employeeSkillVM)
        // {

        //     //No Need For Custom Validation in  TItle
        //     // if(obj.Name != null && obj.Name.ToLower() == "test"){
        //     //      ModelState.AddModelError("","Test is an invalid value");
        //     // }
        //     if (ModelState.IsValid)
        //     {
        //         // string wwwRootPath = _webHostEnvironment.WebRootPath;
        //         // if (file != null)
        //         // {
        //         //     string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //         //     string productPath = Path.Combine(wwwRootPath, @"images\product");

        //         //     if(!string.IsNullOrEmpty(productVM.Product.ImageUrl))
        //         //     {
        //         //         var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
        //         //         if(System.IO.File.Exists(oldImagePath))
        //         //         {
        //         //             System.IO.File.Delete(oldImagePath);
        //         //         }
        //         //     }

        //         //     using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
        //         //     {
        //         //         file.CopyTo(fileStream);
        //         //     }

        //         //     productVM.Product.ImageUrl = @"\images\product\" + fileName;
        //         // }


        //         _unitOfWork.EmployeeSkill.Update(employeeSkillVM.EmployeeSkill);
        //         _unitOfWork.Save();
        //         // TempData["success"] = "Employee Created Successfully";
        //         return RedirectToAction("Index", "EmployeeManage");
        //     }
        //     else
        //     {
        //         employeeSkillVM.SkillList = _unitOfWork.Department.GetAll().Select(u => new SelectListItem
        //         {
        //             Text = u.Name,
        //             Value = u.Id.ToString()
        //         });
        //         return View(employeeSkillVM);
        //     }
        // }


        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> ObjEmployeeSkill = _unitOfWork.Employee.GetAll().ToList();

            var employeeSkillVMs = ObjEmployeeSkill.Select(e => new EmployeeSkillVM
            {
                Employee = new Employee
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DOJ = e.DOJ,
                    Designation = e.Designation,
                    Email = e.Email,
                    DepartmentId = e.DepartmentId,
                    Department = e.Department
                },
                EmployeeSkills = _unitOfWork.EmployeeSkill.GetByEmployeeId(e.Id, includeProperties: "Skill")
            }).ToList();

            return Json(new { data = employeeSkillVMs });
        }



        [HttpGet]
        public IActionResult AssignSkill(int id)
        {
            EmployeeSkillVM employeeSkillVM = new()
            {
                EmployeeSkills = _unitOfWork.EmployeeSkill.GetByEmployeeId(id, includeProperties: "Skill").ToList(),
                SkillList = _unitOfWork.Skill.GetAll().Select(i => new SelectListItem
                {
                    Text = i.allSkills,
                    Value = i.Id.ToString()
                })
            };


            if (id == null || id == 0)
            {

                return NotFound();
            }
            else
            {
                //update
                employeeSkillVM.Employee = _unitOfWork.Employee.Get(u => u.Id == id);
                return Json(new { data = employeeSkillVM });
            }
        }




        #endregion
    }
}