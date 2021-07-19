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
    public class QualificationController : Controller
    {
        private readonly IConfiguration _configuration;


        public QualificationController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }
        public IActionResult GetAll()
        {
            QualificationRepository objRepo = new QualificationRepository(_configuration);
            return View(objRepo.GetAllQualification());
        }
        public IActionResult Active()
        {
            QualificationRepository objRepo = new QualificationRepository(_configuration);
            return View(objRepo.GetActiveQualifiction());
        }
        public IActionResult InActive()
        {
            QualificationRepository objRepo = new QualificationRepository(_configuration);
            return View(objRepo.GetInActiveQualifiction());

        }
        public ActionResult Create()
        {

            CompanyRepository objRepo = new CompanyRepository(_configuration);
            ViewBag.data = objRepo.GetAllCompanys();
            return View();
        }

        // POST: Employee/AddEmployee      
        [HttpPost]
        public IActionResult Create(Qualification obj)
        {
            try
            {
                ModelState.Remove("QUALIFICATION_ID");
                ModelState.Remove("CREATED_DATE");
                ModelState.Remove("MODIFIED_DATE");

                if (ModelState.IsValid)
                {
                    obj.CREATED_BY = 1;
                    obj.CREATED_DATE = DateTime.Now;
                    obj.MODIFIED_BY = 1;
                    obj.MODIFIED_DATE = DateTime.Now;

                    QualificationRepository objRepo = new QualificationRepository(_configuration);

                    objRepo.AddQualification(obj);

                    ViewBag.Message = "Records added successfully.";

                    return RedirectToAction("GetAll");
                }
                else
                {
                    CompanyRepository objRepo = new CompanyRepository(_configuration);
                    ViewBag.data = objRepo.GetAllCompanys();
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            QualificationRepository objRepo = new QualificationRepository(_configuration);
            Qualification obj = objRepo.GetAllQualification().Find(obj => obj.QUALIFICATION_ID == id);
            //return View(EmpRepo.GetAllEmployees().Find(Emp => Emp. == id));
            CompanyRepository objRepo1 = new CompanyRepository(_configuration);
            ViewBag.data = objRepo1.GetAllCompanys();
            return View(obj);

        }
        [HttpPost]
        public IActionResult Edit(Qualification obj)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    QualificationRepository objRepo = new QualificationRepository(_configuration);

                    objRepo.UpdateQualification(obj);

                    return RedirectToAction("GetAll");
                }
                else
                {
                    CompanyRepository objRepo = new CompanyRepository(_configuration);
                    ViewBag.data = objRepo.GetAllCompanys();
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
                QualificationRepository objRepo = new QualificationRepository(_configuration);
                if (objRepo.DeleteQualification(id))
                {
                    ViewBag.AlertMsg = " Qualification deleted successfully";

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
