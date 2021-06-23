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
    public class StateController : Controller
    {
        private readonly IConfiguration _configuration;


        public StateController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }

        public IActionResult GetAll()
        {
            StateRepository objRepo = new StateRepository(_configuration);
            return View(objRepo.GetAllState());
        }

        public ActionResult Create()
        {
           CountryRepository br = new CountryRepository(_configuration);

            ViewBag.data = br.GetAll();
            return View();
        }

        // POST: Employee/AddEmployee      
        [HttpPost]
        public IActionResult Create(State obj)
        {
            try
            {
     
                //obj.BRANCH_NAME = "Default";
                //if (ModelState.IsValid)
                //{
                //    
                //
                //}
                StateRepository objRepo = new StateRepository(_configuration);

                objRepo.AddState(obj);

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
            StateRepository objRepo = new StateRepository(_configuration);
            State obj = objRepo.Grupbyid().Find(obj => obj.STATE_ID == id);
      
            //return View(EmpRepo.GetAllEmployees().Find(Emp => Emp. == id));
            CountryRepository br = new CountryRepository(_configuration);

            ViewBag.data = br.GetAll();
   
            return View(obj);

        }
        [HttpPost]
        public IActionResult Edit(State obj)
        {
            try
            {
                StateRepository objRepo = new StateRepository(_configuration);

                objRepo.Updatestate(obj);

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
                StateRepository objRepo = new StateRepository(_configuration);
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
