using HREmroll.Models;
using HREmroll.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HREmroll.Controllers
{
    public class LeaveController : Controller
    {
        private readonly IConfiguration _configuration;


        public LeaveController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public IActionResult GetAllLeaveDetails()
        {
            LeaveRepository lvrp = new LeaveRepository(_configuration);
            return View(lvrp.GetAllLeaveDetails());
        }

        public IActionResult GetActiveLeave()
        {
            LeaveRepository lvrp = new LeaveRepository(_configuration);
            return View(lvrp.GetActiveLeave());
        }

        public IActionResult GetInActiveLeave()
        {
            LeaveRepository lvrp = new LeaveRepository(_configuration);
            return View(lvrp.GetInActiveLeave());
        }

        //public IActionResult AddLeave()
        //{
        //    HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

        //    ViewBag.data = br.GetAllBranchs();
        //    return View();
        //}

        public IActionResult AddLeave()
        {
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
        
                return View();
        }

        // POST: Employee/AddEmployee      
        [HttpPost]
        public IActionResult AddLeave(Leave lvobj)
        {
            try
            {
                ModelState.Remove("LEAVEID");
                ModelState.Remove("CREATED_DATE");
                ModelState.Remove("MODIFIED_DATE");

                if (ModelState.IsValid)
                {
                    lvobj.CREATED_BY = 1;
                    lvobj.CREATED_DATE = DateTime.Now;
                    lvobj.MODIFIED_BY = 1;
                    lvobj.MODIFIED_DATE = DateTime.Now;
                    lvobj.BRANCH_NAME = "Default";


                    LeaveRepository lvrp = new LeaveRepository(_configuration);
                    lvrp.AddLeaveDetail(lvobj);

                    ViewBag.Message = "Records added successfully.";

                    return RedirectToAction("GetAllLeaveDetails");
                }
                else
                {
                    BranchRepository br = new BranchRepository(_configuration);

                    ViewBag.data = br.GetAllBranchs();

                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // [HttpPut]
        public IActionResult EditLeave(int id)
        {
            LeaveRepository lvrp = new LeaveRepository(_configuration);
            Leave obj = lvrp.GetAllLeaveDetailsById(id);

            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();

            return View(obj);


        }
        [HttpPost]
        public IActionResult EditLeave(Leave obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LeaveRepository lvrp = new LeaveRepository(_configuration);

                    lvrp.UpdateLeaveDetail(obj);

                    return RedirectToAction("GetAllLeaveDetails");
                }
                else
                {
                    BranchRepository br = new BranchRepository(_configuration);

                    ViewBag.data = br.GetAllBranchs();

                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Employee details by id      
        public IActionResult DeleteLeave(int id)
        {
            try
            {
                LeaveRepository lvrp = new LeaveRepository(_configuration);
                if (lvrp.DeleteLeaveData(id))
                {
                    ViewBag.AlertMsg = "Leave details deleted successfully";

                }
                return RedirectToAction("GetAllLeaveDetails");
            }
            catch
            {
                return RedirectToAction("GetAllLeaveDetails");

            }


        }

    }
}