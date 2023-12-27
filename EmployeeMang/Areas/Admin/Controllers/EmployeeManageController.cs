using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.DataAccess.Data;
using EmpMan.DataAccess.Repositories.Repository;
using EmpMan.Models;
using Microsoft.AspNetCore.Mvc;
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
            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll().ToList();
            return View(objEmployeeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        // [HttpPost]
        // public IActionResult Create(Employee obj)
        // {
            // if (obj.Name == obj.DisplayOrder.ToString())
            // {
            //     ModelState.AddModelError("name", "The Display Order Can't be exactly match with Name");
            // }
            // if(ModelState.IsValid){
            //     _db.Employees.Add(obj);
            //     _db.SaveChanges();
            //     return RedirectToAction("Index", "EmployeeManage");
            // }
        //     return View();
        // }

    }
}