
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
    public class BranchController : Controller
    {
        //public IActionResult Test()
        //{
        //    return View();
        //}

        // GET: Branch/GetAllBranchs      

        private readonly IConfiguration _configuration;

        public BranchController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }
        public IActionResult GetAllBranchs()
        {
            BranchRepository EmpRepo = new BranchRepository(_configuration);
            return View(EmpRepo.GetAllBranchs());
        }
        // GET: Branch/AddBranch      
        



        public ActionResult Add()
        {
            return View();
        }

        // POST: Branch/AddBranch      
        [HttpPost]
        public IActionResult Add(Branch obj)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    BranchRepository objRepo = new BranchRepository(_configuration);
                    objRepo.AddBranch(obj);

                    ViewBag.Message = "Records added successfully.";

                //}
                return RedirectToAction("GetAllBranchs");
                //return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult EditBranch(int id)
        {
            BranchRepository objRepo = new BranchRepository(_configuration);
            Branch obj = objRepo.GetByID(id);
            //Branch obj = objRepo.GetAllBranchs().Find(obj => obj.GRADE_ID == id);
            //return View(EmpRepo.GetAllBranchs().Find(Emp => Emp. == id));
            //HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);
            //
            //ViewBag.data = br.GetAllBranchs();
            return View(obj);

        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult EditBranch(Branch obj)
        {
            try
            {
                BranchRepository objRepo = new BranchRepository(_configuration);

                objRepo.UpdateBranch(obj);

                return RedirectToAction("GetAllBranchs");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Branch details by id      
        public IActionResult DeleteBranch(int id)
        {
            try
            {
                BranchRepository EmpRepo = new BranchRepository(_configuration);
                if (EmpRepo.DeleteBranch(id))
                {
                    ViewBag.AlertMsg = "Branch details deleted successfully";

                }
                return RedirectToAction("GetAllBranchs");
            }
            catch
            {
                return RedirectToAction("GetAllBranchs");
                
            }


        }
    }
}
