
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
    public class CompanyController : Controller
    {

        private readonly IConfiguration _configuration;


        public CompanyController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }

        public ActionResult CompanyLogin()
        {
            CompanyRepository comprepo = new CompanyRepository(_configuration);

            ViewBag.data = comprepo.GetAllCompanys();
            return View();
        }
        [HttpPost]
        public IActionResult CompanyLogin(Company obj)
        {
            try
            {
                CompanyRepository comprepo = new CompanyRepository(_configuration);

            //= comprepo.GetByID(obj.CMP_ID);
            HttpContext.Session.SetString("CMP_ID", obj.CMP_ID.ToString());
                
            Company editobj = comprepo.GetByID(Convert.ToInt64(HttpContext.Session.GetString("CMP_ID")));
                //RedirectToAction("EditCompany", editobj);
                //ViewBag.data = comprepo.GetAllCompanys();
                return View("EditCompany",editobj);
                //return View("GetAllCompany");
                //CompanyRepository comprepo = new CompanyRepository(_configuration);

                //ViewBag.data = comprepo.GetAllCompanys();
                //return View();
            }
            catch
            {
                return View();
            }
            
        }
        public IActionResult GetAllCompany()
        {
            CompanyRepository objRepo = new CompanyRepository(_configuration);
            return View(objRepo.GetAllCompanys());
        }

        public IActionResult GetActiveCompany()
        {
            CompanyRepository objRepo = new CompanyRepository(_configuration);
            return View(objRepo.GetActiveCompanys());
        }


        public IActionResult GetInActiveCompany()
        {
            CompanyRepository objRepo = new CompanyRepository(_configuration);
            return View(objRepo.GetInActiveCompanys());
        }
        // GET: Branch/AddBranch      
        public ActionResult AddCompany()
        {
            //HREmroll.Repository.BranchRepository br = new BranchRepository();

            //ViewBag.data = br.GetAllBranchs();
            return View();
        }

        // POST: Branch/AddBranch      
        [HttpPost]
        public IActionResult AddCompany(Company obj)
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
                CompanyRepository objRepo = new CompanyRepository(_configuration);

                objRepo.AddCompany(obj);

                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("GetAllCompany");
                // return View("GetAllCompany");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bind controls to Update details      
        public IActionResult EditCompany(int id)
        {
            CompanyRepository objRepo = new CompanyRepository(_configuration);
            Company obj = objRepo.GetByID(id);
            //Company obj = objRepo.GetAllCompanys().Find(obj => obj.COMPANY_ID == id);
            //return View(EmpRepo.GetAllBranchs().Find(Emp => Emp. == id));
            //HREmroll.Repository.BranchRepository br = new BranchRepository();

            //ViewBag.data = br.GetAllBranchs();
            return View(obj);

        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult EditCompany(Company obj)
        {
            try
            {
                CompanyRepository objRepo = new CompanyRepository(_configuration);

                objRepo.UpdateCompany(obj);

                return RedirectToAction("GetAllCompany");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Branch details by id      
        public IActionResult DeleteCompany(int id)
        {
            try
            {
                CompanyRepository objRepo = new CompanyRepository(_configuration);
                if (objRepo.DeleteCompany(id))
                {
                    ViewBag.AlertMsg = "Company deleted successfully";

                }
                return RedirectToAction("GetAllCompany");
            }
            catch
            {
                return RedirectToAction("GetAllCompany");

            }


        }
    }
}
