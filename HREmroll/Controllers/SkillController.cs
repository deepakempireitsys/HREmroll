using HREmroll.DAL;
using HREmroll.Models;
using HREmroll.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Controllers
{
    public class SkillController : Controller
    {
        private readonly IConfiguration _configuration;


        public SkillController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }
        public IActionResult GetAll()
        {
            SkillRepository objRepo = new SkillRepository(_configuration);
            return View(objRepo.GetAllSkill());
        }
        public IActionResult Active()
        {
            SkillRepository objRepo = new SkillRepository(_configuration);
            return View(objRepo.GetActiveSkill());
        }
        public IActionResult InActive()
        {
            SkillRepository objRepo = new SkillRepository(_configuration);
            return View(objRepo.GetInActiveSkill());

        }
        public ActionResult Create()
        {


            CompanyRepository objRepo = new CompanyRepository(_configuration);
            ViewBag.data = objRepo.GetAllCompanys();
            return View();
        }

        // POST: Employee/AddEmployee      
        [HttpPost]
        public IActionResult Create(Skill obj)
        {
            try
            {


                obj.CREATED_BY = 1;
                obj.CREATED_DATE = DateTime.Now;
                obj.MODIFIED_BY = 1;
                obj.MODIFIED_DATE = DateTime.Now;

                SkillRepository objRepo = new SkillRepository(_configuration);

                objRepo.AddSkilll(obj);

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
            SkillRepository objRepo = new SkillRepository(_configuration);
            Skill obj = objRepo.GetAllSkill().Find(obj => obj.SKILL_ID == id);
            //return View(EmpRepo.GetAllEmployees().Find(Emp => Emp. == id));
            CompanyRepository objRepo1 = new CompanyRepository(_configuration);
            ViewBag.data = objRepo1.GetAllCompanys();
            return View(obj);

        }
        [HttpPost]
        public IActionResult Edit(Skill obj)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    SkillRepository objRepo = new SkillRepository(_configuration);

                    objRepo.UpdateSkill(obj);

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
                SkillRepository objRepo = new SkillRepository(_configuration);
                if (objRepo.DeleteSkill(id))
                {
                    ViewBag.AlertMsg = " Skill deleted successfully";

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
