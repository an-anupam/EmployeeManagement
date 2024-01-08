using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.DataAccess.Data;
using EmpMan.DataAccess.Repositories.Repository;
using EmpMan.Models;
using EmpMan.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;


namespace EmployeeMang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeManageController : Controller
    {
        private readonly IUnitOfWork? _unitOfWork;

        public EmployeeManageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll(includeProperties: "Department").ToList();
            return View(objEmployeeList);
        }

        public IActionResult Upsert(int? id)
        {
            EmployeeVM employeeVM = new()
            {
                DepartmentList = _unitOfWork.Department.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Employee = new Employee()
            };
            if (id == null || id == 0)
            {
                //create
                return View(employeeVM);
            }
            else
            {
                //update
                employeeVM.Employee = _unitOfWork.Employee.Get(u => u.Id == id);
                return View(employeeVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(EmployeeVM employeeVM)
        {

            //No Need For Custom Validation in  TItle
            // if(obj.Name != null && obj.Name.ToLower() == "test"){
            //      ModelState.AddModelError("","Test is an invalid value");
            // }
            if (ModelState.IsValid)
            {
                // string wwwRootPath = _webHostEnvironment.WebRootPath;
                // if (file != null)
                // {
                //     string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                //     string productPath = Path.Combine(wwwRootPath, @"images\product");

                //     if(!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                //     {
                //         var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                //         if(System.IO.File.Exists(oldImagePath))
                //         {
                //             System.IO.File.Delete(oldImagePath);
                //         }
                //     }

                //     using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                //     {
                //         file.CopyTo(fileStream);
                //     }

                //     productVM.Product.ImageUrl = @"\images\product\" + fileName;
                // }

                if (employeeVM.Employee.Id == 0)
                {
                    _unitOfWork.Employee.Add(employeeVM.Employee);
                }
                else
                {
                    _unitOfWork.Employee.Update(employeeVM.Employee);
                }

                _unitOfWork.Save();
                TempData["success"] = "Employee Created Successfully";
                return RedirectToAction("Index", "EmployeeManage");
            }
            else
            {
                employeeVM.DepartmentList = _unitOfWork.Department.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(employeeVM);
            }
        }



        // public IActionResult Delete(int? id)
        // {
        //     if (id != null && id != 0)
        //     {
        //         Employee? employeeFromDb = _unitOfWork.Employee.Get(u => u.Id == id);
        //         if (employeeFromDb == null)
        //         {
        //             return NotFound();
        //         }

        //         return View(employeeFromDb);
        //     }
        //     return NotFound();
        // }

        // [HttpPost, ActionName("Delete")]
        // public IActionResult DeletePOST(int? id)
        // {
        //     if (id != null && id != 0)
        //     {
        //         Employee? obj = _unitOfWork.Employee.Get(u => u.Id == id);
        //         _unitOfWork.Employee.Remove(obj);
        //         _unitOfWork.Save();
        //         // TempData["success"] = "Product Deleted Successfully";
        //         return RedirectToAction("Index", "EmployeeManage");
        //     }
        //     return View();
        // }




        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll(includeProperties: "Department").ToList();
            return Json(new { data = objEmployeeList });
        }


         
        public IActionResult Delete(int? id)
        {
            var employeeToBeDeleted = _unitOfWork.Employee.Get(u => u.Id == id);
            if (employeeToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            // string employeePath = @"images\products\product-" + id;
            // string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);

            // if (Directory.Exists(finalPath)) {
            //     string[] filePaths = Directory.GetFiles(finalPath);
            //     foreach (string filePath in filePaths) {
            //         System.IO.File.Delete(filePath);
            //     }

            //     Directory.Delete(finalPath);
            // }
            _unitOfWork.Employee.Remove(employeeToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Successful" });
        }

        #endregion

    }
}