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
    public class SubBranchController : Controller
    {
        private readonly IConfiguration _configuration;


        public SubBranchController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult GetAllSubBranch()
        {
            SubBranchRepository sbrp = new SubBranchRepository(_configuration);
            return View(sbrp.GetAllSBranch());
        }

        public IActionResult GetActiveSubBranch()
        {
            SubBranchRepository sbrp = new SubBranchRepository(_configuration);
            return View(sbrp.GetActiveSBranch());
        }

        public IActionResult GetInActiveSubBranch()
        {
            SubBranchRepository sbrp = new SubBranchRepository(_configuration);
            return View(sbrp.GetInActiveSbranch());
        }


        public IActionResult AddSubBranch()
        {
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();

            return View();
        }

        // POST: Employee/AddEmployee      
        [HttpPost]
        public IActionResult AddSubBranch(SubBranch lvobj)
        {
            try
            {
                lvobj.CREATED_BY = 1;
                lvobj.CREATED_DATE = DateTime.Now;
                lvobj.MODIFIED_BY = 1;
                lvobj.MODIFIED_DATE = DateTime.Now;
                lvobj.BRANCH_NAME = "Default";


                SubBranchRepository sbrp = new SubBranchRepository(_configuration);
                sbrp.AddSBranchDetail(lvobj);

                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("GetAllSubBranch");

            }
            catch
            {
                return View();
            }
        }

        // [HttpPut]
        public IActionResult EditSubBranch(int id)
        {
            SubBranchRepository sbrp = new SubBranchRepository(_configuration);
            SubBranch obj = sbrp.GetAllSBranchById(id);

            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();

            return View(obj);


        }
        [HttpPost]
        public IActionResult EditSubBranch(SubBranch obj)
        {
            try
            {
                SubBranchRepository sbrp = new SubBranchRepository(_configuration);

                sbrp.UpdateSBranch(obj);

                return RedirectToAction("GetAllSubBranch");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Employee details by id      
        public IActionResult DeleteSubBranch(int id)
        {
            try
            {
                SubBranchRepository sbrp = new SubBranchRepository(_configuration);
                if (sbrp.DeleteSBranch(id))
                {
                    ViewBag.AlertMsg = "Sub Branch details deleted successfully";

                }
                return RedirectToAction("GetAllSubBranch");
            }
            catch
            {
                return RedirectToAction("GetAllSubBranch");

            }


        }
    }
}
