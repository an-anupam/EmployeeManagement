using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmpMan.Models;
using EmpMan.DataAccess.Repositories.Repository;
using EmpMan.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeMang.Areas.User.Controllers;

[Area("User")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;


    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll(includeProperties: "Department").ToList();
        var employeeSkillVMs = objEmployeeList.Select(e => new EmployeeSkillVM
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
    }


    public IActionResult View(int id)
    {
        EmployeeSkillVM employeeSkillVM = new EmployeeSkillVM
        {
            Employee = _unitOfWork.Employee.Get(u => u.Id == id, includeProperties: "Department"),
            EmployeeSkills = _unitOfWork.EmployeeSkill.GetByEmployeeId(id, includeProperties: "Skill")
        };

        if (employeeSkillVM.Employee == null)
        {
            return NotFound(); // or handle appropriately
        }

        return View(employeeSkillVM);

    }

    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll(includeProperties: "Department").ToList();
        var employeeSkillVMs = objEmployeeList.Select(e => new EmployeeSkillVM
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

    #endregion
}
//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
// public IActionResult Error()
// {
//     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
// }

