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
    public class DivisionController : Controller
    {

        private readonly IConfiguration _configuration;

        public DivisionController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }

        public IActionResult GetAllDivisions()
        {
            DivisionRepository objRepo = new DivisionRepository(_configuration);
            return View(objRepo.GetAllDivisions());
        }

        public IActionResult GetActiveDivisions()
        {
            DivisionRepository objRepo = new DivisionRepository(_configuration);
            return View(objRepo.GetActiveDivisions());
        }

        public IActionResult GetInActiveDivisions()
        {
            DivisionRepository objRepo = new DivisionRepository(_configuration);
            return View(objRepo.GetInActiveDivisions());
        }
        // GET: Branch/AddBranch      
        public ActionResult AddDivision()
        {
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View();
        }

        // POST: Branch/AddBranch      
        [HttpPost]
        public IActionResult AddDivision(Division obj)
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
                DivisionRepository objRepo = new DivisionRepository(_configuration);

                objRepo.AddDivision(obj);

                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("GetAllDivisions");
                // return View("GetAllDivisions");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bind controls to Update details      
        public IActionResult EditDivision(int id)
        {
            DivisionRepository objRepo = new DivisionRepository(_configuration);
            //Division obj = objRepo.GetAllDivisions().Find(obj => obj.DIVISION_ID == id);
            Division obj = objRepo.GetByID(id);
            //return View(EmpRepo.GetAllBranchs().Find(Emp => Emp. == id));
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View(obj);

        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult EditDivision(Division obj1)
        {
            try
            {
                DivisionRepository objRepo = new DivisionRepository(_configuration);

                objRepo.UpdateDivision(obj1);

                return RedirectToAction("GetAllDivisions");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Branch details by id      
        public IActionResult DeleteDivision(int id)
        {
            try
            {
                DivisionRepository objRepo = new DivisionRepository(_configuration);
                if (objRepo.DeleteDivision(id))
                {
                    ViewBag.AlertMsg = "Division deleted successfully";

                }
                return RedirectToAction("GetAllDivisions");
            }
            catch
            {
                return RedirectToAction("GetAllDivisions");

            }


        }
    }
}
