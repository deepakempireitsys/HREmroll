using Dapper;
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
    public class DesignationController : Controller
    {

        private readonly IConfiguration _configuration;


        public DesignationController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }

        public IActionResult GetAllDesignation()
        {
            DesignationRepository objRepo = new DesignationRepository(_configuration);
            return View(objRepo.GetAllDesignation());
        }
        public IActionResult GetActiveDesignation()
        {
            DesignationRepository objRepo = new DesignationRepository(_configuration);
            return View(objRepo.GetActiveDesignation());
        }
        public IActionResult GetInActiveDesignation()
        {
            DesignationRepository objRepo = new DesignationRepository(_configuration);
            return View(objRepo.GetInActiveDesignation());
        }

        public ActionResult AddDesignation()
        {
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View();
        }

        // POST: Employee/AddEmployee      
        [HttpPost]
        public IActionResult AddDesignation(Designation obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.CREATED_BY = 1;
                    obj.CREATED_DATE = DateTime.Now;
                    obj.MODIFIED_BY = 1;
                    obj.MODIFIED_DATE = DateTime.Now;
                    //obj.BRANCH_NAME = "Default";
                    //if (ModelState.IsValid)
                    //{
                    //    
                    //
                    //}
                    DesignationRepository objRepo = new DesignationRepository(_configuration);

                    objRepo.AddDesignation(obj);

                    ViewBag.Message = "Records added successfully.";

                    return RedirectToAction("GetAllDesignation");
                }
                else
                {
                    HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

                    ViewBag.data = br.GetAllBranchs();
                    return View();
                }
                // return View("GetAllDepartments");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult EditDesignation(int id)
        {
            DesignationRepository objRepo = new DesignationRepository(_configuration);
            Designation obj = objRepo.GetAllDesignation().Find(obj => obj.DESIGNATION_ID == id);
            //return View(EmpRepo.GetAllEmployees().Find(Emp => Emp. == id));
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View(obj);

        }
        [HttpPost]
        public IActionResult EditDesignation(Designation obj)
        {
            try
            {
                DesignationRepository objRepo = new DesignationRepository(_configuration);

                objRepo.UpdateDesignation(obj);

                return RedirectToAction("GetAllDesignation");
            }
            catch
            {
                return View();
            }

        }
        public IActionResult DeleteDesignation(int id)
        {
            try
            {
                DesignationRepository objRepo = new DesignationRepository(_configuration);
                if (objRepo.DeleteDesignation(id))
                {
                    ViewBag.AlertMsg = "Designation deleted successfully";

                }
                return RedirectToAction("GetAllDesignation");
            }
            catch
            {
                return RedirectToAction("GetAllDesignation");

            }


        }
   
    }
}
