using AspNet_Core.Models;
using AspNet_Core.Models.ViewModel;
using AspNet_Core.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Core.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ViewResult Index()
        {
            var model = _unitOfWork.EmployeeRepository.Get();
            return View(model);
        }
        public ViewResult Details(int? id)
        {
            Employee employee = _unitOfWork.EmployeeRepository.GetByID(id.Value);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }
            return View(employee);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee Model)
        {
            if (ModelState.IsValid)
            {
                Employee NewEmployee = new Employee
                {
                    Name = Model.Name,
                    HireDate=Model.HireDate,
                    Salary=Model.Salary,
                    subSectionId=Model.subSectionId
                };
                _unitOfWork.EmployeeRepository.Insert(NewEmployee);
                return RedirectToAction("details", new { id = NewEmployee.ID });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _unitOfWork.EmployeeRepository.GetByID(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee Model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _unitOfWork.EmployeeRepository.GetByID(Model.ID);
                employee.Name = Model.Name;
                employee.HireDate = Model.HireDate;
                employee.Salary = Model.Salary;
                employee.subSectionId = Model.subSectionId;

                _unitOfWork.EmployeeRepository.Update(employee);
                return RedirectToAction("index");
            }
            return View();
        }
    }
}
