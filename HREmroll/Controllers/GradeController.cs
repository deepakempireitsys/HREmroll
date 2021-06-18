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
    public class GradeController : Controller
    {

        private readonly IConfiguration _configuration;


        public GradeController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }
        public IActionResult GetAllGrades()
        {
            GradeRepository objRepo = new GradeRepository(_configuration);
            return View(objRepo.GetAllGrades());
        }

        public IActionResult GetActiveGrades()
        {
            GradeRepository objRepo = new GradeRepository(_configuration);
            return View(objRepo.GetActiveGrades());
        }

        public IActionResult GetInActiveGrades()
        {
            GradeRepository objRepo = new GradeRepository(_configuration);
            return View(objRepo.GetInActiveGrades());
        }
        // GET: Branch/AddBranch      
        public ActionResult AddGrade()
        {
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View();
        }

        // POST: Branch/AddBranch      
        [HttpPost]
        public IActionResult AddGrade(Grade obj)
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
                GradeRepository objRepo = new GradeRepository(_configuration);

                objRepo.AddGrade(obj);

                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("GetAllGrades");
                // return View("GetAllGrades");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bind controls to Update details      
        public IActionResult EditGrade(int id)
        {
            GradeRepository objRepo = new GradeRepository(_configuration);
            Grade obj = objRepo.GetByID(id);
            //Grade obj = objRepo.GetAllGrades().Find(obj => obj.GRADE_ID == id);
            //return View(EmpRepo.GetAllBranchs().Find(Emp => Emp. == id));
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View(obj);

        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult EditGrade(Grade obj)
        {
            try
            {
                GradeRepository objRepo = new GradeRepository(_configuration);

                objRepo.UpdateGrade(obj);

                return RedirectToAction("GetAllGrades");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Branch details by id      
        public IActionResult DeleteGrade(int id)
        {
            try
            {
                GradeRepository objRepo = new GradeRepository(_configuration);
                if (objRepo.DeleteGrade(id))
                {
                    ViewBag.AlertMsg = "Grade deleted successfully";

                }
                return RedirectToAction("GetAllGrades");
            }
            catch
            {
                return RedirectToAction("GetAllGrades");

            }


        }
    }
}
