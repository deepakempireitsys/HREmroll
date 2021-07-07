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
    public class CountryController : Controller
    {

        private readonly IConfiguration _configuration;


        public CountryController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }
        public IActionResult Getall()
        {
            CountryRepository objRepo = new CountryRepository(_configuration);
            return View(objRepo.GetAll());
        }
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employee/AddEmployee      
        [HttpPost]
        public IActionResult Create(Country obj)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    CountryRepository objRepo = new CountryRepository(_configuration);

                    objRepo.AddCountry(obj);

                    ViewBag.Message = "Records added successfully.";

                    return RedirectToAction("GetAll");
                }
                else
                {
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            CountryRepository objRepo = new CountryRepository(_configuration);
            Country obj = objRepo.GetAll().Find(obj => obj.COUNTRY_ID == id);
            //return View(EmpRepo.GetAllEmployees().Find(Emp => Emp. == id));

            return View(obj);

        }
        [HttpPost]
        public IActionResult Edit(Country obj)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    CountryRepository objRepo = new CountryRepository(_configuration);

                    objRepo.UpdateCountry(obj);

                    return RedirectToAction("GetAll");
                }
                else
                {
                    return View();

                }
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
                CountryRepository objRepo = new CountryRepository(_configuration);
                if (objRepo.DeleteCountry(id))
                {
                    ViewBag.AlertMsg = "Counry deleted successfully";

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
