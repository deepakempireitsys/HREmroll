
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
    public class DepartmentController : Controller
    {
        

        //public IActionResult Test()
        //{
        //    return View();
        //}

        // GET: Branch/GetAllBranchs      
        //private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public Int64 Current_Company_ID = 0;


        public DepartmentController( IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
            //if (Convert.ToInt64(HttpContext.Session.GetString("CMP_ID")) < 1)
            //{
            //    RedirectToAction("CompanyLogin", "Company");
            //}
            //else
            //{
            //    Current_Company_ID = Convert.ToInt64(HttpContext.Session.GetString("CMP_ID"));
            //}
            
        }

        public IActionResult GetAllDepartments()
        {
            DepartmentRepository objRepo = new DepartmentRepository(_configuration);
            //return View(objRepo.GetAllDepartments(Current_Company_ID,2));
            return View(objRepo.GetAllDepartments());
        }

        public IActionResult GetActiveDepartments()
        {
            DepartmentRepository objRepo = new DepartmentRepository(_configuration);
            return View(objRepo.GetActiveDepartments());
        }

        public IActionResult GetInActiveDepartments()
        {
            DepartmentRepository objRepo = new DepartmentRepository(_configuration);
            return View(objRepo.GetInActiveDepartments());
        }
        // GET: Branch/AddBranch      
        public ActionResult AddDepartment()
        {
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View();
        }

        // POST: Branch/AddBranch      
        [HttpPost]
        public IActionResult AddDepartment(Department obj)
        {
            try
            {
                ModelState.Remove("DEPARTMENT_ID");
                ModelState.Remove("CREATED_DATE");
                ModelState.Remove("MODIFIED_DATE");
                if (ModelState.IsValid)
                {
                    obj.CREATED_BY = 1;
                    obj.CREATED_DATE = DateTime.Now;
                    obj.MODIFIED_BY = 1;
                    obj.MODIFIED_DATE = DateTime.Now;
                    obj.BRANCH_NAME = "Default";
                    //if (ModelState.IsValid)
                    //{
                    //    
                    //
                    //}
                    DepartmentRepository objRepo = new DepartmentRepository(_configuration);

                    objRepo.AddDepartment(obj);

                    ViewBag.Message = "Records added successfully.";

                    return RedirectToAction("GetAllDepartments");
                    // return View("GetAllDepartments");

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

        // GET: Bind controls to Update details      
        public IActionResult EditDepartment(int id)
        {
            DepartmentRepository objRepo = new DepartmentRepository(_configuration);
            //Department obj = objRepo.GetAllDepartments().Find(obj => obj.DEPARTMENT_ID == id);
            Department obj = objRepo.GetByID(id);
            //return View(EmpRepo.GetAllBranchs().Find(Emp => Emp. == id));
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View(obj);
        
        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult EditDepartment(Department obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DepartmentRepository objRepo = new DepartmentRepository(_configuration);

                    objRepo.UpdateDepartment(obj);

                    return RedirectToAction("GetAllDepartments");
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

        // GET: Delete  Branch details by id      
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                DepartmentRepository objRepo = new DepartmentRepository(_configuration);
                if (objRepo.DeleteDepartment(id))
                {
                    ViewBag.AlertMsg = "Department deleted successfully";

                }
                return RedirectToAction("GetAllDepartments");
            }
            catch
            {
                return RedirectToAction("GetAllDepartments");
                
            }


        }
    }
}
