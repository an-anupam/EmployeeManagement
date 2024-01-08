using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmpMan.DataAccess.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmpMan.Models;
using EmpMan.Models.ViewModels;

namespace EmployeeMang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillManageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SkillManageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            // List<Skill> objSkillList = 
               
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}