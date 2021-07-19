using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HREmroll.Models;
using HREmroll.Repository;
using Microsoft.Extensions.Configuration;

namespace HREmroll.Controllers
{
    public class LicenceController : Controller
    {
        //public IActionResult Test()
        //{
        //    return View();
        //}

        // GET: Licence/GetAll     

        private readonly IConfiguration _configuration;

        public LicenceController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }
        public IActionResult GetAll()
        {
            LicenceRepository EmpRepo = new LicenceRepository(_configuration);
            return View(EmpRepo.GetAll());
        }
        // GET: Licence/AddLicence      

        public IActionResult GetActive()
        {
            LicenceRepository objRepo = new LicenceRepository(_configuration);
            return View(objRepo.GetActive());
        }

        public IActionResult GetInActive()
        {
            LicenceRepository objRepo = new LicenceRepository(_configuration);
            return View(objRepo.GetInActive());
        }


        public ActionResult Add()
        {
            return View();
        }

        // POST: Licence/AddLicence      
        [HttpPost]
        public IActionResult Add(Licence obj)
        {
            try
            {
                ModelState.Remove("LICENCE_ID");
                ModelState.Remove("CREATED_DATE");
                ModelState.Remove("MODIFIED_DATE");
                if (ModelState.IsValid)
                {
                    LicenceRepository objRepo = new LicenceRepository(_configuration);
                    objRepo.Add(obj);

                    ViewBag.Message = "Records added successfully.";

                    //}
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
            LicenceRepository objRepo = new LicenceRepository(_configuration);
            Licence obj = objRepo.GetByID(id);
            
            return View(obj);

        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult Edit(Licence obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LicenceRepository objRepo = new LicenceRepository(_configuration);

                    objRepo.Update(obj);

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

        // GET: Delete  Licence details by id      
        public IActionResult Delete(int id)
        {
            try
            {
                LicenceRepository EmpRepo = new LicenceRepository(_configuration);
                if (EmpRepo.Delete(id))
                {
                    ViewBag.AlertMsg = "Licence details deleted successfully";

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
