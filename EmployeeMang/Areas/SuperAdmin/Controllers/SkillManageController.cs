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
    public class SkillManageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SkillManageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            List<Skill> objSkillList = _unitOfWork.Skill.GetAll().ToList();
            return View(objSkillList);
        }
        
         public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Skill obj)
        {

            // if(obj.Name == obj.DisplayOrder.ToString()){
            //     ModelState.AddModelError("name", "The Display Order Can't be exactly match with Name");
            // }
            // if(obj.Name != null && obj.Name.ToLower() == "test"){
            //      ModelState.AddModelError("","Test is an invalid value");
            // }
            if (ModelState.IsValid)
            {

                _unitOfWork.Skill.Add(obj);
                _unitOfWork.Save();
                 TempData["success"]="Skill Added Successfully";
                return RedirectToAction("Index", "SkillManage");
            }
            return View();
        }


         public IActionResult Edit(int? id)
        {
            if (id != null && id != 0)
            {
                Skill? skillFromDb = _unitOfWork.Skill.Get(u => u.Id == id);
                if (skillFromDb == null)
                {
                    return NotFound();
                }

                return View(skillFromDb);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult Edit(Skill obj)
        {


            if (ModelState.IsValid)
            {
                _unitOfWork.Skill.Update(obj);
                _unitOfWork.Save();
                  TempData["success"]="Skill Updated Successfully";
                return RedirectToAction("Index", "SkillManage");
            }
            return View();
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
            List<Skill> objSkillList = _unitOfWork.Skill.GetAll().ToList();
            return Json(new { data = objSkillList });
        }

        public IActionResult Delete(int? id)
        {
            var skillToBeDeleted = _unitOfWork.Skill.Get(u => u.Id == id);
            if (skillToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            _unitOfWork.Skill.Remove(skillToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Successful" });
        }

          #endregion
    }
}