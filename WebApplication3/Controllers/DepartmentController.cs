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
    public class DepartmentController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ViewResult Index()
        {
            var model = _unitOfWork.DepartmentRepository.GetAll();
            return View(model);
        }
        public ViewResult Details(int? id)
        {
            Department Department = _unitOfWork.DepartmentRepository.Get(id.Value);
            if (Department == null)
            {
                Response.StatusCode = 404;
                return View("Department", id.Value);
            }
            return View(Department);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department Model)
        {
            if (ModelState.IsValid)
            {
                Department NewDepartment = new Department
                {
                    Name = Model.Name,
                };
                _unitOfWork.DepartmentRepository.Add(NewDepartment);
                _unitOfWork.Complete();
                return RedirectToAction("details", new { id = NewDepartment.ID });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Department Department = _unitOfWork.DepartmentRepository.Get(id);
            return View(Department);
        }

        [HttpPost]
        public IActionResult Edit(Department Model)
        {
            if (ModelState.IsValid)
            {
                Department Department = _unitOfWork.DepartmentRepository.Get(Model.ID);
                Department.Name = Model.Name;

                _unitOfWork.DepartmentRepository.Update(Department);
                _unitOfWork.Complete();
                return RedirectToAction("index");
            }
            return View();
        }
    }
}
