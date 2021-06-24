using HREmroll.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Controllers
{
    public class AttributeController : Controller
    {
        private readonly IConfiguration _configuration;


        public AttributeController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }
        public IActionResult GetAll()
        {
            AttributeRepository objRepo = new AttributeRepository(_configuration);
            return View(objRepo.GetAllAttribute());
        }
        public IActionResult Active()
        {
            AttributeRepository objRepo = new AttributeRepository(_configuration);
            return View(objRepo.GetActiveAttribute());
        }
        public IActionResult InActive()
        {
            AttributeRepository objRepo = new AttributeRepository(_configuration);
            return View(objRepo.GetInActiveAttribute());

        }
        public ActionResult Create()
        {


            CompanyRepository objRepo = new CompanyRepository(_configuration);
            ViewBag.data = objRepo.GetAllCompanys();
            return View();
        }

        // POST: Employee/AddEmployee      
        [HttpPost]
        public IActionResult Create(Models.Attribute obj)
        {
            try
            {


                obj.CREATED_BY = 1;
                obj.CREATED_DATE = DateTime.Now;
                obj.MODIFIED_BY = 1;
                obj.MODIFIED_DATE = DateTime.Now;

                AttributeRepository objRepo = new AttributeRepository(_configuration);

                objRepo.AddAtteribute(obj);

                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("GetAll");



            }
            catch
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            AttributeRepository objRepo = new AttributeRepository(_configuration);
            Models.Attribute obj = objRepo.GetAllAttribute().Find(obj => obj.ATTRIBUTE_ID == id);
            //return View(EmpRepo.GetAllEmployees().Find(Emp => Emp. == id));
            CompanyRepository objRepo1 = new CompanyRepository(_configuration);
            ViewBag.data = objRepo1.GetAllCompanys();
            return View(obj);

        }
        [HttpPost]
        public IActionResult Edit(Models.Attribute obj)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    AttributeRepository objRepo = new AttributeRepository(_configuration);

                    objRepo.UpdateAttribute(obj);

                    return RedirectToAction("GetAll");
                }
                else
                {
                    return View();

                }
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
                AttributeRepository objRepo = new AttributeRepository(_configuration);
                if (objRepo.DeleteAttribute(id))
                {
                    ViewBag.AlertMsg = " Attribute deleted successfully";

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
