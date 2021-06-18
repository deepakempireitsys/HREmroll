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
    public class LocationController : Controller
    {

        private readonly IConfiguration _configuration;

        public LocationController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }
        public IActionResult GetAllLocations()
        {
            LocationRepository objRepo = new LocationRepository(_configuration);
            return View(objRepo.GetAllLocations());
        }

        public IActionResult GetActiveLocations()
        {
            LocationRepository objRepo = new LocationRepository(_configuration);
            return View(objRepo.GetActiveLocations());
        }

        public IActionResult GetInActiveLocations()
        {
            LocationRepository objRepo = new LocationRepository(_configuration);
            return View(objRepo.GetInActiveLocations());
        }
        // GET: Branch/AddBranch      
        public ActionResult AddLocation()
        {
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View();
        }

        // POST: Branch/AddBranch      
        [HttpPost]
        public IActionResult AddLocation(Location obj)
        {
            try
            {
                obj.CREATED_BY = 1;
                obj.CREATED_DATE = DateTime.Now;
                obj.MODIFIED_BY = 1;
                obj.MODIFIED_DATE = DateTime.Now;
                
                //if (ModelState.IsValid)
                //{
                //    
                //
                //}
                LocationRepository objRepo = new LocationRepository(_configuration);

                objRepo.AddLocation(obj);

                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("GetAllLocations");
                // return View("GetAllLocations");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bind controls to Update details      
        public IActionResult EditLocation(int id)
        {
            LocationRepository objRepo = new LocationRepository(_configuration);
            //Location obj = objRepo.GetAllLocations().Find(obj => obj.LOCATION_ID == id);
            Location obj = objRepo.GetByID(id);
            //return View(EmpRepo.GetAllBranchs().Find(Emp => Emp. == id));
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View(obj);

        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult EditLocation(Location obj)
        {
            try
            {
                LocationRepository objRepo = new LocationRepository(_configuration);

                objRepo.UpdateLocation(obj);

                return RedirectToAction("GetAllLocations");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Branch details by id      
        public IActionResult DeleteLocation(int id)
        {
            try
            {
                LocationRepository objRepo = new LocationRepository(_configuration);
                if (objRepo.DeleteLocation(id))
                {
                    ViewBag.AlertMsg = "Location deleted successfully";

                }
                return RedirectToAction("GetAllLocations");
            }
            catch
            {
                return RedirectToAction("GetAllLocations");

            }


        }
    }
}
