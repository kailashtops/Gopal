using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    public class EmpController : Controller
    {
        private readonly IEmployeeRepository _repo;

        public EmpController(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var employees = _repo.GetAllEmployees();
            return View(employees);
        }
        public IActionResult Add() => View();

    
        [HttpPost]
        public IActionResult Add(Employes model)
        {
            if (model.ProfileImagePath == null && string.IsNullOrEmpty(model.ExistingProfileImagePath))
            {
                ModelState.AddModelError("ProfileImagePath", "Please upload a profile image.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Save new file if uploaded
            if (model.ProfileImagePath != null)
            {
                var uploadsFolder = Path.Combine("wwwroot", "Images");
                Directory.CreateDirectory(uploadsFolder); // ensure folder exists
                var fileName = Path.GetFileName(model.ProfileImagePath.FileName);
                var savePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = System.IO.File.Create(savePath))
                {
                    model.ProfileImagePath.CopyTo(fileStream);
                }
                model.ExistingProfileImagePath = "/Images/" + fileName;
            }
            _repo.AddEmployee(model);
           
            return RedirectToAction("Index");
        }



    }
}
