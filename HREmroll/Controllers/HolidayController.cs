
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HREmroll.Models;
using HREmroll.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using HREmroll.Globals;

namespace HREmroll.Controllers
{
    public class HolidayController : Controller
    {
        
        private readonly IConfiguration _configuration;

        public Int64 Current_Company_ID = 0;


        public HolidayController( IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
            
            
        }

        public IActionResult GetAllHolidays()
        {
            HolidayRepository objRepo = new HolidayRepository(_configuration);
            //return View(objRepo.GetAllHolidays(Current_Company_ID,2));
            return View(objRepo.GetAllHolidays());
        }

        public IActionResult GetActiveHolidays()
        {
            HolidayRepository objRepo = new HolidayRepository(_configuration);
            return View(objRepo.GetActiveHolidays());
        }

        public IActionResult GetInActiveHolidays()
        {
            HolidayRepository objRepo = new HolidayRepository(_configuration);
            return View(objRepo.GetInActiveHolidays());
        }
        // GET: Branch/AddBranch      
        public ActionResult AddHoliday()
        {
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View();
        }

        // POST: Branch/AddBranch      
        [HttpPost]
        public IActionResult AddHoliday(Holiday obj)
        {
            try
            {
                
                HolidayRepository objRepo = new HolidayRepository(_configuration);

                objRepo.AddHoliday(obj);

                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("GetAllHolidays");
               // return View("GetAllHolidays");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bind controls to Update details      
        public IActionResult EditHoliday(int id)
        {
            HolidayRepository objRepo = new HolidayRepository(_configuration);
            //Holiday obj = objRepo.GetAllHolidays().Find(obj => obj.Holiday_ID == id);
            Holiday obj = objRepo.GetByID(id);
            //return View(EmpRepo.GetAllBranchs().Find(Emp => Emp. == id));
            HREmroll.Repository.HolidayRepository br = new HolidayRepository(_configuration);

            ViewBag.data = br.GetAllHolidays();
            return View(obj);
        
        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult EditHoliday(Holiday obj)
        {
            try
            {
                HolidayRepository objRepo = new HolidayRepository(_configuration);

                objRepo.UpdateHoliday(obj);

                return RedirectToAction("GetAllHolidays");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Branch details by id      
        public IActionResult DeleteHoliday(int id)
        {
            try
            {
                HolidayRepository objRepo = new HolidayRepository(_configuration);
                if (objRepo.DeleteHoliday(id))
                {
                    ViewBag.AlertMsg = "Holiday deleted successfully";

                }
                return RedirectToAction("GetAllHolidays");
            }
            catch
            {
                return RedirectToAction("GetAllHolidays");
                
            }


        }
    }
}
