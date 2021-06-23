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
    public class ShiftController : Controller
    {

        private readonly IConfiguration _configuration;


        public ShiftController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }
        public IActionResult GetAll()
        {
            ShiftRepository objRepo = new ShiftRepository(_configuration);
            return View(objRepo.GetAll());
        }

        public IActionResult GetActive()
        {
            ShiftRepository objRepo = new ShiftRepository(_configuration);
            return View(objRepo.GetActive());
        }

        public IActionResult GetInActive()
        {
            ShiftRepository objRepo = new ShiftRepository(_configuration);
            return View(objRepo.GetInActive());
        }
        // GET: Branch/AddBranch      
        public ActionResult Add()
        {
            HREmroll.Repository.CompanyRepository cr = new CompanyRepository(_configuration);
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);
            HREmroll.Repository.DepartmentRepository dr = new DepartmentRepository(_configuration);
            ViewBag.cr = cr.GetAllCompanys();
            ViewBag.br = br.GetAllBranchs();
            ViewBag.dr = dr.GetAllDepartments();
            return View();
        }

        // POST: Branch/AddBranch      
        [HttpPost]
        public IActionResult Add(Shift obj)
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
                ShiftRepository objRepo = new ShiftRepository(_configuration);

                objRepo.Add(obj);

                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("GetAll");
                // return View("GetAll");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bind controls to Update details      
        public IActionResult Edit(int id)
        {
            ShiftRepository objRepo = new ShiftRepository(_configuration);
            Shift obj = objRepo.GetByID(id);
            //Shift obj = objRepo.GetAllShifts().Find(obj => obj.SHIFT_ID == id);
            //return View(EmpRepo.GetAllBranchs().Find(Emp => Emp. == id));
            HREmroll.Repository.CompanyRepository cr = new CompanyRepository(_configuration);
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);
            HREmroll.Repository.DepartmentRepository dr = new DepartmentRepository(_configuration);
            ViewBag.cr = cr.GetAllCompanys();
            ViewBag.br = br.GetAllBranchs();
            ViewBag.dr = dr.GetAllDepartments();
            return View(obj);

        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult Edit(Shift obj)
        {
            try
            {
                ShiftRepository objRepo = new ShiftRepository(_configuration);

                objRepo.Update(obj);

                return RedirectToAction("GetAll");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Branch details by id      
        public IActionResult Delete(int id)
        {
            try
            {
                ShiftRepository objRepo = new ShiftRepository(_configuration);
                if (objRepo.Delete(id))
                {
                    ViewBag.AlertMsg = "Shift deleted successfully";

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
