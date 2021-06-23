using HREmroll.Models;
using HREmroll.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Controllers
{
    public class CityController : Controller
    {
        private readonly IConfiguration _configuration;


        public CityController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }

        public IActionResult GetAll()
        {
            CityRepository objRepo = new CityRepository(_configuration);
            return View(objRepo.GetAllCity());
        }

        public ActionResult Create()
        {
            CountryRepository objRepo = new CountryRepository(_configuration);
            StateRepository objRepo1 = new StateRepository(_configuration);

            ViewBag.data = objRepo.GetAll();
            ViewBag.data1 = objRepo1.Grupbyid();
            return View();
        }

        // POST: Employee/AddEmployee      
        [HttpPost]
        public IActionResult Create(City obj)
        {
            try
            {

                //obj.BRANCH_NAME = "Default";
                //if (ModelState.IsValid)
                //{
                //    
                //
                //}
                CityRepository objRepo = new CityRepository(_configuration);

                objRepo.AddCity(obj);

                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("GetAll");
                // return View("GetAllDepartments");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            CityRepository objRepo = new CityRepository(_configuration);
            City obj = objRepo.GetById().Find(obj => obj.CITY_ID == id);

            //return View(EmpRepo.GetAllEmployees().Find(Emp => Emp. == id));
            CountryRepository br = new CountryRepository(_configuration);
            StateRepository objRepo1 = new StateRepository(_configuration);

            ViewBag.data = br.GetAll();
            ViewBag.data1 = objRepo1.Grupbyid();
            return View(obj);

        }
        [HttpPost]
        public IActionResult Edit(City obj)
        {
            try
            {
                CityRepository objRepo = new CityRepository(_configuration);

                objRepo.UpdateCity(obj);

                return RedirectToAction("GetAll");
            }
            catch
            {
                return View();
            }

        }
        public IActionResult Delete(int id)
        {
            try
            {
                CityRepository objRepo = new CityRepository(_configuration);
                if (objRepo.Delete(id))
                {
                    ViewBag.AlertMsg = "Designation deleted successfully";

                }
                return RedirectToAction("GetAll");
            }
            catch
            {
                return RedirectToAction("GetAll");

            }


        }

    }
}
