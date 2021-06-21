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
    public class BankController : Controller
    {
        private readonly IConfiguration _configuration;
    

        public BankController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }
        public IActionResult Getall()
        {
            BankRepository objRepo = new BankRepository(_configuration);
            return View(objRepo.GetAllBank());
        }

        public IActionResult Active()
        {
            BankRepository objRepo = new BankRepository(_configuration);
            return View(objRepo.GetActiveBank());
        }
        public IActionResult Inactive()
        {
            BankRepository objRepo = new BankRepository(_configuration);
            return View(objRepo.GetInActiveBank());

        }
        public ActionResult Create()
        {
          
            return View();
        }

        // POST: Employee/AddEmployee      
        [HttpPost]
        public IActionResult Create(Bank obj)
        {
            try
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
                BankRepository objRepo = new BankRepository(_configuration);

                objRepo.AddBank(obj);

                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("GetAll");
                // return View("GetAllDepartments");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            BankRepository objRepo = new BankRepository(_configuration);
            Bank obj = objRepo.GetAllBank().Find(obj => obj.BANK_ID == id);
            //return View(EmpRepo.GetAllEmployees().Find(Emp => Emp. == id));
           
            return View(obj);

        }
        [HttpPost]
        public IActionResult Edit(Bank  obj)
        {
            try
            {
                BankRepository objRepo = new BankRepository(_configuration);

                objRepo.UpdateBank(obj);

                return RedirectToAction("GetAll");
            }
            catch
            {
                return View();
            }

        }
        public IActionResult Delete(int id)
        {
            try
            {
                BankRepository objRepo = new BankRepository(_configuration);
                if (objRepo.DeleteBank(id))
                {
                    ViewBag.AlertMsg = "Bank deleted successfully";

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
