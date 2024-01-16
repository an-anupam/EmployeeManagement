using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.DataAccess.Repositories.Repository;
using EmpMan.Models;
using EmpMan.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeMang.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Authorize(Roles =  SD.Role_SuperAdmin)]
    public class DepartmentManageController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public DepartmentManageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Department> objEmployeeList = _unitOfWork.Department.GetAll().ToList();
            return View(objEmployeeList);
        }

        public IActionResult Create()
        {
            // int lastId = _unitOfWork.Department.GetAll().OrderByDescending(d => d.Id).FirstOrDefault()?.Id ?? 0;
            // System.Diagnostics.Debug.WriteLine($"Last ID: {lastId}");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department obj)
        {

            // if(obj.Name == obj.DisplayOrder.ToString()){
            //     ModelState.AddModelError("name", "The Display Order Can't be exactly match with Name");
            // }
            // if(obj.Name != null && obj.Name.ToLower() == "test"){
            //      ModelState.AddModelError("","Test is an invalid value");
            // }
            if (ModelState.IsValid)
            {

                _unitOfWork.Department.Add(obj);
                _unitOfWork.Save();
                 TempData["success"]="Department Created Successfully";
                return RedirectToAction("Index", "DepartmentManage");
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id != null && id != 0)
            {
                Department? departmentFromDb = _unitOfWork.Department.Get(u => u.Id == id);
                if (departmentFromDb == null)
                {
                    return NotFound();
                }

                return View(departmentFromDb);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Department obj)
        {


            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Update(obj);
                _unitOfWork.Save();
                  TempData["success"]="Department Updated Successfully";
                return RedirectToAction("Index", "DepartmentManage");
            }
            return View();
        }


        // public IActionResult Delete(int? id)
        // {
        //     if (id != null && id != 0)
        //     {
        //         Department? departmentFromDb = _unitOfWork.Department.Get(u => u.Id == id);
        //         if (departmentFromDb == null)
        //         {
        //             return NotFound();
        //         }

        //         return View(departmentFromDb);
        //     }

        //     return NotFound();
        // }


        //   [HttpPost, ActionName("Delete")]
        //    public IActionResult DeletePOST(int? id){

        //     if(id != null && id != 0){
        //         Department? obj = _unitOfWork.Department.Get( u => u.Id == id);
        //         _unitOfWork.Department.Remove(obj);
        //         _unitOfWork.Save();
        //         //  TempData["success"]="Category Deleted Successfully";
        //          return RedirectToAction("Index", "DepartmentManage");
        //     }

        //     return View();
        //    }


        #region API CALLS
        
          [HttpGet]
          public IActionResult GetAll()
        {
            List<Department> objDepartmentList = _unitOfWork.Department.GetAll().ToList();
            return Json(new { data = objDepartmentList });
        }
         
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
       

        
         public IActionResult Delete(int? id)
        {
            var departmentToBeDeleted = _unitOfWork.Department.Get(u => u.Id == id);
            if (departmentToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
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
            _unitOfWork.Department.Remove(departmentToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Successful" });
        }

        #endregion

    }
}